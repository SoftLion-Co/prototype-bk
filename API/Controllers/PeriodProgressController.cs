using BLL.DTOs.PeriodProgressDTO;
using BLL.Services.PeriodProgress;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/period-progress")]
    public class PeriodProgressController : ControllerBase
    {
        private readonly IPeriodProgressService _periodProgressService;

        public PeriodProgressController(IPeriodProgressService periodProgressService)
        {
            _periodProgressService = periodProgressService;
        }

        /// <summary>
        ///  All informations about periodProgresss 
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with an IEnumerable of GetPeriodProgressDTO</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllPeriodProgresssAsync()
        {
            var response = await _periodProgressService.GetAllPeriodProgresssAsync();
            return Ok(response);
        }
        /// <summary>
        /// Information about a specific periodProgress
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetPeriodProgressDTO</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPeriodProgressByIdAsync(Guid id)
        {
            var response = await _periodProgressService.GetPeriodProgressByIdAsync(id);
            return Ok(response);
        }
        /// <summary>
        /// Information about a periodProgresses  by OPS id
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetPeriodProgressDTO</returns>
        [HttpGet("order-project-status/{id}")]
        public async Task<IActionResult> GetPeriodProgressByOPSIdAsync(Guid id)
        {
            var response = await _periodProgressService.GetGetPeriodProgressByOPSIdAsync(id);
            return Ok(response);
        }
        /// <summary>
        /// To create an periodProgress
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetPeriodProgressDTO</returns>
        [HttpPost]
        public async Task<IActionResult> CreatePeriodProgressAsync([FromBody] InsertPeriodProgressDTO periodProgressDTO)
        {
            var response = await _periodProgressService.InsertPeriodProgressAsync(periodProgressDTO);
            return Ok(response);
        }
        /// <summary>
        /// To update an periodProgress by its Guid
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetPeriodProgressDTO</returns>
        [HttpPut]
        public async Task<IActionResult> UpdatePeriodProgressAsync([FromBody] UpdatePeriodProgressDTO periodProgressDTO)
        {
            var response = await _periodProgressService.UpdatePeriodProgressAsync(periodProgressDTO);
            return Ok(response);
        }
        /// <summary>
        /// To delete an periodProgress by its Guid
        /// </summary>
        /// <returns>An ActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeriodProgressById(Guid id)
        {
            var response = await _periodProgressService.DeletePeriodProgressByIdAsync(id);
            return Ok(response);
        }
    }
}
