

using ADN.Domain.Entities.Common;

namespace ADN.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {

        IAdnRepository AdnRepository { get; }
        
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

        Task<int> Complete();

        void SaveChanges();
        void BeginTransaction();
        void Commit();
        void Rollback();

        Task SaveChangesAsync();
    }
}
