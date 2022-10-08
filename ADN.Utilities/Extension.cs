using ADN.Domain.Interfaces.Utilities;
using ADN.Utilities.AdnSequence;
using ADN.Utilities.Cache;
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

            using (var serviceProvider = services.BuildServiceProvider())
            {
                IConfiguration configuration;
                configuration = serviceProvider.GetService<IConfiguration>();
                #region Caching 
                services.AddStackExchangeRedisCache(option =>
                {
                    option.Configuration = configuration.GetConnectionString("RedisCache");
                });
                #endregion
            }

            return services;
        }
    }
}
