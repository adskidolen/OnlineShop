namespace KeepHome.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using KeepHome.Services.Contracts;
    using KeepHome.Web.Controllers.Base;
    using KeepHome.Web.ViewModels;
    using KeepHome.Web.ViewModels.ParentCategories;

    using Microsoft.AspNetCore.Mvc;

    public class ParentCategoriesController : BaseController
    {
        private readonly IParentCategoryService parentCategoryService;
        private readonly IMapper mapper;

        public ParentCategoriesController(IParentCategoryService parentCategoryService, IMapper mapper)
        {
            this.parentCategoryService = parentCategoryService;
            this.mapper = mapper;
        }

        public IActionResult Details(int id)
        {
            var category = this.parentCategoryService.GetCategoryById(id);

            if (category == null)
            {
                return this.View(new ErrorViewModel { RequestId = "Invalid category!" });
            }

            var viewModel = this.mapper.Map<ParentCategoryDetailsViewModel>(category);

            return View(viewModel);
        }

        public IActionResult All()
        {
            var categories = this.parentCategoryService.GetCategories();

            var categoriesViewModels = this.mapper.Map<IEnumerable<ParentCategoryViewModel>>(categories);

            var viewModel = new AllParentCategoriesViewModel
            {
                Categories = categoriesViewModels
            };

            return this.View(viewModel);
        }
    }
}