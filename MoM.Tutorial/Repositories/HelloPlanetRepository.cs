using MoM.Module.Base;
using MoM.Tutorial.Interfaces;
using MoM.Tutorial.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoM.Tutorial.Repositories
{
    public class HelloPlanetRepository : RepositoryBase<HelloPlanet>, IHelloPlanetRepository
    {
        public IEnumerable<HelloPlanet> All()
        {
            return dbSet.OrderBy(i => i.Name);
        }
    }
}
