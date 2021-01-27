using Api.Domain.Entities;
using Api.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public AppDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-8SL6PE8; initial catalog=BarbecueDb; user id=sa; password=sa12345; Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Barbecue>(new BarbecueMap().Configure);
            modelBuilder.Entity<Participant>(new ParticipantMap().Configure);
        }

        public DbSet<Barbecue> Barbecues { get; set; }
        public DbSet<Participant> Participants { get; set; }
    }
}
