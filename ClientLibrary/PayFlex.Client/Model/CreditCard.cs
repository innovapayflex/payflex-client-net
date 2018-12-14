using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayFlex.Client
{
    public class CreditCard
    {
        /// <summary>
        /// Kredi kart numarası bilgisi. Sayısal–15-22. Örnek: 4543600299100712
        /// </summary>
        public string Pan { get; set; }
        /// <summary>
        /// Kart sahibinin adı. Alfanumerik–100
        /// </summary>
        public string CardHolderName { get; set; }
        /// <summary>
        /// Kredi kartı güvenlik kodu bilgisi. Sayısal–3. Örnek: 544
        /// </summary>
        public string CVV { get; set; }
        /// <summary>
        /// Kredi kartı son kullanma tarihi bilgisi. Sayısal–6. YYYYMM
        /// </summary>
        public string Expiry
        {
            get { return $"{ExpireYear}{ExpireMonth}"; }
        }            
       
        /// <summary>
        /// Kredi kartının son kullanma tarihinin ay bilgisi
        /// </summary>
        public string ExpireMonth { get; set; }
        /// <summary>
        /// Kredi kartının son kullanma tarihinin yıl bilgisi
        /// </summary>
        public string ExpireYear { get; set; }
        /// <summary>
        /// İşlemi yapan son kullanıcının email bilgisi. Alfanumerik–50
        /// </summary>
        public string CardHolderEmail { get; set; }
        /// <summary>
        /// İşlemi yapan son kullanıcının IP si Üye iş yeri tarafından alınıp sanal posa gönderilecektir. Alfanumerik–15
        /// Örnek: 78.155.195.43
        /// </summary>
        public string CardHolderIp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Puan tutarı. Sayısal. Örnek: 55.00 ya da 145.34 
        /// </summary>
        public string PointAmount { get; set; }
        /// <summary>
        /// Puan birimi. Sayısal. TL = 949
        /// </summary>
        public string PointCode { get; set; }
        /// <summary>
        /// İşlem taksit sayısı.  Sayısal – Tam sayı – 2 
        /// Örnek: 1, 12, vb...
        /// </summary>
        public byte? InstallmentCount { get; set; }
        /// <summary>
        /// AMEX kartların ön yüzünde bulunan güvenlik numarasıdır.Sayısal-4. Örnek:9456
        /// </summary>
        public string SecurityCode { get; set; }
    }
}
