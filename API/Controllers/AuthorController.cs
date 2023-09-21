using BLL.DTOs.AuthorDTO;
using BLL.Services.Author;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/author")]

    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        /// <summary>
        ///  All informations about authors 
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with an IEnumerable of GetAuthorDTO</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAuthorsAsync()
        {
            var response = await _authorService.GetAllAuthorsAsync();
            return Ok(response);
        }
        /// <summary>
        ///  All shart informations about authors 
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with an IEnumerable of GetTopAuthorDTO</returns>
        [AllowAnonymous]
        [HttpGet("get-short-all")]
        public async Task<IActionResult> GetAllTopAuthorsAsync()
        {
            var response = await _authorService.GetAllTopAuthorsAsync();
            return Ok(response);
        }
        /// <summary>
        /// Information about a specific author
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorByIdAsync(Guid id)
        {
            var response = await _authorService.GetAuthorByIdAsync(id);
            return Ok(response);
        }
        /// <summary>
        /// To create an author
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAuthorAsync([FromBody] InsertAuthorDTO authorDTO)
        {
            var response = await _authorService.InsertAuthorAsync(authorDTO);
            return Ok(response);
        }
        /// <summary>
        /// To update an author by its Guid
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetAuthorDTO</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAuthorAsync([FromBody] UpdateAuthorDTO authorDTO)
        {
            var response = await _authorService.UpdateAuthorAsync(authorDTO);
            return Ok(response);
        }
        /// <summary>
        /// To delete an author by its Guid
        /// </summary>
        /// <returns>An ActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorById(Guid id)
        {
            var response = await _authorService.DeleteAuthorByIdAsync(id);
            return Ok(response);
        }
    }
}
