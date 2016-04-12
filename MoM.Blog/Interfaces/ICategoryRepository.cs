using MoM.Blog.Models;
using MoM.Module.Extensions;
using MoM.Module.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MoM.Blog.Interfaces
{
    public interface ICategoryRepository : IDataRepository
    {
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        IQueryable<Category> Table();
        IQueryable<Category> Fetch(Expression<Func<Category, bool>> predicate);
        IQueryable<Category> Fetch(Expression<Func<Category, bool>> predicate, Action<Orderable<Category>> order);
        IQueryable<Category> Fetch(Expression<Func<Category, bool>> predicate, Action<Orderable<Category>> order, int skip, int count);

        Category Category(string categorySlug);
        Category Category(int id);
    }
}
