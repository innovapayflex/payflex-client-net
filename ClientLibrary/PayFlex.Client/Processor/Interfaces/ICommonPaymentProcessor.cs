using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayFlex.Client
{
    public interface ICommonPaymentProcessor : IPaymentProcessor<CommonPaymentRequest>
    {
        PaymentResponse VposQuery(VposQueryRequest input);
    }
}
