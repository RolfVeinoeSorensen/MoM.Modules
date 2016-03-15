using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoM.Blog.Dtos
{
    public partial class PagingDto
    {
        public int pageNo { get; set; }
        public int pageSize { get; set; }
    }
}
