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
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {

        public void Create(Post entity)
        {
            DbSet.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(Post entity)
        {
            DbSet.Remove(entity);
            Db.SaveChanges();
        }

        public IQueryable<Post> Fetch(Expression<Func<Post, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<Post> Fetch(Expression<Func<Post, bool>> predicate, Action<Orderable<Post>> order)
        {
            var orderable = new Orderable<Post>(Fetch(predicate));
            order(orderable);
            return orderable.Queryable;
        }

        public IQueryable<Post> Fetch(Expression<Func<Post, bool>> predicate, Action<Orderable<Post>> order, int skip, int count)
        {
            return Fetch(predicate, order).Skip(skip).Take(count);
        }

        public Post Post(int id)
        {
            return DbSet.FirstOrDefault(x => x.PostId.Equals(id));
        }

        public Post Post(int year, int month, string titleSlug)
        {
            return DbSet.FirstOrDefault(p => p.PostedDate.Year == year && p.PostedDate.Month == month && p.UrlSlug.Equals(titleSlug));
        }

        public IEnumerable<Post> Posts(int pageNo, int pageSize)
        {
            return DbSet.Where(p => p.IsPublished == 1)
                    .OrderByDescending(p => p.PostedDate)
                    .Skip(pageNo * pageSize)
                    .Take(pageSize);
        }

        public IEnumerable<Post> Posts(int pageNo, int pageSize, string sortColumn, bool sortByAscending)
        {
            switch (sortColumn)
            {
                case "Title":
                    if (sortByAscending)
                        return DbSet
                            .OrderBy(p => p.Title)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                    else
                        return DbSet
                            .OrderByDescending(p => p.Title)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                case "Published":
                    if (sortByAscending)
                        return DbSet
                            .OrderBy(p => p.IsPublished)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                    else
                        return DbSet
                            .OrderByDescending(p => p.IsPublished)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                case "PostedOn":
                    if (sortByAscending)
                        return DbSet
                            .OrderBy(p => p.PostedDate)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                    else
                        return DbSet
                            .OrderByDescending(p => p.PostedDate)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                case "Modified":
                    if (sortByAscending)
                        return DbSet
                            .OrderBy(p => p.ModifiedDate)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                    else
                        return DbSet
                            .OrderByDescending(p => p.ModifiedDate)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                case "Category":
                    if (sortByAscending)
                        return DbSet
                            .OrderBy(p => p.Category.Name)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                    else
                        return DbSet
                            .OrderByDescending(p => p.Category.Name)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                default:
                    return DbSet
                            .OrderByDescending(p => p.ModifiedDate)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
            }
        }

        public IQueryable<Post> Table()
        {
            return DbSet.AsQueryable();
        }

        public int TotalPosts(int isPublished = 1)
        {
            return DbSet.Count(p => p.IsPublished == isPublished);
        }

        public void Update(Post entity)
        {
            DbSet.Update(entity);
            Db.SaveChanges();
        }
    }
}
