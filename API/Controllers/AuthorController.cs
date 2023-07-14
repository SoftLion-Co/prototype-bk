using BLL.MediatR.Authors;
using DAL.WrapperRepository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/author")]
    public class AuthorController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            return Ok(await Mediator.Send(new GetAllAuthorsQuery()));
        }
    }
}
