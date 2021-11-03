using MicroRabbit.Mvc.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroRabbit.Mvc.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _client;

        public TransferService(HttpClient client)
        {
            _client = client;
        }

        public async Task Transfer(TransferDto transferDto)
        {
            var url = "https://localhost:5001";
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            var client = new HttpClient(httpClientHandler) { BaseAddress = new Uri(url) };

            var content = new StringContent(JsonConvert.SerializeObject(transferDto), System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
        }
    }
}
