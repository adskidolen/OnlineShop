using System.ComponentModel.DataAnnotations;

namespace KeepHome.Web.Areas.Blog.ViewModels.BlogComment.Input
{
    public class BlogCommentInputModel
    {
        private const int ContentMinLength = 1;
        private const int ContentMaxLength = 500;

        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; }
    }
}