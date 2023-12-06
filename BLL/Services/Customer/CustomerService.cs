using System.Net;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.DTOs.CustomerDTO;
using BLL.DTOs.Exceptions;
using BLL.DTOs.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using InvalidOperationException = BLL.DTOs.Exceptions.InvalidOperationException;

namespace BLL.Services.Customer;

public class CustomerService : ICustomerService
{
    private readonly UserManager<DAL.Entities.Customer> _userManager;
    private readonly IMapper _mapper;

    public CustomerService(UserManager<DAL.Entities.Customer> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<ResponseEntity<IEnumerable<GetCustomerDto>>> GetAllCustomersAsync()
    {
        return new ResponseEntity<IEnumerable<GetCustomerDto>>(HttpStatusCode.OK, await _userManager.Users.ProjectTo<GetCustomerDto>(_mapper.ConfigurationProvider).ToListAsync());
    }

    public async Task<ResponseEntity<GetCustomerDto>> GetCustomerByIdAsync(Guid id)
    {
        var user = await _userManager.Users.Include(x=>x.OrderProjectStatuses).ThenInclude(x=>x.PeriodProgresses).ThenInclude(x=>x.Service).FirstOrDefaultAsync(x => x.Id == id);
        if (user is null)
        {
            throw new NotFoundException("The user with such Id doesn't exist");
        }
        return new ResponseEntity<GetCustomerDto>(HttpStatusCode.OK, _mapper.Map<GetCustomerDto>(user));
    }

    public async Task<ResponseEntity<GetCustomerDto>> UpdateCustomerAsync(UpdateCustomerDto customerDto)
    {
        var customer = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == customerDto.Id);
        if (customer == null)
        {
            throw new NotFoundException("Customer with such id doesn't exist");
        }
        _mapper.Map(customerDto, customer);
        if (string.IsNullOrEmpty(customer.SecurityStamp))
        {
            await _userManager.UpdateSecurityStampAsync(customer);
        }
        await _userManager.UpdateAsync(customer);
        
        var responseDto = _mapper.Map<GetCustomerDto>(customer);
        return new ResponseEntity<GetCustomerDto>(HttpStatusCode.OK, responseDto);
    }

    public async Task<ResponseEntity> DeleteCustomerByIdAsync(Guid id)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (user is null)
        {
            throw new NotFoundException("User with such Id doesn't exist");
        }

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            throw new InvalidOperationException(result.Errors.Select(error => error.Description));
        }
        return new ResponseEntity(HttpStatusCode.OK);
    }
}