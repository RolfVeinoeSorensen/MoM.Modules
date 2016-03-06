using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoM.Blog.Models
{
    [Table("Tag", Schema = "Blog")]
    public partial class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }

        public List<PostTag> PostTags { get; set; }
    }
}
