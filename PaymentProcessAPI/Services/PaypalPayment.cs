using PaymentProcessAPI.Models;
using PaymentProcessAPI.Models.Entities;

namespace PaymentProcessAPI.Services
{
    public class PaypalPayment : IPaymentProcess
    {
        public async Task<ProcessResult> ProcessPayment(PaymentDetail paymentDetails)
        {
            if (paymentDetails == null)
            {
                return new ProcessResult
                {
                    isSuccessful = false,
                    errorMessage = "Invalid paypal payment details"
                };
            }
            if (paymentDetails.Amount > 1000)
            {
                return new ProcessResult
                {
                    isSuccessful = false,
                    errorMessage = "Amount exceeded paypal limit, Trnsaction failed"
                };
            }
            else
            {
                return new ProcessResult
                {
                    isSuccessful = true,
                    errorMessage = "Success"
                };
            }
        }
    }
}
