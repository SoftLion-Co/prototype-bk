using BLL.DTOs.AuthorDTO;
using DAL.Entities.ResponseEntity;

namespace BLL.Services.Author
{
    public interface IAuthorService
    {
        Task<ResponseEntity<IEnumerable<GetAuthorDTO>>> GetAllAuthorsAsync();
        Task<ResponseEntity<GetAuthorDTO>> GetAuthorByIdAsync(Guid id);
        Task<ResponseEntity<GetAuthorDTO>> InsertAuthorAsync(InsertAuthorDTO authorDTO);
        Task<ResponseEntity<GetAuthorDTO>> UpdateAuthorAsync(UpdateAuthorDTO updateAuthorDTO);
        Task<ResponseEntity<IEnumerable<GetAuthorDTO>>> DeleteAuthorByIdAsync(Guid id);
    }
}
