using System;
using System.Threading.Tasks;

namespace ADN.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAdnRepository AdnRepository { get; }

        void SaveChanges();
        void BeginTransaction();
        void Commit();
        void Rollback();
        Task SaveChangesAsync();
    }
}
