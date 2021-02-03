using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Nager.Date.Website
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
                    webBuilder.ConfigureKestrel(o => o.AddServerHeader = false);
                    webBuilder.UseStartup<Startup>();
                });
    }
}
