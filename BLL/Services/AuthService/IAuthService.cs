using BLL.DTOs.CustomerDTO;
using BLL.DTOs.Response.ResponseEntity;
using BLL.Models;

namespace BLL.Services.AuthService;

public interface IAuthService
{
    Task<ResponseEntity<GetCustomerDto>> SignInAsync(SignInModel model);
    Task<ResponseEntity> SignUpAsync(SignUpModel model);
}