using System;
using System.IO;
using Nancy;

namespace SecurePay.MasterPass.IntegrationTests
{
    public class CustomRootPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}