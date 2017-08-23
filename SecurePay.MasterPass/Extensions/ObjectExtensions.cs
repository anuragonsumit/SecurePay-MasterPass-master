using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SecurePay.MasterPass.SDK;
using SecurePay.Tokeniser.Sdk;


namespace SecurePay.MasterPass.Extensions
{
    public static class ObjectExtensions
    {
        public static PaymentCard ToCreditCard(this CheckoutDetails checkoutDetails)
        {
            return new PaymentCard(checkoutDetails.CardNumber, checkoutDetails.CardHolder,
                checkoutDetails.CardExpiryMonth, checkoutDetails.CardExpiryYear, checkoutDetails.PaymentType.ToCardBrandId(), false);
        }

        public static CheckoutDetails ToCheckoutDetails(this Checkout response)
        {
            return new CheckoutDetails
            {
                CardExpiryMonth = int.Parse(response.Card.ExpiryMonth),
                CardExpiryYear = int.Parse(response.Card.ExpiryYear.Substring(2)),
                CardNumber = response.Card.AccountNumber,
                CardHolder = response.Card.CardHolderName,
                TransactionId = response.TransactionId,
                PaymentType = response.Card.BrandId.ToPaymentType()
            };
        }

        public static string FirstValue(this IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers, string headerName)
        {
            var value = headers.FirstOrDefault(h => h.Key == headerName);
            if (value.Value != null && value.Value.Any())
            {
                return value.Value.First();
            }
            throw new HttpRequestValidationException(
                $"The http request header ('{headerName}' is missing on the request.");
        }
        public static PaymentType ToPaymentType(this string cardBrandId)
        {
            var dict = InitialisePaymentTypes();
            if (dict.ContainsValue(cardBrandId))
            {
                return dict.FirstOrDefault(f => f.Value == cardBrandId).Key;
            }
            return PaymentType.Unknown;
        }

        public static string ToCardBrandId(this PaymentType paymentType)
        {
            var dict = InitialisePaymentTypes();
            return dict[paymentType];
        }

        private static Dictionary<PaymentType, string> InitialisePaymentTypes()
        {
            var dict = new Dictionary<PaymentType, string>
            {
                {PaymentType.AmericanExpress, "amex"},
                {PaymentType.DinersClub, "diners"},
                {PaymentType.Mastercard, "master"},
                {PaymentType.Visa, "visa"}
            };
            return dict;
        }
    }
}