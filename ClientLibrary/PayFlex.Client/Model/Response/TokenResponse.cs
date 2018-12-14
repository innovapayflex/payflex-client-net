using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayFlex.Client
{
    public class TokenResponse
    {
        public string PanMasked { get; set; }
        public string Expiry { get; set; }
        public string Token { get; set; }
        public string CardHolderName { get; set; }
        public ResponseInfo ResponseInfo { get; set; }
    }

    public class ResponseInfo
    {
        public string Status { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseDateTime { get; set; }
        public bool IsIdempotent { get; set; }
    }
}
