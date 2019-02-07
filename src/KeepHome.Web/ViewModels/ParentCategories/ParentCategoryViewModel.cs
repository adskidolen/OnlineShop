using System;

namespace KeepHome.Web.ViewModels.ParentCategories
{
    public class ParentCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        internal object ToList()
        {
            throw new NotImplementedException();
        }
    }
}