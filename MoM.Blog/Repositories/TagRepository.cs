using MoM.Blog.Interfaces;
using MoM.Blog.Models;
using MoM.Module.Base;
using System.Collections.Generic;
using System.Linq;
using MoM.Module.Extensions;
using System;
using System.Linq.Expressions;

namespace MoM.Blog.Repositories
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public void Create(Tag entity)
        {
            DbSet.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(Tag entity)
        {
            DbSet.Remove(entity);
            Db.SaveChanges();
        }

        public IQueryable<Tag> Fetch(Expression<Func<Tag, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<Tag> Fetch(Expression<Func<Tag, bool>> predicate, Action<Orderable<Tag>> order)
        {
            var orderable = new Orderable<Tag>(Fetch(predicate));
            order(orderable);
            return orderable.Queryable;
        }

        public IQueryable<Tag> Fetch(Expression<Func<Tag, bool>> predicate, Action<Orderable<Tag>> order, int skip, int count)
        {
            return Fetch(predicate, order).Skip(skip).Take(count);
        }

        public IQueryable<Tag> Table()
        {
            return DbSet.AsQueryable();
        }

        public Tag Tag(int id)
        {
            return DbSet.FirstOrDefault(t => t.TagId == id);
        }

        public Tag Tag(string tagSlug)
        {
            return DbSet.FirstOrDefault(t => t.UrlSlug == tagSlug);
        }


        public IEnumerable<Tag> TagsWithPostsCount(int pageSize)
        {
            return DbSet.OrderByDescending(t => t.PostTags.Count).Where(t => t.PostTags.Count > 0).Take(pageSize);
        }

        public int TotalTags()
        {
            return DbSet.Count();
        }

        public void Update(Tag entity)
        {
            DbSet.Update(entity);
            Db.SaveChanges();
        }
    }
}
