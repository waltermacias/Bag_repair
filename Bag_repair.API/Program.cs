using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Bag_repair.API.Data;


namespace Bag_repair.API
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
     }
}
