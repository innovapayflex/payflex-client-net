using System;

namespace PayFlex.Client
{
    public class PayFlexClientException : Exception
    {
        public string ResultMessage { get; set; }
        public string ResultCode { get; set; }

        public PayFlexClientException(string code, string message, string result) : base(message)
        {
            ResultCode = code;
            ResultMessage = result;
        }
    }
}
