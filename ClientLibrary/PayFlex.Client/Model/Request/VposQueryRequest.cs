using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayFlex.Client
{
    public class VposQueryRequest : Payment
    {
        public VposQueryRequest()
        {
            PaymentType = PaymentType.VPosQuery;
        }

        /// <summary>
        /// Üye işyeri numarası
        /// </summary>
        public string ClientMerchantCode { get; set; }
        /// <summary>
        /// Üye işyeri şifresi
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Her işlem başına benzersiz olması gereken işlem numarası.
        /// </summary>
        public string TransactionId { get; set; }

        public override string ToString()
        {
            var str = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(TransactionId))
                str.AppendFormat("{0}={1}&", "TransactionId", TransactionId);
            if (!string.IsNullOrWhiteSpace(ClientMerchantCode))
                str.AppendFormat("{0}={1}&", "ClientMerchantCode", ClientMerchantCode);
            if (!string.IsNullOrWhiteSpace(Password))
                str.AppendFormat("{0}={1}", "Password", Password);

            return str.ToString();
        }
    }
}
