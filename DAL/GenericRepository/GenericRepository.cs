using DAL.Context;
using DAL.Entities.Base;
using DAL.Entities.ResponseEntity;
using DAL.GenericRepository.Interface;
using Microsoft.EntityFrameworkCore;


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

        public async Task<ResponseEntity<IEnumerable<TEntity>>> GetAllInformationAsync()
        {
            var response = new ResponseEntity<IEnumerable<TEntity>>();

            response.Result = await _context.Set<TEntity>().AsNoTracking().ToListAsync();
            response.Message = $"Returned all information from {typeof(GenericRepository<TEntity>).FullName}";

            return response;
        }

        public async Task<ResponseEntity<TEntity>> GetEntityByIdAsync(Guid ID)
        {
            var response = new ResponseEntity<TEntity>();

            response.Result = await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x=>x.Id == ID);
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
    }
}
