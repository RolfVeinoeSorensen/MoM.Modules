using System;
using System.Collections.Generic;
using MoM.Blog.Dtos;
using MoM.Blog.Interfaces;
using MoM.Module.Interfaces;
using MoM.Blog.Repositories;
using System.Linq;

namespace MoM.Blog.Services
{
    public class BlogService : IBlogService
    {
        private IDataStorage Storage;

        public BlogService(IDataStorage storage)
        {
            Storage = storage;
        }

        public IList<CategoryDto> Categories()
        {
            var categories = Storage.GetRepository<ICategoryRepository>().All();
            var categoryIds = categories.Select(x => x.CategoryId);
            var posts = Storage.GetRepository<IPostRepository>().All().Where(p => categoryIds.Contains(p.Category.CategoryId));
            foreach(var category in categories)
            {
                category.Posts = posts.Where(p => p.Category.CategoryId == category.CategoryId).ToList();
            }
            return categories.ToDTOs();
        }
    }
}
