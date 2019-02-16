namespace KeepHome.Web.ViewModels.Home
{
    using KeepHome.Web.ViewModels.ParentCategories;
    using KeepHome.Web.ViewModels.Products;

    using System.Collections.Generic;

    public class IndexViewModel
    {
        private const string NoCategoriesMessage = "Все още няма добавени категории...";
        private const string NoLastAddedProductsMessage = "Все още няма добавени нови продукти...";

        public string ShowNoCategoriesMessage => NoCategoriesMessage;
        public string ShowNoLastAddedProductsMessage => NoLastAddedProductsMessage;

        public IEnumerable<LastAddedProductViewModel> LastAddedProducts { get; set; }
        public IEnumerable<RandomParentCategoryViewModel> RandomCategories { get; set; }
    }
}