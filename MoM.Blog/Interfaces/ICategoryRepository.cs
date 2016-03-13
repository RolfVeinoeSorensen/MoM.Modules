using MoM.Blog.Models;
using MoM.Module.Interfaces;
using System.Collections.Generic;

namespace MoM.Blog.Interfaces
{
    public interface ICategoryRepository : IDataRepository
    {
        IEnumerable<Category> All();
    }
}
