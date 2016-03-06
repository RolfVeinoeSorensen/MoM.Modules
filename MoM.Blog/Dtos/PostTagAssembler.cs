using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoM.Blog.Models;

namespace MoM.Blog.Dtos
{
    public static partial class PostTagAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="PostTagDto"/> converted from <see cref="Post"/>.</param>
        static partial void OnDTO(this PostTag entity, PostTagDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="PostTag"/> converted from <see cref="PostDto"/>.</param>
        static partial void OnEntity(this PostTagDto dto, PostTag entity);

        /// <summary>
        /// Converts this instance of <see cref="PPostTagDto"/> to an instance of <see cref="Post"/>.
        /// </summary>
        /// <param name="dto"><see cref="PostTagDto"/> to convert.</param>
        public static PostTag ToEntity(this PostTagDto dto)
        {
            if (dto == null) return null;

            var entity = new PostTag();

            entity.PostId = dto.postId;
            entity.Post = dto.post.ToEntity();
            entity.TagId = dto.tagId;
            entity.Tag = dto.tag.ToEntity();

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="PostTag"/> to an instance of <see cref="PostTagDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="PostTag"/> to convert.</param>
        public static PostTagDto ToDTO(this PostTag entity)
        {
            if (entity == null) return null;

            var dto = new PostTagDto();

            dto.postId = entity.PostId;
            dto.post = entity.Post.ToDTO();
            dto.tagId = entity.TagId;
            dto.tag = entity.Tag.ToDTO();

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="PostTagDto"/> to an instance of <see cref="PostTag"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<PostTag> ToEntities(this IEnumerable<PostTagDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="PostTag"/> to an instance of <see cref="PostTagDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<PostTagDto> ToDTOs(this IEnumerable<PostTag> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }
    }
}
