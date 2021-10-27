using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Nager.Date.Website;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Nager.Date.IntegrationTests
{
    public enum FakeRemoteIP
    {
        NotApplicable = 0,
        Localhost,
        TestNet2
    }
    public static class TestConfigHelpers
    {
        internal static async Task<Stream> ToJsonStream(this TestableAppSettings testConfig)
        {
            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
            };
            var ms = new MemoryStream();
            await JsonSerializer.SerializeAsync(ms, testConfig, options);
            ms.Flush();
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }
        internal static async Task<TestServer> CreateServer(TestableAppSettings testConfig, FakeRemoteIP fakeIp = FakeRemoteIP.NotApplicable)
        {
            using var js = await testConfig.ToJsonStream();
            var fakeHost = new WebHostBuilder().ConfigureAppConfiguration((context, conf) => {
                conf.AddJsonStream(js);
            });
            if (fakeIp == FakeRemoteIP.TestNet2)
            {
                fakeHost.ConfigureServices((context, serviceCollection) =>
                    serviceCollection.AddSingleton<IStartupFilter, CustomStartupFilter<FakeRemoteIpAddressMiddleware>>());
            }
            else if (fakeIp == FakeRemoteIP.Localhost)
            {
                fakeHost.ConfigureServices((context, serviceCollection) =>
                    serviceCollection.AddSingleton<IStartupFilter, CustomStartupFilter<FakeLocalhostIPMiddleware>>());
            }
            var server = new TestServer(fakeHost.UseStartup<Startup>());
            return server;
        }

        internal static async Task<TestableAppSettings> FromAppSettings()
        {
            var options = new JsonSerializerOptions
            {
                Converters =
                {
                    new JsonStringEnumConverter()
                }
            };
            var projectDir = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(projectDir,"appsettings.json");
            using var fs = File.OpenRead(configPath);
            var json = await JsonSerializer.DeserializeAsync<TestableAppSettings>(fs, options);
            return json;
        }
    }
}
