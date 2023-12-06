namespace VendingMachine.BFF.Models
{
    public class PurchaseRequest
    {
        public int SnackId { get; set; }
        public double AmountPaid { get; set; }
    }
}
