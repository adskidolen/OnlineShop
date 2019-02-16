namespace KeepHome.Web.Areas.Blog.Controllers
{
    using KeepHome.Common;
    using KeepHome.Services.Contracts;
    using KeepHome.Web.Areas.Blog.Controllers.Base;
    using KeepHome.Web.Areas.Blog.ViewModels.BlogComment.Input;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class CommentsController : BaseBlogController
    {
        private readonly IBlogCommentsService blogCommentsService;

        public CommentsController(IBlogCommentsService blogCommentsService)
        {
            this.blogCommentsService = blogCommentsService;
        }

        [HttpPost]
        public IActionResult Add(int id, BlogCommentInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                var routeValue = new
                {
                    Id = id
                };

                return this.RedirectToAction(GlobalConstants.DetailsActionName, GlobalConstants.PostsControllerName, routeValue);
            }

            this.blogCommentsService.AddComment(model.Content, id, this.User.Identity.Name);

            var routeValues = new
            {
                Id = id
            };

            return this.RedirectToAction(GlobalConstants.DetailsActionName, GlobalConstants.PostsControllerName, routeValues);
        }

        public IActionResult Delete(int id)
        {
            var post = this.blogCommentsService.GetPostByCommentId(id);

            this.blogCommentsService.RemoveComment(id);

            var routeValues = new
            {
                post.Id
            };

            return this.RedirectToAction(GlobalConstants.DetailsActionName, GlobalConstants.PostsControllerName, routeValues);
        }
    }
}