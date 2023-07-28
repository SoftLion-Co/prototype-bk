
using BLL.DTOs.OrderProjectDTO;
using BLL.Services.OrderProject;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/order-project")]
    public class OrderProjectController : ControllerBase
    {
        private readonly IOrderProjectService _orderProjectService;

        public OrderProjectController(IOrderProjectService orderProjectService)
        {
            _orderProjectService = orderProjectService;
        }

        /// <summary>
        ///  All informations about orderProjects 
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with an IEnumerable of GetOrderProjectDTO</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllOrderProjectsAsync()
        {
            var response = await _orderProjectService.GetAllOrderProjectsAsync();
            return Ok(response);
        }
        /// <summary>
        ///  To update type of orderProject by id
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with an IEnumerable of GetOrderProjectDTO</returns>
        [HttpPut("change-type")]
        public async Task<IActionResult> ChangeTypeOrderAsync([FromBody] Guid id, int typeNumber)
        {
            var response = await _orderProjectService.ChangeTypeOrderAsync(id, typeNumber);
            return Ok(response);
        }
        /// <summary>
        /// Information about a specific orderProject
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetOrderProjectDTO</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderProjectByIdAsync(Guid id)
        {
            var response = await _orderProjectService.GetOrderProjectByIdAsync(id);
            return Ok(response);
        }
        /// <summary>
        /// To create an orderProject
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetOrderProjectDTO</returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrderProjectAsync([FromBody] InsertOrderProjectDTO orderProjectDTO)
        {
            var response = await _orderProjectService.InsertOrderProjectAsync(orderProjectDTO);
            return Ok(response);
        }
        /// <summary>
        /// To update an orderProject by its Guid
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetOrderProjectDTO</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateOrderProjectAsync([FromBody] UpdateOrderProjectDTO orderProjectDTO)
        {
            var response = await _orderProjectService.UpdateOrderProjectAsync(orderProjectDTO);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderProjectById(Guid id)
        {
            var response = await _orderProjectService.DeleteOrderProjectByIdAsync(id);
            return Ok(response);
        }
    }
}