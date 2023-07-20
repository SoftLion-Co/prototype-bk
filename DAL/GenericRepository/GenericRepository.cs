using DAL.Context;
using DAL.Entities.Base;
using DAL.Entities.ResponseEntity;
using DAL.GenericRepository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DAL.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {

        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<TEntity> FindByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ResponseEntity<IEnumerable<TEntity>>> DeleteEntityByIdAsync(Guid ID)
        {
            var response = new ResponseEntity<IEnumerable<TEntity>>();

            var result = await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id ==ID);

            if (result == null)
            {
                throw new NullReferenceException($"Entity with this id {ID} not found");
            }

            _context.Set<TEntity>().Remove(result);

            response.Result = await _context.Set<TEntity>().AsNoTracking().ToListAsync();
            response.Message = $"Remove information from {typeof(GenericRepository<TEntity>).FullName}";

            return response;
        }

        private IQueryable<TEntity> GetQueryable(
        Expression<Func<TEntity, bool>>? predicate = default,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = default,
        Expression<Func<TEntity, TEntity>>? selector = default)
        {
            var query = _context.Set<TEntity>().AsNoTracking();

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

        public async Task<ResponseEntity<IEnumerable<TEntity>>> GetAllInformationAsync(
            Expression<Func<TEntity, TEntity>>? selector = default,
            Expression<Func<TEntity, bool>>? predicate = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = default)
        {
            var response = new ResponseEntity<IEnumerable<TEntity>>();

            response.Result = await GetQueryable(predicate, include, selector).ToListAsync();
            response.Message = $"Returned all information from {typeof(GenericRepository<TEntity>).FullName}";

            return response;
        }

        public async Task<ResponseEntity<TEntity>> GetEntityByIdAsync(Guid ID,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = default)
        {
            var response = new ResponseEntity<TEntity>();

            response.Result = await GetQueryable(include: include).FirstOrDefaultAsync(x=>x.Id == ID);
            response.Message = $"Returned all information from {typeof(GenericRepository<TEntity>).FullName}";

            return response;
        }
    

        public async Task<ResponseEntity<TEntity>> InsertEntityAsync(TEntity entity)
        {
            var response = new ResponseEntity<TEntity>();

            await _context.Set<TEntity>().AddAsync(entity);

            response.Result = entity;
            response.Message = $"Inserted all information from {typeof(GenericRepository<TEntity>).FullName}";

            return response;
        }

        public async Task<ResponseEntity<TEntity>> UploadEntityAsync(TEntity entity)
        {
            var response = new ResponseEntity<TEntity>();
            
            var result = await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.Id);

            if(result == null)
            {
                throw new NullReferenceException($"{entity.Id} not found");
            }

            _context.Set<TEntity>().Update(entity);

            response.Result = entity;
            response.Message = $"Updated all information from {typeof(GenericRepository<TEntity>).FullName}";

            return response;
        }

        public async Task Attach(TEntity entity) 
        {
            var result = await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.Id);

            await Task.Run(() => _context.Set<TEntity>().Entry(result).CurrentValues.SetValues(entity));
        }
    }
}
