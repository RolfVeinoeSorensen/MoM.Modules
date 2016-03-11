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
            return DbSet.OrderBy(i => i.Name);
        }

        public void Init()
        {
            if (All().Count() == 0)
            {
                var items = Models.Init.HelloPlanetInit.HelloPlanetListV1;
                foreach(var item in items)
                {
                    DbSet.Add(item);
                }
                DatabaseContext.SaveChanges();
            }
        }
    }
}
