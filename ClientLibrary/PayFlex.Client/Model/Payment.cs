
using System;
using System.Configuration;

namespace PayFlex.Client
{
    public class Payment
    {
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentType PaymentType { get; set; }
        /// <summary>
        /// İşlem adı bilgisi. 
        /// </summary>
        public PaymentTransactionType? TransactionType { get; set; }

        public string ServiceUrl { get; set; }      

    }
}