using VendingMachine.BFF.Clients.Interfaces;
using VendingMachine.BFF.Models;
using VendingMachine.BFF.Services.Interfaces;

namespace VendingMachine.BFF.Services
{
    public class VendService : IVendService
    {
        private readonly IBackendServiceClient _backendServiceClient;

        public VendService(IBackendServiceClient backendServiceClient)
        {
            _backendServiceClient = backendServiceClient;
        }

        public async Task<PurchaseResult> PurchaseSnack(int snackId, double amountPaid)
        {
            try
            {
                var snack = await _backendServiceClient.GetSnack(snackId);
                var result = new PurchaseResult();
                if (snack.AvailableInventory <= 0)
                {
                    result.Message = "No inventory.";
                    result.IsSuccessful = false;
                    return result;
                }

                if (snack.SnackPrice > amountPaid)
                {
                    result.Message = "Insufficient funds.";
                    result.IsSuccessful = false;
                    return result;
                }

                await _backendServiceClient.PostSnackPurchase(snackId);
                result.Change = amountPaid - snack.SnackPrice;
                result.IsSuccessful = true;
                result.Message = result.Change > 0 ? $"Thank you for your purchase! You received ${result.Change} of change." : "Thank you for your purchase! You paid the exact amount, so no change was given.";
                return result;
            }
            catch
            {
                return new PurchaseResult {Message = "An error occured during purchase.", IsSuccessful= false };
            }
        }

        public async Task<List<Snack>> GetSnacks()
        {
            return await _backendServiceClient.GetSnacks();
        }
    }
}
