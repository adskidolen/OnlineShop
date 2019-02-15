namespace KeepHome.Web.Areas.Blog.Controllers
{
    using KeepHome.Common;
    using KeepHome.Models;
    using KeepHome.Services.Contracts;
    using KeepHome.Web.Areas.Blog.Controllers.Base;
    using KeepHome.Web.Areas.Blog.ViewModels.BlogPost.Input;
    using KeepHome.Web.Areas.Blog.ViewModels.BlogPost.Output;
    using KeepHome.Web.ViewModels;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using System.Linq;

    public class PostsController : BaseBlogController
    {
        private readonly IBlogPostsService blogPostsService;
        private readonly IProductService productService;

        public PostsController(IBlogPostsService blogPostsService, IProductService productService)
        {
            this.blogPostsService = blogPostsService;
            this.productService = productService;
        }

        [Authorize(Roles = GlobalConstants.AdminRoleName)]
        public IActionResult Post()
        {
            var products = this.productService.GetAllProducts();

            var selectListItemProducts = products.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            })
            .ToList();

            var blogInputModel = new BlogPostInputModel
            {
                Products = selectListItemProducts
            };

            return this.View(blogInputModel);
        }

        [Authorize(Roles = GlobalConstants.AdminRoleName)]
        [HttpPost]
        public IActionResult Post(BlogPostInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.blogPostsService.CreatePost(model.Title, model.Content, model.ProductId);

            return this.RedirectToAction(nameof(All));
        }

        [Authorize(Roles = GlobalConstants.AdminRoleName)]
        public IActionResult Edit(int id)
        {
            var postExists = this.blogPostsService.PostExistsById(id);
            if (!postExists)
            {
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = ErrorMessages.BlogPostErrorMessage
                };

                return this.View(GlobalConstants.ErrorViewName, errorViewModel);
            }

            var products = this.productService.GetAllProducts();

            var selectListItemProducts = products.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            })
            .ToList();

            var post = this.blogPostsService.GetPostById<BlogPost>(id);

            var blogPostEditInputModel = new BlogPostEditInputModel
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                ProductId = post.ProductId,
                Products = selectListItemProducts
            };

            return this.View(blogPostEditInputModel);
        }

        [Authorize(Roles = GlobalConstants.AdminRoleName)]
        [HttpPost]
        public IActionResult Edit(BlogPostEditInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                var products = this.productService.GetAllProducts();

                var selectListItemProducts = products.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToList();

                model.Products = selectListItemProducts;

                return this.View(model);
            }

            this.blogPostsService.EditPost(model.Id, model.Title, model.Content, model.ProductId);

            return this.RedirectToAction(nameof(All));
        }

        [Authorize(Roles = GlobalConstants.AdminRoleName)]
        public IActionResult Delete(int id)
        {
            var postExists = this.blogPostsService.PostExistsById(id);
            if (!postExists)
            {
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = ErrorMessages.BlogPostErrorMessage
                };

                return this.View(GlobalConstants.ErrorViewName, errorViewModel);
            }

            var products = this.productService.GetAllProducts();

            var selectListItemProducts = products.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            })
            .ToList();

            var post = this.blogPostsService.GetPostById<BlogPost>(id);

            var blogPostEditInputModel = new BlogPostDeleteViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                ProductId = post.ProductId,
                Products = selectListItemProducts
            };

            return this.View(blogPostEditInputModel);
        }

        [Authorize(Roles = GlobalConstants.AdminRoleName)]
        [HttpPost]
        public IActionResult Delete(BlogPostDeleteViewModel model)
        {
            this.blogPostsService.RemovePost(model.Id);

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Details(int id)
        {
            var postExists = this.blogPostsService.PostExistsById(id);
            if (!postExists)
            {
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = ErrorMessages.BlogPostErrorMessage
                };

                return this.View(GlobalConstants.ErrorViewName, errorViewModel);
            }

            var post = this.blogPostsService.GetPostById<BlogPostDetailsViewModel>(id);
            post.Comment = new ViewModels.BlogComment.Input.BlogCommentInputModel();

            return this.View(post);
        }

        public IActionResult All()
        {
            var posts = this.blogPostsService.AllPosts<BlogPostViewModel>().ToList();

            var allPostsViewModel = new AllBlogPostsViewModel
            {
                Posts = posts
            };

            return this.View(allPostsViewModel);
        }
    }
}