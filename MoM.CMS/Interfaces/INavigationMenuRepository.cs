using MoM.CMS.Models;
using MoM.Module.Extensions;
using MoM.Module.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MoM.CMS.Interfaces
{
    public interface INavigationMenuRepository : IDataRepository
    {
        void Create(NavigationMenu entity);
        void Update(NavigationMenu entity);
        void Delete(NavigationMenu entity);
        IQueryable<NavigationMenu> Table();
        IQueryable<NavigationMenu> Fetch(Expression<Func<NavigationMenu, bool>> predicate);
        IQueryable<NavigationMenu> Fetch(Expression<Func<NavigationMenu, bool>> predicate, Action<Orderable<NavigationMenu>> order);
        IQueryable<NavigationMenu> Fetch(Expression<Func<NavigationMenu, bool>> predicate, Action<Orderable<NavigationMenu>> order, int skip, int count);
    }
}
