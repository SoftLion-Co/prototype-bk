using DAL.Entities.Base;
using DAL.Entities.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GenericRepository.Interface
{
    public interface IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<ResponseEntity<IEnumerable<TEntity>>> GetAllInformationAsync();
        Task<ResponseEntity<TEntity>> GetEntityByIdAsync(Guid ID);
        Task<ResponseEntity<TEntity>> InsertEntityAsync(TEntity entity);
        Task<ResponseEntity<TEntity>> UploadEntityAsync(TEntity entity);
        Task<ResponseEntity<IEnumerable<TEntity>>> DeleteEntityByIdAsync(Guid ID);
    }
}
