namespace KeepHome.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using KeepHome.Data;
    using KeepHome.Models;
    using KeepHome.Models.Enums;
    using KeepHome.Services.Contracts;

    using Microsoft.EntityFrameworkCore;

    public class OrderService : IOrderService
    {
        private readonly IUserService userService;
        private readonly IShoppingBagService shoppingBagService;
        private readonly KeepHomeContext dbContext;


        public OrderService(IUserService userService, IShoppingBagService shoppingBagService,
            KeepHomeContext dbContext)
        {
            this.userService = userService;
            this.shoppingBagService = shoppingBagService;
            this.dbContext = dbContext;
        }


        public Order CreateOrder(string username)
        {
            var user = this.userService.GetUserByUsername(username);

            var order = new Order()
            {
                Customer = user
            };

            this.dbContext.Orders.Add(order);
            this.dbContext.SaveChanges();
            return order;
        }

        public Order GetOrderById(int id)
        {
            return this.dbContext.Orders.FirstOrDefault(x => x.Id == id);
        }

        public Order GetOrderByUsername(string username)
        {
            var user = this.userService.GetUserByUsername(username);
            var order = this.dbContext.Orders.Include(x => x.DeliveryAddress)
                                             .Include(x => x.OrderProducts)
                                             .LastOrDefault(x => x.Customer.UserName == username);

            return order;
        }

        public IEnumerable<Order> GetUserOrders(string userName)
        {
            var order = this.dbContext.Orders.Where(x => x.Customer.UserName == userName).ToList();

            return order;
        }

        public void SetOrder(Order order, string fullName, string phoneNumber, int deliveryAddressId)
        {
            order.Recipient = fullName;
            order.RecipientPhoneNumber = phoneNumber;
            order.DeliveryAddressId = deliveryAddressId;

            this.dbContext.Orders.Update(order);
            this.dbContext.SaveChanges();
        }

        public void CompleteOrder(string username)
        {
            var order = this.dbContext.Orders.LastOrDefault(x => x.Customer.UserName == username);

            if (order == null)
            {
                return;
            }


            var shoppingBagProducts = this.shoppingBagService.GetAllShoppingBagProducts(username).ToList();
            if (shoppingBagProducts.Count == 0)
            {
                return;
            }

            var orderProducts = new List<OrderProduct>();

            foreach (var product in shoppingBagProducts)
            {
                var orderProduct = new OrderProduct
                {
                    Order = order,
                    Product = product.Product,
                    ProductQuantity = product.Quantity,
                    ProductName = product.Product.Name,
                    ProductPrice = product.Product.Price,
                    Date = DateTime.Now
                };
                orderProducts.Add(orderProduct);
            }

            this.shoppingBagService.DeleteAllProduct(username);

            order.CreatedOn = DateTime.Now;
            order.OrderProducts = orderProducts;
            order.TotalPrice = order.OrderProducts.Sum(x => x.ProductQuantity * x.ProductPrice);

            this.dbContext.SaveChanges();
        }
    }
}