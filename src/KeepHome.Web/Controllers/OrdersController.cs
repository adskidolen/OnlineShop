namespace KeepHome.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using KeepHome.Services.Contracts;
    using KeepHome.Web.Controllers.Base;
    using KeepHome.Web.ViewModels.Address;
    using KeepHome.Web.ViewModels.Orders;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class OrdersController : BaseController
    {
        private const string ERROR_MESSAGE = "Моля добавете продукти в кошницата!";
        private const int DELIVERY_PRICE = 20;

        private readonly IAddressesService adressesService;
        private readonly IUserService userService;
        private readonly IOrderService orderService;
        private readonly IShoppingBagService shoppingBagService;
        private readonly IMapper mapper;
        private readonly IOrdersProductsService ordersProductsService;

        public OrdersController(IAddressesService adressesService, IUserService userService, IOrderService orderService,
            IShoppingBagService shoppingBagService, IMapper mapper, IOrdersProductsService ordersProductsService)
        {
            this.adressesService = adressesService;
            this.userService = userService;
            this.orderService = orderService;
            this.shoppingBagService = shoppingBagService;
            this.mapper = mapper;
            this.ordersProductsService = ordersProductsService;
        }

        public IActionResult Checkout()
        {
            if (!this.shoppingBagService.AnyProducts(this.User.Identity.Name))
            {
                this.TempData["error"] = ERROR_MESSAGE;
                return RedirectToAction("Index", "Home");
            }
            
            var address = this.adressesService.GetAllAddressByUser(this.User.Identity.Name);

            var viewModel = Mapper.Map<IList<AddressInputModel>>(address);

            var user = this.userService.GetUserByUsername(this.User.Identity.Name);
            var fullName = $"{user.FirstName} {user.LastName}";


            var createOrderViewModel = new OrderInputModel
            {
                Addresses = viewModel.ToList(),
                FullName = fullName,
                PhoneNumber = user.PhoneNumber
            };

            return this.View(createOrderViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(OrderInputModel model)
        {
            if (!this.shoppingBagService.AnyProducts(this.User.Identity.Name))
            {
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Checkout));
            }

            var order = this.orderService.GetOrderByUsername(this.User.Identity.Name);
            if (order == null)
            {
                order = this.orderService.CreateOrder(this.User.Identity.Name);
            }
            
            this.orderService.SetOrder(order, model.FullName, model.PhoneNumber, model.DeliveryAddressId.Value, DELIVERY_PRICE);

            return this.RedirectToAction(nameof(Confirm));
        }

        public IActionResult Confirm()
        {
            if (!this.shoppingBagService.AnyProducts(this.User.Identity.Name))
            {
                this.TempData["error"] = ERROR_MESSAGE;
                return RedirectToAction("Index", "Home");
            }

            var order = this.orderService.GetOrderByUsername(this.User.Identity.Name);
            var orderViewModel = new ConfirmOrderViewModel()
            {
                TotalPrice = order.TotalPrice,
                Recipient = order.Recipient,
                PhoneNumber = order.RecipientPhoneNumber,
                DeliveryAddressCityName = order.DeliveryAddress.Town,
                DeliveryAddressStreet = order.DeliveryAddress.Street,
                DeliveryAddressDescription = order.DeliveryAddress.OtherDetails,
                DeliveryPrice = DELIVERY_PRICE
            };

            return this.View(orderViewModel);
        }

        public IActionResult Finished(int id)
        {
            if (!this.shoppingBagService.AnyProducts(this.User.Identity.Name))
            {
                this.TempData["error"] = ERROR_MESSAGE;
                return RedirectToAction("Index", "Home");
            }

            var order = this.orderService.GetOrderByUsername(this.User.Identity.Name);
            this.orderService.CompleteOrder(this.User.Identity.Name);

            return this.View();
        }

        [Authorize]
        public IActionResult MyOrders()
        {

            var orders = this.ordersProductsService.GetOrdersProductsByUsername(this.User.Identity.Name)
                                                   .Select(x => new OrderViewModel()
                                                   {
                                                       Id = x.OrderId,
                                                       Quantity = x.ProductQuantity,
                                                       TotalPrice = x.Order.TotalPrice,
                                                       ProductName = x.ProductName,
                                                       ProductPrice = x.Product.Price,
                                                       ProductId = x.ProductId
                                                   });


            var viewModel = new AllOrdersViewModel()
            {
                Orders = orders
            };

            return this.View(viewModel);
        }
    }
}