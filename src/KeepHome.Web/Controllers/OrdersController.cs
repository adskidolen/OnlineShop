namespace KeepHome.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using KeepHome.Services.Contracts;
    using KeepHome.Web.Controllers.Base;
    using KeepHome.Web.ViewModels.Address;
    using KeepHome.Web.ViewModels.Orders;

    using Microsoft.AspNetCore.Mvc;

    public class OrdersController : BaseController
    {
        private const int DeliveryPrice = 20;

        private readonly IOrderService orderService;
        private readonly IShoppingBagService shoppingBagService;
        private readonly IAddressesService addressesService;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public OrdersController(IOrderService orderService, IShoppingBagService shoppingBagService, IAddressesService addressesService,
            IUserService userService, IMapper mapper)
        {
            this.orderService = orderService;
            this.shoppingBagService = shoppingBagService;
            this.addressesService = addressesService;
            this.userService = userService;
            this.mapper = mapper;
        }

        public IActionResult Checkout()
        {
            if (!this.shoppingBagService.AnyProducts(this.User.Identity.Name))
            {
                return this.RedirectToAction("Index", "Home");
            }

            var order = this.orderService.CreateOrder(this.User.Identity.Name);
            var address = this.addressesService.GetAllAddressByUser(this.User.Identity.Name);

            var addressesViewModel = this.mapper.Map<IEnumerable<AddressInputModel>>(address);

            var user = this.userService.GetUserByUsername(this.User.Identity.Name);

            var orderViewModel = new CheckoutInputModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber
            };

            return this.View(orderViewModel);
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                var addresses = this.addressesService.GetAllAddressByUser(this.User.Identity.Name);
                var addressesViewModel = this.mapper.Map<IEnumerable<AddressInputModel>>(addresses).ToList();

                model.Addresses = addressesViewModel;

                return this.View(model);
            }

            var order = this.orderService.GetOrderByUsername(this.User.Identity.Name);
            if (order == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            var fullName = $"{model.FirstName} {model.LastName}";

            this.orderService.SetOrderDetails(order, fullName, model.PhoneNumber, model.PaymentType, model.DeliveryAddressId.Value, DeliveryPrice);

            return this.RedirectToAction(nameof(Finished));
        }

        public IActionResult Finished() => this.View();
    }
}