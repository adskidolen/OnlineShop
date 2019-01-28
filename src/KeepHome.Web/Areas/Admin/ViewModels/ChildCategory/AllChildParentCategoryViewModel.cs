using System.Collections.Generic;
using KeepHome.Web.Areas.Admin.Controllers;
using KeepHome.Web.Areas.Admin.ViewModels.ParentCategory;

namespace KeepHome.Web.Areas.Admin.ViewModels.ChildCategory
{
    public class AllChildParentCategoryViewModel
    {
        public ICollection<AllChildCategoryViewModel> ChildCategoryViewModel { get; set; }

        public ICollection<ParentCategoryViewModel> ParentCategoryViewModels { get; set; }
    }
}