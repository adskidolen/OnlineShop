namespace KeepHome.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using KeepHome.Data;
    using KeepHome.Models;
    using KeepHome.Services.Contracts;

    public class OrdersProductsService : IOrdersProductsService
    {
        private readonly KeepHomeContext dbContext;

        public OrdersProductsService(KeepHomeContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<OrderProduct> GetOrdersProductsByUsername(string username)
            => this.dbContext.OrdersProducts.Where(o => o.Order.Customer.UserName == username).ToList();
    }
}