using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KeepHome.Web.Areas.Admin.ViewModels.Products
{
    public class CreateProductViewModel
    {
        [Display(Name = "Име на продукта")]
        [Required(ErrorMessage = "Моля изберете \"{0}\".")]
        public string Name { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Моля изберете \"{0}\".")]
        public decimal Price { get; set; }

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Моля изберете \"{0}\".")]
        public string Description { get; set; }
        
        [Display(Name = "Име на категория")]
        //[Required(ErrorMessage = "Моля изберете \"{0}\".")]
        public string CategoryName { get; set; }

        [Display(Name = "Количество")]
        [Required(ErrorMessage = "Моля изберете \"{0}\".")]
        public int Quantity { get; set; }

        [Display(Name = "Снимка")]
        [Required(ErrorMessage = "Моля изберете \"{0}\".")]
        public string ImageUrl { get; set; }

        [Display(Name = "Под категория")]
        [Required(ErrorMessage = "Моля изберете \"{0}\".")]
        public int ChildCategoryId { get; set; }
        public ICollection<SelectListItem> ChildCategories { get; set; }
    }
}