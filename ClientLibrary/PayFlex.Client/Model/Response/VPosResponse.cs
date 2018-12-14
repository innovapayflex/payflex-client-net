using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PayFlex.Client
{
    [XmlType(AnonymousType = true)]    
    public partial class VPosResponse
    {
        [XmlElement(IsNullable = true,ElementName = "MerchantId")]        
        public string MerchantId { get; set; }
        [XmlElement(IsNullable = true, ElementName = "TransactionType")]
        public string TransactionType { get; set; }
        [XmlElement(IsNullable = true, ElementName = "TransactionId")]
        public string TransactionId { get; set; }
        [XmlElement(IsNullable = true, ElementName = "ResultCode")]
        public string ResultCode { get; set; }
        [XmlElement(IsNullable = true, ElementName = "ResultDetail")]
        public string ResultDetail { get; set; }
        [XmlElement(IsNullable = true, ElementName = "InstallmentTable")]
        public string InstallmentTable { get; set; }
        [XmlElement(IsNullable = true, ElementName = "TerminalNo")]
        public string TerminalNo { get; set; }
        [XmlElement(IsNullable = true, ElementName = "CurrencyAmount")]
        public string CurrencyAmount { get; set; }
        [XmlElement(IsNullable = true, ElementName = "CurrencyCode")]
        public string CurrencyCode { get; set; }
        [XmlElement(IsNullable = true, ElementName = "OrderId")]
        public string OrderId { get; set; }
        [XmlElement(IsNullable = true, ElementName = "ECI")]
        public string ECI { get; set; }
    }
}
