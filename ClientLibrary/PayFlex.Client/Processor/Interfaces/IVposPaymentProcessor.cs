using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayFlex.Client.Processor
{
    public interface IVposPaymentProcessor : IPaymentProcessor<VposRequest>
    {
        PaymentResponse SaveToken(VposRequest input);
        PaymentResponse UpdatePan(VposRequest input);
        PaymentResponse DeleteToken(VposRequest input);
        PaymentResponse GetToken(VposRequest input);
    }
}
