using System.Linq;
using AutoMapper;
using KeepHome.Models;
using KeepHome.Services.Contracts;
using KeepHome.Web.Areas.Admin.ViewModels.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KeepHome.Web.Areas.Admin.Controllers
{
    using KeepHome.Web.Areas.Admin.Controllers.Base;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : AdminBaseController
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;


        public ProductsController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        public IActionResult All()
        {
            var products = this.productService.GetAllProducts();

            return View(products);
        }
        
        public IActionResult CreateProduct()
        {
            var childCategories = this.productService.GetChildCategories();

            var categories = childCategories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            var model = new CreateProductViewModel { ChildCategories = categories };

            return View(model);
        }
        
        [HttpPost]
        public IActionResult CreateProduct(CreateProductViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            var product = mapper.Map<Product>(model);

            this.productService.AddProduct(product);

            return RedirectToAction(nameof(All));

        }
        
        public IActionResult Edit(int id)
        {
            var product = this.productService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            var childCategories = this.productService.GetChildCategories();

            ViewData["ChildCategoryId"] = childCategories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            var model = mapper.Map<EditProductViewModel>(product);

            return View(model);
        }
        
        [HttpPost]
        public IActionResult Edit(EditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //TODO:Check
                var childCategories = this.productService.GetChildCategories();

                ViewData["ChildCategoryId"] = childCategories.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();

                return View(model);
            }

            var product = mapper.Map<Product>(model);

            this.productService.EditProduct(product);

            return RedirectToAction(nameof(All));
        }
        public IActionResult Delete(int id)
        {
            this.productService.RemoveProduct(id);
            return this.RedirectToAction(nameof(All));
        }
    }
}