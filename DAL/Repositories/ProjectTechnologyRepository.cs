using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;

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
            //var response = new ResponseEntity<IEnumerable<Technology>>();
            //return _context.ProjectTechnologies
            //.Where(pt => pt.ProjectId == Id)
            //.Select(pt => pt.Technology);
            throw new Exception();

        }
    }
}
