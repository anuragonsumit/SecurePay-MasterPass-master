namespace SecurePay.MasterPass
{
    /// <summary>
    /// Types of recognised credit card, including PayPal  
    /// </summary>
    /// <remarks>items should correspond to [tblRefCardTypes] table and also to C:\WJSRC\Common\data\reference data\webjet\customer\CREDCT_Name.Val.CSV
    ///See also PaymentTypeExtensions
	///They are different to 2-character CardTypeCodes
    /// </remarks>
    public enum PaymentType
    {
        Unknown = 0,
        Visa = 1,
        DinersClub = 2,
        AmericanExpress = 3,
        Mastercard = 4,
        PayPal = 5,
        AXPP = 6,
        DJAXPP = 7,
        Voucher = 8,
        PaymentList = 9,
        BankWestRewards = 10,
        FlyBuys = 11,
        BAAXPP = 12,
        Invoice = 13,
        MasterPass = 14,
        MasterCardDebit = 15,
        VisaCheckout = 16,
        Enets = 17
    }
}