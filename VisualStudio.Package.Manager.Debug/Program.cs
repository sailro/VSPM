using System.Linq;

namespace VisualStudio.Package.Manager.Debug
{
    internal static class Program
    {
        private static void Main()
        {
            var configs = VisualStudioRegistry.GetConfigurations();
            var dev14 = configs.First(c => c.Name.StartsWith("14"));
            
            dev14.RefreshState();
            var disabled = dev14.Packages.Where(p => !p.Enabled);
            var signin = dev14.Packages.First(p => p.Name.StartsWith("Sign"));
            signin.Enabled = false;

            dev14.Update();
        }
    }
}
