
using DAL.Context;
using DAL.GenericRepository;
using DAL.GenericRepository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "The Back part of SoftLion project",
                    Description = "Something",
                    Version = "v1"
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            builder.Services.AddDbContext<DataContext>(configurations =>
            {
                configurations.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                    options => options.MigrationsAssembly("MIG"));
            });

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));



            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}