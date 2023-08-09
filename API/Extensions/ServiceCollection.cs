using System.Reflection;
using System.Text;
using BLL.DTOs.Response;
using BLL.Models;
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
            services.AddSingleton(opt =>
            {
                var service = opt.GetRequiredService<IOptions<JwtOptions>>().Value;
                return service;
            });

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

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var settings = provider.GetRequiredService<JwtOptions>();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidAudience = settings.ValidAudience,
                        ValidIssuer = settings.ValidIssuer,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecretKey)),
                        ClockSkew = TimeSpan.FromMinutes(30)
                    };
                });
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "The Back part of SoftLion project",
                    Description = "Something",
                    Version = "v1"
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });

                // Define the security requirement for JWT
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
            return services;
        }
    }
}
