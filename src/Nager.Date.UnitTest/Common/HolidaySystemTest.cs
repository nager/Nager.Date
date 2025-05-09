using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.HolidayProviders;
using Nager.Date.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace Nager.Date.UnitTest.Common
{
    [TestClass]
    public class HolidaySystemTest
    {
        [TestMethod]

        public void GetHolidays_ForEveryCountry()
        {
            var startYear = DateTime.Today.Year - 100;
            var endYear = DateTime.Today.Year + 100;

            foreach (CountryCode countryCode in Enum.GetValues(typeof(CountryCode)))
            {
                var publicHolidayProvider = HolidaySystem.GetHolidayProvider(countryCode);
                if (publicHolidayProvider is NoHolidaysHolidayProvider)
                {
                    continue;
                }

                for (var calculationYear = startYear; calculationYear < endYear; calculationYear++)
                {
                    try
                    {
                        var items = publicHolidayProvider.GetHolidays(calculationYear);
                        Assert.IsTrue(items.Any());
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine($"{countryCode} {exception}");
                    }
                }
            }
        }

        [TestMethod]
        public void Check_NoPublicHolidays_MoveInAnOtherYear()
        {
            var startYear = DateTime.Today.Year - 100;
            var endYear = DateTime.Today.Year + 100;

            foreach (CountryCode countryCode in Enum.GetValues(typeof(CountryCode)))
            {
                var corruptPublicHolidaysFound = false;

                for (var processingYear = startYear; processingYear < endYear; processingYear++)
                {
                    var items = HolidaySystem.GetHolidays(processingYear, countryCode);
                    if (items.Any(o => !o.Date.Year.Equals(processingYear)))
                    {
                        corruptPublicHolidaysFound = true;
                        break;
                    }
                }

                Debug.WriteLineIf(corruptPublicHolidaysFound, $"Check country {countryCode}");

                if (corruptPublicHolidaysFound)
                {
                    Assert.Fail($"Check country {countryCode}");
                }
            }
        }


        [TestMethod]
        public void CheckDuplicateHolidayDefinition()
        {
            var startYear = DateTime.Today.Year - 100;
            var endYear = DateTime.Today.Year + 100;

            foreach (CountryCode countryCode in Enum.GetValues(typeof(CountryCode)))
            {
                for (var calculationYear = startYear; calculationYear < endYear; calculationYear++)
                {
                    var items = HolidaySystem.GetHolidays(calculationYear, countryCode);

                    var groupedHolidays = items
                        .GroupBy(o => new { o.Date, o.EnglishName, o.LocalName, o.SubdivisionCodes })
                        .Select(o => new { o.Key.Date, o.Key.EnglishName, Count = o.Count() });

                    if (groupedHolidays.Where(o => o.Count > 1).Any())
                    {
                        Assert.Fail($"Check country {countryCode}");
                    }
                }
            }
        }

        [TestMethod]
        public void CheckIsPublicHoliday()
        {
            var isPublicHoliday = HolidaySystem.IsPublicHoliday(new DateTime(2016, 5, 1), CountryCode.AT);
            Assert.IsTrue(isPublicHoliday);

            isPublicHoliday = HolidaySystem.IsPublicHoliday(new DateTime(2016, 1, 6), CountryCode.AT);
            Assert.IsTrue(isPublicHoliday);

            isPublicHoliday = HolidaySystem.IsPublicHoliday(new DateTime(2016, 1, 6), "AT");
            Assert.IsTrue(isPublicHoliday);

            isPublicHoliday = HolidaySystem.IsPublicHoliday(new DateTime(2016, 1, 6), "AT");
            Assert.IsTrue(isPublicHoliday);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "endDate is before startDate")]
        public void CheckPublicHolidayWithDateFilter2()
        {
            HolidaySystem.GetHolidays(new DateTime(2016, 1, 2), new DateTime(2016, 1, 1), CountryCode.DE).First();
        }

        [TestMethod]
        public void CheckIsOfficialPublicHolidayByCounty1()
        {
            var isPublicHoliday = HolidaySystem.IsPublicHoliday(new DateTime(2019, 8, 5), CountryCode.AU);
            Assert.IsFalse(isPublicHoliday);

            isPublicHoliday = HolidaySystem.IsPublicHoliday(new DateTime(2019, 8, 5), CountryCode.AU, "AU-NT");
            Assert.IsTrue(isPublicHoliday);

            isPublicHoliday = HolidaySystem.IsPublicHoliday(new DateTime(2019, 8, 5), CountryCode.AU, "AU-WA");
            Assert.IsFalse(isPublicHoliday);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid countyCode AUS-NT")]
        public void CheckIsOfficialPublicHolidayByCounty2()
        {
            var isPublicHoliday = HolidaySystem.IsPublicHoliday(new DateTime(2019, 8, 5), CountryCode.AU, "AUS-NT");
            Assert.IsTrue(isPublicHoliday);
        }

        [TestMethod]
        public void CheckIsHolidayWithTypeBank()
        {
            var isPublicHoliday = HolidaySystem.IsHoliday(new DateTime(2019, 6, 5), CountryCode.DK, HolidayTypes.Bank, out var publicHolidays);
            Assert.IsTrue(isPublicHoliday);
            Assert.IsTrue(publicHolidays.Length > 0);
        }

        [TestMethod]
        public void CheckIsHolidayWithTypeBankAndSchool()
        {
            var isPublicHoliday = HolidaySystem.IsHoliday(new DateTime(2019, 6, 5), CountryCode.DK, HolidayTypes.Bank | HolidayTypes.School, out var publicHolidays);
            Assert.IsTrue(isPublicHoliday);
            Assert.IsTrue(publicHolidays.Length > 0);
        }
    }
}
