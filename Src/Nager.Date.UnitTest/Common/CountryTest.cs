using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Contract;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Common
{
    [TestClass]
    public class CountryTest
    {
        [TestMethod]
        public void CheckCountries()
        {
            foreach (CountryCode countryCode in Enum.GetValues(typeof(CountryCode)))
            {
                var provider = DateSystem.GetPublicHolidayProvider(countryCode);
                if (provider == null)
                {
                    continue;
                }

                var publicHolidays = provider.Get(2018);
                if (publicHolidays.Count() == 0)
                {
                    continue;
                }

                var countries = publicHolidays.GroupBy(o => o.CountryCode).Select(o => o.Key).ToList();

                Assert.AreEqual(1, countries.Count, $"{countryCode} has a failure");
                Assert.AreEqual(countryCode, countries.FirstOrDefault());
            }
        }

        [TestMethod]
        public void CheckCounties()
        {
            foreach (CountryCode countryCode in Enum.GetValues(typeof(CountryCode)))
            {
                var provider = DateSystem.GetPublicHolidayProvider(countryCode);
                if (provider is ICountyProvider)
                {
                    var counties = ((ICountyProvider)provider).GetCounties();

                    var publicHolidays = DateSystem.GetPublicHoliday(DateTime.Now.Year, countryCode);
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

        [TestMethod]
        public void CheckCaseInsensitive()
        {
            var result = DateSystem.GetPublicHoliday(2018, "de");
            var result2 = DateSystem.GetPublicHoliday(2018, "DE");
            
            Assert.IsNotNull(result);
            Assert.IsNotNull(result2);
        }

        [TestMethod]
        public void ThrowOnUndefinedEnum()
        {
            Assert.ThrowsException<ArgumentException>(() => DateSystem.GetPublicHoliday(2018, "1000"));
        }
    }
}
