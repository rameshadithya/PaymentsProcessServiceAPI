using PaymentProcessAPI.Models;
using PaymentProcessAPI.Models.Entities;

namespace PaymentProcessAPI.Services
{
    public interface IPaymentProcess
    {
        Task<ProcessResult> ProcessPayment(PaymentDetail paymentDetails);
    }
}
