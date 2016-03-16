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

        public int AddCategory(CategoryDto category)
        {
            return Storage.GetRepository<ICategoryRepository>().AddCategory(category.ToEntity());
        }

        public PostDto AddPost(PostDto post)
        {
            return Storage.GetRepository<IPostRepository>().AddPost(post.ToEntity()).ToDTO();
        }

        public int AddTag(TagDto tag)
        {
            return Storage.GetRepository<ITagRepository>().AddTag(tag.ToEntity());
        }

        public IList<CategoryDto> Categories()
        {
            var categories = Storage.GetRepository<ICategoryRepository>().Table();
            return categories.ToDTOs();
        }

        public IList<CategoryDto> CategoriesWithPostCount(int pageSize)
        {
            var categories = Storage.GetRepository<ICategoryRepository>().Table();
            var categoryIds = categories.Select(x => x.CategoryId);
            var posts = Storage.GetRepository<IPostRepository>().Table().Where(p => categoryIds.Contains(p.Category.CategoryId));
            foreach (var category in categories)
            {
                category.Posts = posts.Where(p => p.Category.CategoryId == category.CategoryId).ToList();
            }
            return categories.OrderByDescending(c => c.Posts.Count()).Take(pageSize).ToDTOs(true);
        }

        public CategoryDto Category(int id)
        {
            return Storage.GetRepository<ICategoryRepository>().Category(id).ToDTO();
        }

        public CategoryDto Category(string categorySlug)
        {
            return Storage.GetRepository<ICategoryRepository>().Category(categorySlug).ToDTO();
        }

        public void DeleteCategory(int id)
        {
            Storage.GetRepository<ICategoryRepository>().DeleteCategory(id);
        }

        public void DeletePost(int id)
        {
            Storage.GetRepository<IPostRepository>().DeletePost(id);
        }

        public void DeleteTag(int id)
        {
            Storage.GetRepository<ITagRepository>().DeleteTag(id);
        }

        public void EditCategory(CategoryDto category)
        {
            Storage.GetRepository<ICategoryRepository>().EditCategory(category.ToEntity());
        }

        public PostDto EditPost(PostDto post)
        {
            return Storage.GetRepository<IPostRepository>().EditPost(post.ToEntity()).ToDTO();
        }

        public void EditTag(TagDto tag)
        {
            Storage.GetRepository<ITagRepository>().EditTag(tag.ToEntity());
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
            var posts = Storage.GetRepository<IPostRepository>().Posts(pageNo, pageSize);
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
                post.PostTags = postTags.ToList();
            }
            return posts.ToDTOs();
        }

        public IList<PostDto> Posts(int pageNo, int pageSize, string sortColumn, bool sortByAscending)
        {
            return Storage.GetRepository<IPostRepository>().Posts(pageNo, pageSize, sortColumn, sortByAscending).ToDTOs();
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
            //return Storage.GetRepository<ITagRepository>().TagsWithPostsCount(pageSize).ToDTOs();
            return null;
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
