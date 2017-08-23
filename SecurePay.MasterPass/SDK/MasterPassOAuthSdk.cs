using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DevDefined.OAuth;
using DevDefined.OAuth.Framework;
using DevDefined.OAuth.Framework.Signing;
using SecurePay.MasterPass.Microsoft.SDC.Common;

namespace SecurePay.MasterPass.SDK
{
    public class MasterPassOAuthSdk
    {
        private const string Realm = "eWallet";
        private readonly string _consumerKey;
        private readonly string _certThumbprint;
        
        public MasterPassOAuthSdk(string consumerKey, string certThumbprint)
        {
            _consumerKey = consumerKey;
            _certThumbprint = certThumbprint;
            
        }

        public string CreateAuthorizationHeader(string url, string accessToken)
        {
            var parameters = new Dictionary<string, string> { { "Token", accessToken } };
            return CreateAuthorizationHeaderInternal(HttpMethod.Get, url, parameters, null);
        }
        private string CreateAuthorizationHeaderInternal(HttpMethod httpMethod, string url, Dictionary<string, string> parameters,
            string body)
        {
            Encoding enc = Encoding.UTF8;

            NameValueCollection authorizationHeaderParameters = new NameValueCollection();

            authorizationHeaderParameters.Add(Parameters.OAuth_Timestamp, DateTime.Now.Epoch().ToString());
            authorizationHeaderParameters.Add(Parameters.OAuth_Version, "1.0");
            authorizationHeaderParameters.Add(Parameters.OAuth_Consumer_Key, _consumerKey);
            authorizationHeaderParameters.Add(Parameters.OAuth_Signature_Method, SignatureMethod.RsaSha1);
            authorizationHeaderParameters.Add(Parameters.Realm, Realm);

            var oauthContext = new OAuthContext
            {
                AuthorizationHeaderParameters = authorizationHeaderParameters,
                RawUri = new Uri(url),
                RequestMethod = httpMethod.Method
            };

            authorizationHeaderParameters.Add(Parameters.OAuth_Nonce, new GuidNonceGenerator().GenerateNonce(oauthContext));

            if (parameters != null && parameters.ContainsKey("CallbackUrl"))
            {
                authorizationHeaderParameters.Add(Parameters.OAuth_Callback, parameters["CallbackUrl"]);
            }
            if (parameters != null && parameters.ContainsKey("Oauth_Verifier"))
            {
                authorizationHeaderParameters.Add(Parameters.OAuth_Verifier, parameters["Oauth_Verifier"]);
            }
            if (parameters != null && parameters.ContainsKey("Token"))
            {
                authorizationHeaderParameters.Add(Parameters.OAuth_Token, parameters["Token"]);
            }

            if (body != null)
            {
                var rawContent = enc.GetBytes(body);
                oauthContext.Realm = null;
                oauthContext.RawContent = rawContent;
                authorizationHeaderParameters.Add(Parameters.OAuth_Body_Hash, oauthContext.GenerateBodyHash());
            }

            oauthContext.AuthorizationHeaderParameters = authorizationHeaderParameters;

            var privateKey = GetCertificate(_certThumbprint).PrivateKey;
            // Set the signature base string so that it's viewable by the
            // caller upon the return of the response.
            var signatureBaseString = oauthContext.GenerateSignatureBase();
            var signer = new RsaSha1SignatureImplementation();
            signer.SignContext(oauthContext,
                new SigningContext {Algorithm = privateKey, SignatureBase = signatureBaseString});

            authorizationHeaderParameters.Add(Parameters.OAuth_Signature, oauthContext.Signature);
            oauthContext.AuthorizationHeaderParameters = authorizationHeaderParameters;

            var authHeader = oauthContext.GenerateOAuthParametersForHeader();
            return authHeader;
        }

        private X509Certificate2 GetCertificate(string thumbprint)
        {
            return CertificatesHelper.FindCertificate(StoreLocation.LocalMachine, StoreName.Root, X509FindType.FindByThumbprint, thumbprint);
        }
    }
}