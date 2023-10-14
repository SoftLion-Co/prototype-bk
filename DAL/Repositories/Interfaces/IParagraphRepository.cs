using DAL.Entities;
using DAL.GenericRepository.Interface;

namespace DAL.Repositories.Interfaces
{
    public interface IParagraphRepository : IGenericRepository<Paragraph>
    {
        Task<IEnumerable<Paragraph>> FindPicturesByProjectId(Guid projectOrBlogId, bool projectOrBlog);
        Task<string> DeletePicturesByProjectId(IEnumerable<Paragraph> paragraphs);
    }
}
