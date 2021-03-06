﻿using MoM.Module.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoM.Blog.Models
{
    [Table("PostTag", Schema = "Blog")]
    public partial class PostTag : IDataEntity
    {
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
