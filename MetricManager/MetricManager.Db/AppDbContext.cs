using MetricManager.Entityes;
using Microsoft.EntityFrameworkCore;


namespace MetricManager.DB
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<AgentsEntity> Clients { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
