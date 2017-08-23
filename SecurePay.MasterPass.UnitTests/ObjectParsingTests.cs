using NUnit.Framework;
using SecurePay.MasterPass.Extensions;

namespace SecurePay.MasterPass.UnitTests
{
    [TestFixture]
    public class ObjectParsingTests
    {
        [Test]
        public void CanConvertCheckoutDetailsToTokenizerRequest()
        {
            // Given
            var checkOutDetails = new CheckoutDetails
            {
                CardNumber = "1",
                PaymentType = PaymentType.Mastercard,
                CardExpiryMonth = 2,
                CardExpiryYear = 2011,
                CardHolder = "MS",
                TransactionId = "123"
            };

            // When
            var tokeniserRequest = checkOutDetails.ToCreditCard();

            // Then
            Assert.AreEqual(checkOutDetails.CardNumber, tokeniserRequest.CardNumber);
            Assert.AreEqual(checkOutDetails.CardHolder, tokeniserRequest.CardName);
        }
    }
}