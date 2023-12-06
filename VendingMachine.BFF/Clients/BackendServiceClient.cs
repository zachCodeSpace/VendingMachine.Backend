using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using VendingMachine.BFF.Clients.Interfaces;
using VendingMachine.BFF.Models;

namespace VendingMachine.BFF.Clients
{
    public class BackendServiceClient : IBackendServiceClient
    {
        private readonly HttpClient _httpClient;

        public BackendServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7246/");
        }

        public async Task<List<Snack>> GetSnacks()
        {
            var response = await _httpClient.GetAsync("api/Snack");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Snack>>(json) ?? throw new Exception("Issue deserializing json.");
        }

        public async Task PostSnackPurchase(int snackId)
        {
            string json = JsonConvert.SerializeObject(snackId);

            var response = await _httpClient.PostAsync("api/Snack", new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        public async Task<Snack> GetSnack(int snackId)
        {
            string json = JsonConvert.SerializeObject(snackId);

            var response = await _httpClient.PostAsync("api/Snack/GetSnack", new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<Snack>(await response.Content.ReadAsStringAsync()) ?? throw new Exception("Issue deserializing json.");
        }
    }
}
