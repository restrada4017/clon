
using ADN.Application.Contracts.Persistence;
using ADN.Data.Data;
using ADN.Data.Repositories;
using ADN.Domain.CustomEntities;
using ADN.Domain.Entities;
using ADN.Domain.Interfaces.Utilities;
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
            IKeys keys;

            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
                keys = serviceProvider.GetService<IKeys>();
            }

            string connectionString = string.Empty;

            if (keys.IsUseKey())
            {
                connectionString = keys.GetValueByKey("DbADN").Result;
            }
            else
            {
                connectionString = configuration.GetConnectionString("DbADN");
            }


            // configuracion base de datos y manejo sql server Repositorio
            services.AddDbContext<DbADNContext>(options =>
                options.UseNpgsql(connectionString));


            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAdnRepository, AdnRepository>();

            return services;
        }
    }
}
