using DAL.Context;
using DAL.Entities;
using DAL.GenericRepository;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PictureRepository : GenericRepository<Picture>, IPictureRepository
    {
        public PictureRepository(DataContext context) : base(context)
        {        }
        public async Task<IEnumerable<Picture>> FindPicturesByProjectId(Guid projectOrBlogId, bool projectOrBlog)
        {
            if (projectOrBlog)
            {
                return await _dbSet.Where(x => x.ProjectId == projectOrBlogId).ToListAsync();
            }
            else
            {
                return await _dbSet.Where(x => x.BlogId == projectOrBlogId).ToListAsync();
            }
        }
        public async Task<string> DeletePicturesByProjectId(IEnumerable<Picture> pictures)
        {
            _dbSet.RemoveRange(pictures);
            return await Task.FromResult("Successful delete;");
        }

    }
}
