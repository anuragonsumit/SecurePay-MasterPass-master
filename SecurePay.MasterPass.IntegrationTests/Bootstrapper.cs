using Nancy;

namespace SecurePay.MasterPass.IntegrationTests
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override IRootPathProvider RootPathProvider =>
            new CustomRootPathProvider();
    }
}