namespace KeepHome.Web.Areas.Blog.ViewModels.BlogPost.Output
{
    using System.Collections.Generic;

    public class AllBlogPostsViewModel
    {
        public IEnumerable<BlogPostViewModel> Posts { get; set; }
    }
}