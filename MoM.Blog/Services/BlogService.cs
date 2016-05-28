using System.Collections.Generic;
using MoM.Blog.Dtos;
using MoM.Blog.Interfaces;
using MoM.Module.Interfaces;
using System.Linq;
using MoM.Module.Extensions;

namespace MoM.Blog.Services
{
    public class BlogService : IBlogService
    {
        private IDataStorage Storage;

        public BlogService(IDataStorage storage)
        {
            Storage = storage;
        }

        public void CreateCategory(CategoryDto category)
        {
            Storage.GetRepository<ICategoryRepository>().Create(category.ToEntity());
        }

        public void CreatePost(PostDto post)
        {
            Storage.GetRepository<IPostRepository>().Create(post.ToEntity());
        }

        public void CreateTag(TagDto tag)
        {
            Storage.GetRepository<ITagRepository>().Create(tag.ToEntity());
        }

        public IList<CategoryDto> Categories()
        {
            var categories = Storage.GetRepository<ICategoryRepository>().Table();
            return categories.ToDTOs();
        }

        public IList<CategoryDto> CategoriesWithPostCount(int pageSize)
        {
            var categories = Storage.GetRepository<ICategoryRepository>().Table().ToDTOs();
            foreach (var category in categories)
            {
                category.postCount = Storage.GetRepository<IPostRepository>().Fetch(p => p.Category.CategoryId == category.categoryId).Count();
            }
            return categories.OrderByDescending(c => c.postCount).Take(pageSize).ToList();
        }

        public IList<CategoryDto> CategoriesWithPostCount(int pageNo, int pageSize, string sortColumn, bool sortByAscending)
        {
            var categories = Storage.GetRepository<ICategoryRepository>().Categories(pageNo, pageSize, sortColumn, sortByAscending).ToDTOs();

            foreach (var category in categories)
            {
                category.postCount = Storage.GetRepository<IPostRepository>().Fetch(p => p.Category.CategoryId == category.categoryId).Count();
            }
            return categories;
        }

        public CategoryDto Category(int id)
        {
            return Storage.GetRepository<ICategoryRepository>().Category(id).ToDTO();
        }

        public CategoryDto Category(string categorySlug)
        {
            return Storage.GetRepository<ICategoryRepository>().Category(categorySlug).ToDTO();
        }

        public void DeleteCategory(CategoryDto category)
        {
            Storage.GetRepository<ICategoryRepository>().Delete(category.ToEntity());
        }

        public void DeletePost(PostDto post)
        {
            Storage.GetRepository<IPostRepository>().Delete(post.ToEntity());
        }

        public void DeleteTag(TagDto tag)
        {
            Storage.GetRepository<ITagRepository>().Delete(tag.ToEntity());
        }

        public void UpdateCategory(CategoryDto category)
        {
            Storage.GetRepository<ICategoryRepository>().Update(category.ToEntity());
        }

        public void UpdatePost(PostDto post)
        {
            Storage.GetRepository<IPostRepository>().Update(post.ToEntity());
        }

        public void UpdateTag(TagDto tag)
        {
            Storage.GetRepository<ITagRepository>().Update(tag.ToEntity());
        }

        public IList<PostDto> GetBlogPostsDateFormatted(IList<PostDto> postDtos)
        {
            var result = postDtos;
            foreach (var post in result)
            {
                post.month = post.postedDate.Month;
                post.year = post.postedDate.Year;
                post.day = post.postedDate.Day;
                post.monthName = post.postedDate.ToMonthName();
                post.monthNameShort = post.postedDate.ToMonthNameShort();
            }
            return result;
        }

        public PostDto Post(int id)
        {
            return Storage.GetRepository<IPostRepository>().Post(id).ToDTO();
        }

        public PostDto Post(int year, int month, string titleSlug)
        {
            return Storage.GetRepository<IPostRepository>().Post(year, month, titleSlug).ToDTO();
        }

        public IList<PostDto> Posts(int pageNo, int pageSize)
        {
            var posts = Storage.GetRepository<IPostRepository>().Posts(pageNo, pageSize).ToList();
            var categories = Storage.GetRepository<ICategoryRepository>().Table()
                .Where(c => posts.Select(p => p.CategoryId)
                .Contains(c.CategoryId)).ToList();
            var postTags = Storage.GetRepository<IPostTagRepository>().Table()
                .Where(pt => posts.Select(p => p.PostId)
                .Contains(pt.PostId)).ToList();
            var tags = Storage.GetRepository<ITagRepository>().Table()
                .Where(t => postTags.Select(pt => pt.TagId)
                .Contains(t.TagId));
            foreach (var postTag in postTags)
            {
                postTag.Tag = tags.FirstOrDefault(t => t.TagId == postTag.TagId);
            }
            foreach (var post in posts)
            {
                post.Category = categories.FirstOrDefault(c => c.CategoryId == post.Category.CategoryId);
                post.PostTags = postTags.Where(pt => pt.PostId == post.PostId).ToList();
            }
            return GetBlogPostsDateFormatted(posts.ToDTOs());
        }

