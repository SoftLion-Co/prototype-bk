using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
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
    private static readonly Random random = new Random();


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

        return new ResponseEntity<SignInResponse>(HttpStatusCode.Created, new SignInResponse() { AccessToken = accessToken, RefreshToken = refreshToken });
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

        return new ResponseEntity<SignInResponse>(HttpStatusCode.Created, new SignInResponse() { AccessToken = accessToken, RefreshToken = refreshToken });
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
    public async Task<ResponseEntity> ChangePassword(SignInModel model)
    {
        var customer = await _userManager.Users.FirstOrDefaultAsync(user => user.Email == model.Email);

        if (customer is null)
        {
            throw new NotFoundException("The user doesn't exist");
        }

        var accessToken = JwtService.JwtService.GenerateAccessToken(_options, GenerateClaimsIdentity(customer));
        var refreshToken = JwtService.JwtService.GenerateRefreshToken(_options);

        return new ResponseEntity<SignInResponse>(HttpStatusCode.Created, new SignInResponse() { AccessToken = accessToken, RefreshToken = refreshToken });
    }

    public async Task<ResponseEntity<string>> SendCodeAsync(string email)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(user => user.Email == email);
        if(user == null)
        {
            throw new ValidationException("The user with such credentials doesn`t exist");
        }

        var code = RenderCode(); 
        var encryptCode = Encrypt(code); 

       /* SmtpClient client = new SmtpClient("smtp.gmail.com")//сервер
        {
            Port = 587, //порт сервера
            Credentials = new NetworkCredential("mr.haha.gay@gmail.com", "pnmbpy33333"),//пошта та пароль відправника
            EnableSsl = true,
        };

        MailMessage mailMessage = new MailMessage
        {
            From = new MailAddress("mr.haha.gay@gmail.com"),
            Subject = "Ваш код для відновлення паролю",
            Body = $"Ваш код для відновлення паролю: {code}",
            IsBodyHtml = false,
            BodyEncoding = Encoding.UTF8,
        };

        mailMessage.To.Add(email);
        client.Send(mailMessage);*/

        return new ResponseEntity<string>(HttpStatusCode.Created, encryptCode);
    }

    private string RenderCode()
    {
        const string validCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        StringBuilder codeBuilder = new StringBuilder();

        for (int i = 0; i < 6; i++)
        {
            int randomIndex = random.Next(validCharacters.Length);
            codeBuilder.Append(validCharacters[randomIndex]);
        }
        return codeBuilder.ToString();
    }

    public string Encrypt(string plainText)
    {
        string encryptionKey = "Your192BitEncryptionKey123"; 

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Convert.FromBase64String("AAECAwQFBgcICQoLDA0ODw==");//Encoding.UTF8.GetBytes(encryptionKey);
            aesAlg.IV = new byte[16]; 

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            string encryptedText = Convert.ToBase64String(encryptedBytes);

            return encryptedText;
        }
    }

}