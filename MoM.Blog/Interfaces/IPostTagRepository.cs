using MoM.Blog.Models;
using MoM.Module.Extensions;
using MoM.Module.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MoM.Blog.Interfaces
{
    interface IPostTagRepository : IDataRepository
    {
        IQueryable<PostTag> Table();
        IQueryable<PostTag> Fetch(Expression<Func<PostTag, bool>> predicate);
        IQueryable<PostTag> Fetch(Expression<Func<PostTag, bool>> predicate, Action<Orderable<PostTag>> order);
        IQueryable<PostTag> Fetch(Expression<Func<PostTag, bool>> predicate, Action<Orderable<PostTag>> order, int skip, int count);
    }
}
