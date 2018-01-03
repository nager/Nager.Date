using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Contract;

namespace Nager.Date.UnitTest.Common
{
    [TestClass]
    public class CountyTest
    {
        [TestMethod]
        public void CheckCounties()
        {
            foreach (CountryCode countryCode in Enum.GetValues(typeof(CountryCode)))
            {
                var provider = DateSystem.GetProvider(countryCode);
                if (provider is ICountyProvider)
                {
                    var counties = ((ICountyProvider)provider).GetCounties();

                    var publicHolidays = DateSystem.GetPublicHoliday(countryCode, DateTime.Now.Year);
                    foreach (var publicHoliday in publicHolidays)
                    {
                        if (publicHoliday.Counties == null)
                        {
                            continue;
                        }

                        if (publicHoliday.Counties.Where(o => counties.Keys.Contains(o)).Count() != publicHoliday.Counties.Count())
                        {
                            Assert.Fail($"Unknown countie in {provider}");
                        }
                    }
                }
            }
        }
    }
}
