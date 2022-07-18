using sacramentplanner.Models;
using Microsoft.EntityFrameworkCore;
namespace sacramentplanner.Models
{
    public class SacramentPlannerContext : DbContext
    {
        public SacramentPlannerContext(DbContextOptions<SacramentPlannerContext> options)
            : base(options)
        {
        }
        public DbSet<Bishopric> Bishoprics { get; set; }
        public DbSet<Hymn> Hymns { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Talk> Talks { get; set; }
        public DbSet<SacramentPlan> SacramentPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bishopric>().ToTable("Bishopric");
            modelBuilder.Entity<Hymn>().ToTable("Hymn");
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Talk>().ToTable("Talk");
            modelBuilder.Entity<SacramentPlan>().ToTable("SacramentPlan");
            modelBuilder.Entity<SacramentPlan>()
                .HasMany(s => s.Talks)
                .WithOne(r => r.SacramentPlan)
                .OnDelete(DeleteBehavior.Cascade);            
        }
    }
}