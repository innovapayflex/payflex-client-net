using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayFlex.Client.Test
{
    [TestFixture]
    public class PayFlexClientTest
    {
        //+ Test CommonPayment Post Payment Then Return GetAnyResponse
        //+ Test CommonPayment Post Payment Query Then Return GetAnyResponse
        //+ Test VPos Sale & Installment Sale & Token Sale Payment Then Return GetAnyResponse
        //+ Test VPos Sale Cancellation - Installment Sale Cancellation Then Return GetAnyResponse
        //+ Test VPos Sale Refund - Installment Sale Refund Then Return GetAnyResponse
        //+ Test VPos Point Query Then Return GetAnyResponse
        //+ Test VPos PreAuthorization Then Return GetAnyResponse
        //+ Test VPos PreAuthorization Close Then Return GetAnyResponse
        //+ Test VPos PreAuthorization Capture Then Return GetAnyResponse
        //+ Test VPos Reversal Then Return GetAnyResponse       
        //+ Test VPos Save Card Then Return GetAnyResponse
        //+ Test VPos Save Token Then Return GetAnyResponse
        //+ Test VPos Update Pan Then Return GetAnyResponse
        //+ Test VPos Get Token Then Return GetAnyResponse
        //+ Test VPos Delete Token Then Return GetAnyResponse


        [Test]
        public void Test_CommonPayment_Post_Payment_Then_Return_GetAnyResponse()
        {
            string serviceUrl = "https://sanalpos.innova.com.tr/VposClient/CpWeb/api/RegisterTransaction";

            var paymentManager = new PayFlex.Client.PaymentManager();

            var commonPaymentRequest = new PayFlex.Client.CommonPaymentRequest()
            {
                ServiceUrl = serviceUrl,
                TransactionId = Guid.NewGuid().ToString(),
                ClientMerchantCode = "1B18B80EF00A41C2BC4AF2628EA88xxx",
                Password = "xxxx",
                CreditCard = new CreditCard
                {
                    CardHolderIp = "127.0.0.1",
                    CardHolderEmail = "xx@xx.com",
                    CardHolderName = "xxx"
                },
                Apply3DS = true,
                SupportHalfSecure = true,
                ReturnUrl = "https://www.innova.com.tr",
                Amount = (decimal)2.99,
                AmountCode = Currency.TRY,
                PaymentTransactionType = PaymentTransactionType.Sale,
                IsSaveCard = true,
                IsHideSaveCard = false
            };

            var result = paymentManager.PostProcess(commonPaymentRequest);

            var registerTransactionResponse = JsonConvert.DeserializeObject(result.Response, typeof(RegisterTransactionResponse));

            Assert.AreNotEqual("", result.Response);
        }
        [Test]
        public void Test_CommonPayment_Post_Payment_Query_Then_Return_GetAnyResponse()
        {
            string serviceUrl = "https://sanalpos.innova.com.tr/VposClient/CpWeb/api/VposTransaction";

            var paymentManager = new PayFlex.Client.PaymentManager();

            var vposQueryRequest = new PayFlex.Client.VposQueryRequest()
            {
                ServiceUrl = serviceUrl,
                TransactionId = Guid.NewGuid().ToString(),
                ClientMerchantCode = "1B18B80EF00A41C2BC4AF2628EA88xxx",
                Password = "xxxx"
            };

            var result = paymentManager.PostProcess(vposQueryRequest);

            var vposQueryResponse = JsonConvert.DeserializeObject(result.Response, typeof(VposQueryResponse));

            Assert.AreNotEqual("", result.Response);
        }

        [Test]
        public void Test_VPos_Sale_Installment_Sale_Token_Sale_Payment_Then_Return_GetAnyResponse()
        {
            string serviceUrl = "https://sanalpos.innova.com.tr/VposClient/VposClientWebApi/api/VposClient";

            var paymentManager = new PayFlex.Client.PaymentManager();

            //Peşin Satış
            var vposSaleRequest = new PayFlex.Client.VposRequest()
            {
                ServiceUrl = serviceUrl,
                TransactionType = PaymentTransactionType.Sale,
                ClientMerchantCode = "1B18B80EF00A41C2BC4AF2628EA88600",
                Password = "*****",
                TranscationId = Guid.NewGuid().ToString(),
                Bank = Bank.Garanti,
                CreditCard = new CreditCard()
                {
                    Pan = "4938410160702981",
                    ExpireMonth = "03",
                    ExpireYear = "2024",
                    CVV = "243",
                    CardHolderIp = "127.0.0.1"
                },
                CurrencyAmount = (decimal)4.00,
                CurrencyCode = Currency.TRY,

            };

            //Taksitli Satış
            var vposSaleInstallmentRequest = new PayFlex.Client.VposRequest()
            {
                ServiceUrl = serviceUrl,
                ClientMerchantCode = "1B18B80EF00A41C2BC4AF2628EA88600",
                Password = "*****",
                TransactionType = PaymentTransactionType.Sale,
                TranscationId = Guid.NewGuid().ToString(),
                Bank = Bank.IsBank,
                CreditCard = new CreditCard()
                {
                    Pan = "4938410160702981",
                    ExpireMonth = "03",
                    ExpireYear = "2024",
                    CVV = "243",
                    CardHolderIp = "127.0.0.1",
                    InstallmentCount = 2
                },
                CurrencyAmount = (decimal)4.00,
                CurrencyCode = Currency.TRY
            };

            //Token ile Satış
            var vposTokenRequest = new PayFlex.Client.VposRequest()
            {
                ServiceUrl = serviceUrl,
                ClientMerchantCode = "1B18B80EF00A41C2BC4AF2628EA88600",
                Password = "*****",
                TransactionType = PaymentTransactionType.Sale,
                TranscationId = Guid.NewGuid().ToString(),
                Bank = Bank.IsBank,
                Token = "0dabdcb7ebf04059979fa89300xxxxxx",
                CurrencyAmount = (decimal)4.00,
                CurrencyCode = Currency.TRY
            };

            var vposSaleResponse = paymentManager.PostProcess(vposSaleRequest);
            var vposSaleInstallmentResponse = paymentManager.PostProcess(vposSaleInstallmentRequest);
            var vposTokenResponse = paymentManager.PostProcess(vposTokenRequest);

            Assert.AreNotEqual("", vposSaleResponse.Response);
            Assert.AreNotEqual("", vposSaleInstallmentResponse.Response);
            Assert.AreNotEqual("", vposTokenResponse.Response);
        }

        [Test]
        public void Test_VPos_Sale_Cancellation_Installment_Sale_Cancellation_Then_Return_GetAnyResponse()
        {
            string serviceUrl = "https://sanalpos.innova.com.tr/VposClient/VposClientWebApi/api/VposClient";

            var paymentManager = new PaymentManager();

            var vposSaleCancelationRequest = new PayFlex.Client.VposRequest()
            {
                ServiceUrl = serviceUrl,
                ClientMerchantCode = "1B18B80EF00A41C2BC4AF2628EA88600",
                Password = "****",
                PaymentTransactionType = PaymentTransactionType.SaleCancel,
                ReferenceTransactionId = "9B539FAF6A174428B905A893",
                CreditCard = new CreditCard
                {
                    CardHolderIp = "127.0.0.1"
                }
            };

            var vposSaleCancelationResponse = paymentManager.PostProcess(vposSaleCancelationRequest);

            Assert.AreNotEqual("", vposSaleCancelationResponse);
        }

        [Test]
        public void Test_VPos_Sale_Refund_Installment_Sale_Refund_Then_Return_GetAnyResponse()
        {
            string serviceUrl = "https://sanalpos.innova.com.tr/VposClient/VposClientWebApi/api/VposClient";

            var paymentManager = new PaymentManager();

            var vposSaleRefundRequest = new PayFlex.Client.VposRequest()
            {
                ServiceUrl = serviceUrl,
                ClientMerchantCode = "1B18B80EF00A41C2BC4AF2628EA88600",
                Password = "****",
                PaymentTransactionType = PaymentTransactionType.SaleRefund,
                ReferenceTransactionId = "9B539FAF6A174428B905A893",
                CreditCard = new CreditCard
                {
                    CardHolderIp = "127.0.0.1"
                },
                CurrencyAmount = (decimal)1.25,
                CurrencyCode = Currency.TRY
            };

            var vposSaleRefundResponse = paymentManager.PostProcess(vposSaleRefundRequest);

            Assert.AreNotEqual("", vposSaleRefundResponse);
        }

        [Test]
        public void Test_VPos_Point_Query_Then_Return_GetAnyResponse()
        {
            string serviceUrl = "https://sanalpos.innova.com.tr/VposClient/VposClientWebApi/api/VposClient";

            var paymentManager = new PaymentManager();

            var vposPointQueryRequest = new PayFlex.Client.VposRequest()
            {
                ServiceUrl = serviceUrl,
                ClientMerchantCode = "1B18B80EF00A41C2BC4AF2628EA88600",
                Password = "****",
                PaymentTransactionType = PaymentTransactionType.LoyaltyQuery,
                CreditCard = new CreditCard
                {
                    Pan = "4543xxxx9699",
                    ExpireMonth = "10",
                    ExpireYear = "2020",
                    CardHolderIp = "127.0.0.1"
                },
                Bank = Bank.IsBank_Innova
            };

            var vposPointQueryResponse = paymentManager.PostProcess(vposPointQueryRequest);

            Assert.AreNotEqual("", vposPointQueryResponse);
        }

        [Test]
        public void Test_VPos_PreAuthorization_Then_Return_GetAnyResponse()
        {
            string serviceUrl = "https://sanalpos.innova.com.tr/VposClient/VposClientWebApi/api/VposClient";

            var paymentManager = new PaymentManager();

            var vposPreAuthorizationRequest = new PayFlex.Client.VposRequest()
            {
                ServiceUrl = serviceUrl,
                ClientMerchantCode = "1B18B80EF00A41C2BC4AF2628EA88600",
                Password = "****",
                PaymentTransactionType = PaymentTransactionType.Auth,
                CreditCard = new CreditCard
                {
                    Pan = "4543xxxx9699",
                    ExpireMonth = "10",
                    ExpireYear = "2020",
                    CardHolderIp = "127.0.0.1"
                },
                Bank = Bank.IsBank_Innova,
                CurrencyAmount = (decimal)1.25,
                CurrencyCode = Currency.TRY
            };

            var vposPreAuthorizationResponse = paymentManager.PostProcess(vposPreAuthorizationRequest);

            Assert.AreNotEqual("", vposPreAuthorizationResponse);
        }

        [Test]
        public void Test_VPos_PreAuthorization_Close_Then_Return_GetAnyResponse()
        {
            string serviceUrl = "https://sanalpos.innova.com.tr/VposClient/VposClientWebApi/api/VposClient";

            var paymentManager = new PaymentManager();

            var vposPreAuthorizationCancelRequest = new PayFlex.Client.VposRequest()
            {
                ServiceUrl = serviceUrl,
                ClientMerchantCode = "1B18B80EF00A41C2BC4AF2628EA88600",
                Password = "****",
                PaymentTransactionType = PaymentTransactionType.AuthCancel,
                ReferenceTransactionId = "4318FDED5FD44FC3A90BA893",
                CreditCard = new CreditCard
                {
                    CardHolderIp = "127.0.0.1"
                },
                Bank = Bank.IsBank_Innova
            };

            var vposPreAuthorizationCancelResponse = paymentManager.PostProcess(vposPreAuthorizationCancelRequest);

            Assert.AreNotEqual("", vposPreAuthorizationCancelResponse);
        }

        [Test]
        public void Test_VPos_PreAuthorization_Capture_Then_Return_GetAnyResponse()
        {
            string serviceUrl = "https://sanalpos.innova.com.tr/VposClient/VposClientWebApi/api/VposClient";

            var paymentManager = new PaymentManager();

            var vposPreAuthorizationCaptureRequest = new PayFlex.Client.VposRequest()
            {
                ServiceUrl = serviceUrl,
                ClientMerchantCode = "1B18B80EF00A41C2BC4AF2628EA88600",
                Password = "****",
                PaymentTransactionType = PaymentTransactionType.Capture,
                ReferenceTransactionId = "4318FDED5FD44FC3A90BA893",
                CreditCard = new CreditCard
                {
                    CardHolderIp = "127.0.0.1"
                },
                CurrencyAmount = (decimal)1.25,
                Bank = Bank.IsBank_Innova
            };

            var vposPreAuthorizationCaptureResponse = paymentManager.PostProcess(vposPreAuthorizationCaptureRequest);

            Assert.AreNotEqual("", vposPreAuthorizationCaptureResponse);
        }

        [Test]
        public void Test_VPos_Reversal_Then_Return_GetAnyResponse()
        {
            string serviceUrl = "https://sanalpos.innova.com.tr/VposClient/VposClientWebApi/api/VposClient";

            var paymentManager = new PaymentManager();

            var vposReversalRequest = new PayFlex.Client.VposRequest()
            {
                ServiceUrl = serviceUrl,
                ClientMerchantCode = "1B18B80EF00A41C2BC4AF2628EA88600",
                Password = "****",
                PaymentTransactionType = PaymentTransactionType.Reversal,
                ReferenceTransactionId = "4318FDED5FD44FC3A90BA893",
                TranscationId = Guid.NewGuid().ToString()
            };

            var vposReversalResponse = paymentManager.PostProcess(vposReversalRequest);

            Assert.AreNotEqual("", vposReversalResponse);
        }

        [Test]
        public void Test_VPos_Save_Card_Then_Return_GetAnyResponse()
        {
            string serviceUrl = "https://sanalpos.innova.com.tr/VposClient/VposClientWebApi/api/VposClient";

            var paymentManager = new PaymentManager();

            var vposSaveCardRequest = new PayFlex.Client.VposRequest()
            {
                ServiceUrl = serviceUrl,
                ClientMerchantCode = "1B18B80EF00A41C2BC4AF2628EA88600",
                Password = "1q2w3eASD",
                PaymentTransactionType = PaymentTransactionType.SaveCard,                
                TranscationId = Guid.NewGuid().ToString(),
                CreditCard = new CreditCard()
                {
                    Pan = "4506347011448053",
                    ExpireMonth = "02",
                    ExpireYear = "2020",
                    CVV = "000",
                    CardHolderIp = "127.0.0.1",
                    CardHolderEmail = "xxx@xx.com"
                },
                CurrencyAmount = (decimal)0.01,
                CurrencyCode = Currency.TRY,
                CustomerId = "platform11"
            };

            var vposSaveCardResponse = paymentManager.PostProcess(vposSaveCardRequest);

            Assert.AreNotEqual("", vposSaveCardResponse);
        }

        [Test]
        public void Test_VPos_Save_Token_Then_Return_GetAnyResponse()
        {
            string serviceUrl = "https://sanalpos.innova.com.tr/VposClient/VposClientWebApi/api/SaveToken";

            var paymentManager = new PaymentManager();

            var vposSaveTokenRequest = new PayFlex.Client.VposRequest()
            {
                PaymentType = PaymentType.SaveToken,
                ServiceUrl = serviceUrl,
                ClientMerchantCode = "6A47D5DCC1354C1B92769A8A6F708C15",
                Password = "123456",                                
                CreditCard = new CreditCard()
                {
                    Pan = "4531444531442283",
                    ExpireMonth = "11",
                    ExpireYear = "2017"                  
                },                
                CustomerId = "hkntspnr"
            };

            var vposSaveTokenResponse = paymentManager.PostProcess(vposSaveTokenRequest);

            var tokenResponse = JsonConvert.DeserializeObject(vposSaveTokenResponse.Response, typeof(TokenResponse));

            Assert.AreNotEqual("", vposSaveTokenResponse);
        }

        [Test]
        public void Test_VPos_Update_Pan_Then_Return_GetAnyResponse()
        {
            string serviceUrl = "https://sanalpos.innova.com.tr/VposClient/VposClientWebApi/api/UpdatePan";

            var paymentManager = new PaymentManager();

            var vposUpdatePanRequest = new PayFlex.Client.VposRequest()
            {
                PaymentType = PaymentType.UpdatePan,
                ServiceUrl = serviceUrl,
                ClientMerchantCode = "1B18B80EF00A41C2BC4AF2628EA88600",
                Password = "1q2w3eASD",
                CreditCard = new CreditCard()
                {
                    Pan = "4506347011448053",
                    ExpireMonth = "02",
                    ExpireYear = "2020"
                },
                CustomerId = "platform11",
                Token = "2b5f2bc7c2f44d61a72ca32100e79605"
            };

            var vposUpdatePanResponse = paymentManager.PostProcess(vposUpdatePanRequest);

            var tokenResponse = JsonConvert.DeserializeObject(vposUpdatePanResponse.Response, typeof(TokenResponse));

            Assert.AreNotEqual("", vposUpdatePanResponse);
        }

        [Test]
        public void Test_VPos_Get_Token_Then_Return_GetAnyResponse()
        {
            string serviceUrl = "https://sanalpos.innova.com.tr/VposClient/VposClientWebApi/api/GetPan";

            var paymentManager = new PaymentManager();

            var vposGetTokenRequest = new PayFlex.Client.VposRequest()
            {
                PaymentType = PaymentType.GetToken,
                ServiceUrl = serviceUrl,
                ClientMerchantCode = "1B18B80EF00A41C2BC4AF2628EA88600",
                Password = "1q2w3eASD",               
                Token = "2b5f2bc7c2f44d61a72ca32100e79605"
            };

            var vposGetTokenResponse = paymentManager.PostProcess(vposGetTokenRequest);

            var tokenResponse = JsonConvert.DeserializeObject(vposGetTokenResponse.Response, typeof(TokenResponse));

            Assert.AreNotEqual("", vposGetTokenResponse);
        }

        [Test]
        public void Test_VPos_Delete_Token_Then_Return_GetAnyResponse()
        {
            string serviceUrl = "https://sanalpos.innova.com.tr/VposClient/VposClientWebApi/api/DeleteToken";

            var paymentManager = new PaymentManager();

            var vposGetTokenRequest = new PayFlex.Client.VposRequest()
            {
                PaymentType = PaymentType.DeleteToken,
                ServiceUrl = serviceUrl,
                ClientMerchantCode = "1B18B80EF00A41C2BC4AF2628EA88600",
                Password = "1q2w3eASD",
                Token = "2b5f2bc7c2f44d61a72ca32100e79605"
            };

            var vposGetTokenResponse = paymentManager.PostProcess(vposGetTokenRequest);

            var tokenResponse = JsonConvert.DeserializeObject(vposGetTokenResponse.Response, typeof(TokenResponse));

            Assert.AreNotEqual("", vposGetTokenResponse);
        }
    }
}

