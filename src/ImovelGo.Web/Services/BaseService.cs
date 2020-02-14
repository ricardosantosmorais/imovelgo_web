using System;
using System.Net.Http;

namespace ImovelGo.Web.Services
{
    public class BaseService
    {
        public const string BaseUrl = "https://localhost:5010/api";
        public HttpClient _client;

        public BaseService()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            _client = new HttpClient(clientHandler);
        }
    }
}
