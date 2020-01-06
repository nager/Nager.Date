using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Contract;
using System;
using System.Diagnostics;
using System.Linq;

namespace Nager.Date.UnitTest.Common
{
    [TestClass]
    public class LogicTest
    {
        [TestMethod]
        [Ignore]
        public void CheckNoCorruptPublicHolidays()
        {
            var startYear = DateTime.Today.Year - 100;
            var endYear = DateTime.Today.Year + 100;

            foreach (CountryCode countryCode in Enum.GetValues(typeof(CountryCode)))
            {
                for (var calculationYear = startYear; calculationYear < endYear; calculationYear++)
                {
                    var items = DateSystem.GetPublicHoliday(calculationYear, countryCode);
                    var corruptPublicHolidaysAvailable = items.Any(o => !o.Date.Year.Equals(calculationYear));
                    Assert.IsFalse(corruptPublicHolidaysAvailable, $"Check country {countryCode} {calculationYear}");
                    //Trace.WriteLineIf(corruptPublicHolidaysAvailable, $"Check country {countryCode} {calculationYear}");
                }
            }
        }

        [TestMethod]
        public void CheckEasterSunday()
        {
            var catholicProvider = new MockProvider(new CatholicProvider());

            var easterSunday = catholicProvider.EasterSunday(1900);
            Assert.AreEqual(new DateTime(1900, 4, 15), easterSunday);

            easterSunday = catholicProvider.EasterSunday(2014);
            Assert.AreEqual(new DateTime(2014, 4, 20), easterSunday);

            easterSunday = catholicProvider.EasterSunday(2015);
            Assert.AreEqual(new DateTime(2015, 4, 5), easterSunday);

            easterSunday = catholicProvider.EasterSunday(2016);
            Assert.AreEqual(new DateTime(2016, 3, 27), easterSunday);

            easterSunday = catholicProvider.EasterSunday(2017);
            Assert.AreEqual(new DateTime(2017, 4, 16), easterSunday);

            easterSunday = catholicProvider.EasterSunday(2018);
            Assert.AreEqual(new DateTime(2018, 4, 1), easterSunday);

            easterSunday = catholicProvider.EasterSunday(2019);
            Assert.AreEqual(new DateTime(2019, 4, 21), easterSunday);

            easterSunday = catholicProvider.EasterSunday(2020);
            Assert.AreEqual(new DateTime(2020, 4, 12), easterSunday);

            easterSunday = catholicProvider.EasterSunday(2200);
            Assert.AreEqual(new DateTime(2200, 4, 6), easterSunday);
        }

        [TestMethod]
        public void CheckIsPublicHoliday()
        {
            var isPublicHoliday = DateSystem.IsPublicHoliday(new DateTime(2016, 5, 1), CountryCode.AT);
            Assert.AreEqual(true, isPublicHoliday);

            isPublicHoliday = DateSystem.IsPublicHoliday(new DateTime(2016, 1, 6), CountryCode.AT);
            Assert.AreEqual(true, isPublicHoliday);
        }

        [TestMethod]
        public void CheckFindDay()
        {
            var result = DateSystem.FindDay(2017, 1, 1, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 6), result);

            result = DateSystem.FindDay(2017, 1, 2, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 6), result);

