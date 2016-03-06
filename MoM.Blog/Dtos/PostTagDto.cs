namespace MoM.Blog.Dtos
{
    public partial class PostTagDto
    {
        public int postId { get; set; }
        public PostDto post { get; set; }

        public int tagId { get; set; }
        public TagDto tag { get; set; }

        public PostTagDto() { }

        public PostTagDto(int PostId, PostDto Post, int TagId, TagDto Tag)
        {
            postId = PostId;
            post = Post;

            tagId = TagId;
            tag = Tag;
        }
    }
}
