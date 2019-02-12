namespace KeepHome.Web.Components
{
    using KeepHome.Services.Contracts;
    using KeepHome.Web.ViewModels.ShoppingBag;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using System.Linq;

    public class FullShoppingBagDetailsComponent : ViewComponent
    {
        private readonly IShoppingBagService shoppingBagService;

        public FullShoppingBagDetailsComponent(IShoppingBagService shoppingBagService)
        {
            this.shoppingBagService = shoppingBagService;
        }

        [Authorize]
        public IViewComponentResult Invoke()
        {
            var shoppingBagProducts = this.shoppingBagService.GetAllShoppingBagProducts(this.User.Identity.Name);

            var shoppingBagViewModel = shoppingBagProducts.Select(x => new ShoppingBagProductViewModel()
            {
                Id = x.ProductId,
                ImageUrl = x.Product.ImageUrl,
                Name = x.Product.Name,
                Price = x.Product.Price,
                Quantity = x.Quantity,
                TotalPrice = x.Quantity * x.Product.Price
            }).ToList();

            return this.View(shoppingBagViewModel);
        }
    }
}