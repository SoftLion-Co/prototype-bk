using System.Reflection;
using System.Text;
using BLL.DTOs.Response;
using BLL.Models;
using BLL.Services.Author;
using BLL.Services.Blog;
using BLL.Services.OrderProject;
using BLL.Services.Rating;
using BLL.Services.Technology;
using DAL.Context;
using DAL.Entities;
using DAL.GenericRepository;
using DAL.GenericRepository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
 using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using OpenTelemetry.Metrics;
using FluentValidation.AspNetCore;
using FluentValidation;
using DAL.WrapperRepository.Interface;
using DAL.WrapperRepository;
using BLL.Services.AuthService;
using BLL.Services.Country;
using BLL.Services.Customer;
using BLL.Services.OrderBlog;
using BLL.Services.Project;
using BLL.Services.OrderProjectStatusStatus;
using BLL.Services.OrderProjectStatus;
using BLL.Services.PeriodProgress;

namespace API.Extensions
{
    public static class ServiceCollection
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            System.Console.WriteLine("Checking Migrations...");
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<DataContext>());
            }
        }
        private static void SeedData(DataContext dataContext)
        {
            System.Console.WriteLine("Apling Migrations...");
            dataContext.Database.Migrate();
             
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
        
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }

        public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
            services.AddSingleton(opt =>
            {
                var service = opt.GetRequiredService<IOptions<JwtOptions>>().Value;
                return service;
            });

            return services;
        }
        public static IServiceCollection AddDb(this IServiceCollection services, IConfiguration Configuration)
        {
            var conf = Configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();

            if (conf is null)
            {
                throw new NullReferenceException(nameof(conf));
            }

            var connectionString =
                $@"Server={conf.Server},{conf.Port};Initial Catalog={conf.Database};User ID={conf.UserId};Password={conf.Password};TrustServerCertificate=true;";

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionString));

            /*services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));*/

            return services;
        }
        public static IServiceCollection AddMetrics(this IServiceCollection services)
        {
            services.AddOpenTelemetry().WithMetrics(builder => builder.AddAspNetCoreInstrumentation());
            return services;
        }
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<Program>();
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
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderBlogService, OrderBlogService>();
            services.AddScoped<IOrderProjectService, OrderProjectService>();
            services.AddScoped<IOrderProjectStatusService, OrderProjectStatusService>();
            services.AddScoped<IPeriodProgressService, PeriodProgressService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<ITechnologyService, TechnologyService>();
            services.AddScoped<IProjectService, ProjectService>();

            services.AddScoped<IWrapperRepository, WrapperRepository>();
            services.AddExceptionHandlers(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }

        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "The Back part of SoftLion project",
                    Version = "v1"
                });

                options.CustomSchemaIds(x => x.FullName);
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

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

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
        public static IServiceCollection AddCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
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
