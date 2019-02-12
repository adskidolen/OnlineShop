namespace KeepHome.Web.ViewModels.Orders
{
    public class ConfirmOrderViewModel
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DeliveryPrice { get; set; }
        public string Recipient { get; set; }
        public string PhoneNumber { get; set; }
        public string DeliveryAddressOtherDetails { get; set; }
        public string DeliveryAddressStreet { get; set; }
        public string DeliveryAddressTown { get; set; }
        public string DeliveryAddressCountry { get; set; }
    }
}