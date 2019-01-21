using System;
using System.Collections.Generic;
using System.Text;
using KeepHome.Models;
using KeepHome.Models.Enums;

namespace KeepHome.Services.Contracts
{
    public interface IOrderService
    {
        Order CreateOrder(string username);
        Order GetOrderById(int id);
        Order GetOrderByUsername(string username);

        IEnumerable<Order> GetUserOrders(string userName);
        void SetOrderDetails(Order order, string fullName, string phoneNumber, PaymentType paymentType, int deliveryAddressId, decimal deliveryPrice);

        void CompleteOrder(string username);
    }
}
