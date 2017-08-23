using Nancy;
using Nancy.Bootstrapper;
using Nancy.Elmah;
using Nancy.TinyIoc;
using SecurePay.MasterPass.Extensions;

namespace SecurePay.MasterPass
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            StaticConfiguration.DisableErrorTraces = true;
            base.ApplicationStartup(container, pipelines);
            Elmahlogging.Enable(pipelines, "elmah");
            pipelines.EnableNewRelicLogging();
        }
    }
}