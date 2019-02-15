namespace KeepHome.Services
{
    using AutoMapper.QueryableExtensions;

    using KeepHome.Data;
    using KeepHome.Models;
    using KeepHome.Services.Contracts;

    using System.Linq;

    public class BlogCommentsService : IBlogCommentsService
    {
        private readonly KeepHomeContext dbContext;

        public BlogCommentsService(KeepHomeContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddComment(string content, int postId, string username)
        {
            var user = this.dbContext.Users.FirstOrDefault(u => u.UserName == username);

            var blogComment = new BlogComment
            {
                Content = content,
                BlogPostId = postId,
                User = user
            };

            this.dbContext.BlogComments.Add(blogComment);
            this.dbContext.SaveChanges();
        }

        public void RemoveComment(int id)
        {
            var comment = this.dbContext.BlogComments.FirstOrDefault(c => c.Id == id);

            this.dbContext.Remove(comment);
            this.dbContext.SaveChanges();
        }

        public BlogPost GetPostByCommentId(int commentId)
            => this.dbContext.BlogComments.FirstOrDefault(c => c.Id == commentId).BlogPost;

        public IQueryable<TModel> AllCommentsForPost<TModel>(int postId)
            => this.dbContext.BlogComments.AsQueryable().Where(p => p.BlogPostId == postId).ProjectTo<TModel>();

    }
}