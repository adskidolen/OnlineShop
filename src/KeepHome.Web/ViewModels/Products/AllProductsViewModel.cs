namespace KeepHome.Web.ViewModels.Products
{
    using System.Collections.Generic;

    public class AllProductsViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}