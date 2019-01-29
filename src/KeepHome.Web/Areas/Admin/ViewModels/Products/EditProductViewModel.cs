namespace KeepHome.Web.Areas.Admin.ViewModels.Products
{
    public class EditProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int ChildCategoryId { get; set; }
        public int Quantity { get; set; }
        public string CategoryName { get; set; }
    }
}