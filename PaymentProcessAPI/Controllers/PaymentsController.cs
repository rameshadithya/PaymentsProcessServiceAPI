using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentProcessAPI.Data;
using PaymentProcessAPI.Models;
using PaymentProcessAPI.Models.Entities;
using PaymentProcessAPI.Services;

namespace PaymentProcessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly PaymentProvider _paymentProvider;

        public PaymentsController(ApplicationDbContext context, PaymentProvider paymentProvider)
        {
            _context = context; 
            _paymentProvider = paymentProvider;
        }
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var result = await _context.paymentDetails.ToListAsync();
            return Ok(result);
        }

        [HttpPost("process")]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentDetail paymentDetail)
        {
            if (paymentDetail == null || string.IsNullOrEmpty(paymentDetail.PaymentType))
            {
                return BadRequest("Invalid payment request.");
            }

            try
            {
                var paymentMethod = _paymentProvider.GetPayment(paymentDetail.PaymentType);
                var response = await paymentMethod.ProcessPayment(paymentDetail);
                return Ok(response);
            }
            catch (NotImplementedException)
            {
                return BadRequest("The specified payment method is not supported.");
            }
        }
    }
}
