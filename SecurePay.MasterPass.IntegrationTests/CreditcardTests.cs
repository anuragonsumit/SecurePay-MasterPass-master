using System;
using Nancy;
using Nancy.Hosting.Self;
using Nancy.Testing;
using NUnit.Framework;

namespace SecurePay.MasterPass.IntegrationTests
{
    [TestFixture]
    public class CreditcardTests
    {
        private NancyHost _host;
        private const string SecurePayMasterPassToken = "X-SecurePay-MasterPass-Token";
        private const string SecurePayMasterPassCheckOutUrl = "X-SecurePay-MasterPass-CheckOutUrl";
        private const string SecurePayMasterPassConsumerKey = "X-SecurePay-MasterPass-ConsumerKey";
        private const string SecurePayMasterPassCertThumbprint = "X-SecurePay-MasterPass-CertThumbprint";


        [SetUp]
        public void Init()
        {

            _host = new NancyHost(new Uri("http://localhost:1234"), new Bootstrapper());

            //_host = new NancyHost(new Uri("http://localhost:1234"),
            //    new Bootstrapper(), new HostConfiguration() { UrlReservations = new UrlReservations() { CreateAutomatically = true} });

            _host.Start();
        }

        [Test]
        public void ReturnErrorWhenTheAccessTokenAndCheckOutUrlAreMissing()
        {
            // Given
            var browser = new Browser(new Bootstrapper());

            // When
            var result = browser.Get("/creditcard", with =>
            {
                with.HttpRequest();
            });

            // Then
            Assert.AreEqual(HttpStatusCode.InternalServerError, result.StatusCode);

        }

        [Test]
        public void Return200WhenCreditCardRequestIsSuccessful()
        {
            // Given
            var browser = new Browser(new Bootstrapper());

            // When
            var result = browser.Get("/creditcard", with =>
            {
                with.HttpRequest();
                with.Header(SecurePayMasterPassToken, "abc");
                with.Header(SecurePayMasterPassCheckOutUrl, "http://localhost:1234/checkout");
                with.Header(SecurePayMasterPassConsumerKey, "abc1234");
                with.Header(SecurePayMasterPassCertThumbprint, "01b5fc5aca757ae06e3c8ade69cebefe5c56fde2");
            });

            // Then
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

        }

        [TearDown]
        public void Dispose()
        {
            _host.Stop();
            _host.Dispose();
        }
    }
}