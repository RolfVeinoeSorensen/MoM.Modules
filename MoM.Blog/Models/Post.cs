using MoM.Module.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoM.Blog.Models
{
    [Table("Post", Schema = "Blog")]
    public partial class Post : IDataEntity
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Teaser { get; set; }
        public string Content { get; set; }
        public string Meta { get; set; }
        public string UrlSlug { get; set; }
        public int IsPublished { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Category Category { get; set; }
        public virtual List<PostTag> PostTags { get; set; }
    }
}
