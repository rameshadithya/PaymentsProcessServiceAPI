namespace PaymentProcessAPI.Models.Entities
{
    public class PaymentDetail
    {
        public Guid ID { get; set; }
        public required string UserName { get; set; }
        public required int Amount {  get; set; } 
        public required string PaymentType { get; set; }
        public required int TransactionId {  get; set; }
    }
}
