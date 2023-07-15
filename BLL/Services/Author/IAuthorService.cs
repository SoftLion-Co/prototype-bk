using BLL.DTOs.AuthorDTO;
using DAL.Entities.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Author
{
    public interface IAuthorService
    {
        Task<ResponseEntity<IEnumerable<GetAuthorDTO>>> GetAllAuthorsAsync();
    }
}
