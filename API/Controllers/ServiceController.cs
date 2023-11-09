
using BLL.DTOs.ServiceDTO;
using BLL.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/service")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        /// <summary>
        ///  All informations about countries 
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with an IEnumerable of GetServiceDTO</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCountriesAsync()
        {
            var response = await _serviceService.GetAllCountriesAsync();
            return Ok(response);
        }
        /// <summary>
        /// Information about a specific service
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetServiceDTO</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceByIdAsync(Guid id)
        {
            var response = await _serviceService.GetServiceByIdAsync(id);
            return Ok(response);
        }
        /// <summary>
        /// To create an service
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetServiceDTO</returns>
        [HttpPost]
        public async Task<IActionResult> CreateServiceAsync([FromBody] InsertServiceDTO serviceDTO)
        {
            var response = await _serviceService.InsertServiceAsync(serviceDTO);
            return Ok(response);
        }
        /// <summary>
        /// To update an service by its Guid
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetServiceDTO</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateServiceAsync([FromBody] UpdateServiceDTO serviceDTO)
        {
            var response = await _serviceService.UpdateServiceAsync(serviceDTO);
            return Ok(response);
        }
        /// <summary>
        /// To delete an service by its Guid
        /// </summary>
        /// <returns>An ActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceById(Guid id)
        {
            var response = await _serviceService.DeleteServiceByIdAsync(id);
            return Ok(response);
        }
    }
}