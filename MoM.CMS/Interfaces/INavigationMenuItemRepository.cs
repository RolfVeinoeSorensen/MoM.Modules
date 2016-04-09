using MoM.CMS.Models;
using MoM.Module.Extensions;
using MoM.Module.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MoM.CMS.Interfaces
{
    public interface INavigationMenuItemRepository : IDataRepository
    {
        void Create(NavigationMenuItem entity);
        void Update(NavigationMenuItem entity);
        void Delete(NavigationMenuItem entity);
        IQueryable<NavigationMenuItem> Table();
        IQueryable<NavigationMenuItem> Fetch(Expression<Func<NavigationMenuItem, bool>> predicate);
        IQueryable<NavigationMenuItem> Fetch(Expression<Func<NavigationMenuItem, bool>> predicate, Action<Orderable<NavigationMenuItem>> order);
        IQueryable<NavigationMenuItem> Fetch(Expression<Func<NavigationMenuItem, bool>> predicate, Action<Orderable<NavigationMenuItem>> order, int skip, int count);
    }
}
