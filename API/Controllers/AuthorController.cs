using BLL.DTOs.AuthorDTO;
using BLL.MediatR.Author;
using DAL.Entities.ResponseEntity;
using DAL.WrapperRepository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/author")]
    public class AuthorController : BaseApiController
    {
        /// <summary>
        ///  All informations about authors 
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with an IEnumerable of GetAuthorDTO</returns>
        [HttpGet]
        public async Task<ActionResult<ResponseEntity<IEnumerable<GetAuthorDTO>>>> GetAllAuthorsAsync()
        {
            return Ok(await Mediator.Send(new GetAllAuthorsQuery()));
        }
    }
}
