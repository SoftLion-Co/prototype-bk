using System.Net;
using System.Security.Claims;
using AutoMapper;
using BLL.DTOs.Exceptions;
using BLL.DTOs.Response;
using BLL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly UserManager<DAL.Entities.Customer> _userManager;
    private readonly SignInManager<DAL.Entities.Customer> _signInManager;
    private readonly IMapper _mapper;
    private readonly JwtOptions _options;

    public AuthService(UserManager<DAL.Entities.Customer> userManager, SignInManager<DAL.Entities.Customer> signInManager, IMapper mapper, JwtOptions options)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _options = options;
    }

    public async Task<ResponseEntity<SignInResponse>> SignInAsync(SignInModel model)
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

        var accessToken = JwtService.JwtService.GenerateAccessToken(_options, GenerateClaimsIdentity(customer));
        var refreshToken = JwtService.JwtService.GenerateRefreshToken(_options);
        
        return new ResponseEntity<SignInResponse>(HttpStatusCode.Created, new SignInResponse() {AccessToken = accessToken, RefreshToken = refreshToken});
    }

    public async Task<ResponseEntity<SignInResponse>> SignUpAsync(SignUpModel model)
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
        
        var accessToken = JwtService.JwtService.GenerateAccessToken(_options, GenerateClaimsIdentity(entity));
        var refreshToken = JwtService.JwtService.GenerateRefreshToken(_options);
        
        return new ResponseEntity<SignInResponse>(HttpStatusCode.Created, new SignInResponse() {AccessToken = accessToken, RefreshToken = refreshToken});
    }

    private ClaimsIdentity GenerateClaimsIdentity(DAL.Entities.Customer customer)
    {
        return new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, customer.UserName!),
            new Claim(ClaimTypes.Email, customer.Email!),
            new Claim("Id", customer.Id.ToString())
        });
    } 
}