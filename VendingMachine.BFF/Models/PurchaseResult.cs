namespace VendingMachine.BFF.Models
{
    public class PurchaseResult
    {
        public string Message { get; set; }
        public double Change { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