        public IList<PostDto> Posts(int pageNo, int pageSize, string sortColumn, bool sortByAscending)
        {
            var posts = Storage.GetRepository<IPostRepository>().Posts(pageNo, pageSize, sortColumn, sortByAscending);
            var categories = Storage.GetRepository<ICategoryRepository>().Table()
                .Where(c => posts.Select(p => p.Category.CategoryId)
                .Contains(c.CategoryId));
            var postTags = Storage.GetRepository<IPostTagRepository>().Table()
                .Where(pt => posts.Select(p => p.PostId)
                .Contains(pt.PostId));
            var tags = Storage.GetRepository<ITagRepository>().Table()
                .Where(t => postTags.Select(pt => pt.TagId)
                .Contains(t.TagId));
            foreach (var postTag in postTags)
            {
                postTag.Tag = tags.FirstOrDefault(t => t.TagId == postTag.TagId);
            }
            foreach (var post in posts)
            {
                post.Category = categories.FirstOrDefault(c => c.CategoryId == post.Category.CategoryId);
                post.PostTags = postTags.Where(pt => pt.PostId == post.PostId).ToList();
            }
            return GetBlogPostsDateFormatted(posts.ToDTOs());
        }

        public IList<PostDto> PostsForCategory(string categorySlug, int pageNo, int pageSize)
        {
            //return Storage.GetRepository<IPostRepository>().PostsForCategory(categorySlug, pageNo, pageSize).ToDTOs();
            return null;
        }

        public IList<PostDto> PostsForSearch(string search, int pageNo, int pageSize)
        {
            //return Storage.GetRepository<IPostRepository>().PostsForSearch(search, pageNo, pageSize).ToDTOs();
            return null;
        }

        public IList<PostDto> PostsForTag(string tagSlug, int pageNo, int pageSize)
        {
            //return Storage.GetRepository<IPostRepository>().PostsForTag(tagSlug, pageNo, pageSize).ToDTOs();
            return null;
        }

        public TagDto Tag(int id)
        {
            return Storage.GetRepository<ITagRepository>().Tag(id).ToDTO();
        }

        public TagDto Tag(string tagSlug)
        {
            return Storage.GetRepository<ITagRepository>().Tag(tagSlug).ToDTO();
        }

        public IList<TagDto> Tags()
        {
            return Storage.GetRepository<ITagRepository>().Table().ToDTOs();
        }

        public IList<TagDto> TagsWithPostsCount(int pageSize)
        {
            var tags = Storage.GetRepository<ITagRepository>().Table().ToList();
            var postTags = Storage.GetRepository<IPostTagRepository>().Table()
                        .Where(pt => tags.Select(p => p.TagId)
                        .Contains(pt.TagId)).ToList();

            foreach (var tag in tags)
            {
                tag.PostTags = postTags.Where(pt => pt.TagId == tag.TagId).ToList();
            }

            var result = tags.OrderByDescending(t => t.PostTags.Count()).Take(pageSize).ToDTOs();
            //Do not evaluate tagclasses if there are no tags
            if (result.Count == 0)
                return result;

            var min = tags.Min(t => t.PostTags.Count);
            var max = tags.Max(t => t.PostTags.Count);
            var dist = (max - min) / 3;

            foreach (var tag in result)
            {
                string tagClass;
                if (tag.postCount == max)
                {
                    tagClass = "largest";
                }
                else if (tag.postCount > (min + (dist * 2)))
                {
                    tagClass = "large";
                }
                else if (tag.postCount > (min + dist))
                {
                    tagClass = "medium";
                }
                else if (tag.postCount == min)
                {
                    tagClass = "smallest";
                }
                else
                {
                    tagClass = "small";
                }
                tag.className = tagClass;
            }

            return result;
        }

        public int TotalCategories()
        {
            return Storage.GetRepository<ITagRepository>().Table().Count();
        }

        public int TotalPosts(int isPublished = 1)
        {
            return Storage.GetRepository<IPostRepository>().Table().Count(p => p.IsPublished == isPublished);
        }

        public int TotalPostsForCategory(string categorySlug)
        {
            //return Storage.GetRepository<IPostRepository>().TotalPostsForCategory(categorySlug);
            return 0;
        }

        public int TotalPostsForSearch(string search)
        {
            //return Storage.GetRepository<IPostRepository>().TotalPostsForSearch(search);
            return 0;
        }

        public int TotalPostsForTag(string tagSlug)
        {
            //return Storage.GetRepository<IPostRepository>().TotalPostsForTag(tagSlug);
            return 0;
        }

        public int TotalTags()
        {
            return Storage.GetRepository<ITagRepository>().Table().Count();
        }
    }
}
