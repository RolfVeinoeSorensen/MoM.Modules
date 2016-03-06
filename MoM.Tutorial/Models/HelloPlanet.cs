using MoM.Module.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoM.Tutorial.Models
{
    [Table("HelloPlanet", Schema = "Tutorial")]
    public class HelloPlanet : IDataEntity
    {
        public int HelloPlanetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
