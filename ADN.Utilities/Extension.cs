using ADN.Domain.Interfaces.Utilities;
using ADN.Utilities.AdnSequence;
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

            return services;
        }
    }
}
