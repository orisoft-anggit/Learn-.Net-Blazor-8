using LearningBlazorApps.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LearningBlazorApps.Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(x => x.Title).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Book>().Property(x => x.Author).IsRequired().HasMaxLength(100);
        }

        public DbSet<Book> Books { get; set; }
    }

    //instance for migration specific design db context
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../LearningBlazorApps/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<DataContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new DataContext(builder.Options);
        }
    }


}

