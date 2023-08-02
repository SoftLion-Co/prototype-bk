using System.Net;
using AutoMapper;
using BLL.DTOs.CustomerDTO;
using BLL.DTOs.Exceptions;
using BLL.DTOs.Response.ResponseEntity;
using BLL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly UserManager<DAL.Entities.Customer> _userManager;
    private readonly SignInManager<DAL.Entities.Customer> _signInManager;
    private readonly IMapper _mapper;

    public AuthService(UserManager<DAL.Entities.Customer> userManager, SignInManager<DAL.Entities.Customer> signInManager, IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
    }

    public async Task<ResponseEntity<GetCustomerDto>> SignInAsync(SignInModel model)
    {
        var customer = await _userManager.Users.FirstOrDefaultAsync(user => user.Email == model.Email);
        if (customer is null)
        {
            throw new NotFoundException("The user doesn't exist");
        }

        var validPassword = await _signInManager.CheckPasswordSignInAsync(customer, model.Password, false);
        if (!validPassword.Succeeded)
        {
            throw new NotFoundException("Passwords don't match");
        }

        return new ResponseEntity<GetCustomerDto>(HttpStatusCode.OK, _mapper.Map<GetCustomerDto>(customer));
    }

    public async Task<ResponseEntity> SignUpAsync(SignUpModel model)
    {
        var customer = await _userManager.Users.FirstOrDefaultAsync(user => user.Email == model.Email || user.PhoneNumber == model.PhoneNumber);
        if (customer is not null)
        {
            throw new ValidationException("The user with such credentials already exist");
        }
        var entity = _mapper.Map<DAL.Entities.Customer>(model);
        var result = await _userManager.CreateAsync(entity, model.Password);
        if (!result.Succeeded)
        {
            throw new ValidationException(result.Errors.Select(error => error.Description));
        }
        return new ResponseEntity<GetCustomerDto>(HttpStatusCode.Created, _mapper.Map<GetCustomerDto>(entity));
    }
}