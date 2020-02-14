using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ImovelGo.Web.Helper;
using ImovelGo.Web.Models;
using Newtonsoft.Json;

namespace ImovelGo.Web.Services
{
    public class CityService : BaseService
    {
        public CityService() { }

        public async Task<List<CityViewModel>> GetAll()
        {
            var items = await RestHelper<List<CityViewModel>, string>.Get($"{BaseUrl}/City");
            return items;
        }
    }
}
