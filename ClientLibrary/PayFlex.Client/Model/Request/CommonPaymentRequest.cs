using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayFlex.Client
{
    public class CommonPaymentRequest : Payment
    {
        public CommonPaymentRequest()
        {
            PaymentType = PaymentType.CommonPayment;
        }

        /// <summary>
        /// Üye işyeri numarası
        /// Örn: 5BCCDF60DC2849EEBCF69D9223CD8C98
        /// </summary>
        public string ClientMerchantCode { get; set; }
        /// <summary>
        /// İşlem kur bilgisi
        /// Örn: 840, 949
        /// </summary>
        public Currency? AmountCode { get; set; }
        /// <summary>
        /// İşlem tutar bilgisi küsuratları . ile ayrılmalıdır.
        /// Örn: 0.01 (1 kuruşluk işlem geçmek için)
        /// </summary>
        public decimal? Amount { get; set; }
        /// <summary>
        /// Üye işyeri şifresi
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Her işlem başına benzersiz olması gereken işlem numarası gönderilmemesi durumunda ortak ödeme tarafından yaratılacaktır.
        /// </summary>
        public string TransactionId { get; set; }
        /// <summary>
        /// Sipariş numarası, başarısız olan işlemler boyunca tekrar tekrar gönderilebilir. OrderId ye sahip bir işlem başarılı olduğunda Aynı OrderId ile bir daha işlem yapılamaz.
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// Sipariş açıklaması
        /// </summary>
        public string OrderDescription { get; set; }
        /// <summary>
        /// Kredi kartı bilgisi
        /// </summary>
        public CreditCard CreditCard { get; set; }
        /// <summary>
        /// Üye işyeri yapılan işlem için sistemde tanımlı dönüş sayfasından farklı bir sayfa kullanmak istiyorsa bu alanda yeni url i belirleyebilir.
        /// </summary>
        public string ReturnUrl { get; set; }
        /// <summary>
        /// İşlem sırasında 3D Secure akışı uygulanıp uygulanmayacağını belirten parametredir.
        /// </summary>
        public bool Apply3DS { get; set; }
        /// <summary>
        /// İşlem yapılan kart bilgileri 3D Secure sistemine dahil değilse işlemin Vpos işlemcisine iletilip, iletilmeyeceğini belirten parametredir.
        /// </summary>
        public bool SupportHalfSecure { get; set; }
        /// <summary>
        /// Hiyerarşik şekilde çalışan üye işyerleri için, ana üye işyerinin alt bayisinin sistemde tanımlı kodunun iletilmesi beklenmektedir.
        /// </summary>
        public string SubMerchantCode { get; set; }
        /// <summary>
        /// İşlem yapılan kart bilgilerinin kaydedilmesini müşterinin insiyatifine bırakmak için belirtilen parametredir.
        ///(Not:Kart kaydetme yetkisi olmadan parametreler geçersizdir.)
        /// </summary>
        public bool IsHideSaveCard { get; set; }
        /// <summary>
        /// İşlem yapılan kartın kaydedilip kaydedilmeyeceğini belirten parametredir.Üye iş yeri veya müşteri tarafından iletilmelidir.
        /// </summary>
        public bool IsSaveCard { get; set; }
        /// <summary>
        /// Ortak ödeme süreci sonunda kredi kartı bilgisinin kaydedilip Token dönülmesi isteniyor ise doldurulmalıdır. Kart token'ı CustomerId bazında tutulur (aynı kart farklı CustomerId'ler ile kaydedilebilir).
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// Name ve value çiftleri olarak custom alanlar kayıt edilebilmektedir.
        /// </summary>
        public Dictionary<string, string> CustomFields { get; set; }
        /// <summary>
        /// Ortak ödeme adresinin müşteriye sms olarak gönderilmesi için kullanılır. Sms olarak link gönderilmek isteniyorsa 1 değeri verilmelidir.
        /// </summary>
        public bool? IsSmsUsage { get; set; }
        /// <summary>
        /// Ortak ödeme adresinin müşteriye sms olarak gönderilmesi için kullanılan müşteri telefon numarası bilgisidir.
        /// </summary>
        public string TelephoneNumber { get; set; }
        /// <summary>
        /// Token alanında karta ait kaydedilmiş Token değeri girilecektir.
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Kart giriş ekranında, kart sahibinden tutar bilgisi gizlenmek istenirse bu alan kullanılabilir
        /// </summary>
        public bool? HideAmount { get; set; }




        public override string ToString()
        {
            NumberFormatInfo moneyFormatInfo = new NumberFormatInfo();
            moneyFormatInfo.NumberDecimalSeparator = ".";

            var str = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(TransactionId))
                str.AppendFormat("{0}={1}&", "TransactionId", TransactionId);
            if (!string.IsNullOrWhiteSpace(ClientMerchantCode))
                str.AppendFormat("{0}={1}&", "ClientMerchantCode", ClientMerchantCode);
            if (!string.IsNullOrWhiteSpace(Password))
                str.AppendFormat("{0}={1}&", "Password", Password);
            if (!string.IsNullOrWhiteSpace(CreditCard.CardHolderIp))
                str.AppendFormat("{0}={1}&", "CardHolderIp", CreditCard.CardHolderIp);
            if (!string.IsNullOrWhiteSpace(CreditCard.CardHolderName))
                str.AppendFormat("{0}={1}&", "CardHolderName", CreditCard.CardHolderName);
            if (!string.IsNullOrWhiteSpace(ReturnUrl))
                str.AppendFormat("{0}={1}&", "ReturnUrl", ReturnUrl);
            if (Amount.HasValue)
                str.AppendFormat("{0}={1}&", "Amount", Amount.Value.ToString(moneyFormatInfo));
            if (AmountCode.HasValue)
                str.AppendFormat("{0}={1}&", "AmountCode", (int)Enum.Parse(typeof(Currency), AmountCode.Value.ToString()));
            if (PaymentTransactionType.HasValue)
                str.AppendFormat("{0}={1}&", "TransactionType", PaymentTransactionType.ToString());
            if (!string.IsNullOrWhiteSpace(OrderId))
                str.AppendFormat("{0}={1}&", "OrderId", OrderId);
            if (!string.IsNullOrWhiteSpace(OrderDescription))
                str.AppendFormat("{0}={1}&", "OrderDescription", OrderDescription);
            if (HideAmount.HasValue)
                str.AppendFormat("{0}={1}&", "HideAmount", HideAmount.Value ? "1" : "0");
            if (!string.IsNullOrWhiteSpace(Token))
                str.AppendFormat("{0}={1}&", "Token", Token);
            if (!string.IsNullOrWhiteSpace(TelephoneNumber))
                str.AppendFormat("{0}={1}&", "TelephoneNumber", TelephoneNumber);
            if (!string.IsNullOrWhiteSpace(CustomerId))
                str.AppendFormat("{0}={1}&", "CustomerId", CustomerId);
            if (!string.IsNullOrWhiteSpace(SubMerchantCode))
                str.AppendFormat("{0}={1}&", "SubMerchantCode", SubMerchantCode);
            if (IsSmsUsage.HasValue)
                str.AppendFormat("{0}={1}&", "IsSmsUsage", IsSmsUsage.Value ? "1" : "0");

            if (CustomFields != null && CustomFields.Count > 0)
            {
                for (int i = 0; i < CustomFields.Count; i++)
                {
                    str.AppendFormat($"CustomFields[{i}][{CustomFields.ElementAt(0).Key}]={CustomFields.ElementAt(0).Value}&");
                }
            }

            str.AppendFormat("{0}={1}&", "Apply3DS", Apply3DS ? "1" : "0");
            str.AppendFormat("{0}={1}&", "SupportHalfSecure", SupportHalfSecure ? "1" : "0");
            str.AppendFormat("{0}={1}&", "IsSaveCard", IsSaveCard ? "1" : "0");
            str.AppendFormat("{0}={1}", "IsHideSaveCard", IsHideSaveCard ? "1" : "0");

            return str.ToString();
        }
    }
}
