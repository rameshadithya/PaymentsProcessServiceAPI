using Microsoft.EntityFrameworkCore;
using PaymentProcessAPI.Models.Entities;

namespace PaymentProcessAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<PaymentDetail> paymentDetails { get; set; }
    }
}
