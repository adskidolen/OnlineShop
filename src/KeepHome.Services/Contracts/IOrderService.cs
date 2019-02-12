namespace KeepHome.Services.Contracts
{
    using System.Collections.Generic;
    using KeepHome.Models;
    using KeepHome.Models.Enums;

    public interface IOrderService
    {
        Order CreateOrder(string username);
        Order GetOrderById(int id);
        Order GetOrderByUsername(string username);
        void SetOrder(Order order, string fullName, string phoneNumber, int deliveryAddressId);
        void CompleteOrder(string username);
        IEnumerable<Order> GetUserOrders(string userName);
    }
}