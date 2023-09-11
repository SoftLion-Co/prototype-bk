using BLL.DTOs.CustomerDTO;
using BLL.DTOs.Response;
using BLL.Services.Customer;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/customer")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    /// <summary>
    /// Information about all customers
    /// </summary>
    /// <returns>The ResponseEntity with GetCustomerDto</returns>
    [HttpGet]
    public async Task<ResponseEntity> GetAllBlogsAsync()
    {
        return await _customerService.GetAllCustomersAsync();
    }
    /// <summary>
    /// Information about a specific customer
    /// </summary>
    /// <returns>The ResponseEntity with GetCustomerDto</returns>
    [HttpGet("{id}")]
    public async Task<ResponseEntity> GetBlogByIdAsync(Guid id)
    {
        return await _customerService.GetCustomerByIdAsync(id);
    }
    /// <summary>
    /// Deletes Customer by id
    /// </summary>
    /// <returns>The ResponseEntity with status code of the operation</returns>
    [HttpDelete("{id}")]
    public async Task<ResponseEntity> DeleteCustomerByIdAsync(Guid id)
    {
        return await _customerService.DeleteCustomerByIdAsync(id);
    } 
    /// <summary>
    /// Deletes Customer by id
    /// </summary>
    /// <returns>The ResponseEntity with status code of the operation</returns>
    [HttpPut]
    public async Task<ResponseEntity> UpdateCustomerAsync(UpdateCustomerDto model)
    {
        return await _customerService.UpdateCustomerAsync(model);
    } 
}