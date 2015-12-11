using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;

namespace VisualStudio.Package.Manager
{
    public static class VisualStudioRegistry
    {

        public static IEnumerable<VisualStudioConfiguration> GetConfigurations()
        {
            var rootKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft", false);
            return ReadRegistryEntities(rootKey, "VisualStudio", s => s.EndsWith(".0_Config"), GetConfiguration);
        }

        private static IEnumerable<VisualStudioPackage> GetPackages(RegistryKey configKey)
        {
            return ReadRegistryEntities(configKey, "Packages", s => true, GetPackage);
        }

        private static VisualStudioConfiguration GetConfiguration(RegistryKey rootConfigKey, string configName)
        {
            return ReadRegistryEntity<VisualStudioConfiguration>(rootConfigKey, configName, (key, configuration) =>
            {
                configuration.Name = configName;
                configuration.InstallDir = key.GetValue("InstallDir") as string;
                configuration.Packages = GetPackages(key).ToList();
            });
        }

        private static VisualStudioPackage GetPackage(RegistryKey rootPackageKey, string packageId)
        {
            return ReadRegistryEntity<VisualStudioPackage>(rootPackageKey, packageId, (key, package) =>
            {
                package.Id = packageId;
                package.Enabled = true;
                package.Name = key.GetValue(null, "?") as string;
            });
        }

        private static IEnumerable<T> ReadRegistryEntities<T>(RegistryKey rootKey, string subKeyName, Func<string, bool> predicate, Func<RegistryKey, string, T> reader) where T : new()
        {
            if (rootKey == null || string.IsNullOrEmpty(subKeyName))
                yield break;

            using (var subKey = rootKey.OpenSubKey(subKeyName, false))
            {
                if (subKey == null)
                    yield break;

                var names = subKey.GetSubKeyNames().Where(predicate);
                foreach (var name in names)
                    yield return reader(subKey, name);
            }
        }

        private static T ReadRegistryEntity<T>(RegistryKey rootKey, string subKeyName, Action<RegistryKey, T> action) where T : new()
        {
            if (rootKey == null || string.IsNullOrEmpty(subKeyName))
                return default(T);

            using (var subKey = rootKey.OpenSubKey(subKeyName, false))
            {
                if (subKey == null)
                    return default(T);

                var entity = new T();
                action(subKey, entity);
                return entity;
            }
        }

    }
}
