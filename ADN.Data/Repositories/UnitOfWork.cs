using ADN.Data.Data;
using ADN.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADN.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAdnRepository _adnRepository;
     
        private readonly DbADNContext _context;


        public IAdnRepository AdnRepository => _adnRepository ?? new AdnRepository(_context);
       
        public UnitOfWork(DbADNContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.Database.CommitTransaction();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }

        public void SaveChanges()
        {
            _context.ChangeTracker.DetectChanges();
            _context.SaveChanges();
            _context.ChangeTracker.AutoDetectChangesEnabled = true;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
