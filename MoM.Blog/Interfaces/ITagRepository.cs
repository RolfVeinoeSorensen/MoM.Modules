using MoM.Blog.Models;
using MoM.Module.Interfaces;
using System.Collections.Generic;


namespace MoM.Blog.Interfaces
{
    public interface ITagRepository : IDataRepository
    {
        IEnumerable<Tag> Tags();
        IEnumerable<Tag> TagsWithPostsCount(int pageSize);
        int TotalTags();
        Tag Tag(string tagSlug);
        Tag Tag(int id);
        int AddTag(Tag tag);
        void EditTag(Tag tag);
        void DeleteTag(int id);
    }
}
