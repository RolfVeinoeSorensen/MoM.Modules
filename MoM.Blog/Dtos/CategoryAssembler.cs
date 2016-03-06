using System.Collections.Generic;
using System.Linq;
using MoM.Blog.Models;

namespace MoM.Blog.Dtos
{
    public static partial class CategoryAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="CategoryDto"/> converted from <see cref="Category"/>.</param>
        static partial void OnDTO(this Category entity, CategoryDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="Category"/> converted from <see cref="CategoryDto"/>.</param>
        static partial void OnEntity(this CategoryDto dto, Category entity);

        /// <summary>
        /// Converts this instance of <see cref="CategoryDto"/> to an instance of <see cref="Category"/>.
        /// </summary>
        /// <param name="dto"><see cref="CategoryDto"/> to convert.</param>
        public static Category ToEntity(this CategoryDto dto)
        {
            if (dto == null) return null;

            var entity = new Category();

            entity.CategoryId = dto.categoryId;
            entity.Name = dto.name;
            entity.UrlSlug = dto.urlSlug;
            entity.Description = dto.description;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="Category"/> to an instance of <see cref="CategoryDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="Category"/> to convert.</param>
        public static CategoryDto ToDTO(this Category entity)
        {
            if (entity == null) return null;

            var dto = new CategoryDto();

            dto.categoryId = entity.CategoryId;
            dto.name = entity.Name;
            dto.urlSlug = entity.UrlSlug;
            dto.description = entity.Description;
            dto.postCount = entity.Posts.Where(p => p.IsPublished == 1).Count();
            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="CategoryDto"/> to an instance of <see cref="Category"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<Category> ToEntities(this IEnumerable<CategoryDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="Category"/> to an instance of <see cref="CategoryDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<CategoryDto> ToDTOs(this IEnumerable<Category> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }
    }
}
