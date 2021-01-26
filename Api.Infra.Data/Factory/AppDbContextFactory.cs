using Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Infra.Data.Factory
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            string connectionString = "Data Source=DESKTOP-8SL6PE8; initial catalog=BarbecueDb; user id=sa; password=sa12345; Integrated Security=True";
            var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionBuilder.UseSqlServer(connectionString);
            return new AppDbContext(optionBuilder.Options);
        }
    }
}
