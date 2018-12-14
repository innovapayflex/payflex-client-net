using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PayFlex.Client
{
    [XmlType(AnonymousType = true)]
    public class RegisterTransactionResponse
    {
        [XmlElement(IsNullable = true, ElementName = "ResponseCode")]
        public string ResponseCode { get; set; }
        [XmlElement(IsNullable = true, ElementName = "ResponseMessage")]
        public string ResponseMessage { get; set; }
        [XmlElement(IsNullable = true, ElementName = "PaymentToken")]
        public string PaymentToken { get; set; }        
    }
}
