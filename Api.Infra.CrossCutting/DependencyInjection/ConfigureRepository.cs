using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Repository;
using Api.Infra.Data.Context;
using Api.Infra.Data.Implementations;
using Api.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infra.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IBarbecueRepository, BarbecueImplementation>();

            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer("Data Source=DESKTOP-8SL6PE8; initial catalog=BarbecueDb; user id=sa; password=sa12345; Integrated Security=True")
            );
        }
    }
}
