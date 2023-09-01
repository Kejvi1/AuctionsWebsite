using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Serilog;
using System;

namespace AuctionsWebsite.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Creates logger instance and injects it into the DI pipeline
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void CreateLogger(this IServiceCollection services, IConfiguration config)
        {
            ILoggerManager logger = new LoggerManager(new LoggerConfiguration().ReadFrom
            .Configuration(config)
            .WriteTo.Map(
                 e => DateTime.Now.ToString("yyyyMMdd"),
                 (v, wt) => wt.File($"{AppDomain.CurrentDomain.BaseDirectory}/logs/{v}_log.txt"))
            .CreateLogger());

            services.AddSingleton(logger);
        }

        /// <summary>
        /// Register dependency injections
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        public static void RegisterServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ApplicationContext>(o =>
            {
                o.UseSqlServer(connectionString, b => b.MigrationsAssembly("AuctionsWebsite"));
                o.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }
    }
}