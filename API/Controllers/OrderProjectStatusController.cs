using BLL.DTOs.OrderProjectStatusDTO;
using BLL.Services.OrderProjectStatus;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/order-project-status")]
    public class OrderProjectStatusController : ControllerBase
    {
        private readonly IOrderProjectStatusService _orderProjectStatusService;

        public OrderProjectStatusController(IOrderProjectStatusService orderProjectStatusService)
        {
            _orderProjectStatusService = orderProjectStatusService;
        }

        /// <summary>
        /// Information about a specific orderProjectStatus
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetOrderProjectStatusDTO</returns>
        [HttpGet("customer/{id}")]
        public async Task<IActionResult> GetOrderProjectStatusByCustomerIdAsync(Guid id)
        {
            var response = await _orderProjectStatusService.GetOrderProjectStatusByCustomerIdAsync(id);
            return Ok(response);
        }

        /// <summary>
        ///  All informations about orderProjectStatuss 
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with an IEnumerable of GetOrderProjectStatusDTO</returns>
        /// InProgress =0, Completed =1,OnHold = 2,Canceled =3
        [HttpGet]
        public async Task<IActionResult> GetAllOrderProjectStatusesAsync()
        {
            var response = await _orderProjectStatusService.GetAllOrderProjectStatusesAsync();
            return Ok(response);
        }
        /// <summary>
        ///  To update type of orderProjectStatus by id
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with an IEnumerable of GetOrderProjectStatusDTO</returns>
        [HttpPut("change-type")]
        public async Task<IActionResult> ChangeTypeAsync(Guid id, int typeNumber)
        {
            var response = await _orderProjectStatusService.ChangeTypeAsync(id, typeNumber);
            return Ok(response);
        }
        /// <summary>
        /// Information about a specific orderProjectStatus
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetOrderProjectStatusDTO</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderProjectStatusByIdAsync(Guid id)
        {
            var response = await _orderProjectStatusService.GetOrderProjectStatusByIdAsync(id);
            return Ok(response);
        }
        /// <summary>
        /// To create an orderProjectStatus
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetOrderProjectStatusDTO</returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrderProjectStatusAsync([FromBody] InsertOrderProjectStatusDTO orderProjectStatusDTO)
        {
            var response = await _orderProjectStatusService.InsertOrderProjectStatusAsync(orderProjectStatusDTO);
            return Ok(response);
        }
        /// <summary>
        /// To update an orderProjectStatus by its Guid
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetOrderProjectStatusDTO</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateOrderProjectStatusAsync([FromBody] UpdateOrderProjectStatusDTO orderProjectStatusDTO)
        {
            var response = await _orderProjectStatusService.UpdateOrderProjectStatusAsync(orderProjectStatusDTO);
            return Ok(response);
        }
        /// <summary>
        /// To delete an orderProjectStatus by its Guid
        /// </summary>
        /// <returns>An ActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderProjectStatusById(Guid id)
        {
            var response = await _orderProjectStatusService.DeleteOrderProjectStatusByIdAsync(id);
            return Ok(response);
        }
    }
}
