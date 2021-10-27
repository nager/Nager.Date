using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nager.Date.IntegrationTests
{
    [TestClass]
    public class TestCors
    {
        private const string FakeOrigin = "https://example.com/";
        [TestMethod]
        public async Task TestDisableCors()
        {
            using var s = await TestConfigHelpers.CreateServer(new TestableAppSettings { EnableCors = false });
            using var c = s.CreateClient();
            var respnse = await c.SendAsync(PreflightGet());
            Assert.AreEqual(System.Net.HttpStatusCode.MethodNotAllowed, respnse.StatusCode);
        }
        [TestMethod]
        public async Task TestAllowCors()
        {
            using var server = await TestConfigHelpers.CreateServer(new TestableAppSettings { EnableCors = true });
            using var client = server.CreateClient();
            client.BaseAddress = new System.Uri(FakeOrigin);
            var res = await client.SendAsync(PreflightGet());
            const string CorsHeaderKey = "Access-Control-Allow-Origin";
            Assert.IsTrue(res.Headers.Contains(CorsHeaderKey));
            var corsHeaders = res.Headers.GetValues(CorsHeaderKey).ToList();
            Assert.AreEqual(1, corsHeaders.Count);
            CollectionAssert.Contains(new[] { "*", FakeOrigin }, corsHeaders[0]);
        }

        private static HttpRequestMessage PreflightGet()
        {
            var rqst = new HttpRequestMessage(HttpMethod.Options, "/api/v3/PublicHolidays/2021/NZ");
            rqst.Headers.Add("Access-Control-Request-Method", "GET");
            rqst.Headers.Add("Access-Control-Request-Headers", "content-type");
            rqst.Headers.Add("Origin", FakeOrigin);
            return rqst;
        }

    }
}
