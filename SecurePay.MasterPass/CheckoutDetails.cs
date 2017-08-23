namespace SecurePay.MasterPass
{
    public class CheckoutDetails {
        
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public int CardExpiryMonth { get; set; }
        public int CardExpiryYear { get; set; }
        public string TransactionId { get; set; }

        public PaymentType PaymentType { get; set; }
    }
}