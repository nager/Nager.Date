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
            using var s = await TestConfigHelpers.CreateServer(appSettings, FakeRemoteIP.Localhost);
            using var c = s.CreateClient();
            var requests = _testApiPathEndpoints.Select(c.GetAsync).ToArray();
            await Task.WhenAll(requests);
            foreach (var r in requests) {
                r.Result.EnsureSuccessStatusCode();
            }
        }

        [TestMethod]
        public async Task TestNoRateLimitIfWhitelist()
        {
            var appSettings = await GetThrottledIpAppSettings();
            appSettings.IpRateLimiting.IpWhitelist = new List<string> {
                FakeRemoteIpAddressMiddleware._testNet2IP.ToString()
            };
            using var s = await TestConfigHelpers.CreateServer(appSettings, FakeRemoteIP.TestNet2);
            using var c = s.CreateClient();
            var requests = _testApiPathEndpoints.Select(c.GetAsync).ToArray();
            await Task.WhenAll(requests);
            foreach (var r in requests)
            {
                r.Result.EnsureSuccessStatusCode();
            }
        }
        [TestMethod]
        public async Task TestDoesRateLimitNonWhitelist()
        {
            var appSettings = await GetThrottledIpAppSettings();
            using var s = await TestConfigHelpers.CreateServer(appSettings, FakeRemoteIP.TestNet2);
            using var c = s.CreateClient();
            var requests = _testApiPathEndpoints.Select(c.GetAsync).ToArray();
            await Task.WhenAll(requests);
            var tooManyStatusCode = appSettings.IpRateLimiting.HttpStatusCode == default
                ? HttpStatusCode.TooManyRequests
                : (HttpStatusCode)appSettings.IpRateLimiting.HttpStatusCode;
            var responseStatus = requests.Select(r => r.Result.StatusCode).ToList();
            var expectedStatus = Enumerable.Repeat(tooManyStatusCode, requests.Length - 1).ToList();
            // 1 request allowed through
            expectedStatus.Add(HttpStatusCode.OK);
            CollectionAssert.AreEquivalent(expectedStatus, responseStatus);
            // check our endpoint whitelist works for MVC pages
            requests = new[] {
                // not currently working for "/" - I'll make a PR and uncomment when
                // the underlying IpRateLimit package is fixed
                // "/",
                "/home/Countries",
                "/publicholiday/Country/NZ" }.Select(c.GetAsync).ToArray();
            await Task.WhenAll(requests);
            foreach (var r in requests)
            {
                r.Result.EnsureSuccessStatusCode();
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
