using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Contract;
using System;
using System.Collections.Generic;
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

                var publicHolidays = provider.GetHolidays(2018);
                if (!publicHolidays.Any())
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
            var failures = new List<string>();

            foreach (CountryCode countryCode in Enum.GetValues(typeof(CountryCode)))
            {
                var provider = DateSystem.GetPublicHolidayProvider(countryCode);
                var counties = provider is ICountyProvider countyProvider
                    ? countyProvider.GetCounties()
                    : new Dictionary<string, string>();

                var startYear = DateTime.Today.Year - 100;
                var endYear = DateTime.Today.Year + 100;

                for (var year = startYear; year <= endYear; year++)
                {
                    var publicHolidays = DateSystem.GetPublicHolidays(year, countryCode);
                    foreach (var publicHoliday in publicHolidays)
                    {
                        if (publicHoliday.Counties == null)
                        {
                            continue;
                        }

                        if (publicHoliday.Counties.Count(o => counties.Keys.Contains(o)) != publicHoliday.Counties.Length)
                        {
                            var diff = publicHoliday.Counties.Except(counties.Keys);
                            failures.Add($"Unknown county in {provider} \"{publicHoliday.Name}\" {string.Join(',', diff)}");
                        }
                    }
                }

            }

            if (failures.Count > 0)
            {
                Assert.Fail(Environment.NewLine + string.Join(Environment.NewLine, failures));
            }
        }

        [DataTestMethod]
        [DataRow("de")]
        [DataRow("De")]
        [DataRow("dE")]
        [DataRow("DE")]
        public void CheckCaseInsensitive(string countryCode)
        {
            var result = DateSystem.GetPublicHolidays(2018, countryCode);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ThrowOnUndefinedEnum()
        {
            Assert.ThrowsException<ArgumentException>(() => DateSystem.GetPublicHolidays(2018, "1000"));
        }
    }
}
