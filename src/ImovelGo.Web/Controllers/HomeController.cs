using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ImovelGo.Web.Models;
using Microsoft.Extensions.Caching.Memory;
using ImovelGo.Web.Services;

namespace ImovelGo.Web.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        private readonly ILogger<HomeController> _logger;
        public static PageViewModel currentPage;
        private IMemoryCache _cache;
        private PropertyService _propertyService;

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache) : base(memoryCache)
        {
            _logger = logger;
            _propertyService = new PropertyService();
        }

        public IActionResult Index()
        {
            currentPage = ActualPage;
            return View(ActualPage.FullPath, _Company);
        }

        public IActionResult About()
        {
            currentPage = ActualPage;
            return View(ActualPage.FullPath, _Company);
        }

        public IActionResult Buy()
        {
            currentPage = ActualPage;
            ViewBag.QueryString = HttpContext.Request.QueryString.ToString();
            ViewBag.Query = HttpContext.Request.Query.ToString();
            return View(ActualPage.FullPath, _Company);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private FilterViewModel CreateFilter()
        {
            return new FilterViewModel
            {
                OffSet = 0,
                PageSize = 10,
                CompanyId = _Company.Id
            };
        }
    }
}
