using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SecurePay.MasterPass.SDK
{

    [GeneratedCode("System.Xml", "4.0.30319.1015")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Checkout {

        private Card _cardField;

        private string _transactionIdField;

        private Contact _contactField;

        private ShippingAddress _shippingAddressField;

        private string _payPassWalletIndicatorField;

        private AuthenticationOptions _authenticationOptionsField;

        private RewardProgram _rewardProgramField;

        public Checkout() {
            _rewardProgramField = new RewardProgram();
            _authenticationOptionsField = new AuthenticationOptions();
            _shippingAddressField = new ShippingAddress();
            _contactField = new Contact();
            _cardField = new Card();
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public Card Card
        {
            get
            {
                return _cardField;
            }
            set
            {
                _cardField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string TransactionId
        {
            get
            {
                return _transactionIdField;
            }
            set
            {
                _transactionIdField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public Contact Contact
        {
            get
            {
                return _contactField;
            }
            set
            {
                _contactField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public ShippingAddress ShippingAddress
        {
            get
            {
                return _shippingAddressField;
            }
            set
            {
                _shippingAddressField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string PayPassWalletIndicator
        {
            get
            {
                return _payPassWalletIndicatorField;
            }
            set
            {
                _payPassWalletIndicatorField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public AuthenticationOptions AuthenticationOptions
        {
            get
            {
                return _authenticationOptionsField;
            }
            set
            {
                _authenticationOptionsField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public RewardProgram RewardProgram
        {
            get
            {
                return _rewardProgramField;
            }
            set
            {
                _rewardProgramField = value;
            }
        }
    }

    [GeneratedCode("System.Xml", "4.0.30319.1015")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlRoot(Namespace = "", IsNullable = true)]
    public class Card {

        private string _brandIdField;

        private string _brandNameField;

        private string _accountNumberField;

        private Address _billingAddressField;

        private string _cardHolderNameField;

        private string _expiryMonthField;

        private string _expiryYearField;

        public Card() {
            _billingAddressField = new Address();
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string BrandId
        {
            get
            {
                return _brandIdField;
            }
            set
            {
                _brandIdField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string BrandName
        {
            get
            {
                return _brandNameField;
            }
            set
            {
                _brandNameField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string AccountNumber
        {
            get
            {
                return _accountNumberField;
            }
            set
            {
                _accountNumberField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public Address BillingAddress
        {
            get
            {
                return _billingAddressField;
            }
            set
            {
                _billingAddressField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CardHolderName
        {
            get
            {
                return _cardHolderNameField;
            }
            set
            {
                _cardHolderNameField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ExpiryMonth
        {
            get
            {
                return _expiryMonthField;
            }
            set
            {
                _expiryMonthField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ExpiryYear
        {
            get
            {
                return _expiryYearField;
            }
            set
            {
                _expiryYearField = value;
            }
        }
    }

    [XmlInclude(typeof(ShippingAddress))]
    [GeneratedCode("System.Xml", "4.0.30319.1015")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlRoot(Namespace = "", IsNullable = true)]
    public class Address {

        private string _cityField;

        private string _countryField;

        private string _countrySubdivisionField;

        private string _line1Field;

        private string _line2Field;

        private string _line3Field;

        private string _postalCodeField;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string City
        {
            get
            {
                return _cityField;
            }
            set
            {
                _cityField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Country
        {
            get
            {
                return _countryField;
            }
            set
            {
                _countryField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CountrySubdivision
        {
            get
            {
                return _countrySubdivisionField;
            }
            set
            {
                _countrySubdivisionField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Line1
        {
            get
            {
                return _line1Field;
            }
            set
            {
                _line1Field = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Line2
        {
            get
            {
                return _line2Field;
            }
            set
            {
                _line2Field = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Line3
        {
            get
            {
                return _line3Field;
            }
            set
            {
                _line3Field = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string PostalCode
        {
            get
            {
                return _postalCodeField;
            }
            set
            {
                _postalCodeField = value;
            }
        }
    }

    [GeneratedCode("System.Xml", "4.0.30319.1015")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlRoot(Namespace = "", IsNullable = true)]
    public class RewardProgram {

        private string _rewardNumberField;

        private string _rewardIdField;

        private string _rewardNameField;

        private string _expiryMonthField;

        private string _expiryYearField;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string RewardNumber
        {
            get
            {
                return _rewardNumberField;
            }
            set
            {
                _rewardNumberField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string RewardId
        {
            get
            {
                return _rewardIdField;
            }
            set
            {
                _rewardIdField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string RewardName
        {
            get
            {
                return _rewardNameField;
            }
            set
            {
                _rewardNameField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ExpiryMonth
        {
            get
            {
                return _expiryMonthField;
            }
            set
            {
                _expiryMonthField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ExpiryYear
        {
            get
            {
                return _expiryYearField;
            }
            set
            {
                _expiryYearField = value;
            }
        }
    }

    [GeneratedCode("System.Xml", "4.0.30319.1015")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlRoot(Namespace = "", IsNullable = true)]
    public class AuthenticationOptions {

        private string _authenticateMethodField;

        private string _cardEnrollmentMethodField;

        private string _cAvvField;

        private string _eciFlagField;

        private string _masterCardAssignedIdField;

        private string _paResStatusField;

        private string _sCEnrollmentStatusField;

        private string _signatureVerificationField;

        private string _xidField;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string AuthenticateMethod
        {
            get
            {
                return _authenticateMethodField;
            }
            set
            {
                _authenticateMethodField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CardEnrollmentMethod
        {
            get
            {
                return _cardEnrollmentMethodField;
            }
            set
            {
                _cardEnrollmentMethodField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CAvv
        {
            get
            {
                return _cAvvField;
            }
            set
            {
                _cAvvField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string EciFlag
        {
            get
            {
                return _eciFlagField;
            }
            set
            {
                _eciFlagField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string MasterCardAssignedId
        {
            get
            {
                return _masterCardAssignedIdField;
            }
            set
            {
                _masterCardAssignedIdField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string PaResStatus
        {
            get
            {
                return _paResStatusField;
            }
            set
            {
                _paResStatusField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ScEnrollmentStatus
        {
            get
            {
                return _sCEnrollmentStatusField;
            }
            set
            {
                _sCEnrollmentStatusField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string SignatureVerification
        {
            get
            {
                return _signatureVerificationField;
            }
            set
            {
                _signatureVerificationField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Xid
        {
            get
            {
                return _xidField;
            }
            set
            {
                _xidField = value;
            }
        }
    }

    [GeneratedCode("System.Xml", "4.0.30319.1015")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlRoot(Namespace = "", IsNullable = true)]
    public class DateOfBirth {

        private long _yearField;

        private long _monthField;

        private long _dayField;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long Year
        {
            get
            {
                return _yearField;
            }
            set
            {
                _yearField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long Month
        {
            get
            {
                return _monthField;
            }
            set
            {
                _monthField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long Day
        {
            get
            {
                return _dayField;
            }
            set
            {
                _dayField = value;
            }
        }
    }

    [GeneratedCode("System.Xml", "4.0.30319.1015")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlRoot(Namespace = "", IsNullable = true)]
    public class Contact {

        private string _firstNameField;

        private string _middleNameField;

        private string _lastNameField;

        private Gender _genderField;

        private bool _genderFieldSpecified;

        private DateOfBirth _dateOfBirthField;

        private string _nationalIdField;

        private string _countryField;

        private string _emailAddressField;

        private string _phoneNumberField;

        //public Contact()
        //{
        //    this.dateOfBirthField = new DateOfBirth();
        //}

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string FirstName
        {
            get
            {
                return _firstNameField;
            }
            set
            {
                _firstNameField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string MiddleName
        {
            get
            {
                return _middleNameField;
            }
            set
            {
                _middleNameField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string LastName
        {
            get
            {
                return _lastNameField;
            }
            set
            {
                _lastNameField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public Gender Gender
        {
            get
            {
                return _genderField;
            }
            set
            {
                _genderField = value;
            }
        }

        [XmlIgnore]
        public bool GenderSpecified
        {
            get
            {
                return _genderFieldSpecified;
            }
            set
            {
                _genderFieldSpecified = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DateOfBirth DateOfBirth
        {
            get
            {
                return _dateOfBirthField;
            }
            set
            {
                _dateOfBirthField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string NationalId
        {
            get
            {
                return _nationalIdField;
            }
            set
            {
                _nationalIdField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Country
        {
            get
            {
                return _countryField;
            }
            set
            {
                _countryField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string EmailAddress
        {
            get
            {
                return _emailAddressField;
            }
            set
            {
                _emailAddressField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string PhoneNumber
        {
            get
            {
                return _phoneNumberField;
            }
            set
            {
                _phoneNumberField = value;
            }
        }
    }

    [GeneratedCode("System.Xml", "4.0.30319.1015")]
    [Serializable]
    public enum Gender {

        /// <remarks/>
        M,

        /// <remarks/>
        F
    }

    [GeneratedCode("System.Xml", "4.0.30319.1015")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlRoot(Namespace = "", IsNullable = true)]
    public class ShippingAddress : Address {

        private string _recipientNameField;

        private string _recipientPhoneNumberField;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string RecipientName
        {
            get
            {
                return _recipientNameField;
            }
            set
            {
                _recipientNameField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string RecipientPhoneNumber
        {
            get
            {
                return _recipientPhoneNumberField;
            }
            set
            {
                _recipientPhoneNumberField = value;
            }
        }
    }

    [GeneratedCode("System.Xml", "4.0.30319.1015")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Errors {

        private List<Error> _errorField;

        public Errors() {
            _errorField = new List<Error>();
        }

        [XmlElement("Error", Form = XmlSchemaForm.Unqualified)]
        public List<Error> Error
        {
            get
            {
                return _errorField;
            }
            set
            {
                _errorField = value;
            }
        }
    }

    [GeneratedCode("System.Xml", "4.0.30319.1015")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlRoot(Namespace = "", IsNullable = true)]
    public class Error {

        private string _sourceField;

        private string _reasonCodeField;

        private string _descriptionField;

        private bool _recoverableField;

        private List<Detail> _detailsField;

        public Error() {
            _detailsField = new List<Detail>();
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Source
        {
            get
            {
                return _sourceField;
            }
            set
            {
                _sourceField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ReasonCode
        {
            get
            {
                return _reasonCodeField;
            }
            set
            {
                _reasonCodeField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Description
        {
            get
            {
                return _descriptionField;
            }
            set
            {
                _descriptionField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public bool Recoverable
        {
            get
            {
                return _recoverableField;
            }
            set
            {
                _recoverableField = value;
            }
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem(Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public List<Detail> Details
        {
            get
            {
                return _detailsField;
            }
            set
            {
                _detailsField = value;
            }
        }
    }

    [GeneratedCode("System.Xml", "4.0.30319.1015")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlRoot(Namespace = "", IsNullable = true)]
    public class Detail {

        private string _nameField;

        private string _valueField;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Name
        {
            get
            {
                return _nameField;
            }
            set
            {
                _nameField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Value
        {
            get
            {
                return _valueField;
            }
            set
            {
                _valueField = value;
            }
        }
    }

    [GeneratedCode("System.Xml", "4.0.30319.1015")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class MerchantTransactions {

        private List<MerchantTransaction> _merchantTransactions1Field;

        public MerchantTransactions() {
            _merchantTransactions1Field = new List<MerchantTransaction>();
        }

        [XmlElement("MerchantTransactions", Form = XmlSchemaForm.Unqualified)]
        public List<MerchantTransaction> MerchantTransactions1
        {
            get
            {
                return _merchantTransactions1Field;
            }
            set
            {
                _merchantTransactions1Field = value;
            }
        }
    }

    [GeneratedCode("System.Xml", "4.0.30319.1015")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlRoot(Namespace = "", IsNullable = true)]
    public class MerchantTransaction {

        private string _transactionIdField;

        private string _consumerKeyField;

        private string _currencyField;

        private long _orderAmountField;

        private DateTime _purchaseDateField;

        private TransactionStatus _transactionStatusField;

        private string _approvalCodeField;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string TransactionId
        {
            get
            {
                return _transactionIdField;
            }
            set
            {
                _transactionIdField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ConsumerKey
        {
            get
            {
                return _consumerKeyField;
            }
            set
            {
                _consumerKeyField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Currency
        {
            get
            {
                return _currencyField;
            }
            set
            {
                _currencyField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long OrderAmount
        {
            get
            {
                return _orderAmountField;
            }
            set
            {
                _orderAmountField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public DateTime PurchaseDate
        {
            get
            {
                return _purchaseDateField;
            }
            set
            {
                _purchaseDateField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public TransactionStatus TransactionStatus
        {
            get
            {
                return _transactionStatusField;
            }
            set
            {
                _transactionStatusField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ApprovalCode
        {
            get
            {
                return _approvalCodeField;
            }
            set
            {
                _approvalCodeField = value;
            }
        }
    }

    [GeneratedCode("System.Xml", "4.0.30319.1015")]
    [Serializable]
    public enum TransactionStatus {

        /// <remarks/>
        Success,

        /// <remarks/>
        Failure
    }

    [GeneratedCode("System.Xml", "4.0.30319.1015")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class ShoppingCartRequest {

        private string _oAuthTokenField;

        private ShoppingCart _shoppingCartField;

        public ShoppingCartRequest() {
            _shoppingCartField = new ShoppingCart();
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string OAuthToken
        {
            get
            {
                return _oAuthTokenField;
            }
            set
            {
                _oAuthTokenField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public ShoppingCart ShoppingCart
        {
            get
            {
                return _shoppingCartField;
            }
            set
            {
                _shoppingCartField = value;
            }
        }
    }

    [GeneratedCode("System.Xml", "4.0.30319.1015")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlRoot(Namespace = "", IsNullable = true)]
    public class ShoppingCart {

        private string _currencyCodeField;

        private long _subtotalField;

        private List<ShoppingCartItem> _shoppingCartItemField;

        public ShoppingCart() {
            _shoppingCartItemField = new List<ShoppingCartItem>();
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string CurrencyCode
        {
            get
            {
                return _currencyCodeField;
            }
            set
            {
                _currencyCodeField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long Subtotal
        {
            get
            {
                return _subtotalField;
            }
            set
            {
                _subtotalField = value;
            }
        }

        [XmlElement("ShoppingCartItem", Form = XmlSchemaForm.Unqualified)]
        public List<ShoppingCartItem> ShoppingCartItem
        {
            get
            {
                return _shoppingCartItemField;
            }
            set
            {
                _shoppingCartItemField = value;
            }
        }
    }

    [GeneratedCode("System.Xml", "4.0.30319.1015")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlRoot(Namespace = "", IsNullable = true)]
    public class ShoppingCartItem {

        private string _descriptionField;

        private long _quantityField;

        private long _valueField;

        private string _imageUrlField;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Description
        {
            get
            {
                return _descriptionField;
            }
            set
            {
                _descriptionField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long Quantity
        {
            get
            {
                return _quantityField;
            }
            set
            {
                _quantityField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long Value
        {
            get
            {
                return _valueField;
            }
            set
            {
                _valueField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ImageUrl
        {
            get
            {
                return _imageUrlField;
            }
            set
            {
                _imageUrlField = value;
            }
        }
    }

    [GeneratedCode("System.Xml", "4.0.30319.1015")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class ShoppingCartResponse {

        private string _oAuthTokenField;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string OAuthToken
        {
            get
            {
                return _oAuthTokenField;
            }
            set
            {
                _oAuthTokenField = value;
            }
        }
    }

    [GeneratedCode("System.Xml", "4.0.30319.1015")]
    [Serializable]
    [DesignerCategory("code")]
    [XmlRoot(Namespace = "", IsNullable = true)]
    public class Details {

        private List<Detail> _detailField;

        public Details() {
            _detailField = new List<Detail>();
        }

        [XmlElement("Detail", Form = XmlSchemaForm.Unqualified)]
        public List<Detail> Detail
        {
            get
            {
                return _detailField;
            }
            set
            {
                _detailField = value;
            }
        }
    }
}