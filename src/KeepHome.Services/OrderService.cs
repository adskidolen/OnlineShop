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
        private readonly IRepository<Order> orderRepository;

        private readonly KeepHomeContext dbContext;


        public OrderService(IUserService userService, IShoppingBagService shoppingBagService,
            IRepository<Order> orderRepository, KeepHomeContext db)
        {
            this.userService = userService;
            this.shoppingBagService = shoppingBagService;
            this.orderRepository = orderRepository;
            this.dbContext = db;
        }


        public Order CreateOrder(string username)
        {
            var user = this.userService.GetUserByUsername(username);

            var order = new Order()
            {
                Customer = user
            };

            this.dbContext.Orders.Add(order);
            this.orderRepository.SaveChanges();
            return order;
        }

        public Order GetOrderById(int id)
        {
            return this.orderRepository.All().FirstOrDefault(x => x.Id == id);
        }

        public Order GetOrderByUsername(string username)
        {
            var user = this.userService.GetUserByUsername(username);
            var order = this.dbContext.Orders.Include(x => x.DeliveryAddress).Include(x => x.OrderProducts)
                .LastOrDefault(x => x.Customer.UserName == username);

            return order;
        }

        public IEnumerable<Order> GetUserOrders(string userName)
        {
            var order = this.orderRepository.All().Where(x => x.Customer.UserName == userName).ToList();

            return order;
        }

        public void SetOrder(Order order, string fullName, string phoneNumber, int deliveryAddressId, decimal deliveryPrice, PaymentType paymentType)
        {
            order.Recipient = fullName;
            order.RecipientPhoneNumber = phoneNumber;
            order.DeliveryAddressId = deliveryAddressId;
            order.DeliveryPrice = deliveryPrice;
            order.PaymentType = paymentType;

            this.dbContext.Orders.Update(order);
            this.orderRepository.SaveChanges();
        }

        public void CompleteOrder(string username)
        {
            var order = this.orderRepository.All().LastOrDefault(x => x.Customer.UserName == username);

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

            this.orderRepository.SaveChanges();
        }

        public bool SetOrderStatusByInvoice(string invoiceNumber, string status)
        {
            var isOrderStatus = Enum.TryParse(typeof(PaymentStatus), status, true, out object paymentStatus);
            var order = this.dbContext.Orders.FirstOrDefault(x => x.InvoiceNumber == invoiceNumber);

            if (order == null || !isOrderStatus)
            {
                return false;
            }

            order.PaymentStatus = (PaymentStatus)paymentStatus;
            this.dbContext.SaveChanges();
            return true;
        }

        public void SetEasyPayNumber(Order order, string easyPayNumber)
        {
            order.EasyPayNumber = easyPayNumber;
            this.dbContext.SaveChanges();
        }
    }
}