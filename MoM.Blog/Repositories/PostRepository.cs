using MoM.Blog.Interfaces;
using MoM.Blog.Models;
using MoM.Module.Base;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MoM.Blog.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public Post AddPost(Post post)
        {
            DbSet.Add(post);
            DatabaseContext.SaveChanges();
            return post;
        }

        public IEnumerable<Post> All()
        {
                return DbSet.OrderByDescending(i => i.ModifiedDate);
        }

        public void DeletePost(int id)
        {
            var deletePost = DbSet.FirstOrDefault(x => x.PostId.Equals(id));
            DbSet.Remove(deletePost);
            DatabaseContext.SaveChanges();
        }

        public Post EditPost(Post post)
        {
            DbSet.Update(post);
            DatabaseContext.SaveChanges();
            return post;
        }

        public Post Post(int id)
        {
            return DbSet.FirstOrDefault(x => x.PostId.Equals(id));
        }

        public Post Post(int year, int month, string titleSlug)
        {
            return DbSet.FirstOrDefault(p => p.PostedDate.Year == year && p.PostedDate.Month == month && p.UrlSlug.Equals(titleSlug));
        }

        public IEnumerable<Post> Posts(int pageNo, int pageSize)
        {
            return DbSet.Where(p => p.IsPublished == 1)
                    .OrderByDescending(p => p.PostedDate)
                    .Skip(pageNo * pageSize)
                    .Take(pageSize);
        }

        public IEnumerable<Post> Posts(int pageNo, int pageSize, string sortColumn, bool sortByAscending)
        {
            switch (sortColumn)
            {
                case "Title":
                    if (sortByAscending)
                        return DbSet
                            .OrderBy(p => p.Title)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                    else
                        return DbSet
                            .OrderByDescending(p => p.Title)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                case "Published":
                    if (sortByAscending)
                        return DbSet
                            .OrderBy(p => p.IsPublished)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                    else
                        return DbSet
                            .OrderByDescending(p => p.IsPublished)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                case "PostedOn":
                    if (sortByAscending)
                        return DbSet
                            .OrderBy(p => p.PostedDate)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                    else
                        return DbSet
                            .OrderByDescending(p => p.PostedDate)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                case "Modified":
                    if (sortByAscending)
                        return DbSet
                            .OrderBy(p => p.ModifiedDate)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                    else
                        return DbSet
                            .OrderByDescending(p => p.ModifiedDate)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                case "Category":
                    if (sortByAscending)
                        return DbSet
                            .OrderBy(p => p.Category.Name)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                    else
                        return DbSet
                            .OrderByDescending(p => p.Category.Name)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
                default:
                    return DbSet
                            .OrderByDescending(p => p.ModifiedDate)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize);
            }
        }

        public IEnumerable<Post> PostsForCategory(string categorySlug, int pageNo, int pageSize)
        {
            return DbSet
                    .Where(p => p.IsPublished == 1 && p.Category.UrlSlug == categorySlug)
                    .OrderByDescending(p => p.PostedDate)
                    .Skip(pageNo * pageSize)
                    .Take(pageSize);
        }

        public IEnumerable<Post> PostsForSearch(string search, int pageNo, int pageSize)
        {
            return DbSet
                    .Where(p => p.IsPublished == 1 && (p.Title.Contains(search) || p.Category.Name.Equals(search) || p.PostTags.Any(t => t.Tag.Name.Equals(search))))
                    .OrderByDescending(p => p.PostedDate)
                    .Skip(pageNo * pageSize)
                    .Take(pageSize);
        }

        public IEnumerable<Post> PostsForTag(string tagSlug, int pageNo, int pageSize)
        {
            return DbSet
                    .Where(p => p.IsPublished == 1 && p.PostTags.Any(t => t.Tag.UrlSlug.Equals(tagSlug)))
                    .OrderByDescending(p => p.PostedDate)
                    .Skip(pageNo * pageSize)
                    .Take(pageSize);
        }

        public int TotalPosts(bool checkIsPublished = true)
        {
            return DbSet.Count(p => checkIsPublished || p.IsPublished == 1);
        }

        public int TotalPostsForCategory(string categorySlug)
        {
            return DbSet.Count(p => p.IsPublished == 1 && p.Category.UrlSlug.Equals(categorySlug));
        }

        public int TotalPostsForSearch(string search)
        {
            return DbSet.Count(p => p.IsPublished == 1 && (p.Title.Contains(search) || p.Category.Name.Equals(search) || p.PostTags.Any(t => t.Tag.Name.Equals(search))));
        }

        public int TotalPostsForTag(string tagSlug)
        {
            return DbSet.Count(p => p.IsPublished == 1 && p.PostTags.Any(t => t.Tag.UrlSlug.Equals(tagSlug)));
        }
    }
}
