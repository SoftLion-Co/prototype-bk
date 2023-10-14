using DAL.Context;
using DAL.Entities;
using DAL.GenericRepository;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ParagraphRepository : GenericRepository<Paragraph>,IParagraphRepository
    {
        public ParagraphRepository(DataContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Paragraph>> FindPicturesByProjectId(Guid projectOrBlogId, bool projectOrBlog)
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
        public async Task<string> DeletePicturesByProjectId(IEnumerable<Paragraph> paragraphs)
        {
            _dbSet.RemoveRange(paragraphs);
            return await Task.FromResult("Successful delete;");
        }
    }
}