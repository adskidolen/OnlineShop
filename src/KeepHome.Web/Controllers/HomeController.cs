namespace KeepHome.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using KeepHome.Web.ViewModels;
    using KeepHome.Web.Controllers.Base;
    using KeepHome.Services.Contracts;

    using AutoMapper;
    using KeepHome.Web.ViewModels.Home;
    using KeepHome.Web.ViewModels.ParentCategories;

    public class HomeController : BaseController
    {
        private readonly IParentCategoryService parentCategoryService;
        private readonly IMapper mapper;

        public HomeController(IParentCategoryService parentCategoryService, IMapper mapper)
        {
            this.parentCategoryService = parentCategoryService;
            this.mapper = mapper;
        }

        public IActionResult Index(LayoutViewModel model)
        {
            var categories = this.parentCategoryService.GetCategories();
            var categoryViewModels = this.mapper.Map<IList<ParentCategoryPartialViewModel>>(categories);

            model.ParentCategories = categoryViewModels;

            return View(model);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
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
    }
}