using MoM.Blog.Interfaces;
using MoM.Blog.Models;
using MoM.Module.Base;
using System.Collections.Generic;
using System.Linq;

namespace MoM.Blog.Repositories
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public int AddTag(Tag tag)
        {
            DbSet.Add(tag);
            DatabaseContext.SaveChanges();
            return tag.TagId;
        }

        public void DeleteTag(int id)
        {
            var tagToDelete = DbSet.FirstOrDefault(t => t.TagId == id);
            DbSet.Remove(tagToDelete);
            DatabaseContext.SaveChanges();
        }

        public void EditTag(Tag tag)
        {
            DbSet.Update(tag);
            DatabaseContext.SaveChanges();
        }

        public Tag Tag(int id)
        {
            return DbSet.FirstOrDefault(t => t.TagId == id);
        }

        public Tag Tag(string tagSlug)
        {
            return DbSet.FirstOrDefault(t => t.UrlSlug == tagSlug);
        }

        public IEnumerable<Tag> Table()
        {
            return DbSet;
        }

        public IEnumerable<Tag> TagsWithPostsCount(int pageSize)
        {
            return DbSet.OrderByDescending(t => t.PostTags.Count).Where(t => t.PostTags.Count > 0).Take(pageSize);
        }

        public int TotalTags()
        {
            return DbSet.Count();
        }
    }
}
