using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KeepHome.Common;
using KeepHome.Services.Contracts;
using KeepHome.Web.Areas.Admin.Controllers.Base;
using KeepHome.Web.Areas.Admin.ViewModels.ChildCategory;
using KeepHome.Web.Areas.Admin.ViewModels.ParentCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KeepHome.Web.Areas.Admin.Controllers
{
    public class ChildCategoriesController:AdminBaseController
    {

        private readonly IChildCategoryService childCategoryService;
        private readonly IParentCategoryService parentCategoryService;
        private readonly IMapper mapper;

        public ChildCategoriesController(IChildCategoryService childCategoryService,
            IParentCategoryService parentCategoryService,
                                         IMapper mapper)
        {
            this.childCategoryService = childCategoryService;
            this.parentCategoryService = parentCategoryService;
            this.mapper = mapper;
        }

        public IActionResult Edit(int id)
        {
            var category = this.childCategoryService.GetChildCategoryById(id);
            var parentCategories = this.parentCategoryService.GetCategories().ToList();

            if (category == null)
            {
                return RedirectToAction(nameof(All));
            }

            var categoryViewModel = mapper.Map<EditChildCategoryViewModel>(category);
            categoryViewModel.ParentCategories = parentCategories;

            return View(categoryViewModel);
        }
        
        [HttpPost]
        public IActionResult Edit(EditChildCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.ParentCategories = this.parentCategoryService.GetCategories().ToList();

                return this.View(model);
            }

            this.childCategoryService.EditChildCategory(model.Id, model.Name, (int)model.ParentCategoryId,model.ImageUrl);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Add()
        {
            var parentCategories = this.parentCategoryService.GetCategories().ToList();

            var addViewModel = new AddChildCategoryViewModel
            {
                ParentCategories = parentCategories
            };

            return View(addViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddChildCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.ParentCategories = this.parentCategoryService.GetCategories().ToList();

                return this.View(model);
            }

            var childCategory = this.childCategoryService
                                    .CreateChildCategory(model.Name, (int)model.ParentId, model.ImageUrl);



            return this.RedirectToAction(nameof(All));
        }

        public IActionResult All()
        {
            var childCategories = this.childCategoryService.GetChildCategories();
            var childCategoriesViewModel = this.mapper.Map<IList<AllChildCategoryViewModel>>(childCategories);

            var parentCategories = this.parentCategoryService.GetCategories();
            var parentCategoriesViewModel = this.mapper.Map<IList<ParentCategoryViewModel>>(parentCategories);

            var childParentViewModel = new AllChildParentCategoryViewModel
            {
                ChildCategoryViewModel = childCategoriesViewModel,
                ParentCategoryViewModels = parentCategoriesViewModel
            };

            return View(childParentViewModel);
        }

        public IActionResult Delete(int id)
        {
            if (!this.childCategoryService.DeleteChildCategory(id))
            {
                this.TempData["error"] = GlobalConstants.CANNOT_DELETE_CATEGORY_IF_ANY_PRODUCTS;
            }

            return RedirectToAction(nameof(All));
        }
    }
}
