using BLL.MediatR.Author;
using BLL.Services.Author;
using DAL.Context;
using DAL.GenericRepository;
using DAL.GenericRepository.Interface;
using DAL.WrapperRepository;
using DAL.WrapperRepository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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

            builder.Services.AddScoped<IWrapperRepository, WrapperRepository>();
            builder.Services.AddScoped<IAuthorService, AuthorService>();

            var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            builder.Services.AddAutoMapper(currentAssemblies);

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllAuthorsQuery>());

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