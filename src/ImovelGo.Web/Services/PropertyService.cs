using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImovelGo.Web.Helper;
using ImovelGo.Web.Models;
using Newtonsoft.Json;

namespace ImovelGo.Web.Services
{
    public class PropertyService : BaseService
    {
        public PropertyService()
        {
        }

        public async Task<List<PropertyViewModel>> GetFeaturedPropertiesByCompany(int CompanyId)
        {
            var items = await RestHelper<List<PropertyViewModel>, string>.Get($"{BaseUrl}/Property/GetFeatured/{CompanyId}");
            return items;
        }

        public async Task<List<PropertyViewModel>> GetPopularPropertiesByCompany(int CompanyId)
        {
            var items = await RestHelper<List<PropertyViewModel>, string>.Get($"{BaseUrl}/Property/GetPopular/{CompanyId}");
            return items;
        }

        public async Task<PagedResultsModel<PropertyViewModel>> Search(FilterViewModel filter)
        {
            var items = await RestHelper<PagedResultsModel<PropertyViewModel>, FilterViewModel>.PostRequest($"{BaseUrl}/Property/Search", filter);
            return items;
        }

    }
}
