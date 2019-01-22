namespace KeepHome.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using KeepHome.Data;
    using KeepHome.Models;
    using KeepHome.Models.Enums;
    using KeepHome.Services.Contracts;

    public class OrderService : IOrderService
    {
        private readonly KeepHomeContext dbContext;
        private readonly IUserService userService;
        private readonly IShoppingBagService shoppingBagService;

        public OrderService(KeepHomeContext dbContext, IUserService userService, IShoppingBagService shoppingBagService)
        {
            this.dbContext = dbContext;
            this.userService = userService;
            this.shoppingBagService = shoppingBagService;
        }

        public Order CreateOrder(string username)
        {
            var user = this.userService.GetUserByUsername(username);

            var order = new Order
            {
                Customer = user
            };

            this.dbContext.Orders.Add(order);
            this.dbContext.SaveChanges();

            return order;
        }

        public Order GetOrderById(int id)
            => this.dbContext.Orders.FirstOrDefault(o => o.Id == id);

        public Order GetOrderByUsername(string username)
            => this.dbContext.Orders.FirstOrDefault(o => o.Customer.UserName == username);

        public IEnumerable<Order> GetUserOrders(string userName)
            => this.dbContext.Orders.Where(c => c.Customer.UserName == userName).ToList();

        public void SetOrderDetails(Order order, string fullName, string phoneNumber, PaymentType paymentType,
            int deliveryAddressId, decimal deliveryPrice)
        {
            order.Recipient = fullName;
            order.RecipientPhoneNumber = phoneNumber;
            order.PaymentType = paymentType;
            order.DeliveryAddressId = deliveryAddressId;
            order.DeliveryPrice = deliveryPrice;

            this.dbContext.Update(order);
            this.dbContext.SaveChanges();
        }

        public void CompleteOrder(string username)
        {
            var order = this.dbContext.Orders.FirstOrDefault(x => x.Customer.UserName == username);

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

            order.OrderProducts = orderProducts;
            order.TotalPrice = order.OrderProducts.Sum(x => x.ProductQuantity * x.ProductPrice);

            this.dbContext.SaveChanges();
        }
    }
}