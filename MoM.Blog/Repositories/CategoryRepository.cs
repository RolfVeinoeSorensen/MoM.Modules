using MoM.Blog.Interfaces;
using MoM.Blog.Models;
using MoM.Module.Base;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MoM.Blog.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public int AddCategory(Category category)
        {
            DbSet.Add(category);
            DatabaseContext.SaveChanges();
            return category.CategoryId;

        }

        public IEnumerable<Category> AdminCategories()
        {
            return DbSet.OrderBy(t => t.Name);
        }

        public IEnumerable<Category> All()
        {
                return DbSet.OrderByDescending(i => i.Posts.Count);
        }

        public IEnumerable<Category> Categories()
        {
            return DbSet.OrderByDescending(x => x.Posts.Count).ToList();
        }

        public IEnumerable<Category> CategoriesWithPostCount(int pageSize)
        {
            return DbSet.OrderByDescending(t => t.Posts.Count)
                    .Where(t => t.Posts.Count > 0)
                    .Take(pageSize);
        }

        public Category Category(int id)
        {
            return DbSet.FirstOrDefault(t => t.CategoryId == id);
        }

        public Category Category(string categorySlug)
        {
            return DbSet.FirstOrDefault(t => t.UrlSlug.Equals(categorySlug));
        }

        public void DeleteCategory(int id)
        {
            var categoryToDelete = DbSet.FirstOrDefault(x => x.CategoryId == id);
            DbSet.Remove(categoryToDelete);
            DatabaseContext.SaveChanges();
        }

        public void EditCategory(Category category)
        {
            DbSet.Update(category);
            DatabaseContext.SaveChanges();
        }

        public int TotalCategories()
        {
            return DbSet.Count();
        }
    }
}
