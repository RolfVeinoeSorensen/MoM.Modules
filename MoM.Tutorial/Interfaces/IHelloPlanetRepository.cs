using MoM.Module.Interfaces;
using MoM.Tutorial.Models;
using System.Collections.Generic;

namespace MoM.Tutorial.Interfaces
{
    public interface IHelloPlanetRepository : IDataRepository
    {
        IEnumerable<HelloPlanet> All();
    }
}
