namespace KeepHome.Services.Contracts
{
    using KeepHome.Models;

    using System.Collections.Generic;

    public interface IOrdersProductsService
    {
        IEnumerable<OrderProduct> GetOrdersProductsByUsername(string username);
    }
}