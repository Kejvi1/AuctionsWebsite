using Contracts;
using LoggerService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;

namespace AuctionsWebsite.Extensions
{
    public static class ServiceExtensions
    {
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
    }
}