using DAL.Context;
using DAL.Entities.Base;
using DAL.GenericRepository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DAL.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> _dbSet;
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> FindByIdAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteEntityByIdAsync(Guid id)
        {
            var result = await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                throw new NullReferenceException($"Entity with this id {id} not found");
            }

            _dbSet.Remove(result);
        }

        public async Task<IQueryable<TEntity>> GetAllInformationQueryableAsync(
           Expression<Func<TEntity, TEntity>>? selector = default,
           Expression<Func<TEntity, bool>>? predicate = default,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = default)
        {
            var entities = await Task.Run(() => GetQueryable(predicate, include, selector));

            if (entities == null)
            {
                throw new NullReferenceException("not found");
            }

            return entities;
        }

        private IQueryable<TEntity> GetQueryable(
        Expression<Func<TEntity, bool>>? predicate = default,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = default,
        Expression<Func<TEntity, TEntity>>? selector = default)
        {
            var query = _dbSet.AsNoTracking();

            if (include is not null)
            {
                query = include(query);
            }

            if (predicate is not null)
            {
                query = query.Where(predicate);
            }

            if (selector is not null)
            {
                query = query.Select(selector);
            }

            return query.AsNoTracking();
        }

        public async Task<IQueryable<TEntity>> GetAllInformationAsync(
            Expression<Func<TEntity, TEntity>>? selector = default,
            Expression<Func<TEntity, bool>>? predicate = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = default)
        {
            return GetQueryable(predicate, include, selector);
        }

        public async Task<TEntity> GetEntityByIdAsync(
            Guid id,
            Expression<Func<TEntity, TEntity>>? selector = default,
            Expression<Func<TEntity, bool>>? predicate = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = default)
        {

            return await GetQueryable(predicate, include, selector).FirstOrDefaultAsync(x => x.Id == id);
        }
    
        public async Task<TEntity> InsertEntityAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<TEntity> UploadEntityAsync(TEntity entity)
        {

            var result = await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.Id);

            if(result == null)
            {
                throw new NullReferenceException($"{entity.Id} not found");
            }

            _dbSet.Entry(result).CurrentValues.SetValues(entity);

            return entity;
        }
    }
}
