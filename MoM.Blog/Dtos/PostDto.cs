using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoM.Blog.Dtos
{
    public partial class PostDto
    {
        public int postId { get; set; }
        public string title { get; set; }
        public string teaser { get; set; }
        public string content { get; set; }
        public string meta { get; set; }
        public string urlSlug { get; set; }
        public int isPublished { get; set; }
        public DateTime postedDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public CategoryDto category { get; set; }
        public List<PostTagDto> postTags { get; set; }
        public int? day { get; set; }
        public int? month { get; set; }
        public int? year { get; set; }
        public string monthName { get; set; }
        public string monthNameShort { get; set; }

        public PostDto()
        {
        }

        public PostDto(
            int PostId, 
            string Title, 
            string Teaser, 
            string Content, 
            string Meta, 
            string UrlSlug, 
            int IsPublished, 
            DateTime PostedDate, 
            DateTime ModifiedDate, 
            CategoryDto Category, 
            List<PostTagDto> PostTags, 
            int? Year, 
            int? Month)
        {
            postId = PostId;
            title = Title;
            teaser = Teaser;
            content = Content;
            meta = Meta;
            urlSlug = UrlSlug;
            isPublished = IsPublished;
            postedDate = PostedDate;
            modifiedDate = ModifiedDate;
            category = Category;
            postTags = PostTags;
            year = Year;
            month = Month;
        }
    }
}
