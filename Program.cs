using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Threading;
using Escalada.Service;

namespace Escalada
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            var host = CreateHostBuilder(args).Build();

            // using (var scope = host.Services.CreateScope())
            // {
            //     var services = scope.ServiceProvider;
            //     try
            //     {
            //         var context = services.GetRequiredService<EscaladaContext>();

            //         if (context.Database.CanConnect())
            //         {
            //             Console.WriteLine($"Can connect to database. {context.Database.GetDbConnection().DataSource}");
            //             DbInitializer.Initialize(context);
            //         }
            //         else
            //             Console.WriteLine("Can't connect to database.");
            //     }
            //     catch (Exception ex)
            //     {
            //         var logger = services.GetRequiredService<ILogger<Program>>();
            //         logger.LogError(ex, "An error occurred while seeding the database.");
            //     }
            // }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}