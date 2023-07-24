using BLL.DTOs.AuthorDTO;
using BLL.MediatR.Author;
using BLL.MediatR.Author.CreateAuthor;
using BLL.MediatR.Author.DeleteAuthor;
using BLL.MediatR.Author.GetAllAuthors;
using BLL.MediatR.Author.GetAuthorById;
using BLL.MediatR.Author.UpdateAuthor;
using DAL.Entities.ResponseEntity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/authors")]
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
        /// <summary>
        /// Information about a specific author
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseEntity<GetAuthorDTO>>> GetAuthorByIdAsync(Guid id)
        {
            return Ok(await Mediator.Send(new GetAuthorByIdQuery(id)));
        }
        /// <summary>
        /// To create an author
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO</returns>
        [HttpPost]
        public async Task<ActionResult<ResponseEntity<GetAuthorDTO>>> CreateAuthorAsync(InsertAuthorDTO authorDTO)
        {
            return Ok(await Mediator.Send(new CreateAuthorCommand(authorDTO)));
        }
        /// <summary>
        /// To update an author by its Guid
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAuthorAsync(UpdateAuthorDTO authorDTO)
        {
            return Ok(await Mediator.Send(new UpdateAuthorCommand(authorDTO)));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseEntity<IEnumerable<GetAuthorDTO>>>> DeleteAuthorById(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteAuthorCommand(id)));
        }
    }
}
