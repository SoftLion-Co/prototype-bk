using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DAL.Context
{
    public class DataContext : IdentityDbContext<Customer, IdentityRole<Guid>, Guid>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Paragraph> Paragraphs { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<OrderBlog> OrderBlogs { get; set; }
        public DbSet<OrderProject> OrderProjects { get; set; }
        public DbSet<SVG> SVGs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<ProjectORBlogTechnology> ProjectORBlogTechnologies { get; set; }
        public DbSet<OrderProjectStatus> OrderProjectStatuses { get; set; }
        public DbSet<Service> Services { get; set; }

        //migrations : dotnet ef migrations add AddTableToDataBase --project ../DAL
        //database : dotnet ef database update

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
