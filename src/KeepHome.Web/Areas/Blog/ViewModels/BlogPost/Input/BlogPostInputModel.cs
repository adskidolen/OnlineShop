namespace KeepHome.Web.Areas.Blog.ViewModels.BlogPost.Input
{
    using KeepHome.Common;

    using Microsoft.AspNetCore.Mvc.Rendering;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BlogPostInputModel
    {
        [Required]
        [Display(Name = GlobalConstants.TitleNameInBG)]
        public string Title { get; set; }

        [Required]
        [Display(Name = GlobalConstants.ContentNameInBG)]
        public string Content { get; set; }

        [Required]
        public int ProductId { get; set; }
        public ICollection<SelectListItem> Products { get; set; }
    }
}