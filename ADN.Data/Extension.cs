
using ADN.Data.Data;
using ADN.Data.Repositories;
using ADN.Domain.Entities;
using ADN.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ADN.Data
{
    public static class Extension
    {

        public static IServiceCollection AddPersistenceSQL(this IServiceCollection services)
        {
            //Add services to use in Persistence
            IConfiguration configuration;


            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }

            // configuracion base de datos y manejo sql server Repositorio
            services.AddDbContext<DbADNContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DbADN")));

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
