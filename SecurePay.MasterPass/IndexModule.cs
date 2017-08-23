using System.IO;
using System.Reflection;
using Nancy;

namespace SecurePay.MasterPass
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = (__) => $"Welcome to SecurePay.MasterPass - {File.GetLastWriteTimeUtc(Assembly.GetExecutingAssembly().Location)}"; ;
        }
    }
}