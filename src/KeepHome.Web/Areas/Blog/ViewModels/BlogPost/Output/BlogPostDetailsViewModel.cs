using KeepHome.Web.Areas.Blog.ViewModels.BlogComment.Input;

namespace KeepHome.Web.Areas.Blog.ViewModels.BlogPost.Output
{
    public class BlogPostDetailsViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }

        public BlogCommentInputModel Comment { get; set; }
    }
}