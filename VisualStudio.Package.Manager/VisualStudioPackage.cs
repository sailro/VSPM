namespace VisualStudio.Package.Manager
{
	public class VisualStudioPackage
	{
		public string Name { get; internal set; }
		public string Id { get; internal set; }
		public bool Enabled { get; set; }
		public PackageSource Source { get; set; }

		public string PathId => $@"[$RootKey$\Packages\{Id}]";

		public override string ToString()
		{
			return Name;
		}
	}
}