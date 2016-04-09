using System;
using System.Linq;
using System.Linq.Expressions;
using MoM.CMS.Interfaces;
using MoM.CMS.Models;
using MoM.Module.Base;
using MoM.Module.Extensions;

namespace MoM.CMS.Repositories
{
    public class NavigationMenuRepository : RepositoryBase<NavigationMenu>, INavigationMenuRepository
    {
        public void Create(NavigationMenu entity)
        {
            DbSet.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(NavigationMenu entity)
        {
            DbSet.Remove(entity);
            Db.SaveChanges();
        }

        public IQueryable<NavigationMenu> Fetch(Expression<Func<NavigationMenu, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<NavigationMenu> Fetch(Expression<Func<NavigationMenu, bool>> predicate, Action<Orderable<NavigationMenu>> order)
        {
            var orderable = new Orderable<NavigationMenu>(Fetch(predicate));
            order(orderable);
            return orderable.Queryable;
        }

        public IQueryable<NavigationMenu> Fetch(Expression<Func<NavigationMenu, bool>> predicate, Action<Orderable<NavigationMenu>> order, int skip, int count)
        {
            return Fetch(predicate, order).Skip(skip).Take(count);
        }

        public IQueryable<NavigationMenu> Table()
        {
            return DbSet.AsQueryable();
        }

        public void Update(NavigationMenu entity)
        {
            DbSet.Update(entity);
            Db.SaveChanges();
        }
    }
}
