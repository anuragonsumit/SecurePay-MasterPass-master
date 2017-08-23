using System;
using System.Threading.Tasks;
using System.Web;
using Elmah;
using Nancy;
using NewRelicAgent = NewRelic.Api.Agent.NewRelic;

namespace SecurePay.MasterPass.Extensions
{
    public class TrycatchExtensions
    {
        public static async Task<dynamic> RunAsync(Func<Task<dynamic>> action)
        {
            try
            {
                return await action();
            }
            catch (Exception ex)
            {
                NewRelicAgent.NoticeError(ex);
                ErrorSignal.FromContext(HttpContext.Current).Raise(ex);

                Response exceptionResponse = ex.Message;
                exceptionResponse.StatusCode = HttpStatusCode.NotAcceptable;

                return exceptionResponse;
            }
        }
    }
}