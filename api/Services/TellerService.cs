using System.Security.Cryptography.X509Certificates;
using System.Text;
using api.DTOs;
using api.Models;
using AutoMapper;
using Newtonsoft.Json;

namespace api.Services
{
    public class TellerService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly string _tellerApiUrl;
        public TellerService(IConfiguration config, IMapper mapper)
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
            _mapper = mapper;
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

        public async Task<List<Account>> GetAccountsAsync()
        {
            var response = await GetAsync("accounts", "test_token_lygsiaethecgu");
            var accountDtos = JsonConvert.DeserializeObject<List<AccountDto>>(response);
            var accounts = _mapper.Map<List<Account>>(accountDtos);
            return accounts;
        }

        public async Task<AccountBalanceUpdateDto> GetAccountBalanceAsync(string accountId)
        {
            var response = await GetAsync($"accounts/{accountId}/balances", "test_token_lygsiaethecgu");
            var accountBalanceUpdateDto = JsonConvert.DeserializeObject<AccountBalanceUpdateDto>(response);
            return accountBalanceUpdateDto;
        }
    }
}