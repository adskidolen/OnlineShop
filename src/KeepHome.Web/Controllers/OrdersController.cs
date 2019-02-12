namespace KeepHome.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using KeepHome.Data;
    using KeepHome.Models;
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
        private readonly IRepository<OrderProduct> orderProductRepository;

        public OrdersController(IAddressesService adressesService, IUserService userService, IOrderService orderService,
            IShoppingBagService shoppingBagService, IMapper mapper, IRepository<OrderProduct> orderProductRepository)
        {
            this.adressesService = adressesService;
            this.userService = userService;
            this.orderService = orderService;
            this.shoppingBagService = shoppingBagService;
            this.mapper = mapper;
            this.orderProductRepository = orderProductRepository;
        }

        public IActionResult Checkout()
        {
            if (!this.shoppingBagService.AnyProducts(this.User.Identity.Name))
            {
                this.TempData["error"] = ERROR_MESSAGE;
                return RedirectToAction("Index", "Home");
            }

            var order = this.orderService.CreateOrder(this.User.Identity.Name);
            var address = this.adressesService.GetAllAddressByUser(this.User.Identity.Name);

            var viewModel = this.mapper.Map<IList<AddressInputModel>>(address);

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
            if (this.ModelState.IsValid)
            {
                var order = this.orderService.GetOrderByUsername(this.User.Identity.Name);
                if (order == null)
                {
                    return this.RedirectToAction("Index", "ShoppingBag");
                }

                this.orderService.SetOrder(order, model.FullName, model.PhoneNumber, model.DeliveryAddressId.Value, DELIVERY_PRICE, model.PaymentType);

                return this.RedirectToAction(nameof(Confirm));
            }
            else
            {
                var addresses = this.adressesService.GetAllAddressByUser(this.User.Identity.Name);
                var addressesViewModel = this.mapper.Map<IList<AddressInputModel>>(addresses);

                model.Addresses = addressesViewModel.ToList();
                return this.RedirectToAction(nameof(Confirm));
            }
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
                DeliveryAddressTown = order.DeliveryAddress.Town,
                DeliveryAddressStreet = order.DeliveryAddress.Street,
                DeliveryAddressCountry = order.DeliveryAddress.Country,
                DeliveryAddressOtherDetails = order.DeliveryAddress.OtherDetails,
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

            var orders = this.orderProductRepository.All().Where(x => x.Order.Customer.UserName == this.User.Identity.Name)
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