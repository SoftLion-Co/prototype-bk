﻿using BLL.DTOs.CustomerDTO;
using BLL.DTOs.Response.ResponseEntity;
using BLL.Models;
using BLL.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("sign-in")]
        public async Task<ResponseEntity<GetCustomerDto>> SignInAsync(SignInModel model)
        {
            return await _authService.SignInAsync(model);
        }
        [HttpPost("sign-up")]
        public async Task<ResponseEntity> SignUpAsync(SignUpModel model)
        {
            return await _authService.SignUpAsync(model);
        }
    }
}
