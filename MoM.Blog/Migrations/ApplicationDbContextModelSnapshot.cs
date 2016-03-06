using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using MoM.Blog.Models;

namespace MoM.Blog.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoM.Blog.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("UrlSlug");

                    b.HasKey("CategoryId");

                    b.HasAnnotation("Relational:Schema", "Blog");

                    b.HasAnnotation("Relational:TableName", "Category");
                });

            modelBuilder.Entity("MoM.Blog.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryCategoryId");

                    b.Property<string>("Description");

                    b.Property<int>("IsPublished");

                    b.Property<string>("Meta");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<DateTime>("PostedDate");

                    b.Property<string>("ShortDescription");

                    b.Property<string>("Title");

                    b.Property<string>("UrlSlug");

                    b.HasKey("PostId");

                    b.HasAnnotation("Relational:Schema", "Blog");

                    b.HasAnnotation("Relational:TableName", "Post");
                });

            modelBuilder.Entity("MoM.Blog.Models.PostTag", b =>
                {
                    b.Property<int>("PostId");

                    b.Property<int>("TagId");

                    b.HasKey("PostId", "TagId");

                    b.HasAnnotation("Relational:Schema", "Blog");

                    b.HasAnnotation("Relational:TableName", "PostTag");
                });

            modelBuilder.Entity("MoM.Blog.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("UrlSlug");

                    b.HasKey("TagId");

                    b.HasAnnotation("Relational:Schema", "Blog");

                    b.HasAnnotation("Relational:TableName", "Tag");
                });

            modelBuilder.Entity("MoM.Blog.Models.Post", b =>
                {
                    b.HasOne("MoM.Blog.Models.Category")
                        .WithMany()
                        .HasForeignKey("CategoryCategoryId");
                });

            modelBuilder.Entity("MoM.Blog.Models.PostTag", b =>
                {
                    b.HasOne("MoM.Blog.Models.Post")
                        .WithMany()
                        .HasForeignKey("PostId");

                    b.HasOne("MoM.Blog.Models.Tag")
                        .WithMany()
                        .HasForeignKey("TagId");
                });
        }
    }
}
