using BLL.DTOs.AuthorDTO;
using BLL.DTOs.Response.ResponseEntity;

namespace BLL.Services.Author
{
    public interface IAuthorService
    {
        Task<ResponseEntity<IEnumerable<GetAuthorDTO>>> GetAllAuthorsAsync();
        Task<ResponseEntity<GetAuthorDTO>> GetAuthorByIdAsync(Guid id);
        Task<ResponseEntity<GetAuthorDTO>> InsertAuthorAsync(InsertAuthorDTO authorDTO);
        Task<ResponseEntity<GetAuthorDTO>> UpdateAuthorAsync(UpdateAuthorDTO updateAuthorDTO);
        Task<ResponseEntity> DeleteAuthorByIdAsync(Guid id);
    }
}
