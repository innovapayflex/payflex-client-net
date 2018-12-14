using System;
using PayFlex.Client.Processor;
using System.Collections.Generic;

namespace PayFlex.Client
{
    public class PaymentProcessorFactory<T>
    {
        static readonly Dictionary<VposPaymentSupplier, Func<T>> _dict = new Dictionary<VposPaymentSupplier, Func<T>>();

        public static T Create(VposPaymentSupplier id)
        {
            Func<T> constructor = null;
            if (_dict.TryGetValue(id, out constructor))
            {
                return constructor();
            }

            throw new ArgumentException("No type registered for this vpos supplier");
        }

        public static void Register(VposPaymentSupplier id, Func<T> ctor)
        {
            _dict.Add(id, ctor);
        }
    }  
}