using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ImovelGo.Web.Helper;
using ImovelGo.Web.Models;
using Newtonsoft.Json;

namespace ImovelGo.Web.Services
{
    public class ReviewServices : BaseService
    {
        public ReviewServices() { }

        public async Task<List<ReviewViewModel>> GetByCompany(int CompanyId)
        {
            var items = await RestHelper<List<ReviewViewModel>, string>.Get($"{BaseUrl}/Review/{CompanyId}");
            return items;
        }
    }
}
