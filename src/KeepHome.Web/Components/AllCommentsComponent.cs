namespace KeepHome.Web.Components
{
    using KeepHome.Services.Contracts;
    using KeepHome.Web.Areas.Blog.ViewModels.BlogComment.Output;

    using Microsoft.AspNetCore.Mvc;

    using System.Linq;

    public class AllCommentsComponent : ViewComponent
    {
        private readonly IBlogCommentsService blogCommentsService;

        public AllCommentsComponent(IBlogCommentsService blogCommentsService)
        {
            this.blogCommentsService = blogCommentsService;
        }

        public IViewComponentResult Invoke(int postId)
        {
            var comments = this.blogCommentsService.AllCommentsForPost<BlogCommentViewModel>(postId)
                                                   .OrderByDescending(d => d.CommentedOn)
                                                   .ToList();

            var blogCommentsViewModel = new AllBlogCommentsViewModel
            {
                Comments = comments
            };

            return this.View(blogCommentsViewModel);
        }
    }
}