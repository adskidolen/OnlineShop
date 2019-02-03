using System.Linq;
using KeepHome.Services.Contracts;
using KeepHome.Web.Controllers.Base;
using KeepHome.Web.ViewModels.ShoppingBag;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KeepHome.Web.Controllers
{
    public class ShoppingBagController:BaseController
    {
        private readonly IShoppingBagService shoppingBagService;


        public ShoppingBagController(IShoppingBagService shoppingBagService)
        {
            this.shoppingBagService = shoppingBagService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var shoppingBagProducts = this.shoppingBagService.GetAllShoppingBagProducts(this.User.Identity.Name);

            var viewModel = shoppingBagProducts.Select(x => new ShoppingBagProductViewModel()
            {
                Id = x.ProductId,
                Name = x.Product.Name,
                Price = x.Product.Price,
                Quantity = x.Quantity,
                TotalPrice = x.Quantity * x.Product.Price,
                ImageUrl = x.Product.ImageUrl
            });


            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Add(int id)
        {
            this.shoppingBagService.AddProduct(id, this.User.Identity.Name);
            return this.RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            this.shoppingBagService.DeleteProduct(id, this.User.Identity.Name);
            return this.RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id, int quantity)
        {
            this.shoppingBagService.EditProduct(id, this.User.Identity.Name, quantity);
            return this.RedirectToAction(nameof(Index));
        }
    }
}
