namespace KeepHome.Web.ViewModels.Products
{
    using System.Collections.Generic;

    public class AllProductsViewModel
    {
        private const string NoProductsMessage = "Все още няма добавени продукти...";
        public string ShowNoProductsMessage => NoProductsMessage;

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}