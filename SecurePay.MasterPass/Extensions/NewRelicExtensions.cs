using Nancy.Bootstrapper;

namespace SecurePay.MasterPass.Extensions
{
    public static class NewRelicExtensions
    {
        public static void EnableNewRelicLogging(this IPipelines pipelines)
        {
            pipelines.BeforeRequest.AddItemToEndOfPipeline(ctx =>
            {
                NewRelic.Api.Agent.NewRelic.SetTransactionName("Request.Path", ctx.Request.Url);
                return null;
            });
        }
    }
}