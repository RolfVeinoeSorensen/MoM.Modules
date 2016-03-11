using MoM.Blog.Interfaces;
using MoM.Blog.Models;
using MoM.Module.Base;
using System.Collections.Generic;
using System.Linq;

namespace MoM.Blog.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public IEnumerable<Post> All()
        {
            using (var ctx = DatabaseContext)
            {
                return DbSet.OrderByDescending(i => i.ModifiedDate);
            }
            
        }
    }
}
