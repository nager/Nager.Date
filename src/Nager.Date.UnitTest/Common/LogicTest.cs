using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.HolidayProviders;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Diagnostics;
using System.Linq;

namespace Nager.Date.UnitTest.Common
{
    [TestClass]
    public class LogicTest
    {
        [TestMethod]

        public void CheckPublicHolidayProviders()
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
        [Ignore]
        public void Check_NoPublicHolidays_MoveInAnOtherYear()
        {
            var startYear = DateTime.Today.Year - 100;
            var endYear = DateTime.Today.Year + 100;

            foreach (CountryCode countryCode in Enum.GetValues(typeof(CountryCode)))
            {
                var corruptPublicHolidaysFound = false;

                for (var calculationYear = startYear; calculationYear < endYear; calculationYear++)
                {
                    try
                    {
                        var items = HolidaySystem.GetHolidays(calculationYear, countryCode);
                        if (items.Any(o => !o.Date.Year.Equals(calculationYear)))
                        {
                            corruptPublicHolidaysFound = true;
                            break;
                        }
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine($"{countryCode} {exception}");
                    }
                }

                Debug.WriteLineIf(corruptPublicHolidaysFound, $"Check country {countryCode}");
            }
        }

        [DataTestMethod]
        [DataRow(1900, 4, 15)]
        [DataRow(2014, 4, 20)]
        [DataRow(2015, 4, 5)]
        [DataRow(2016, 3, 27)]
        [DataRow(2017, 4, 16)]
        [DataRow(2018, 4, 1)]
        [DataRow(2019, 4, 21)]
        [DataRow(2020, 4, 12)]
        [DataRow(2200, 4, 6)]
        public void CheckEasterSunday(int year, int month, int day)
        {
            var catholicProvider = new MockPublicHolidayProvider(new CatholicProvider());

            var easterSunday = catholicProvider.EasterSunday(year);
            Assert.AreEqual(new DateTime(year, month, day), easterSunday);
        }

        [TestMethod]
        public void CheckIsPublicHoliday()
        {
            var isPublicHoliday = HolidaySystem.IsPublicHoliday(new DateTime(2016, 5, 1), CountryCode.AT);
            Assert.AreEqual(true, isPublicHoliday);

            isPublicHoliday = HolidaySystem.IsPublicHoliday(new DateTime(2016, 1, 6), CountryCode.AT);
            Assert.AreEqual(true, isPublicHoliday);

            isPublicHoliday = HolidaySystem.IsPublicHoliday(new DateTime(2016, 1, 6), "AT");
            Assert.AreEqual(true, isPublicHoliday);

            isPublicHoliday = HolidaySystem.IsPublicHoliday(new DateTime(2016, 1, 6), "AT");
            Assert.AreEqual(true, isPublicHoliday);
        }

        [TestMethod]
        public void CheckIsWeekend()
        {
            var isPublicHoliday = WeekendSystem.IsWeekend(new DateTime(2021, 10, 20), CountryCode.AT);
            Assert.IsFalse(isPublicHoliday);

            isPublicHoliday = WeekendSystem.IsWeekend(new DateTime(2021, 10, 20), "AT");
            Assert.IsFalse(isPublicHoliday);

            isPublicHoliday = WeekendSystem.IsWeekend(new DateTime(2021, 10, 24), CountryCode.AT);
            Assert.IsTrue(isPublicHoliday);

            isPublicHoliday = WeekendSystem.IsWeekend(new DateTime(2021, 10, 24), "AT");
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
        public void CheckHolidayNationalWork()
        {
            var publicHoliday = new Holiday
            {
                Date = new DateTime(2020, 01, 30),
                EnglishName = "Test",
                LocalName = "Test",
                CountryCode = CountryCode.AT,
                HolidayTypes = HolidayTypes.Public
            };
            Assert.IsTrue(publicHoliday.NationalHoliday);

            var publicHolidayWithSubdivisionCodes = new Holiday
            {
                Date = new DateTime(2020, 01, 30),
                EnglishName = "Test",
                LocalName = "Test",
                CountryCode = CountryCode.AT,
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["AT-1"]
            };
            Assert.IsFalse(publicHolidayWithSubdivisionCodes.NationalHoliday);
        }
    }
}
