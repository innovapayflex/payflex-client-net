using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PayFlex.Client
{
    /// <summary>
    /// 
    /// PayFlex VPos uygulamasına gönderilen XML isteği alanlarını içerir.
    /// </summary>
    public class VposRequest : Payment
    {
        /// <summary>
        /// İşlem adı bilgisi Boşluk içermemelidir.
        /// </summary>
        public PaymentTransactionType TransactionType { get; set; }
        /// <summary>
        /// Üye işyeri kodu
        /// </summary>
        public string ClientMerchantCode { get; set; }
        /// <summary>
        /// Üye işyeri şifre
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Alt Bayi kodu
        /// </summary>
        public string SubMerchantCode { get; set; }
        /// <summary>
        /// Bank numarası
        /// </summary>
        public Bank Bank { get; set; }
        /// <summary>
        /// Benzesiz (Unique) İşlem numara bilgisi
        /// </summary>
        public string TranscationId { get; set; }
        /// <summary>
        /// İşlem tutar bilgisi
        /// </summary>
        public decimal CurrencyAmount { get; set; }
        /// <summary>
        /// İşlem kur bilgisi (YTL = 949)
        /// </summary>
        public Currency CurrencyCode { get; set; }
        /// <summary>
        /// Kredi kart bilgisi
        /// </summary>
        public CreditCard CreditCard { get; set; }
        /// <summary>
        /// Orijinal işlem üye işyeri işlem numarası bilgisi
        /// </summary>
        public string ReferenceTransactionId { get; set; }
        /// <summary>
        /// Sipariş numarası
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// Sipariş ile ilgili varsa detaylı açıklama
        /// </summary>
        public string OrderDescription { get; set; }
        /// <summary>
        /// MPI tarafından 3D Secure işlemin sonucunda gönderilen alan
        /// </summary>
        public string Cavv { get; set; }
        /// <summary>
        /// 3D secure işlemin sonucu
        /// </summary>
        public string Eci { get; set; }
        /// <summary>
        /// 3D secure işlemi sonucundan MPI tarafından gönderilen değer. Eğer gönderilmemişse üye işyeri kendisi oluşturmalıdır
        /// </summary>
        public string Xid { get; set; }
        /// <summary>
        /// 3D secure işlemi sonucundan MPI tarafından gönderilen kredi kartı kart bilgileri yerine geçen değer.
        /// </summary>
        public string Md { get; set; }
        /// <summary>
        /// İşlem tekrar parametresi
        /// </summary>
        public bool? TryMultiBanks { get; set; }
        /// <summary>
        /// Kart bilgileri yerine geçen token ile PayFlex Sanal Pos Üye İşyeri aracılığıyla finansal işlem yapılmasını sağlar
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Kart kullanıcısını belirten benzersiz (unique) değerdir. Aynı kart için farklı tokenlar kaydedebilmeyi sağlar.
        /// </summary>
        public string CustomerId { get; set; }

        public VposRequest()
        {
            PaymentType = PaymentType.VPos;
        }

        public string ToJson()
        {
            NumberFormatInfo moneyFormatInfo = new NumberFormatInfo();
            moneyFormatInfo.NumberDecimalSeparator = ".";

            if (CreditCard == null)
            {
                CreditCard = new CreditCard();
            }

            string json = new JavaScriptSerializer().Serialize(new
            {
                TransactionType = TransactionType.ToString(),
                ClientMerchantCode = ClientMerchantCode,
                SubMerchantCode = SubMerchantCode,
                BankId = (int)Enum.Parse(typeof(Bank), Bank.ToString()),
                TranscationId = TranscationId,
                CurrencyAmount = CurrencyAmount.ToString(moneyFormatInfo),
                CurrencyCode = (int)Enum.Parse(typeof(Currency), CurrencyCode.ToString()),
                InstallmentCount = CreditCard.InstallmentCount.HasValue ? CreditCard.InstallmentCount.Value.ToString() : "",
                Pan = CreditCard.Pan,
                Expiry = CreditCard.Expiry,
                Cvv = CreditCard.CVV,
                ReferenceTransactionId = ReferenceTransactionId,
                CardHoldersClientIp = CreditCard.CardHolderIp,
                CardHoldersEmail = CreditCard.CardHolderName,
                OrderId = OrderId,
                OrderDescription = OrderDescription,
                Cavv = Cavv,
                Eci = Eci,
                Xid = Xid,
                Md = Md,
                TryMultiBanks = TryMultiBanks.HasValue ? (TryMultiBanks.Value ? "1" : "") : "",
                Token = Token
            });

            return json;
        }

        public string ToStringBySaveToken()
        {
            if (CreditCard == null)
            {
                CreditCard = new CreditCard();
            }

            StringBuilder str = new StringBuilder();
            str.AppendFormat("{0}={1}&", "ClientMerchantCode", ClientMerchantCode);
            str.AppendFormat("{0}={1}&", "Password", Password);
            str.AppendFormat("{0}={1}&", "Pan", CreditCard.Pan);
            str.AppendFormat("{0}={1}&", "Expiry", CreditCard.Expiry);
            str.AppendFormat("{0}={1}&", "CustomerId", CustomerId);
            str.AppendFormat("{0}={1}", "Token", Token);

            return str.ToString();
        }

        public string ToStringByUpdateToken()
        {
            if (CreditCard == null)
            {
                CreditCard = new CreditCard();
            }

            StringBuilder str = new StringBuilder();
            str.AppendFormat("{0}={1}&", "ClientMerchantCode", ClientMerchantCode);
            str.AppendFormat("{0}={1}&", "Password", Password);
            str.AppendFormat("{0}={1}&", "Pan", CreditCard.Pan);
            str.AppendFormat("{0}={1}&", "Expiry", CreditCard.Expiry);
            str.AppendFormat("{0}={1}", "CustomerId", CustomerId);

            return str.ToString();
        }

        public string ToStringByToken()
        {
            if (CreditCard == null)
            {
                CreditCard = new CreditCard();
            }

            StringBuilder str = new StringBuilder();
            str.AppendFormat("{0}={1}&", "ClientMerchantCode", ClientMerchantCode);
            str.AppendFormat("{0}={1}&", "Password", Password);
            str.AppendFormat("{0}={1}", "Token", Token);

            return str.ToString();
        }
    }
}
