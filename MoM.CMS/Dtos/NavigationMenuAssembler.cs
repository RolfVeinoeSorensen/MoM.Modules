using MoM.CMS.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoM.CMS.Dtos
{
    public static partial class NavigationMenuAssembler
    {
        static partial void OnDTO(this NavigationMenu entity, NavigationMenuDto dto);

        static partial void OnEntity(this NavigationMenuDto dto, NavigationMenu entity);

        public static NavigationMenu ToEntity(this NavigationMenuDto dto)
        {
            if (dto == null) return null;

            var entity = new NavigationMenu();

            entity.NavigationMenuId = dto.navigationMenuId;
            entity.Name = dto.name;
            entity.DisplayName = dto.displayName;
            entity.IconClass = dto.iconClass;
            dto.OnEntity(entity);

            return entity;
        }

        public static NavigationMenuDto ToDTO(this NavigationMenu entity)
        {
            if (entity == null) return null;

            var dto = new NavigationMenuDto();

            dto.navigationMenuId = entity.NavigationMenuId;
            dto.name = entity.Name;
            dto.displayName = entity.DisplayName;
            dto.iconClass = entity.IconClass;
            entity.OnDTO(dto);

            return dto;
        }

        public static List<NavigationMenu> ToEntities(this IEnumerable<NavigationMenuDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        public static List<NavigationMenuDto> ToDTOs(this IEnumerable<NavigationMenu> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }
    }
}
