using DAL.Entities.Base;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DAL.GenericRepository.Interface
{
    public interface IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, TEntity>>? selector = default,
            Expression<Func<TEntity, bool>>? predicate = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = default);
        Task<TEntity> GetEntityByIdAsync(
            Guid id,
            Expression<Func<TEntity, TEntity>>? selector = default,
            Expression<Func<TEntity, bool>>? predicate = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = default);
        Task<TEntity> InsertEntityAsync(TEntity entity);
        Task<TEntity> UploadEntityAsync(TEntity entity);
        Task DeleteEntityByIdAsync(TEntity entity);
        Task<TEntity> FindByIdAsync(Guid id);

    }
}
