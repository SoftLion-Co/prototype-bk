using BLL.DTOs.CustomerDTO;
using BLL.DTOs.Response.ResponseEntity;
using BLL.Models;

namespace BLL.Services.AuthService;

public interface IAuthService
{
    Task<ResponseEntity<SignInResponse>> SignInAsync(SignInModel model);
    Task<ResponseEntity<SignInResponse>> SignUpAsync(SignUpModel model);
    Task<ResponseEntity<string>> SendCodeAsync(string email);
    Task<ResponseEntity> ChangePassword(SignInModel model);
}