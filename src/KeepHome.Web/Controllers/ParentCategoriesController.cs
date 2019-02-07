namespace KeepHome.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using KeepHome.Services.Contracts;
    using KeepHome.Web.Controllers.Base;
    using KeepHome.Web.ViewModels;
    using KeepHome.Web.ViewModels.ChildCategories;
    using KeepHome.Web.ViewModels.ParentCategories;

    using Microsoft.AspNetCore.Mvc;

    public class ParentCategoriesController : BaseController
    {
        private readonly IParentCategoryService parentCategoryService;
        private readonly IChildCategoryService childCategoryService;
        private readonly IMapper mapper;

        public ParentCategoriesController(IParentCategoryService parentCategoryService, IChildCategoryService childCategoryService,
            IMapper mapper)
        {
            this.parentCategoryService = parentCategoryService;
            this.childCategoryService = childCategoryService;
            this.mapper = mapper;
        }

        public IActionResult Details(int id)
        {
            var category = this.parentCategoryService.GetCategoryById(id);

            if (category == null)
            {
                return this.View(new ErrorViewModel { RequestId = "Invalid category!" });
            }

            var childCategories = category.ChildCategories;

            var childCategoriesViewModels = this.mapper.Map<IEnumerable<ChildCategoryDetailsViewModel>>(childCategories);

            var viewModel = new AllParentCategoriesDetailsViewModel
            {
                Name = category.Name,
                ChildCategories = childCategoriesViewModels
            };

            return this.View(viewModel);
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