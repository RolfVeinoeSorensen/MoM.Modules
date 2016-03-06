using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using MoM.Tutorial.Models;

namespace MoM.Tutorial.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160306195449_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoM.Tutorial.Models.HelloPlanet", b =>
                {
                    b.Property<int>("HelloPlanetId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("HelloPlanetId");

                    b.HasAnnotation("Relational:Schema", "Tutorial");

                    b.HasAnnotation("Relational:TableName", "HelloPlanet");
                });
        }
    }
}
