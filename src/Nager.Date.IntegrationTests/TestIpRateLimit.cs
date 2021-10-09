using AspNetCoreRateLimit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Nager.Date.IntegrationTests
{
    [TestClass]
    public class TestIpRateLimit
    {
        private static readonly string[] _testApiPathEndpoints = new[] {
                "/Api/v2/AvailableCountries",
                "/Api/v2/CountryInfo",
                "/Api/v2/NextPublicHolidaysWorldwide"
            };
        // This should test that when running in IIS express from localhost,
        // all requests bypass any IpRateLimiting setting
        [TestMethod]
        public async Task TestNoRateLimitIfLocalhost()
        {
            var appSettings = await GetThrottledIpAppSettings();
            using var server = await TestConfigHelpers.CreateServer(appSettings, FakeRemoteIP.Localhost);
            using var client = server.CreateClient();
            foreach (var path in _testApiPathEndpoints)
            {
                var res = await client.GetAsync(path);
                Assert.AreNotEqual(HttpStatusCode.TooManyRequests, res.StatusCode);
            }
        }

        [TestMethod]
        public async Task TestNoRateLimitIfWhitelist()
        {
            var appSettings = await GetThrottledIpAppSettings();
            appSettings.IpRateLimiting.IpWhitelist = new List<string> {
                FakeRemoteIpAddressMiddleware._testNet2IP.ToString()
            };
            using var server = await TestConfigHelpers.CreateServer(appSettings, FakeRemoteIP.TestNet2);
            using var client = server.CreateClient();
            foreach (var path in _testApiPathEndpoints)
            {
                var res = await client.GetAsync(path);
                Assert.AreNotEqual(HttpStatusCode.TooManyRequests, res.StatusCode);
            }
        }
        [TestMethod]
        public async Task TestRateLimitsNonIPWhitelist()
        {
            var appSettings = await GetThrottledIpAppSettings();
            using var server = await TestConfigHelpers.CreateServer(appSettings, FakeRemoteIP.TestNet2);
            using var client = server.CreateClient();
            // 1st request gets through
            var res = await client.GetAsync(_testApiPathEndpoints[0]);
            Assert.AreNotEqual(HttpStatusCode.TooManyRequests, res.StatusCode);
            // subsequent requests do not proceed
            foreach (var path in _testApiPathEndpoints.Skip(1))
            {
                res = await client.GetAsync(path);
                Assert.AreEqual(HttpStatusCode.TooManyRequests, res.StatusCode);
            }
        }
        [TestMethod]
        public async Task TestNoRateLimitOnMVCEndPoint()
        {
            var appSettings = await GetThrottledIpAppSettings();
            using var server = await TestConfigHelpers.CreateServer(appSettings, FakeRemoteIP.TestNet2);
            using var client = server.CreateClient();
            // check our endpoint whitelist works for MVC pages
            var mvcEndpoints = new[] {
                // not currently working for "/" - I'll make a PR and uncomment when
                // the underlying IpRateLimit package is fixed
                // "/",
                "/home/Countries",
                "/publicholiday/Country/NZ" };
            foreach (var path in mvcEndpoints)
            {
                var res = await client.GetAsync(path);
                Assert.AreNotEqual(HttpStatusCode.TooManyRequests, res.StatusCode);
            }
        }
        private static async Task<TestableAppSettings> GetThrottledIpAppSettings()
        {
            var existingAppSettings = await TestConfigHelpers.FromAppSettings();
            existingAppSettings.EnableIpRateLimiting = true;
            existingAppSettings.IpRateLimiting.GeneralRules = new List<RateLimitRule> {
                new RateLimitRule // 1 request per day
                {
                    Endpoint = "*",
                    Period = "1d",
                    Limit = 1
                }
            };
            return existingAppSettings;
        }
    }
}
