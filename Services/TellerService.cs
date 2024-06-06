using System.Security.Cryptography.X509Certificates;
using System.Text;
using api.DTOs;
using Api.Models;
using Newtonsoft.Json;

namespace api.Services
{
    public class TellerService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly string _tellerApiUrl;
        public TellerService(IConfiguration config)
        {
            _config = config;
            var certPath = _config["CertPath"];
            var certKeyPath = _config["CertKeyPath"];
            var cert = new X509Certificate2(certPath, certKeyPath);
            var handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual
            };
            handler.ClientCertificates.Add(cert);

            _httpClient = new HttpClient(handler);
            _tellerApiUrl = _config["TellerApiUrl"];
        }

        public async Task<string> GetAsync(string endpoint, string token)
        {
            var byteArray = Encoding.ASCII.GetBytes($"{token}:");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            var response = await _httpClient.GetAsync(_tellerApiUrl + endpoint);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            else
            {
                throw new Exception($"Request failed with status code: {response.StatusCode}");
            }
        }

        public async Task<List<AccountDto>> GetAccountsAsync()
        {
            var test = await GetAsync("accounts", "test_token_lygsiaethecgu");
            var accounts = JsonConvert.DeserializeObject<List<AccountDto>>(test);
            return accounts;
        }
    }
}