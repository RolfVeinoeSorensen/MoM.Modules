namespace MoM.Blog.Dtos
{
    public partial class TagDto
    {
        public int tagId { get; set; }
        public string name { get; set; }
        public string urlSlug { get; set; }
        public string description { get; set; }
        public string className { get; set; }
        public int? postCount { get; set; }

        public TagDto() { }

        public TagDto(int TagId, string Name, string UrlSlug, string Description, string ClassName, int? PostCount)
        {
            tagId = TagId;
            name = Name;
            urlSlug = UrlSlug;
            description = Description;
            postCount = PostCount;
            className = ClassName;
        }
    }
}
