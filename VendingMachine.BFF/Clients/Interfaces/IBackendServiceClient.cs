using VendingMachine.BFF.Models;

namespace VendingMachine.BFF.Clients.Interfaces
{
    public interface IBackendServiceClient
    {
        Task<List<Snack>> GetSnacks();
        Task PostSnackPurchase(int snackId);
        Task<Snack> GetSnack(int snackId);
    }
}
