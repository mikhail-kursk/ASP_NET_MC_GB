using MetricAgent.Entityes;
using Microsoft.EntityFrameworkCore;


namespace MetricAgent.DB
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<CpuEntity> CpuMetrics { get; set; }
        public DbSet<HddEntity> HddMetrics { get; set; }
        public DbSet<NetworkEntity> NetworkMetrics { get; set; }
        public DbSet<RamEntity> RamMetrics { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
