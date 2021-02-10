using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using WebAutofacPro.CustomConfiguration;

namespace WebAutofacPro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureHostConfiguration(builder=> {
                builder.AddQueryStringFile("hhhh.config");
            })
            .ConfigureLogging((context, loggingBuilder) =>
            {
                loggingBuilder.ClearProviders();
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .UseSerilog((context, configuration) =>
            {
                configuration.ReadFrom.Configuration(context.Configuration).Enrich.FromLogContext();
            })
            .UseServiceProviderFactory(new AutofacServiceProviderFactory());
    }
}
