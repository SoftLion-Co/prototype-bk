using DAL.Context;
using DAL.Entities;
using DAL.GenericRepository;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SVGRepository : GenericRepository<SVG>, ISVGRepository
    {
        public SVGRepository(DataContext context) : base(context)
        {
        }
        public async Task<IEnumerable<SVG>> FindPicturesByProjectId(Guid blogId)
        {
            return await _dbSet.Where(x => x.BlogId == blogId).ToListAsync();
        }
        
        public async Task<string> DeletePicturesByProjectId(IEnumerable<SVG> svgs)
        {
            _dbSet.RemoveRange(svgs);
            return await Task.FromResult("Successful delete;");
        }
    }
}
