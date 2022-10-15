using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADN.Data.Data
{
    public partial class DbADNContext : DbContext
    {

        private readonly ILogger _logger;

        public DbADNContext(DbContextOptions<DbADNContext> options, ILogger Logger)
            : base(options)
        {
            this._logger = Logger;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
