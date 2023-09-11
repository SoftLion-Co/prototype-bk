
using BLL.DTOs.OrderBlogDTO;
using BLL.Services.OrderBlog;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/order-blog")]
    public class OrderBlogController : ControllerBase
    {
        private readonly IOrderBlogService _orderBlogService;

        public OrderBlogController(IOrderBlogService orderBlogService)
        {
            _orderBlogService = orderBlogService;
        }

        /// <summary>
        ///  All informations about orderBlogs 
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with an IEnumerable of GetOrderBlogDTO</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllOrderBlogsAsync()
        {
            var response = await _orderBlogService.GetAllOrderBlogsAsync();
            return Ok(response);
        }
        /// <summary>
        ///  To update type of orderBlog by id
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with an IEnumerable of GetOrderBlogDTO</returns>
        [HttpPut("change-type")]
        public async Task<IActionResult> ChangeTypeOrderAsync([FromQuery]Guid id, int typeNumber)
        {
            var response = await _orderBlogService.ChangeTypeOrderAsync(id, typeNumber);
            return Ok(response);
        }
        /// <summary>
        /// Information about a specific orderBlog
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetOrderBlogDTO</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderBlogByIdAsync(Guid id)
        {
            var response = await _orderBlogService.GetOrderBlogByIdAsync(id);
            return Ok(response);
        }
        /// <summary>
        /// To create an orderBlog
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetOrderBlogDTO</returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrderBlogAsync([FromBody] InsertOrderBlogDTO orderBlogDTO)
        {
            var response = await _orderBlogService.InsertOrderBlogAsync(orderBlogDTO);
            return Ok(response);
        }
        /// <summary>
        /// To update an orderBlog by its Guid
        /// </summary>
        /// <returns>An ActionResult containing a ResponseEntity with GetOrderBlogDTO</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateOrderBlogAsync([FromBody] UpdateOrderBlogDTO orderBlogDTO)
        {
            var response = await _orderBlogService.UpdateOrderBlogAsync(orderBlogDTO);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderBlogById(Guid id)
        {
            var response = await _orderBlogService.DeleteOrderBlogByIdAsync(id);
            return Ok(response);
        }
    }
}