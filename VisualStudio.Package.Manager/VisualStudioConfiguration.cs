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

            var content = File.ReadAllLines(file).Select(l => l.Trim()).Where(l => !l.StartsWith(";")).ToList();

            foreach (var package in Packages)
                package.Enabled = content.All(l => !string.Equals(package.PathId, l, StringComparison.OrdinalIgnoreCase));
        }

        private void UpdateUndefFile()
        {
            var file = Path.Combine(InstallDir, PkgUndefFileName);
            var content = Packages.Where(p => !p.Enabled).Select(p => string.Concat(";", p.Name, Environment.NewLine, p.PathId));
            
            File.WriteAllLines(file, content);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
