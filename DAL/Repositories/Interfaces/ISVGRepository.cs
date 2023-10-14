using DAL.Entities;
using DAL.GenericRepository.Interface;

namespace DAL.Repositories.Interfaces
{
    public interface ISVGRepository : IGenericRepository<SVG>
    {
        Task<IEnumerable<SVG>> FindPicturesByProjectId(Guid blog);
        Task<string> DeletePicturesByProjectId(IEnumerable<SVG> svgs);
    }
}
