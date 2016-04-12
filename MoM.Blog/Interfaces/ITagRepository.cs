using MoM.Blog.Models;
using MoM.Module.Extensions;
using MoM.Module.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MoM.Blog.Interfaces
{
    public interface ITagRepository : IDataRepository
    {
        void Create(Tag entity);
        void Update(Tag entity);
        void Delete(Tag entity);
        IQueryable<Tag> Table();
        IQueryable<Tag> Fetch(Expression<Func<Tag, bool>> predicate);
        IQueryable<Tag> Fetch(Expression<Func<Tag, bool>> predicate, Action<Orderable<Tag>> order);
        IQueryable<Tag> Fetch(Expression<Func<Tag, bool>> predicate, Action<Orderable<Tag>> order, int skip, int count);

        Tag Tag(string tagSlug);
        Tag Tag(int id);
    }
}
