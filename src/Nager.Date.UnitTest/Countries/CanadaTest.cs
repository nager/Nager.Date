using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class CanadaTest
    {
        [TestMethod]
        public void TestCanada2017()
        {
            var year = 2017;
            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.CA).ToArray();

            //New Year's Day
            Assert.AreEqual(new DateTime(year, 1, 1), publicHolidays[0].Date, $"{publicHolidays[0].EnglishName} is wrong");
        }

        [DataTestMethod]
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
            var isWeekend = date.IsWeekend(CountryCode.CA);
            Assert.AreEqual(expectedIsWeekend, isWeekend);
        }
    }
}
