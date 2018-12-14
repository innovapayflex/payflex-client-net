using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayFlex.Client
{
    public class VposQueryResponse
    {
        public string Rc { get; set; }
        public string AuthCode { get; set; }
        public string Message { get; set; }
        public string TransactionId { get; set; }
        public string Ptkn { get; set; }
        public string PanMasked { get; set; }
        public string CardExpireDate { get; set; }
        public string BankId { get; set; }
        public string CardBankId { get; set; }
        public string CardType { get; set; }
        public string CustomFields { get; set; }
        public string CurrencyAmount { get; set; }
        public string CurrencyCode { get; set; }
        public string CardHolderName { get; set; }
        public string TransactionDate { get; set; }
        public string BankHostMerchantId { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}
