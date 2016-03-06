using System.Collections.Generic;
using System.Linq;
using MoM.Blog.Models;

namespace MoM.Blog.Dtos
{
    public static partial class TagAssembler
    {
        static partial void OnDTO(this Tag entity, TagDto dto);

        static partial void OnEntity(this TagDto dto, Tag entity);

        public static Tag ToEntity(this TagDto dto)
        {
            if (dto == null) return null;

            var entity = new Tag();

            entity.TagId = dto.tagId;
            entity.Name = dto.name;
            entity.UrlSlug = dto.urlSlug;
            entity.Description = dto.description;
            //entity.BlogPost = dto.BlogPost.ToEntities();
            dto.OnEntity(entity);

            return entity;
        }

        public static TagDto ToDTO(this Tag entity)
        {
            if (entity == null) return null;

            var dto = new TagDto();

            dto.tagId = entity.TagId;
            dto.name = entity.Name;
            dto.urlSlug = entity.UrlSlug;
            dto.description = entity.Description;
            //dto.BlogPost = entity.BlogPost.ToDTOs();
            entity.OnDTO(dto);

            return dto;
        }

        public static List<Tag> ToEntities(this IEnumerable<TagDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        public static List<TagDto> ToDTOs(this IEnumerable<Tag> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }
    }
}
