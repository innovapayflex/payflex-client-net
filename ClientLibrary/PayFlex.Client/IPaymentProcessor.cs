namespace PayFlex.Client
{
    public interface IPaymentProcessor<T> where T : Payment
    {
        PaymentResponse Pay(T input);
       
    }
}
