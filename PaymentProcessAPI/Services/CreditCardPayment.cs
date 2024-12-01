using PaymentProcessAPI.Models;
using PaymentProcessAPI.Models.Entities;

namespace PaymentProcessAPI.Services
{
    public class CreditCardPayment : IPaymentProcess
    {
        public async Task<ProcessResult> ProcessPayment(PaymentDetail paymentDetails)
        {
            if (paymentDetails == null) 
            {
                return new ProcessResult
                {
                    isSuccessful = false,
                    errorMessage = "Invalid Credit card payment details"
                };
            }
            if(paymentDetails.Amount> 1000)
            {
                return new ProcessResult
                {
                    isSuccessful = false,
                    errorMessage = "Amount exceeded Credit limit, Trnsaction failed"
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
