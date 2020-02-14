using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ImovelGo.Web.Helper;
using ImovelGo.Web.Models;
using Newtonsoft.Json;

namespace ImovelGo.Web.Services
{
    public class AccountServices : BaseService
    {
        public AccountServices() { }

        public async Task<AccountViewModel> Register(AccountViewModel account)
        {
            return await RestHelper<AccountViewModel, AccountViewModel>.PostRequest($"{BaseUrl}/Account/Register", account);
        }

        public async Task<AccountViewModel> Login(AccountViewModel account)
        {
            return await RestHelper<AccountViewModel, AccountViewModel>.PostRequest($"{BaseUrl}/Account/Login", account);
        }
    }
}
