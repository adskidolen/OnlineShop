namespace KeepHome.Services.Contracts
{
    using KeepHome.Models;

    using System.Linq;

    public interface IBlogCommentsService
    {
        void AddComment(string content, int postId, string username);
        void RemoveComment(int id);
        BlogPost GetPostByCommentId(int commentId);
        IQueryable<TModel> AllCommentsForPost<TModel>(int postId);
    }
}