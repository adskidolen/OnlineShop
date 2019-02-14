namespace KeepHome.Web.Areas.Blog.ViewModels.BlogPost.Input
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BlogPostEditInputModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int ProductId { get; set; }
        public ICollection<SelectListItem> Products { get; set; }
    }
}