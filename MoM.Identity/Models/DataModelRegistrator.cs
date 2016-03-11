using Microsoft.Data.Entity;
using MoM.Module.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoM.Identity.Models
{
    public class DataModelRegistrator : IDataModelRegistrator
    {
        public void RegisterModels(ModelBuilder modelBuilder)
        {
            // build the model
            ModelBuilderFactory.BuildModels(modelBuilder);
            //modelBuilder.Entity<HelloPlanet>(etb =>
            //{
            //    etb.HasKey(e => e.HelloPlanetId);
            //    etb.Property(e => e.HelloPlanetId);
            //    etb.ForSqlServerToTable("HelloPlanet", "Tutorial");
            //});
            //Add data to tables
            //modelBuilder.Entity<HelloPlanet>();
        }
    }
}
