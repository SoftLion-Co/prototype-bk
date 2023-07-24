using DAL.Context;
using DAL.Entities;
using DAL.GenericRepository;
using DAL.Helpers;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly DataContext _context;
        public ProjectRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedList<Project>> GetProducts(ItemParameters itemParameters)
        {
            var projects = await _context.Projects.ToListAsync();

            return PagedList<Project>.ToPagedList(projects, itemParameters.PageNumber, itemParameters.PageSize);
        }
    }
}
