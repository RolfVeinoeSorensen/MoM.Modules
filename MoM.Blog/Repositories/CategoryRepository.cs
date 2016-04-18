using MoM.Blog.Interfaces;
using MoM.Blog.Models;
using MoM.Module.Base;
using System.Collections.Generic;
using System.Linq;
using System;
using MoM.Module.Extensions;
using System.Linq.Expressions;

namespace MoM.Blog.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public IEnumerable<Category> Categories(int pageNo, int pageSize, string sortColumn, bool sortByAscending)
        {
            switch (sortColumn.ToLower())
            {
                case "name":
                    if (sortByAscending)
                        return DbSet
                            .OrderBy(p => p.Name)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                    else
                        return DbSet
                            .OrderByDescending(p => p.Name)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                case "urlslug":
                    if (sortByAscending)
                        return DbSet
                            .OrderBy(p => p.UrlSlug)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                    else
                        return DbSet
                            .OrderByDescending(p => p.UrlSlug)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                case "postcount":
                    if (sortByAscending)
                        return DbSet
                            .OrderBy(p => p.Posts.Count())
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                    else
                        return DbSet
                            .OrderByDescending(p => p.Posts.Count())
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                default:
                        return DbSet
                            .OrderByDescending(p => p.Name)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
            }
        }

        public Category Category(int id)
        {
            return DbSet.FirstOrDefault(t => t.CategoryId == id);
        }

        public Category Category(string categorySlug)
        {
            return DbSet.FirstOrDefault(t => t.UrlSlug.Equals(categorySlug));
        }

        public void Create(Category entity)
        {
            DbSet.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(Category entity)
        {
            DbSet.Remove(entity);
            Db.SaveChanges();
        }

        public IQueryable<Category> Fetch(Expression<Func<Category, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<Category> Fetch(Expression<Func<Category, bool>> predicate, Action<Orderable<Category>> order)
        {
            var orderable = new Orderable<Category>(Fetch(predicate));
            order(orderable);
            return orderable.Queryable;
        }

        public IQueryable<Category> Fetch(Expression<Func<Category, bool>> predicate, Action<Orderable<Category>> order, int skip, int count)
        {
            return Fetch(predicate, order).Skip(skip).Take(count);
        }

        public IQueryable<Category> Table()
        {
            return DbSet.AsQueryable();
        }

        public void Update(Category entity)
        {
            DbSet.Update(entity);
            Db.SaveChanges();
        }
    }
}
