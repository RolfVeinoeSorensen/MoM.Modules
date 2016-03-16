using MoM.Blog.Interfaces;
using System.Collections.Generic;
using MoM.Blog.Models;
using MoM.Module.Base;

namespace MoM.Blog.Repositories
{
    public class PostTagRepository : RepositoryBase<PostTag>, IPostTagRepository
    {
        public IEnumerable<PostTag> Table()
        {
            return DbSet;
        }
    }
}
