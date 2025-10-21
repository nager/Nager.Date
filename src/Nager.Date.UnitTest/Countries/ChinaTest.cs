using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class ChinaTest
    {
        [TestMethod]
        public void TestChina2015()
        {
            var publicHolidays = HolidaySystem.GetHolidays(2015, CountryCode.CN).ToArray();
            var isHolidayAvailable = publicHolidays.Any(o => o.Date == new DateTime(2015, 9, 27) && o.EnglishName == "Mid-Autumn Festival");

            Assert.IsTrue(isHolidayAvailable);
        }

        [TestMethod]
        public void TestChina2016()
        {
            var publicHolidays = HolidaySystem.GetHolidays(2016, CountryCode.CN).ToArray();
            var isHolidayAvailable = publicHolidays.Any(o => o.Date == new DateTime(2016, 9, 15) && o.EnglishName == "Mid-Autumn Festival");

            Assert.IsTrue(isHolidayAvailable);
        }

        [TestMethod]
        public void TestChina2017()
        {
            var publicHolidays = HolidaySystem.GetHolidays(2017, CountryCode.CN).ToArray();
            var isHolidayAvailable = publicHolidays.Any(o => o.Date == new DateTime(2017, 10, 4) && o.EnglishName == "Mid-Autumn Festival");

            Assert.IsTrue(isHolidayAvailable);
        }

        [TestMethod]
        public void TestChina2018()
        {
            var publicHolidays = HolidaySystem.GetHolidays(2018, CountryCode.CN).ToArray();
            var isHolidayAvailable = publicHolidays.Any(o => o.Date == new DateTime(2018, 9, 24) && o.EnglishName == "Mid-Autumn Festival");

            Assert.IsTrue(isHolidayAvailable);
        }

        [TestMethod]
        public void TestChina2019()
        {
            var publicHolidays = HolidaySystem.GetHolidays(2019, CountryCode.CN).ToArray();
            var isHolidayAvailable = publicHolidays.Any(o => o.Date == new DateTime(2019, 9, 13) && o.EnglishName == "Mid-Autumn Festival");

            Assert.IsTrue(isHolidayAvailable);
        }

        [TestMethod]
        public void TestChina2020()
        {
            var publicHolidays = HolidaySystem.GetHolidays(2020, CountryCode.CN).ToArray();
            var isHolidayAvailable = publicHolidays.Any(o => o.Date == new DateTime(2020, 10, 1) && o.EnglishName == "Mid-Autumn Festival");

            Assert.IsTrue(isHolidayAvailable);
        }

        [TestMethod]
        [DataRow(2018, 10, 8, false)]
        [DataRow(2018, 10, 9, false)]
        [DataRow(2018, 10, 10, false)]
        [DataRow(2018, 10, 11, false)]
        [DataRow(2018, 10, 12, false)]
        [DataRow(2018, 10, 13, true)]
        [DataRow(2018, 10, 14, true)]
        public void ChecksThatUniversalWeekendIsUsed(int year, int month, int day, bool expectedIsWeekend)
        {
            var date = new DateTime(year, month, day);
            var isWeekend = date.IsWeekend(CountryCode.CN);

            Assert.AreEqual(expectedIsWeekend, isWeekend);
        }
    }
}
