namespace SecurePay.MasterPass.Core
{
    public interface IConfigurationSection
    {
        string GetSectionSetting(string sectionName, string keyName);
        T GetSection<T>(string sectionName) where T : class;
    }
}