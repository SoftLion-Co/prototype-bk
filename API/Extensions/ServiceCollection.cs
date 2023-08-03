using BLL.DTOs.Response;
using BLL.Services.Author;
using BLL.Services.AuthService;
using BLL.Services.Blog;
using BLL.Services.Country;
using BLL.Services.Customer;
using BLL.Services.Rating;
using DAL.Context;
using DAL.Entities;
using DAL.GenericRepository;
using DAL.GenericRepository.Interface;
using DAL.WrapperRepository;
using DAL.WrapperRepository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWrapperRepository, WrapperRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        
            return services;
        }

        public static IServiceCollection AddDb(this IServiceCollection services,
            Func<DatabaseSettings> connectionConfiguration)
        {
            var conf = connectionConfiguration();
            if (conf is null)
            {
                throw new NullReferenceException(nameof(conf));
            }

            var connectionString =
                $@"Server={conf.Server};Database={conf.Database};User Id={conf.UserId};Password={conf.Password};TrustServerCertificate=true;";

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.AddAutoMapper(assemblies);
            return services;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentityCore<IdentityUser<Guid>>(x =>
                {
                    x.User.RequireUniqueEmail = true;
                })
                .AddRoles<IdentityRole<Guid>>()
                .AddSignInManager<SignInManager<IdentityUser<Guid>>>()
                .AddUserManager<UserManager<IdentityUser<Guid>>>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();
            
            services.AddIdentityCore<Customer>(x =>
                {
                    x.User.RequireUniqueEmail = true;
                })
                .AddSignInManager<SignInManager<Customer>>()
                .AddUserManager<UserManager<Customer>>()
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICustomerService, CustomerService>();
            return services;
        }
    }
}
