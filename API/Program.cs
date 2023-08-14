using Microsoft.OpenApi.Models;
using System.Reflection;
using API.Extensions;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>

            {
                webBuilder.UseStartup<Startup>();
            });
    }
}