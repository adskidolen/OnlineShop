using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeepHome.Data;
using KeepHome.Models;
using KeepHome.Models.Enums;
using KeepHome.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace KeepHome.Services
{
    public class OrderService:IOrderService
    {

        private readonly IUserService userService;
        private readonly IShoppingBagService shoppingCartService;
        private readonly KeepHomeContext db;

        public OrderService(IUserService userService, IShoppingBagService shoppingCartService, KeepHomeContext db)
        {
            this.userService = userService;
            this.shoppingCartService = shoppingCartService;
            this.db = db;
        }

        public Order CreateOrder(string username)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetUserOrders(string userName)
        {
            throw new NotImplementedException();
        }

        public void SetOrderDetails(Order order, string fullName, string phoneNumber, PaymentType paymentType, int deliveryAddressId,
            decimal deliveryPrice)
        {
            throw new NotImplementedException();
        }

        public void CompleteOrder(string username)
        {
            throw new NotImplementedException();
        }
    }
}
