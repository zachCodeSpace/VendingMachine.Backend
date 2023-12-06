using MongoDB.Bson;

namespace VendingMachine.BFF.Models
{
    public class Snack
    {
        public int SnackId { get; set; }
        public string SnackName { get; set; }
        public double SnackPrice { get; set; }
        public int AvailableInventory { get; set; }
    }
}
