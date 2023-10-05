﻿using API.Extensions;
using API.Middlewares;
using Serilog;

namespace API
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("log.txt").CreateLogger();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddSerilog(dispose: true);
            });

            services
                .AddMetrics()
                .AddSwaggerServices()
                .AddSettings(Configuration)
                .AddValidation()
                .AddMapper()
                .AddDb(Configuration)
                .AddRepositories()
                .AddIdentity()
                .AddServices()
                .AddJwtAuthentication()
                .AddCORS();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           /* if (env.IsDevelopment())
            {*/
                app.UseSwagger();
                app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger"); });
           /* }*/

            app.UseCors();
            app.UseRouting();
            app.ConfigureCustomExceptionMiddleware();
            app.UseAuthentication();
            app.UseAuthorization();

            Extensions.ServiceCollection.PrepPopulation(app);

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

    }
}
