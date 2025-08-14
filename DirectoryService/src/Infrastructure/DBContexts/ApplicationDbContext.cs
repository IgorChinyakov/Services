using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.DBContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Department> Departments => Set<Department>();

        public DbSet<Location> Locations => Set<Location>();

        public DbSet<Position> Positions => Set<Position>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
            .UseLoggerFactory(LoggerFactory.Create(build => build.AddConsole()));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
