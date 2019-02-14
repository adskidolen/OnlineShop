using KeepHome.Data;
using Korzh.EasyQuery.Linq;

namespace KeepHome.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using AutoMapper;

    using KeepHome.Services.Contracts;
    using KeepHome.Web.Controllers.Base;
    using KeepHome.Web.ViewModels;
    using KeepHome.Web.ViewModels.ParentCategories;
    using KeepHome.Web.ViewModels.Products;
    using KeepHome.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private const int FeaturesProductsCount = 10;
        private const int RandomCategoriesCount = 3;

        private readonly IProductService productService;
        private readonly IParentCategoryService parentCategoryService;
        private readonly IMapper mapper;
        private readonly KeepHomeContext db;

        public HomeController(IProductService productService, IParentCategoryService parentCategoryService, IMapper mapper, KeepHomeContext db)
        {
            this.productService = productService;
            this.parentCategoryService = parentCategoryService;
            this.mapper = mapper;
            this.db = db;
        }

        public IActionResult Index()
        {
            var products = this.productService.GetAllProducts()
                               .OrderByDescending(d => d.AddedOn)
                               .Take(FeaturesProductsCount)
                               .ToList();

            var categories = this.parentCategoryService.GetCategories()
                                                       .Take(RandomCategoriesCount)
                                                       .ToList();

            var mappedProducts = this.mapper.Map<IEnumerable<LastAddedProductViewModel>>(products);
            var mappedCategories = this.mapper.Map<IEnumerable<RandomParentCategoryViewModel>>(categories);

            var indexViewModel = new IndexViewModel
            {
                LastAddedProducts = mappedProducts,
                RandomCategories = mappedCategories
            };

            return View(indexViewModel);
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