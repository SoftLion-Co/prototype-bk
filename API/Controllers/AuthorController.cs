using BLL.MediatR.Authors;
using DAL.WrapperRepository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : BaseApiController
    {
        private readonly IWrapperRepository _repository;
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            //var result = await _repository.AuthorRepository.GetAllInformationAsync();
            //return Ok(result);
            return Ok(await Mediator.Send(new GetAllAuthorsQuery()));
        }
    }
}
