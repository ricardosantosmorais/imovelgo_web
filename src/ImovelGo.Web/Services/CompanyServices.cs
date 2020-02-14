using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ImovelGo.Web.Models;
using Newtonsoft.Json;

namespace ImovelGo.Web.Services
{
    public class CompanyService : BaseService
    {
        public CompanyService() { }

        public async Task<CompanyViewModel> GetTodoAsyncByDomain(string domain)
        {
            var endpoint = $"{BaseUrl}/Company/{domain}";
            var httpResponse = await _client.GetAsync(endpoint);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var todoItem = JsonConvert.DeserializeObject<CompanyViewModel>(content);

            return todoItem;
        }
    }
}
