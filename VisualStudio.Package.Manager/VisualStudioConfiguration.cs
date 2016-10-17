using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace VisualStudio.Package.Manager
{
	public class VisualStudioConfiguration
	{
		private const string PkgUndefFileName = "devenv.pkgundef";

		public string InstallDir { get; internal set; }
		public string Name { get; internal set; }
		public List<VisualStudioPackage> Packages { get; internal set; }

		public void Update()
		{
			UpdateUndefFile();

			var devenv = Path.Combine(InstallDir, "devenv.exe");
			const string arguments = "/updateconfiguration";

			Process.Start(devenv, arguments);
		}

		public void RefreshState()
		{
			var file = Path.Combine(InstallDir, PkgUndefFileName);
			if (!File.Exists(file))
				return;

			var packages = Packages.Where(p => p.Source == PackageSource.Registry).ToList();
			var content = File.ReadAllLines(file).Select(l => l.Trim()).ToList();

			var disabledIds = content.Where(l => !l.StartsWith(";")).ToList();
			var disabledPackages = content.Where(l => l.StartsWith(";") && (l.Split('|').Length == 2));

			foreach (var package in packages)
				package.Enabled = disabledIds.All(l => !string.Equals(package.PathId, l, StringComparison.OrdinalIgnoreCase));

			foreach (var line in disabledPackages)
			{
				var tokens = line.Substring(1).Split('|');
				var package = new VisualStudioPackage
				{
					Name = tokens[0],
					Id = tokens[1],
					Source = PackageSource.File
				};
				if (packages.All(p => p.Id != package.Id))
					packages.Add(package);
			}

			Packages = packages;
		}

		private void UpdateUndefFile()
		{
			var file = Path.Combine(InstallDir, PkgUndefFileName);
			var content = Packages.Where(p => !p.Enabled).Select(p => string.Concat(";", p.Name, "|", p.Id, Environment.NewLine, p.PathId));

			File.WriteAllLines(file, content);
		}

		public override string ToString()
		{
			return Name;
		}
	}
}