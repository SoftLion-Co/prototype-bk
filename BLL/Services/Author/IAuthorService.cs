using BLL.DTOs.AuthorDTO;
using BLL.DTOs.Response;

namespace BLL.Services.Author
{
    public interface IAuthorService
    {
        Task<ResponseEntity<IEnumerable<GetAuthorDTO>>> GetAllAuthorsAsync();
        Task<ResponseEntity<GetAuthorDTO>> GetAuthorByIdAsync(Guid id);
        Task<ResponseEntity<GetAuthorDTO>> InsertAuthorAsync(InsertAuthorDTO authorDTO);
        Task<ResponseEntity<GetAuthorDTO>> UpdateAuthorAsync(UpdateAuthorDTO updateAuthorDTO);
        Task<ResponseEntity<IEnumerable<GetTopAuthorDTO>>> GetAllTopAuthorsAsync();
        Task<ResponseEntity> DeleteAuthorByIdAsync(Guid id);
    }
}
