using MoM.Blog.Dtos;
using System.Collections.Generic;

namespace MoM.Blog.Interfaces
{
    public interface IBlogService
    {
        /// <summary>
        /// Return collection of posts based on pagination parameters.
        /// </summary>
        /// <param name="pageNo">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns></returns>
        IList<PostDto> Posts(int pageNo, int pageSize);

        /// <summary>
        /// Return collection of posts belongs to a particular tag.
        /// </summary>
        /// <param name="tagSlug">Tag's url slug</param>
        /// <param name="pageNo">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns></returns>
        IList<PostDto> PostsForTag(string tagSlug, int pageNo, int pageSize);

        /// <summary>
        /// Return collection of posts belongs to a particular category.
        /// </summary>
        /// <param name="categorySlug">Category's url slug</param>
        /// <param name="pageNo">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns></returns>
        IList<PostDto> PostsForCategory(string categorySlug, int pageNo, int pageSize);

        /// <summary>
        /// Return collection of posts that matches the search text.
        /// </summary>
        /// <param name="search">search text</param>
        /// <param name="pageNo">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns></returns>
        IList<PostDto> PostsForSearch(string search, int pageNo, int pageSize);

        /// <summary>
        /// Return total no. of all or published posts.
        /// </summary>
        /// <param name="checkIsPublished">True to count only published posts</param>
        /// <returns></returns>
        int TotalPosts(int isPublished = 1);

        /// <summary>
        /// Return total no. of posts belongs to a particular category.
        /// </summary>
        /// <param name="categorySlug">Category's url slug</param>
        /// <returns></returns>
        int TotalPostsForCategory(string categorySlug);

        /// <summary>
        /// Return total no. of posts belongs to a particular tag.
        /// </summary>
        /// <param name="tagSlug">Tag's url slug</param>
        /// <returns></returns>
        int TotalPostsForTag(string tagSlug);

        /// <summary>
        /// Return total no. of posts that matches the search text.
        /// </summary>
        /// <param name="search">search text</param>
        /// <returns></returns>
        int TotalPostsForSearch(string search);

        /// <summary>
        /// Return posts based on pagination and sorting parameters.
        /// </summary>
        /// <param name="pageNo">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="sortColumn">Sort column name</param>
        /// <param name="sortByAscending">True to sort by ascending</param>
        /// <returns></returns>
        IList<PostDto> Posts(int pageNo, int pageSize, string sortColumn, bool sortByAscending);

        /// <summary>
        /// Return post based on the published year, month and title slug.
        /// </summary>
        /// <param name="year">Published year</param>
        /// <param name="month">Published month</param>
        /// <param name="titleSlug">Post's url slug</param>
        /// <returns></returns>
        PostDto Post(int year, int month, string titleSlug);

        /// <summary>
        /// Return post based on unique id.
        /// </summary>
        /// <param name="id">Post unique id</param>
        /// <returns></returns>
        PostDto Post(int id);

        /// <summary>
        /// Adds a new post and returns the id.
        /// </summary>
        /// <param name="post"></param>
        /// <returns>Newly added post id</returns>
        void CreatePost(PostDto post);

        /// <summary>
        /// Update an existing post.
        /// </summary>
        /// <param name="post"></param>
        void UpdatePost(PostDto post);

        /// <summary>
        /// Delete the post permanently from database.
        /// </summary>
        /// <param name="post"></param>
        void DeletePost(PostDto post);

        /// <summary>
        /// Return all the categories where postcount > 0
        /// </summary>
        /// <returns></returns>
        IList<CategoryDto> Categories();

        /// <summary>
        /// Return all the categories with the number of post for each category.
        /// </summary>
        /// <returns></returns>
        IList<CategoryDto> CategoriesWithPostCount(int pageSize);

        /// <summary>
        /// Return total no. of categories.
        /// </summary>
        /// <returns></returns>
        int TotalCategories();

        /// <summary>
        /// Return category based on url slug.
        /// </summary>
        /// <param name="categorySlug">Category's url slug</param>
        /// <returns></returns>
        CategoryDto Category(string categorySlug);

        /// <summary>
        /// Return category based on id.
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns></returns>
        CategoryDto Category(int id);

        /// <summary>
        /// Add a new category.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        void CreateCategory(CategoryDto category);

        /// <summary>
        /// Update an existing category.
        /// </summary>
        /// <param name="category"></param>
        void UpdateCategory(CategoryDto category);

        /// <summary>
        /// Delete a category permanently.
        /// </summary>
        /// <param name="category"></param>
        void DeleteCategory(CategoryDto category);

        /// <summary>
        /// Return all the tags.
        /// </summary>
        /// <returns></returns>
        IList<TagDto> Tags();

        /// <summary>
        /// Return all the tags with a count of posts that uses the tag.
        /// </summary>
        /// <returns></returns>
        IList<TagDto> TagsWithPostsCount(int pageSize);

        /// <summary>
        /// Return total no. of tags.
        /// </summary>
        /// <returns></returns>
        int TotalTags();

        /// <summary>
        /// Return tag based on url slug.
        /// </summary>
        /// <param name="tagSlug"></param>
        /// <returns></returns>
        TagDto Tag(string tagSlug);

        /// <summary>
        /// Return tag based on unique id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TagDto Tag(int id);

        /// <summary>
        /// Add a new tag.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        void CreateTag(TagDto tag);

        /// <summary>
        /// Edit an existing tag.
        /// </summary>
        /// <param name="tag"></param>
        void UpdateTag(TagDto tag);

        /// <summary>
        /// Delete an existing tag permanently.
        /// </summary>
        /// <param name="tag"></param>
        void DeleteTag(TagDto tag);

        IList<PostDto> GetBlogPostsDateFormatted(IList<PostDto> postDtos);
    }
}
