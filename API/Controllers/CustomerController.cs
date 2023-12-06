using Azure;
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
    public async Task<IActionResult> GetAllCustomersAsync()
    {
        var response = await _customerService.GetAllCustomersAsync();
        return Ok(response);
    }
    /// <summary>
    /// Information about a specific customer
    /// </summary>
    /// <returns>The ResponseEntity with GetCustomerDto</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerByIdAsync(Guid id)
    {
        var response = await _customerService.GetCustomerByIdAsync(id);
        return Ok(response);
    }
    /// <summary>
    /// Deletes Customer by id
    /// </summary>
    /// <returns>The ResponseEntity with status code of the operation</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomerByIdAsync(Guid id)
    {
        var response = await _customerService.DeleteCustomerByIdAsync(id);
        return Ok(response);
    } 
    /// <summary>
    /// Deletes Customer by id
    /// </summary>
    /// <returns>The ResponseEntity with status code of the operation</returns>
    [HttpPut]
    public async Task<IActionResult> UpdateCustomerAsync(UpdateCustomerDto model)
    {
        var response = await _customerService.UpdateCustomerAsync(model);
        return Ok(response);
    } 
}