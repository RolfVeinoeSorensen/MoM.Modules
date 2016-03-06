using MoM.Module.Interfaces;
using Microsoft.Data.Entity;

namespace MoM.Tutorial.Models
{
    public class DataModelRegistrator : IDataModelRegistrator
    {
        public void RegisterModels(ModelBuilder modelBuilder)
        {
            // build the model
            ModelBuilderFactory.BuildModels(modelBuilder);
            //Add data to tables
            
        }
    }
}
