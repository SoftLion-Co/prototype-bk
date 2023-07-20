using DAL.Entities.Base;
using DAL.Entities.ResponseEntity;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DAL.GenericRepository.Interface
{
    public interface IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<ResponseEntity<IEnumerable<TEntity>>> GetAllInformationAsync(
            Expression<Func<TEntity, TEntity>>? selector = default,
            Expression<Func<TEntity, bool>>? predicate = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = default);
        Task<ResponseEntity<TEntity>> GetEntityByIdAsync(Guid ID, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = default);
        Task<ResponseEntity<TEntity>> InsertEntityAsync(TEntity entity);
        Task<ResponseEntity<TEntity>> UploadEntityAsync(TEntity entity);
        Task<ResponseEntity<IEnumerable<TEntity>>> DeleteEntityByIdAsync(Guid ID);
        Task<TEntity> FindByIdAsync(Guid id);

        Task Attach(TEntity entity);
    }
}
