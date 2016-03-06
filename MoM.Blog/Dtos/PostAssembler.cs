using System.Collections.Generic;
using System.Linq;
using MoM.Blog.Models;

namespace MoM.Blog.Dtos
{
    public static partial class PostAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="PostDto"/> converted from <see cref="Post"/>.</param>
        static partial void OnDTO(this Post entity, PostDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="Post"/> converted from <see cref="PostDto"/>.</param>
        static partial void OnEntity(this PostDto dto, Post entity);

        /// <summary>
        /// Converts this instance of <see cref="PostDto"/> to an instance of <see cref="Post"/>.
        /// </summary>
        /// <param name="dto"><see cref="PostDto"/> to convert.</param>
        public static Post ToEntity(this PostDto dto)
        {
            if (dto == null) return null;

            var entity = new Post();

            entity.PostId = dto.postId;
            entity.Title = dto.title;
            entity.ShortDescription = dto.shortDescription;
            entity.Description = dto.description;
            entity.Meta = dto.meta;
            entity.UrlSlug = dto.urlSlug;
            entity.IsPublished = dto.isPublished;
            entity.PostedDate = dto.postedDate;
            entity.ModifiedDate = dto.modifiedDate;
            entity.Category = dto.category.ToEntity();
            entity.PostTags = dto.postTags.ToEntities();

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="Post"/> to an instance of <see cref="PostDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="Post"/> to convert.</param>
        public static PostDto ToDTO(this Post entity)
        {
            if (entity == null) return null;

            var dto = new PostDto();

            dto.postId = entity.PostId;
            dto.title = entity.Title;
            dto.shortDescription = entity.ShortDescription;
            dto.description = entity.Description;
            dto.meta = entity.Meta;
            dto.urlSlug = entity.UrlSlug;
            dto.isPublished = entity.IsPublished;
            dto.postedDate = entity.PostedDate;
            dto.modifiedDate = entity.ModifiedDate;
            dto.category = entity.Category.ToDTO();
            dto.postTags = entity.PostTags.ToDTOs();

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="PostDto"/> to an instance of <see cref="Post"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<Post> ToEntities(this IEnumerable<PostDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="Post"/> to an instance of <see cref="PostDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<PostDto> ToDTOs(this IEnumerable<Post> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }
    }
}
