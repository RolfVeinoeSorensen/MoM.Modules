using MoM.Blog.Dtos;
using System.Collections.Generic;

namespace MoM.Blog.Interfaces
{
    public interface IBlogService
    {
        IList<CategoryDto> Categories();
    }
}
