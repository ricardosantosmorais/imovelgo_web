using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ImovelGo.Web.Models;
using ImovelGo.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.Extensions;

namespace ImovelGo.Web.Controllers
{
    public class ComponentController : BaseController<ComponentController>
    {
        private readonly ILogger<ComponentController> _logger;
        private IMemoryCache _cache;
        private PropertyService _propertyService;
        private ReviewServices _reviewService;
        private PostServices _postServices;

        public ComponentController(ILogger<ComponentController> logger, IMemoryCache memoryCache) : base(memoryCache)
        {
            _logger = logger;
            _propertyService = new PropertyService();
            _reviewService = new ReviewServices();
            _postServices = new PostServices();
        }

        public async Task<IActionResult> LoadSlideFeature(string view)
        {
            var viewModel = await _propertyService.GetFeaturedPropertiesByCompany(_Company.Id);
            return PartialView(view, viewModel);
        }

        public IActionResult LoadLocationByRegion(string view)
        {
            return PartialView(view);
        }

        public IActionResult LoadBannerPlaceHome(string view)
        {
            return PartialView(view);
        }

        public async Task<IActionResult> LoadTestimonials(string view)
        {
            var viewModel = await _reviewService.GetByCompany(_Company.Id);
            return PartialView(view, viewModel);
        }

        public IActionResult LoadAgents(string view)
        {
            return PartialView(view, _Company);
        }

        public IActionResult LoadStepHowUser(string view)
        {
            return PartialView(view);
        }

        public async Task<IActionResult> LoadSmartTestimonials(string view)
        {
            var viewModel = await _reviewService.GetByCompany(_Company.Id);
            return PartialView(view, viewModel);
        }

        public async Task<IActionResult> LoadPopularProperties(string view)
        {
            var viewModel = await _propertyService.GetPopularPropertiesByCompany(_Company.Id);
            return PartialView(view, viewModel);
        }

        public async Task<IActionResult> LoadSmartTestimonialsBig(string view)
        {
            var viewModel = await _reviewService.GetByCompany(_Company.Id);
            return PartialView(view, viewModel);
        }

        public async Task<IActionResult> LoadPostsBlog(string view)
        {
            var viewModel = await _postServices.GetPopularByCompany(_Company.Id);
            return PartialView(view, viewModel);
        }

        public IActionResult LoadTopFullBannerModel1(string view)
        {
            return PartialView(view, _Company);
        }

        public async Task<IActionResult> LoadSearchResult(string view)
        {
            var filters = new FilterViewModel(HttpContext.Request.GetDisplayUrl());
            filters.CompanyId = _Company.Id;
            var viewModel = await _propertyService.Search(filters);
            return PartialView(view, viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
