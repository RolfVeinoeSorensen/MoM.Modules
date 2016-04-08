using MoM.CMS.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoM.CMS.Dtos
{
    public static partial class NavigationMenuNavigationMenuItemAssembler
    {
        static partial void OnDTO(this NavigationMenuNavigationMenuItem entity, NavigationMenuNavigationMenuItemDto dto);

        static partial void OnEntity(this NavigationMenuNavigationMenuItemDto dto, NavigationMenuNavigationMenuItem entity);

        public static NavigationMenuNavigationMenuItem ToEntity(this NavigationMenuNavigationMenuItemDto dto)
        {
            if (dto == null) return null;

            var entity = new NavigationMenuNavigationMenuItem();

            entity.NavigationMenuId = dto.navigationMenuId;
            entity.NavigationMenu = dto.navigationMenu.ToEntity();
            entity.NavigationMenuItemId = dto.navigationMenuItemId;
            entity.NavigationMenuItem = dto.navigationMenuItem.ToEntity();

            dto.OnEntity(entity);

            return entity;
        }

        public static NavigationMenuNavigationMenuItemDto ToDTO(this NavigationMenuNavigationMenuItem entity)
        {
            if (entity == null) return null;

            var dto = new NavigationMenuNavigationMenuItemDto();

            dto.navigationMenuId = entity.NavigationMenuId;
            dto.navigationMenu = entity.NavigationMenu.ToDTO();
            dto.navigationMenuItemId = entity.NavigationMenuItemId;
            dto.navigationMenuItem = entity.NavigationMenuItem.ToDTO();
            entity.OnDTO(dto);

            return dto;
        }

        public static List<NavigationMenuNavigationMenuItem> ToEntities(this IEnumerable<NavigationMenuNavigationMenuItemDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        public static List<NavigationMenuNavigationMenuItemDto> ToDTOs(this IEnumerable<NavigationMenuNavigationMenuItem> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }
    }
}
