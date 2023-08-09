using Microsoft.OpenApi.Models;
using System.Reflection;
using API.Extensions;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwagger();
            builder.Services.AddDb(() => new BLL.DTOs.Response.DatabaseSettings
            {
                Server = builder.Configuration.GetValue<string>("DatabaseSettings:Server"),
                Database = builder.Configuration.GetValue<string>("DatabaseSettings:Database"),
                UserId = builder.Configuration.GetValue<string>("DatabaseSettings:UserId"),
                Password = builder.Configuration.GetValue<string>("DatabaseSettings:Password"),
            });
            builder.Services.AddOptions(builder.Configuration);
            builder.Services.AddRepositories();
            builder.Services.AddIdentity();
            builder.Services.AddServices();
            builder.Services.AddMapper();
            builder.Services.AddJwtAuthentication();
            
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}