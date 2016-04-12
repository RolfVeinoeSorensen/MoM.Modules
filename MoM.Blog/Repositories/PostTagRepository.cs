using MoM.Blog.Interfaces;
using MoM.Blog.Models;
using MoM.Module.Base;
using MoM.Module.Extensions;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MoM.Blog.Repositories
{
    public class PostTagRepository : RepositoryBase<PostTag>, IPostTagRepository
    {
        public IQueryable<PostTag> Fetch(Expression<Func<PostTag, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<PostTag> Fetch(Expression<Func<PostTag, bool>> predicate, Action<Orderable<PostTag>> order)
        {
            var orderable = new Orderable<PostTag>(Fetch(predicate));
            order(orderable);
            return orderable.Queryable;
        }

        public IQueryable<PostTag> Fetch(Expression<Func<PostTag, bool>> predicate, Action<Orderable<PostTag>> order, int skip, int count)
        {
            return Fetch(predicate, order).Skip(skip).Take(count);
        }

        public IQueryable<PostTag> Table()
        {
            return DbSet.AsQueryable();
        }
    }
}
