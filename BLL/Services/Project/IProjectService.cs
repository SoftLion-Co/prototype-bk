using BLL.DTOs.ProjectDTO;
using BLL.DTOs.Response;

namespace BLL.Services.Project
{
    public interface IProjectService
    {
        Task<ResponseEntity<IEnumerable<GetProjectDTO>>> GetAllProjectsAsync();
        Task<ResponseEntity<GetProjectDTO>> GetProjectByIdAsync(Guid id);
        Task<ResponseEntity<GetProjectDTO>> InsertProjectAsync(InsertProjectDTO projectDTO);
        Task<ResponseEntity<GetProjectDTO>> UpdateProjectAsync(UpdateProjectDTO updateProjectDTO);
        Task<ResponseEntity<IEnumerable<GetProjectDTO>>> DeleteProjectByIdAsync(Guid id);
    }
}