using DAL.Context;
using DAL.Entities;
using DAL.Entities.ResponseEntity;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProjectTechnologyRepository : IProjectTechnologyRepository
    {
        private readonly DataContext _context;

        public ProjectTechnologyRepository(DataContext context)
        {
            _context = context;
        }
        public IQueryable<Technology> GetAllTechnologiesAsync(Guid Id)
        {
            var response = new ResponseEntity<IEnumerable<Technology>>();
            return _context.ProjectTechnologies
            .Where(pt => pt.ProjectId == Id)
            .Select(pt => pt.Technology);


        }
    }
}
