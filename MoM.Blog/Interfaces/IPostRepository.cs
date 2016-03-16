using MoM.Blog.Models;
using MoM.Module.Interfaces;
using System.Collections.Generic;

namespace MoM.Blog.Interfaces
{
    public interface IPostRepository : IDataRepository
    {
        IEnumerable<Post> Table();
        IEnumerable<Post> Posts(int pageNo, int pageSize);
        IEnumerable<Post> Posts(int pageNo, int pageSize, string sortColumn, bool sortByAscending);
        Post Post(int year, int month, string titleSlug);
        Post Post(int id);
        Post AddPost(Post post);
        Post EditPost(Post post);
        void DeletePost(int id);
        int TotalPosts(int isPublished = 1);
    }
}
