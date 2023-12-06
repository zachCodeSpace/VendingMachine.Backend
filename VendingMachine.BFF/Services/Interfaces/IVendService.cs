using VendingMachine.BFF.Models;

namespace VendingMachine.BFF.Services.Interfaces
{
    public interface IVendService
    {
        Task<PurchaseResult> PurchaseSnack(int snackId, double amountPaid);
        Task<List<Snack>> GetSnacks();
    }
}
