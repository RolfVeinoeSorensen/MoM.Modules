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

        public IList<CategoryDto> AdminCategories()
        {
            return Storage.GetRepository<ICategoryRepository>().AdminCategories().ToDTOs();
        }

        public IList<CategoryDto> Categories()
        {
            var categories = Storage.GetRepository<ICategoryRepository>().All();
            var categoryIds = categories.Select(x => x.CategoryId);
            var posts = Storage.GetRepository<IPostRepository>().All().Where(p => categoryIds.Contains(p.Category.CategoryId));
            foreach(var category in categories)
            {
                category.Posts = posts.Where(p => p.Category.CategoryId == category.CategoryId).ToList();
            }
            return categories.ToDTOs();
        }

        public IList<CategoryDto> CategoriesWithPostCount(int pageSize)
        {
            return Storage.GetRepository<ICategoryRepository>().CategoriesWithPostCount(pageSize).ToDTOs();
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
            return Storage.GetRepository<IPostRepository>().Posts(pageNo, pageSize).ToDTOs();
        }

        public IList<PostDto> Posts(int pageNo, int pageSize, string sortColumn, bool sortByAscending)
        {
            return Storage.GetRepository<IPostRepository>().Posts(pageNo, pageSize, sortColumn, sortByAscending).ToDTOs();
        }

        public IList<PostDto> PostsForCategory(string categorySlug, int pageNo, int pageSize)
        {
            return Storage.GetRepository<IPostRepository>().PostsForCategory(categorySlug, pageNo, pageSize).ToDTOs();
        }

        public IList<PostDto> PostsForSearch(string search, int pageNo, int pageSize)
        {
            return Storage.GetRepository<IPostRepository>().PostsForSearch(search, pageNo, pageSize).ToDTOs();
        }

        public IList<PostDto> PostsForTag(string tagSlug, int pageNo, int pageSize)
        {
            return Storage.GetRepository<IPostRepository>().PostsForTag(tagSlug, pageNo, pageSize).ToDTOs();
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
            return Storage.GetRepository<ITagRepository>().Tags().ToDTOs();
        }

        public IList<TagDto> TagsWithPostsCount(int pageSize)
        {
            return Storage.GetRepository<ITagRepository>().TagsWithPostsCount(pageSize).ToDTOs();
        }

        public int TotalCategories()
        {
            return Storage.GetRepository<ITagRepository>().TotalTags();
        }

        public int TotalPosts(bool checkIsPublished = true)
        {
            return Storage.GetRepository<IPostRepository>().TotalPosts(checkIsPublished);
        }

        public int TotalPostsForCategory(string categorySlug)
        {
            return Storage.GetRepository<IPostRepository>().TotalPostsForCategory(categorySlug);
        }

        public int TotalPostsForSearch(string search)
        {
            return Storage.GetRepository<IPostRepository>().TotalPostsForSearch(search);
        }

        public int TotalPostsForTag(string tagSlug)
        {
            return Storage.GetRepository<IPostRepository>().TotalPostsForTag(tagSlug);
        }

        public int TotalTags()
        {
            return Storage.GetRepository<ITagRepository>().TotalTags();
        }
    }
}
