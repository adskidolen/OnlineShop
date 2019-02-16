namespace KeepHome.Web.ViewModels.ParentCategories
{
    using KeepHome.Web.ViewModels.ChildCategories;

    using System.Collections.Generic;

    public class AllParentCategoriesDetailsViewModel
    {
        private const string NoChildCategoriesMessage = "Все още няма добавени подкатегории...";
        public string ShowNoChildCategorieMessage => NoChildCategoriesMessage;

        public string Name { get; set; }
        public IEnumerable<ChildCategoryDetailsViewModel> ChildCategories { get; set; }
    }
}