using System.Threading.Tasks;
using Nancy;
using Nancy.Hosting.Self;
using NUnit.Framework;

namespace SecurePay.MasterPass.IntegrationTests
{
    
    public class MockModule : NancyModule
    {
        public MockModule() 
        {
            Get["/access_token"] = parameters => "";
            Post["/tokeniser", true] = async (x, ct) => await Task.FromResult(@"{ ""id"" : ""155442"" }");
            Get["/checkout"] = parameters => @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?><Checkout><Card><BrandId>visa</BrandId><BrandName>Visa</BrandName><AccountNumber>4111111111111111</AccountNumber><BillingAddress><City>Bisbane</City><Country>US</Country><CountrySubdivision>US-CA</CountrySubdivision><Line1>300</Line1><PostalCode>90601</PostalCode></BillingAddress><CardHolderName>Vitaly Test</CardHolderName><ExpiryMonth>2</ExpiryMonth><ExpiryYear>2017</ExpiryYear></Card><TransactionId>440218535</TransactionId><Contact><FirstName>Joe</FirstName><LastName>Test3</LastName><Country>US</Country><EmailAddress>joe.test3@email.com</EmailAddress><PhoneNumber>US+19871111111</PhoneNumber></Contact><PayPassWalletIndicator>101</PayPassWalletIndicator></Checkout>";
        }
    }
}