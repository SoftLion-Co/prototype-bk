using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/value")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        [HttpGet("hi")]
        public async Task<string> Get()
        {
            return await Task.FromResult("HI, welcome to our site");
        }
    }
}
