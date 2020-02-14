using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ImovelGo.Web.Models;
using ImovelGo.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImovelGo.Web.Controllers
{
    public abstract class BaseController<T> : Controller where T : BaseController<T>
    {
        public CompanyViewModel _Company;
        private CompanyService _companyService;
        private readonly IMemoryCache _cache;

        public string Router
        {
            get => String.Format("{0}/{1}",
                this.ControllerContext.RouteData.Values["controller"].ToString(),
                this.ControllerContext.RouteData.Values["action"].ToString());
        }

        public PageViewModel ActualPage
        {
            get => _Company.Pages.Where(x => x.Router == this.Router).FirstOrDefault();
        }

        public BaseController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
            _companyService = new CompanyService();
            InitCompany();
        }

        private void InitCompany()
        {
            var companyCacheKey = "imovelgo.com";

            if (_cache.TryGetValue(companyCacheKey, out CompanyViewModel company))
            {
                _Company = company;
            } else
            {
                if (_Company == null)
                {
                    _Company = _companyService.GetTodoAsyncByDomain("imovelgo.com").Result;

                    if (_Company != null)
                    {
                        if (_Company.Pages != null)
                        {
                            foreach (var item in _Company.Pages)
                            {
                                item.FullPath = String.Format("~/Views/{0}{1}", _Company.Template.Name, item.File);

                                foreach (var area in item.Areas)
                                {
                                    area.File = String.Format("~/Views/{0}/Shared/{1}", _Company.Template.Name, area.File);
                                }
                            }
                        }
                    }

                    _cache.Set(companyCacheKey, _Company, new MemoryCacheEntryOptions()
                              .SetAbsoluteExpiration(TimeSpan.FromMinutes(15)));
                }
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //How do I get the current controller? 
            //How do I get the current method being called? 
            //How can I pass in additional parameters?
            //How can I get the user? 

            //logger.LogWarning("Loaded BaseController");

            //if (_Company == null)
            //{
            //    _Company = CompanyService.GetTodoAsyncByDomain("imovelgo.com").Result;

            //    if (_Company != null)
            //    {
            //        if (_Company.Pages != null)
            //        {
            //            foreach (var item in _Company.Pages)
            //            {
            //                item.FullPath = String.Format("~/Views/{0}{1}", _Company.Template.Name, item.File);

            //                foreach (var area in item.Areas)
            //                {
            //                    area.File = String.Format("~/Views/{0}/Shared/{1}", _Company.Template.Name, area.File);
            //                }
            //            }
            //        }
            //    }
            //}
            
            base.OnActionExecuting(context);
        }
    }
}
