using MoM.Tutorial.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoM.Tutorial.Dtos
{
    public static partial class HelloPlanetAssembler
    {
        static partial void OnDTO(this HelloPlanet entity, HelloPlanetDto dto);

        static partial void OnEntity(this HelloPlanetDto dto, HelloPlanet entity);

        public static HelloPlanet ToEntity(this HelloPlanetDto dto)
        {
            if (dto == null) return null;

            var entity = new HelloPlanet();

            entity.HelloPlanetId = dto.helloPlanetId;
            entity.Name = dto.name;
            entity.Description = dto.description;

            dto.OnEntity(entity);

            return entity;
        }

        public static HelloPlanetDto ToDTO(this HelloPlanet entity)
        {
            if (entity == null) return null;

            var dto = new HelloPlanetDto();

            dto.helloPlanetId = entity.HelloPlanetId;
            dto.name = entity.Name;
            dto.description = entity.Description;

            entity.OnDTO(dto);

            return dto;
        }

        public static List<HelloPlanet> ToEntities(this IEnumerable<HelloPlanetDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        public static List<HelloPlanetDto> ToDTOs(this IEnumerable<HelloPlanet> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }
    }
}
