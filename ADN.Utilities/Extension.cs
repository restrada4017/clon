using ADN.Domain.CustomEntities;
using ADN.Domain.Interfaces.Utilities;
using ADN.Utilities.AdnSequence;
using ADN.Utilities.Cache;
using AISC.Utilities.Keys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ADN.Utilities
{
    public static class Extension
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services.AddTransient<IAdnAnalyses, AdnAnalyses>();
            services.AddTransient<ICache, CacheRedis>();
            services.AddTransient<IKeys, AzureKeyvault>();
            IKeys keys;

            using (var serviceProvider = services.BuildServiceProvider())
            {
                IConfiguration configuration;
                configuration = serviceProvider.GetService<IConfiguration>();
                keys = serviceProvider.GetService<IKeys>();

                #region Caching 


                string connectionString = string.Empty;

                if (keys.IsUseKey())
                {
                    connectionString = keys.GetValueByKey("RedisCache").Result;
                }
                else
                {
                    connectionString = configuration.GetConnectionString("RedisCache");
                }

                services.AddStackExchangeRedisCache(option =>
                {
                    option.Configuration = connectionString;
                });
                #endregion
            }

            return services;
        }
    }
}
