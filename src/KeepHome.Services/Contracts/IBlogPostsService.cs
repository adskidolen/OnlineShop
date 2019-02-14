namespace KeepHome.Services.Contracts
{
    using System.Linq;

    public interface IBlogPostsService
    {
        void CreatePost(string title, string content, int productId);
        IQueryable<TModel> AllPosts<TModel>();
        bool PostExistsById(int id);
        TModel GetPostById<TModel>(int id);
        TModel GetPostByTitle<TModel>(string title);
        void EditPost(int id, string title, string content, int productId);
        void RemovePost(int id);
    }
}