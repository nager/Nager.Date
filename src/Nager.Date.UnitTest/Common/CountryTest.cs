using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.HolidayProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.UnitTest.Common
{
    [TestClass]
    public class CountryTest
    {
        [TestMethod]
        public void HolidayProvider_ReturnCorrectCountryCode()
        {
            foreach (CountryCode countryCode in Enum.GetValues(typeof(CountryCode)))
            {
                var provider = HolidaySystem.GetHolidayProvider(countryCode);

                var publicHolidays = provider.GetHolidays(DateTime.Today.Year);
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
        public void CheckSubdivisonCodes()
        {
            var failures = new List<string>();

            foreach (CountryCode countryCode in Enum.GetValues(typeof(CountryCode)))
            {
                var provider = HolidaySystem.GetHolidayProvider(countryCode);
                var subdivisionCodes = provider is ISubdivisionCodesProvider subdivisionCodesProvider
                    ? subdivisionCodesProvider.GetSubdivisionCodes()
                    : new Dictionary<string, string>();

                var startYear = DateTime.Today.Year - 100;
                var endYear = DateTime.Today.Year + 100;

                for (var year = startYear; year <= endYear; year++)
                {
                    var publicHolidays = HolidaySystem.GetHolidays(year, countryCode);
                    foreach (var publicHoliday in publicHolidays)
                    {
                        if (publicHoliday.SubdivisionCodes == null)
                        {
                            continue;
                        }

                        var groupedSubdivisonCodes = publicHoliday.SubdivisionCodes.GroupBy(subdivisionCode => subdivisionCode).Select(subdivisionCodes => new { subdivisionCodes.Key, Count = subdivisionCodes.Count() });
                        if (groupedSubdivisonCodes.Where(o => o.Count > 1).Any())
                        {
                            failures.Add($"{countryCode} - Duplicate SubdivisonCode by {publicHoliday}");
                        }

                        if (publicHoliday.SubdivisionCodes.Count(o => subdivisionCodes.Keys.Contains(o)) != publicHoliday.SubdivisionCodes.Length)
                        {
                            var diff = publicHoliday.SubdivisionCodes.Except(subdivisionCodes.Keys);
                            failures.Add($"Unknown subdivisionCode in {provider} \"{publicHoliday.EnglishName}\" {string.Join(',', diff)}");
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
            var result = HolidaySystem.GetHolidays(2018, countryCode);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void HolidaySystem_CheckInvalidCountry_ThrowException()
        {
            HolidaySystem.GetHolidays(2018, "1000");
        }
    }
}
