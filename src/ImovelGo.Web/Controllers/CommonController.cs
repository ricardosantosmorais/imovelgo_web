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
    public class CommonController : BaseController<CommonController>
    {
        private readonly ILogger<ComponentController> _logger;
        private IMemoryCache _cache;
        private CityService _cityService;

        public CommonController(ILogger<ComponentController> logger, IMemoryCache memoryCache) : base(memoryCache)
        {
            _logger = logger;
            _cityService = new CityService();
        }

        public async Task<JsonResult> LoadAllCities()
        {
            var storage = new LocalStorage();
            var token = storage.Get("accessToken");
            return Json(await _cityService.GetAll());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
