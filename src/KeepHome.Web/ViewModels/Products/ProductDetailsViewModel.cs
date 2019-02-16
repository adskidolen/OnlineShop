namespace KeepHome.Web.ViewModels.Products
{
    public class ProductDetailsViewModel
    {
        private const string OutOfStockMessage = "Няма в наличност";
        private const string InStockMessage = "Наличност: {0}";

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }

        public string ShowOutOfStockMessage => OutOfStockMessage;
        public string ShowInStockMessage => string.Format(InStockMessage, this.Quantity);
    }
}