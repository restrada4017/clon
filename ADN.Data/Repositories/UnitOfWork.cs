using ADN.Application.Contracts.Persistence;
using ADN.Data.Data;
using ADN.Domain.Entities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADN.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
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


        public async Task<int> Complete()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Err");
            }

        }


        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(BaseRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }

    }
}
