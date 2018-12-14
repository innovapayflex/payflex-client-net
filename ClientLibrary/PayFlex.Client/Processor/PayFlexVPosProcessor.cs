using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Text;

namespace PayFlex.Client.Processor
{
    public class PayFlexVPosProcessor : IVposPaymentProcessor
    {
        /// <summary>
        ///  PayFlex Vpos satış işlemi.
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public PaymentResponse Pay(VposRequest payment)
        {
            #region Pos Configuration             
            string strHostAddress = payment.ServiceUrl;
            #endregion

            byte[] postByteArray = Encoding.UTF8.GetBytes(payment.ToJson());

            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | (SecurityProtocolType)768 | (SecurityProtocolType)3072 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            WebRequest webRequest = WebRequest.Create(strHostAddress);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json; charset=utf-8";
            webRequest.ContentLength = postByteArray.Length;
            webRequest.UseDefaultCredentials = true;

            Stream dataStream = webRequest.GetRequestStream();
            dataStream.Write(postByteArray, 0, postByteArray.Length);
            dataStream.Close();

            WebResponse webResponse = webRequest.GetResponse();
            dataStream = webResponse.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            var bankResponse = new PaymentResponse();
            bankResponse.Response = reader.ReadToEnd();
            bankResponse.IsSuccessful = true;
            reader.Close();
            dataStream.Close();
            webResponse.Close();

            return bankResponse;
        }

        /// <summary>
        /// Token Kaydetme
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PaymentResponse SaveToken(VposRequest input)
        {
            #region Pos Configuration             
            string strHostAddress = input.ServiceUrl;
            #endregion

            byte[] postByteArray = Encoding.UTF8.GetBytes(input.ToStringBySaveToken());

            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | (SecurityProtocolType)768 | (SecurityProtocolType)3072 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            WebRequest webRequest = WebRequest.Create(strHostAddress);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = postByteArray.Length;
            webRequest.UseDefaultCredentials = true;

            Stream dataStream = webRequest.GetRequestStream();
            dataStream.Write(postByteArray, 0, postByteArray.Length);
            dataStream.Close();

            WebResponse webResponse = webRequest.GetResponse();
            dataStream = webResponse.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            var bankResponse = new PaymentResponse();
            bankResponse.Response = reader.ReadToEnd();
            bankResponse.IsSuccessful = true;
            reader.Close();
            dataStream.Close();
            webResponse.Close();

            return bankResponse;
        }

        /// <summary>
        /// Token ile Kart Bilgileri Güncelleme
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PaymentResponse UpdatePan(VposRequest input)
        {
            #region Pos Configuration             
            string strHostAddress = input.ServiceUrl;
            #endregion

            byte[] postByteArray = Encoding.UTF8.GetBytes(input.ToStringByUpdateToken());

            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | (SecurityProtocolType)768 | (SecurityProtocolType)3072 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            WebRequest webRequest = WebRequest.Create(strHostAddress);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = postByteArray.Length;
            webRequest.UseDefaultCredentials = true;

            Stream dataStream = webRequest.GetRequestStream();
            dataStream.Write(postByteArray, 0, postByteArray.Length);
            dataStream.Close();

            WebResponse webResponse = webRequest.GetResponse();
            dataStream = webResponse.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            var bankResponse = new PaymentResponse();
            bankResponse.Response = reader.ReadToEnd();
            bankResponse.IsSuccessful = true;
            reader.Close();
            dataStream.Close();
            webResponse.Close();

            return bankResponse;
        }

        /// <summary>
        /// Token ile Kart Silme
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PaymentResponse DeleteToken(VposRequest input)
        {
            #region Pos Configuration             
            string strHostAddress = input.ServiceUrl;
            #endregion

            byte[] postByteArray = Encoding.UTF8.GetBytes(input.ToStringByToken());

            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | (SecurityProtocolType)768 | (SecurityProtocolType)3072 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            WebRequest webRequest = WebRequest.Create(strHostAddress);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = postByteArray.Length;
            webRequest.UseDefaultCredentials = true;

            Stream dataStream = webRequest.GetRequestStream();
            dataStream.Write(postByteArray, 0, postByteArray.Length);
            dataStream.Close();

            WebResponse webResponse = webRequest.GetResponse();
            dataStream = webResponse.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            var bankResponse = new PaymentResponse();
            bankResponse.Response = reader.ReadToEnd();
            bankResponse.IsSuccessful = true;
            reader.Close();
            dataStream.Close();
            webResponse.Close();

            return bankResponse;
        }

        /// <summary>
        /// Token ile Kart Sorgulama
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PaymentResponse GetToken(VposRequest input)
        {
            #region Pos Configuration             
            string strHostAddress = input.ServiceUrl;
            #endregion

            byte[] postByteArray = Encoding.UTF8.GetBytes(input.ToStringByToken());

            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | (SecurityProtocolType)768 | (SecurityProtocolType)3072 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            WebRequest webRequest = WebRequest.Create(strHostAddress);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = postByteArray.Length;
            webRequest.UseDefaultCredentials = true;

            Stream dataStream = webRequest.GetRequestStream();
            dataStream.Write(postByteArray, 0, postByteArray.Length);
            dataStream.Close();

            WebResponse webResponse = webRequest.GetResponse();
            dataStream = webResponse.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            var bankResponse = new PaymentResponse();
            bankResponse.Response = reader.ReadToEnd();
            bankResponse.IsSuccessful = true;
            reader.Close();
            dataStream.Close();
            webResponse.Close();

            return bankResponse;
        }
    }
}