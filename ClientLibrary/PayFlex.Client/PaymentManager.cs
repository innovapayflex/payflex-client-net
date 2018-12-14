using PayFlex.Client.Processor;

namespace PayFlex.Client
{
    public class PaymentManager
    {
        public PaymentManager()
        {
            PaymentProcessorFactory<IVposPaymentProcessor>.Register(VposPaymentSupplier.VPos, () => new PayFlexVPosProcessor());
            PaymentProcessorFactory<ICommonPaymentProcessor>.Register(VposPaymentSupplier.CommonPayment, () => new PayFlexCommonPaymentProcessor());
        }

        public PaymentResponse PostProcess(Payment payment)
        {
            try
            {
                PaymentResponse result = null;

                switch (payment.PaymentType)
                {
                    case PaymentType.VPos:

                        var paymentVposProcessor = PaymentProcessorFactory<IVposPaymentProcessor>.Create(VposPaymentSupplier.VPos);
                        VposRequest vposRequest = payment as VposRequest;
                        result = paymentVposProcessor.Pay(vposRequest);

                        break;
                    case PaymentType.CommonPayment:

                        var paymentCommonProcessor = PaymentProcessorFactory<ICommonPaymentProcessor>.Create(VposPaymentSupplier.CommonPayment);
                        CommonPaymentRequest commonPaymentRequest = payment as CommonPaymentRequest;
                        result = paymentCommonProcessor.Pay(commonPaymentRequest);

                        break;
                    case PaymentType.VPosQuery:

                        var paymentCommonQueryProcessor = PaymentProcessorFactory<ICommonPaymentProcessor>.Create(VposPaymentSupplier.CommonPayment);
                        VposQueryRequest vposQueryRequest = payment as VposQueryRequest;
                        result = paymentCommonQueryProcessor.VposQuery(vposQueryRequest);

                        break;
                    case PaymentType.SaveToken:

                        var paymentVposSaveTokenProcessor = PaymentProcessorFactory<IVposPaymentProcessor>.Create(VposPaymentSupplier.VPos);
                        VposRequest saveTokenRequest = payment as VposRequest;
                        result = paymentVposSaveTokenProcessor.SaveToken(saveTokenRequest);

                        break;
                    case PaymentType.UpdatePan:

                        var paymentUpdatePanProcessor = PaymentProcessorFactory<IVposPaymentProcessor>.Create(VposPaymentSupplier.VPos);
                        VposRequest updatePanRequest = payment as VposRequest;
                        result = paymentUpdatePanProcessor.UpdatePan(updatePanRequest);

                        break;
                    case PaymentType.DeleteToken:

                        var deleteTokenProcessor = PaymentProcessorFactory<IVposPaymentProcessor>.Create(VposPaymentSupplier.VPos);
                        VposRequest deleteTokenRequest = payment as VposRequest;
                        result = deleteTokenProcessor.DeleteToken(deleteTokenRequest);

                        break;
                    case PaymentType.GetToken:
                        var tokenProcessor = PaymentProcessorFactory<IVposPaymentProcessor>.Create(VposPaymentSupplier.VPos);
                        VposRequest tokenRequest = payment as VposRequest;
                        result = tokenProcessor.GetToken(tokenRequest);

                        break;



                }

                return result;
            }
            catch (PayFlexClientException ex)
            {
                throw ex;
            }
        }
    }
}