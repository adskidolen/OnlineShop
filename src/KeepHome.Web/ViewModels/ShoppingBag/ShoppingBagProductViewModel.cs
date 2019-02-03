namespace KeepHome.Web.ViewModels.ShoppingBag
{
    public class ShoppingBagProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public string ImageUrl { get; set; }
    }
}
