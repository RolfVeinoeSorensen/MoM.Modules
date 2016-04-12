using MoM.Blog.Models;
using MoM.Module.Extensions;
using MoM.Module.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MoM.Blog.Interfaces
{
    public interface IPostRepository : IDataRepository
    {
        void Create(Post entity);
        void Update(Post entity);
        void Delete(Post entity);
        IQueryable<Post> Table();
        IQueryable<Post> Fetch(Expression<Func<Post, bool>> predicate);
        IQueryable<Post> Fetch(Expression<Func<Post, bool>> predicate, Action<Orderable<Post>> order);
        IQueryable<Post> Fetch(Expression<Func<Post, bool>> predicate, Action<Orderable<Post>> order, int skip, int count);

        IEnumerable<Post> Posts(int pageNo, int pageSize);
        IEnumerable<Post> Posts(int pageNo, int pageSize, string sortColumn, bool sortByAscending);
        Post Post(int year, int month, string titleSlug);
        Post Post(int id);
        int TotalPosts(int isPublished = 1);
    }
}
