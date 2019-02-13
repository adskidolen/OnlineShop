namespace KeepHome.Web.ViewModels.Products
{
    using System;

    public class LastAddedProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime AddedOn { get; set; }
    }
}