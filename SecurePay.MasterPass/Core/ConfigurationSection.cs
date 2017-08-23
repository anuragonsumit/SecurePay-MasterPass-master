using System.Collections;
using System.Configuration;

namespace SecurePay.MasterPass.Core
{
    public class ConfigurationSection : IConfigurationSection {
        public string GetSectionSetting(string sectionName, string keyName)
        {
            var section = GetSection<Hashtable>(sectionName); 
            return section[keyName] as string;
        }

        public T GetSection<T>(string sectionName) where T : class {
            return ConfigurationManager.GetSection(sectionName) as T;
        }
    }
}