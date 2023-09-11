using BLL.DTOs.CustomerDTO;
using BLL.DTOs.Response;

namespace BLL.Services.Customer;

public interface ICustomerService
{
    Task<ResponseEntity<IEnumerable<GetCustomerDto>>> GetAllCustomersAsync();
    Task<ResponseEntity<GetCustomerDto>> GetCustomerByIdAsync(Guid id);
    Task<ResponseEntity<GetCustomerDto>> UpdateCustomerAsync(UpdateCustomerDto customerDto);
    Task<ResponseEntity> DeleteCustomerByIdAsync(Guid id);
}