using MoM.CMS.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoM.CMS.Dtos
{
    public static partial class NavigationMenuItemAssembler
    {
        static partial void OnDTO(this NavigationMenuItem entity, NavigationMenuItemDto dto);

        static partial void OnEntity(this NavigationMenuItemDto dto, NavigationMenuItem entity);

        public static NavigationMenuItem ToEntity(this NavigationMenuItemDto dto)
        {
            if (dto == null) return null;

            var entity = new NavigationMenuItem();

            entity.NavigationMenuItemId = entity.NavigationMenuItemId;
            entity.Parent = dto.parent.ToEntity();
            entity.Name = dto.name;
            entity.DisplayName = dto.displayName;
            entity.RouterLink = dto.routerLink;
            entity.IconClass = dto.iconClass;
            entity.SortOrder = dto.sortOrder;
            entity.NavigationMenu = dto.navigationMenu.ToEntity();
            
            dto.OnEntity(entity);

            return entity;
        }

        public static NavigationMenuItemDto ToDTO(this NavigationMenuItem entity)
        {
            if (entity == null) return null;

            var dto = new NavigationMenuItemDto();

            dto.navigationMenuItemId = entity.NavigationMenuItemId;
            dto.parent = entity.Parent.ToDTO();
            dto.name = entity.Name;
            dto.displayName = entity.DisplayName;
            dto.routerLink = entity.RouterLink;
            dto.iconClass = entity.IconClass;
            dto.sortOrder = entity.SortOrder;
            dto.navigationMenu = entity.NavigationMenu.ToDTO();

            entity.OnDTO(dto);

            return dto;
        }

        public static List<NavigationMenuItem> ToEntities(this IEnumerable<NavigationMenuItemDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        public static List<NavigationMenuItemDto> ToDTOs(this IEnumerable<NavigationMenuItem> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }
    }
}
