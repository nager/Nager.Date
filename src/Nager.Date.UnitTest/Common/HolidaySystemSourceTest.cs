using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.HolidayProviders;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nager.Date.UnitTest.Common
{
    [Ignore]
    [TestClass]
    public class HolidaySystemSourceTest
    {
        [TestMethod]

        public async Task CheckHolidaySources_ForEveryCountry()
        {
            using var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(30);
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Nager.Date - Check Source Link");

            foreach (var countryCode in Enum.GetValues<CountryCode>())
            {
                var publicHolidayProvider = HolidaySystem.GetHolidayProvider(countryCode);
                if (publicHolidayProvider is NoHolidaysHolidayProvider)
                {
                    continue;
                }

                var sources = publicHolidayProvider.GetSources();

                foreach (var source in sources)
                {
                    try
                    {
                        var response = await httpClient.GetAsync(source, this.TestContext.CancellationToken);
                        if ((int)response.StatusCode == 200)
                        {
                            //Trace.WriteLine(response.ti)
                        }
                        else
                        {
                            Trace.WriteLine($"{countryCode} - {response.StatusCode} {source}");
                        }
                    }
                    catch (Exception exception)
                    {
                        Trace.WriteLine($"{countryCode} - {exception} {source}");
                    }
                }
            }
        }

        public TestContext TestContext { get; set; }
    }
}
