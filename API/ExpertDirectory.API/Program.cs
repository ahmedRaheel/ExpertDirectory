using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Compact;
using System;

namespace ExpertDirectory.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                          .Enrich.FromLogContext()
                          .WriteTo.Console(new RenderedCompactJsonFormatter())
                          .WriteTo.Debug(outputTemplate: DateTime.Now.ToString())
                          .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                          .CreateLogger(); 
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
