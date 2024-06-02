using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace api.Services
{
    public class TellerService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
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
        }

        public async Task<string> TestRequestAsync()
        {
            var byteArray = Encoding.ASCII.GetBytes("test_token_lygsiaethecgu:");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            var response = await _httpClient.GetAsync("https://api.teller.io/accounts");
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

        
    }
}