using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoM.Blog.Models
{
    [Table("Category", Schema = "Blog")]
    public partial class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }

        public List<Post> Posts { get; set; }
    }
}
