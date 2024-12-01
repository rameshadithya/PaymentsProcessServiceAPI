namespace PaymentProcessAPI.Services
{
    public class PaymentProvider
    {
        private readonly IServiceProvider _serviceProvider;
        public PaymentProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider; 
        }

        public IPaymentProcess GetPayment(string Paytype)
        {
            return Paytype.ToLower() switch
            {
                "creditcard" => _serviceProvider.GetService<CreditCardPayment>(),
                "paypal" => _serviceProvider.GetService<PaypalPayment>(),
                _ => throw new NotImplementedException("Payment method not supported")
            };
        }
    }
}
