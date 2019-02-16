namespace KeepHome.Web.Areas.Blog.ViewModels.BlogPost.Output
{
    using System.Collections.Generic;

    public class AllBlogPostsViewModel
    {
        private const string NoPostsMessage = "Все още няма направени публикации...";
        public string ShowNoPostsMessage => NoPostsMessage;

        public IEnumerable<BlogPostViewModel> Posts { get; set; }
    }
}