namespace KeepHome.Web.Areas.Admin.ViewModels.ChildCategory
{
    public class AllChildCategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ParentCategoryName { get; set; }

        public int ProductsCount { get; set; }
    }
}