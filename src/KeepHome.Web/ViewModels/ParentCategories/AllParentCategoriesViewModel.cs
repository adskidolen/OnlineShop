namespace KeepHome.Web.ViewModels.ParentCategories
{
    using System.Collections.Generic;

    public class AllParentCategoriesViewModel
    {
        private const string NoCategoriesMessage = "Все още няма добавени категории...";
        public string ShowNoCategoriesMessage => NoCategoriesMessage;

        public IEnumerable<ParentCategoryViewModel> Categories { get; set; }
    }
}