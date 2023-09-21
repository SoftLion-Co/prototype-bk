
using BLL.DTOs.TechnologyDTO;
using BLL.Services.Technology;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/technology")]
    public class TechnologyController : ControllerBase
    {
        private readonly ITechnologyService _technologyService;

        public TechnologyController(ITechnologyService technologyService)
        {
            _technologyService = technologyService;
        }

        /// <summary>
        ///  All informations about technologies 
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with an IEnumerable of GetTechnologyDTO</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllTechnologiesAsync()
        {
            var response = await _technologyService.GetAllTechnologiesAsync();
            return Ok(response);
        }
        /// <summary>
        /// Information about a specific technology
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetTechnologyDTO</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTechnologyByIdAsync(Guid id)
        {
            var response = await _technologyService.GetTechnologyByIdAsync(id);
            return Ok(response);
        }
        /// <summary>
        /// To create an technology
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetTechnologyDTO</returns>
        [HttpPost]
        public async Task<IActionResult> CreateTechnologyAsync([FromBody] InsertTechnologyDTO technologyDTO)
        {
            var response = await _technologyService.InsertTechnologyAsync(technologyDTO);
            return Ok(response);
        }
        /// <summary>
        /// To update an technology by its Guid
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetTechnologyDTO</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateTechnologyAsync([FromBody] UpdateTechnologyDTO technologyDTO)
        {
            var response = await _technologyService.UpdateTechnologyAsync(technologyDTO);
            return Ok(response);
        }
        /// <summary>
        /// To delete an technology by its Guid
        /// </summary>
        /// <returns>An ActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnologyById(Guid id)
        {
            var response = await _technologyService.DeleteTechnologyByIdAsync(id);
            return Ok(response);
        }
    }
}