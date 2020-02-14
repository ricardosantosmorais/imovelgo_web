using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hanssens.Net;
using ImovelGo.Web.Models;
using ImovelGo.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace ImovelGo.Web.Controllers
{
    public class AccountController : BaseController<AccountController>
    {
        private readonly ILogger<AccountController> _logger;
        private IMemoryCache _cache;
        private AccountServices _accountService;

        public AccountController(ILogger<AccountController> logger, IMemoryCache memoryCache) : base(memoryCache)
        {
            _logger = logger;
            _accountService = new AccountServices();
        }

        [HttpPost]
        public async Task<JsonResult> Login([FromBody] AccountViewModel viewModel)
        {
            viewModel.CompanyId = _Company.Id;
            try
            {
                var response = await _accountService.Login(viewModel);
                var storage = new LocalStorage();
                storage.Store("accessToken", response.accessToken);
                storage.Persist();
                return Json(new ResponseViewModel<TokenViewModel>
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Success = true,
                    data = new TokenViewModel { Authenticated = true, accessToken = response.accessToken }
                });
            }
            catch (Exception ex)
            {
                return Json(new ErrorViewModel {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<JsonResult> Register([FromBody] AccountViewModel viewModel)
        {
            viewModel.CompanyId = _Company.Id;
            try
            {
                var response = await _accountService.Register(viewModel);
                return Json(new ResponseViewModel<AccountViewModel>
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Success = true,
                    data = response
                });
            }
            catch (Exception ex)
            {
                return Json(new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
