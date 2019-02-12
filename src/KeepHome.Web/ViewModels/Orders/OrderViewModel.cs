namespace KeepHome.Web.ViewModels.Orders
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }

        public decimal ProductPrice { get; set; }
        public int ProductId { get; set; }

        public string ProductName { get; set; }
    }
}