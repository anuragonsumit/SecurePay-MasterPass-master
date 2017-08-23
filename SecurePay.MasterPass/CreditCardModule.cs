using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Nancy;
using SecurePay.Gateway.Service;
using SecurePay.MasterPass.Core;
using SecurePay.MasterPass.Extensions;
using SecurePay.Tokeniser.Sdk;
using HttpStatusCode = System.Net.HttpStatusCode;

namespace SecurePay.MasterPass
{
    public class CreditCardModule : NancyModule
    {
        private const string TokeniserSectionName = "TokeniserConfig";
        private const string TokeniserUrlKey = "TokeniserUrl";
        private const string TokeniserDomainPlaceHolderKey = "TokeniserDomainPlaceHolder";
        private readonly string _tokeniserUrl;
        private readonly string _tokeniserUrlDomainPlaceHolder;

        public CreditCardModule(IConfigurationSection configurationSection) : base("/creditcard")
        {
            _tokeniserUrl = configurationSection.GetSectionSetting(TokeniserSectionName, TokeniserUrlKey);
            _tokeniserUrlDomainPlaceHolder = configurationSection.GetSectionSetting(TokeniserSectionName, TokeniserDomainPlaceHolderKey);

            //Get["/", true] = async (x, ct) => await GetTokenizedCreditCard();

            Get["/", true] = async (parameters, ctx) =>
                await TrycatchExtensions.RunAsync(async () => await GetTokenizedCreditCard()).ConfigureAwait(false);
        }

        private async Task<Response> GetTokenizedCreditCard()
        {
            var clientResponse = await ClientRequestService.SendRequestAsync(Request.Headers.ToRequestParameter());
            if (clientResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException();
            }

            var checkoutDetails = clientResponse.SoapResponse.ToCheckoutDetails();

            var tokenFromTokeniser = await new TokeniserService(GetTokeniserUrl(Request.Url.HostName, _tokeniserUrl, _tokeniserUrlDomainPlaceHolder))
                .GetTokenAsync(checkoutDetails.ToCreditCard());

            checkoutDetails.CardNumber = tokenFromTokeniser;

            return Response.AsJson(checkoutDetails);
        }

        private static string GetTokeniserUrl(string requestUrl, string tokeniserUrl, string tokeniserDomainPlaceHolder)
        {
            if (tokeniserUrl.Contains(tokeniserDomainPlaceHolder))
            {
                tokeniserUrl = tokeniserUrl.Replace(tokeniserDomainPlaceHolder, string.Join(".", requestUrl.Split('.').Skip(1))); //As discussed, the expect URL is {1-subdomain}{maindomain}. if the request url is different format then it will fail.   
            }

            return tokeniserUrl;
        }
    }
}