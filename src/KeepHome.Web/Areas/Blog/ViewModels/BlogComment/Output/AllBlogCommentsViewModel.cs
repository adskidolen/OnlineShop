namespace KeepHome.Web.Areas.Blog.ViewModels.BlogComment.Output
{
    using System.Collections.Generic;

    public class AllBlogCommentsViewModel
    {
        public IEnumerable<BlogCommentViewModel> Comments { get; set; }
    }
}