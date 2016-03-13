using MoM.Blog.Interfaces;
using MoM.Blog.Models;
using MoM.Module.Base;
using System.Collections.Generic;
using System.Linq;

namespace MoM.Blog.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public IEnumerable<Category> All()
        {
                return DbSet.OrderByDescending(i => i.Posts.Count);
        }
    }
}
