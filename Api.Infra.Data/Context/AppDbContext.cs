using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Barbecue> Barbecues { get; set; }
        public DbSet<Participant> Participants { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
        }
    }
}
