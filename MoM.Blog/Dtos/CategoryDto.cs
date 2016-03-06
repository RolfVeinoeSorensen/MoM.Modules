namespace MoM.Blog.Dtos
{
    public partial class CategoryDto
    {
        public int categoryId { get; set; }
        public string name { get; set; }
        public string urlSlug { get; set; }
        public string description { get; set; }
        public int? postCount { get; set; }

        public CategoryDto()
        {
        }

        public CategoryDto(int CategoryId, string Name, string UrlSlug, string Description, int? PostCount)
        {
            categoryId = CategoryId;
            name = Name;
            urlSlug = UrlSlug;
            description = Description;
            postCount = PostCount;
        }
    }
}
