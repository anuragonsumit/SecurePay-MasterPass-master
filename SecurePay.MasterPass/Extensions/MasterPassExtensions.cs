using System.Collections.Generic;
using System.Net.Http;
using Nancy;
using SecurePay.Gateway.Model;
using SecurePay.MasterPass.SDK;

namespace SecurePay.MasterPass.Extensions
{
    public static class MasterPassExtensions
    {
        private const string SecurePayMasterPassToken = "X-SecurePay-MasterPass-Token";
        private const string SecurePayMasterPassCheckOutUrl = "X-SecurePay-MasterPass-CheckOutUrl";
        private const string SecurePayMasterPassConsumerKey = "X-SecurePay-MasterPass-ConsumerKey";
        private const string SecurePayMasterPassCertThumbprint = "X-SecurePay-MasterPass-CertThumbprint";
        private const string MasterPassServiceId = "MasterPassServiceId";
        private const string AuthorizationHeaderKey = "authorization";


        public static RequestParameter ToRequestParameter(this RequestHeaders requestHeaders)
        {
            var accessTokenHeaderValue = requestHeaders.FirstValue(SecurePayMasterPassToken);
            var checkoutUrlHeaderValue = requestHeaders.FirstValue(SecurePayMasterPassCheckOutUrl);
            var consumerKeyHeaderValue = requestHeaders.FirstValue(SecurePayMasterPassConsumerKey);
            var certThumbprintHeaderValue = requestHeaders.FirstValue(SecurePayMasterPassCertThumbprint);

            var sdk = new MasterPassOAuthSdk(consumerKeyHeaderValue, certThumbprintHeaderValue);
            var authorizationHeader = sdk.CreateAuthorizationHeader(checkoutUrlHeaderValue, accessTokenHeaderValue);
            
            var requestParameters = new RequestParameter()
            {
                Id = MasterPassServiceId,
                Headers = new Dictionary<string, string>
                {
                    {AuthorizationHeaderKey, authorizationHeader},
                    { "x-secure-pay-url", checkoutUrlHeaderValue },
                    { "content-type",  "application/xml" }
                },
                HttpMethod = HttpMethod.Get.Method
                
            };
            return requestParameters;
        }

        public static CheckoutDetails ToCheckoutDetails(this string checkoutResponse)
        {
            Checkout checkout = WalletSerializer<Checkout>.Deserialize(checkoutResponse);
            return checkout.ToCheckoutDetails();
        }
    }
}