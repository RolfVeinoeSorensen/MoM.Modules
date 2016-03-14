using MoM.Blog.Models;
using MoM.Module.Interfaces;
using System.Collections.Generic;

namespace MoM.Blog.Interfaces
{
    public interface ICategoryRepository : IDataRepository
    {
        IEnumerable<Category> All();
        IEnumerable<Category> AdminCategories();
        IEnumerable<Category> Categories();
        IEnumerable<Category> CategoriesWithPostCount(int pageSize);
        int TotalCategories();
        Category Category(string categorySlug);
        Category Category(int id);
        int AddCategory(Category category);
        void EditCategory(Category category);
        void DeleteCategory(int id);
    }
}
