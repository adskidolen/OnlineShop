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

        IEnumerable<Order> GetUserOrders(string userName);
        void SetOrder(Order order, string fullName, string phoneNumber, int deliveryAddressId, decimal deliveryPrice, PaymentType paymentType);
        void CompleteOrder(string username);
        bool SetOrderStatusByInvoice(string invoice, string status);
        void SetEasyPayNumber(Order order, string easyPayNumber);

    }
}