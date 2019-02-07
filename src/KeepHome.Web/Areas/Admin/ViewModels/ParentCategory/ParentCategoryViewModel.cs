using System.ComponentModel.DataAnnotations;

namespace KeepHome.Web.Areas.Admin.ViewModels.ParentCategory
{
    public class ParentCategoryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Полето \"{0}\" e задължително.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Полето \"{0}\" трябва да бъде текст с минимална дължина {2} и максимална дължина {1} символа.")]
        public string Name { get; set; }

        public string ImageUrl { get; set; }
        public int ChildCategoriesCount { get; set; }
    }
}