            result = DateSystem.FindDay(2017, 1, 3, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 6), result);

            result = DateSystem.FindDay(2017, 1, 4, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 6), result);

            result = DateSystem.FindDay(2017, 1, 5, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 6), result);

            result = DateSystem.FindDay(2017, 1, 6, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 6), result);

            result = DateSystem.FindDay(2017, 1, 7, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 13), result);

            result = DateSystem.FindDay(2017, 1, 8, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 13), result);

            result = DateSystem.FindDay(2017, 1, 9, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 13), result);

            result = DateSystem.FindDay(2017, 1, 10, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 13), result);

            result = DateSystem.FindDay(2017, 1, 11, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 13), result);

            result = DateSystem.FindDay(2017, 1, 12, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 13), result);

            result = DateSystem.FindDay(2017, 1, 13, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2017, 1, 13), result);

            result = DateSystem.FindDay(2017, 1, 14, DayOfWeek.Wednesday);
            Assert.AreEqual(new DateTime(2017, 1, 18), result);
        }

        [TestMethod]
        public void CheckFindDayBefore()
        {
            var result = DateSystem.FindDayBefore(2018, 5, 25, DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2018, 5, 21), result);

            result = DateSystem.FindDayBefore(2018, 1, 9, DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2018, 1, 8), result);

            result = DateSystem.FindDayBefore(2018, 1, 8, DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2018, 1, 1), result);

            result = DateSystem.FindDayBefore(2018, 1, 12, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2018, 1, 5), result);
        }

        [TestMethod]
        public void CheckFindDayBetween()
        {
            var result = DateSystem.FindDayBetween(2019, 7, 1, 2019, 7, 7, DayOfWeek.Tuesday);
            Assert.AreEqual(new DateTime(2019, 7, 2), result);

            result = DateSystem.FindDayBetween(2019, 7, 1, 2019, 7, 7, DayOfWeek.Wednesday);
            Assert.AreEqual(new DateTime(2019, 7, 3), result);

            result = DateSystem.FindDayBetween(2019, 7, 1, 2019, 7, 7, DayOfWeek.Friday);
            Assert.AreEqual(new DateTime(2019, 7, 5), result);

            result = DateSystem.FindDayBetween(2019, 7, 1, 2019, 7, 7, DayOfWeek.Saturday);
            Assert.AreEqual(new DateTime(2019, 7, 6), result);
        }

        [TestMethod]
        public void CheckPublicHolidayWithDateFilter1()
        {
            this.CheckPublicHolidayWithDateFilter1(new DateTime(2016, 5, 1), new DateTime(2018, 5, 31));
            this.CheckPublicHolidayWithDateFilter1(new DateTime(2016, 5, 1, 0, 0, 1), new DateTime(2018, 5, 31, 23, 59, 59));
            this.CheckPublicHolidayWithDateFilter1(new DateTime(2016, 5, 1, 12, 30, 0), new DateTime(2018, 5, 31, 0, 0, 0));
            this.CheckPublicHolidayWithDateFilter1(new DateTime(2016, 5, 1, 23, 59, 59), new DateTime(2018, 5, 31, 23, 59, 59));
        }

        private void CheckPublicHolidayWithDateFilter1(DateTime startDate, DateTime endDate)
        {
            var items = DateSystem.GetPublicHoliday(startDate, endDate, CountryCode.DE);

            Assert.AreEqual(38, items.Count());
            Assert.IsTrue(items.First().Date > new DateTime(2016, 4, 28));
            Assert.IsTrue(items.Last().Date < new DateTime(2018, 6, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "startDate is before endDate")]
        public void CheckPublicHolidayWithDateFilter2()
        {
            DateSystem.GetPublicHoliday(new DateTime(2016, 1, 2), new DateTime(2016, 1, 1), CountryCode.DE).First();
        }

        [TestMethod]
        public void CheckIsOfficialPublicHolidayByCounty1()
        {
            var isPublicHoliday = DateSystem.IsPublicHoliday(new DateTime(2019, 8, 5), CountryCode.AU);
            Assert.IsFalse(isPublicHoliday);
            isPublicHoliday = DateSystem.IsOfficialPublicHolidayByCounty(new DateTime(2019, 8, 5), CountryCode.AU, "AUS-NT");
            Assert.IsTrue(isPublicHoliday);
            isPublicHoliday = DateSystem.IsOfficialPublicHolidayByCounty(new DateTime(2019, 8, 5), CountryCode.AU, "AUS-WA");
            Assert.IsFalse(isPublicHoliday);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid countyCode AU-NT")]
        public void CheckIsOfficialPublicHolidayByCounty2()
        {
            var isPublicHoliday = DateSystem.IsOfficialPublicHolidayByCounty(new DateTime(2019, 8, 5), CountryCode.AU, "AU-NT");
            Assert.IsTrue(isPublicHoliday);
        }
    }
}
