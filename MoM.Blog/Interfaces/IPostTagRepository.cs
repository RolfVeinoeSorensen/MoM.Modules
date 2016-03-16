using MoM.Blog.Models;
using MoM.Module.Interfaces;
using System.Collections.Generic;

namespace MoM.Blog.Interfaces
{
    interface IPostTagRepository : IDataRepository
    {
        IEnumerable<PostTag> Table();
    }
}
