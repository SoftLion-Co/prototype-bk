using DAL.Entities;
using DAL.GenericRepository.Interface;

namespace DAL.Repositories.Interfaces
{
    public interface IPictureRepository : IGenericRepository<Picture>
    {
        Task<IEnumerable<Picture>> FindPicturesByProjectId(Guid projectOrBlogId, bool projectOrBlog);
        Task<string> DeletePicturesByProjectId(IEnumerable<Picture> pictures);
    }
}
