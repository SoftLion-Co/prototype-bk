using BLL.DTOs.Response;
using BLL.Services.Author;
using BLL.Services.Blog;
using BLL.Services.Country;
using BLL.Services.Rating;
using DAL.Context;
using DAL.GenericRepository;
using DAL.GenericRepository.Interface;
using DAL.WrapperRepository;
using DAL.WrapperRepository.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWrapperRepository, WrapperRepository>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        
            return services;
        }

        public static IServiceCollection AddDb(this IServiceCollection services, Func<DatabaseSettings> connectionConfiguration)
        {
            var conf = connectionConfiguration();
            if (conf is null)
            {
                throw new NullReferenceException(nameof(conf));
            }
            var connectionString = $@"Server={conf.Server};Database={conf.Database};User Id={conf.UserId};Password={conf.Password};TrustServerCertificate=true;";

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddMediatr(this IServiceCollection services)
        {
            var name = AppDomain.CurrentDomain.GetAssemblies()
                .SingleOrDefault(assembly => assembly.GetName().Name == "BLL");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(name!));
            return services;
        }

        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.AddAutoMapper(assemblies);
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IRatingService, RatingService>();
            return services;
        }
    }
}
