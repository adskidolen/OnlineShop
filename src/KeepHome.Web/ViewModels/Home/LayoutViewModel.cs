namespace KeepHome.Web.ViewModels.Home
{
    using KeepHome.Web.ViewModels.ParentCategories;

    using System.Collections.Generic;

    public class LayoutViewModel
    {
        public IList<ParentCategoryPartialViewModel> ParentCategories { get; set; }
    }
}