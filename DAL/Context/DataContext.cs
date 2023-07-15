using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DAL.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Paragraph> Paragraphs { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<OrderBlog> OrderBlogs { get; set; }
        public DbSet<OrderProject> OrderProjects { get; set; }
        public DbSet<SVG> SVGs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Technology> technologies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
        }
    }
}
