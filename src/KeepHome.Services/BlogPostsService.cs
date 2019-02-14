namespace KeepHome.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper.QueryableExtensions;

    using KeepHome.Data;
    using KeepHome.Models;
    using KeepHome.Services.Contracts;

    public class BlogPostsService : IBlogPostsService
    {
        private readonly KeepHomeContext dbContext;
        private readonly IProductService productService;

        public BlogPostsService(KeepHomeContext dbContext, IProductService productService)
        {
            this.dbContext = dbContext;
            this.productService = productService;
        }

        public void CreatePost(string title, string content, int productId)
        {
            var product = this.productService.GetProduct(productId);

            var post = new BlogPost
            {
                Title = title,
                Content = content,
                Product = product
            };

            this.dbContext.BlogPosts.Add(post);
            this.dbContext.SaveChanges();
        }

        public void EditPost(int id, string title, string content, int productId)
        {
            var post = this.dbContext.BlogPosts.FirstOrDefault(p => p.Id == id);

            post.Title = title;
            post.Content = content;
            post.ProductId = productId;
            post.EditedOn = DateTime.UtcNow;
            post.IsEdited = true;

            this.dbContext.Update(post);
            this.dbContext.SaveChanges();
        }

        public void RemovePost(int id)
        {
            var post = this.dbContext.BlogPosts.FirstOrDefault(p => p.Id == id);

            this.dbContext.Remove(post);
            this.dbContext.SaveChanges();
        }

        public TModel GetPostById<TModel>(int id)
            => this.By<TModel>(p => p.Id == id).SingleOrDefault();

        public TModel GetPostByTitle<TModel>(string title)
            => this.By<TModel>(p => p.Title == title).SingleOrDefault();

        public bool PostExistsById(int id)
            => this.dbContext.BlogPosts.Any(p => p.Id == id);

        public IQueryable<TModel> AllPosts<TModel>()
            => this.dbContext.BlogPosts.AsQueryable().ProjectTo<TModel>();

        private IEnumerable<TModel> By<TModel>(Func<BlogPost, bool> predicate)
            => this.dbContext.BlogPosts.Where(predicate).AsQueryable().ProjectTo<TModel>();

    }
}