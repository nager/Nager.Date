﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Contract;
using Nager.Date.PublicHolidays;
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

                var publicHolidays = provider.Get(2018);
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
            foreach (CountryCode countryCode in Enum.GetValues(typeof(CountryCode)))
            {
                var provider = DateSystem.GetPublicHolidayProvider(countryCode);
                if (provider is ICountyProvider countyProvider)
                {
                    var counties = countyProvider.GetCounties();

                    var publicHolidays = DateSystem.GetPublicHoliday(DateTime.Now.Year, countryCode);
                    foreach (var publicHoliday in publicHolidays)
                    {
                        if (publicHoliday.Counties == null)
                        {
                            continue;
                        }

                        if (publicHoliday.Counties.Count(o => counties.Keys.Contains(o)) != publicHoliday.Counties.Count())
                        {
                            var diff = publicHoliday.Counties.Except(counties.Keys);
                            Assert.Fail($"Unknown countie in {provider} {string.Join(",", diff)}");
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
