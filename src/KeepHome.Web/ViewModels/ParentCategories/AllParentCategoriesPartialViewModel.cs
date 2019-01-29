namespace KeepHome.Web.ViewModels.ParentCategories
{
    using System.Collections.Generic;

    public class AllParentCategoriesPartialViewModel
    {
        public IEnumerable<ParentCategoryPartialViewModel> Categories { get; set; }
    }
}