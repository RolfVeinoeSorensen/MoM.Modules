using MoM.CMS.Interfaces;
using MoM.CMS.Models;
using MoM.Module.Base;
using MoM.Module.Extensions;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MoM.CMS.Repositories
{
    public class NavigationMenuItemRepository : RepositoryBase<NavigationMenuItem>, INavigationMenuItemRepository
    {
        public void Create(NavigationMenuItem entity)
        {
            DbSet.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(NavigationMenuItem entity)
        {
            DbSet.Remove(entity);
            Db.SaveChanges();
        }

        public IQueryable<NavigationMenuItem> Fetch(Expression<Func<NavigationMenuItem, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<NavigationMenuItem> Fetch(Expression<Func<NavigationMenuItem, bool>> predicate, Action<Orderable<NavigationMenuItem>> order)
        {
            var orderable = new Orderable<NavigationMenuItem>(Fetch(predicate));
            order(orderable);
            return orderable.Queryable;
        }

        public IQueryable<NavigationMenuItem> Fetch(Expression<Func<NavigationMenuItem, bool>> predicate, Action<Orderable<NavigationMenuItem>> order, int skip, int count)
        {
            return Fetch(predicate, order).Skip(skip).Take(count);
        }

        public IQueryable<NavigationMenuItem> Table()
        {
            return DbSet.AsQueryable();
        }

        public void Update(NavigationMenuItem entity)
        {
            DbSet.Update(entity);
            Db.SaveChanges();
        }
    }
}
