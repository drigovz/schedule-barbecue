using Api.Domain.Entities;
using Api.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Barbecue> Barbecues { get; set; }
        public DbSet<Participant> Participants { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Barbecue>(new BarbecueMap().Configure);
            modelBuilder.Entity<Participant>(new ParticipantMap().Configure);
        }
    }
}
