namespace KeepHome.Web.Controllers
{
    using System.Collections.Generic;

    using AutoMapper;

    using KeepHome.Common;
    using KeepHome.Services.Contracts;
    using KeepHome.Web.Controllers.Base;
    using KeepHome.Web.ViewModels;
    using KeepHome.Web.ViewModels.Products;

    using Microsoft.AspNetCore.Mvc;

    using X.PagedList;

    public class ProductsController : BaseController
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        public IActionResult All(int id, int? pageNumber)
        {
            var nextPage = pageNumber ?? GlobalConstants.NextPageValue;

            var products = this.productService.GetProductsByCategory(id);

            var mappedProducts = this.mapper.Map<IEnumerable<ProductViewModel>>(products);

            var pagedProducts = mappedProducts.ToPagedList(nextPage, GlobalConstants.MaxProductsOnPage);

            var productsViewModel = new AllProductsViewModel
            {
                Products = pagedProducts
            };

            return this.View(productsViewModel);
        }

        public IActionResult Details(int id)
        {
            var product = this.productService.GetProduct(id);

            if (product == null)
            {
                return this.View("Error", new ErrorViewModel { RequestId = "Invalid product id!" });
            }

            var productViewModel = this.mapper.Map<ProductDetailsViewModel>(product);

            return this.View(productViewModel);
        }
    }
}