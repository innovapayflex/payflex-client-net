using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Text;

namespace PayFlex.Client.Processor
{
    public class PayFlexCommonPaymentProcessor : IPaymentProcessor<CommonPaymentRequest>, ICommonPaymentProcessor
    {
        /// <summary>
        /// Ortak Ödeme Sistemine İşlem Kayıt Etme.Ortak Ödeme sayfasında satış işlemine başlamadan önce işlem kaydedilmelidir.
        /// </summary>
        /// <param name="payment">İşlemi kaydetmek için Ortak Ödeme API Adresi belirtilen CommonPaymentRequest ile kullanılmaktadır. </param>
        /// <returns>API çağrısının sonucunda Ortak Ödeme sistemi bir GUID dönecektir. Bu GUID ile Ortak Ödeme Ekranı açılabilir</returns>
        public PaymentResponse Pay(CommonPaymentRequest payment)
        {
            #region Pos Configuration           
            string strHostAddress = payment.ServiceUrl;
            #endregion

            byte[] postByteArray = Encoding.UTF8.GetBytes(payment.ToString());

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
        /// Üye işyeri dönüş sayfasına gönderilen TransacitonId nin sonucunu doğrulamak için bu kullanır. İşlemin sanal pos ayağını sorgular.
        /// Dönen sonuç içerisinde ResponseCode 0  ve Rc 0000 ise doğrulama başarılı,ResponseCode  0 dan farklı ise bir hata olmuş ve devamında bu hatayla ilgili bilgiler yer alıyor demektir. 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PaymentResponse VposQuery(VposQueryRequest query)
        {
            #region Pos Configuration           
            string strHostAddress = query.ServiceUrl;
            #endregion

            byte[] postByteArray = Encoding.UTF8.GetBytes(query.ToString());

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