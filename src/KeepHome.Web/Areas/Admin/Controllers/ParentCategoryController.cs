using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KeepHome.Common;
using KeepHome.Models;
using KeepHome.Services.Contracts;
using KeepHome.Web.Areas.Admin.Controllers.Base;
using KeepHome.Web.Areas.Admin.ViewModels.ParentCategory;
using Microsoft.AspNetCore.Mvc;

namespace KeepHome.Web.Areas.Admin.Controllers
{
    public class ParentCategoryController:AdminBaseController
    {

        private readonly IParentCategoryService parentCategoryService;
        private readonly IMapper mapper;

        public ParentCategoryController(IParentCategoryService parentCategoryService, IMapper mapper)
        {
            this.parentCategoryService = parentCategoryService;
            this.mapper = mapper;
        }

        public IActionResult Edit(int id)
        {
            ParentCategory category = this.parentCategoryService.GetCategoryById(id);

            if (category == null)
            {
                return RedirectToAction("All");
            }

            var categoryViewModel = mapper.Map<ParentCategoryViewModel>(category);

            return View(categoryViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ParentCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            this.parentCategoryService.EditCategory(model.Id, model.Name);

            return RedirectToAction("All");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ParentCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            this.parentCategoryService.AddMainCategory(model.Name);

            return RedirectToAction("All");
        }

        public IActionResult All()
        {
            var categories = this.parentCategoryService.GetCategories();

            var categoriesViewModel = mapper.Map<IList<ParentCategoryViewModel>>(categories);

            return View(categoriesViewModel);
        }

        public IActionResult Delete(int id)
        {
            if (!this.parentCategoryService.DeleteCategory(id))
            {
                this.TempData["error"] = GlobalConstants.CANNOT_DELETE_CATEGORY_IF_ANY_CHILD_CATEGORY;
            }

            return RedirectToAction(nameof(All));
        }
    }
}