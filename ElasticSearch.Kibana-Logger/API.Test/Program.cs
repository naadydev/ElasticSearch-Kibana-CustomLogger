using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
            // --------- ***** Logging Config  --------------------
            // Or in StartUp 
            //.ConfigureLogging(builder => builder.ClearProviders()
            //.AddProvider(new CustomLoggerProvider(new CustomLoggerConfiguration
            //{
            //    LoggerType = LoggerType.ElasticSearch,
            //    //LogLevel = LogLevel.Error,
            //})));
            // ---
        //.AddColorConsoleLogger()
        //.AddColorConsoleLogger(configuration =>
        //{
        //    // configuration.LogLevel = LogLevel.Warning;
        //    // configuration.Color = ConsoleColor.DarkMagenta;
        //}));
    }
}
