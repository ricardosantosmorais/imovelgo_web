using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ImovelGo.Web.Helper;
using ImovelGo.Web.Models;
using Newtonsoft.Json;

namespace ImovelGo.Web.Services
{
    public class PostServices : BaseService
    {
        public PostServices() { }

        public async Task<List<PostViewModel>> GetPopularByCompany(int CompanyId)
        {
            var items = await RestHelper<List<PostViewModel>, string>.Get($"{BaseUrl}/Post/GetPopular/{CompanyId}");
            return items;
        }
    }
}
