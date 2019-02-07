namespace KeepHome.Web.ViewModels.ParentCategories
{
    using KeepHome.Web.ViewModels.ChildCategories;
    using System.Collections.Generic;

    public class AllParentCategoriesDetailsViewModel
    {
        public string Name { get; set; }
        public IEnumerable<ChildCategoryDetailsViewModel> ChildCategories { get; set; }
    }
}