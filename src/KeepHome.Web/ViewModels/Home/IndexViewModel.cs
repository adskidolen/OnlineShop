namespace KeepHome.Web.ViewModels.Home
{
    using KeepHome.Web.ViewModels.ParentCategories;
    using KeepHome.Web.ViewModels.Products;

    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<LastAddedProductViewModel> LastAddedProducts { get; set; }
        public IEnumerable<RandomParentCategoryViewModel> RandomCategories { get; set; }
    }
}