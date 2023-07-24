using DAL.Entities;
using DAL.Entities.ResponseEntity;
using DAL.GenericRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IProjectTechnologyRepository 
    {
        IQueryable<Technology> GetAllTechnologiesAsync(Guid Id);
    }
}
