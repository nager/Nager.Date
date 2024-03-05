using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class AustriaTest
    {
        [TestMethod]
        public void TestAustria2017()
        {
            var year = 2017;
            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.AT).ToArray();

            Assert.AreEqual(new DateTime(year, 1, 1), publicHolidays[0].Date, $"{publicHolidays[0].EnglishName} is wrong");
            Assert.AreEqual(new DateTime(year, 1, 6), publicHolidays[1].Date, $"{publicHolidays[1].EnglishName} is wrong");
            Assert.AreEqual(new DateTime(year, 4, 17), publicHolidays[2].Date, $"{publicHolidays[2].EnglishName} is wrong");
            Assert.AreEqual(new DateTime(year, 5, 1), publicHolidays[3].Date, $"{publicHolidays[3].EnglishName} is wrong");
            Assert.AreEqual(new DateTime(year, 5, 25), publicHolidays[4].Date, $"{publicHolidays[4].EnglishName} is wrong");
            Assert.AreEqual(new DateTime(year, 6, 5), publicHolidays[5].Date, $"{publicHolidays[5].EnglishName} is wrong");
            Assert.AreEqual(new DateTime(year, 6, 15), publicHolidays[6].Date, $"{publicHolidays[6].EnglishName} is wrong");
            Assert.AreEqual(new DateTime(year, 8, 15), publicHolidays[7].Date, $"{publicHolidays[7].EnglishName} is wrong");
            Assert.AreEqual(new DateTime(year, 10, 26), publicHolidays[8].Date, $"{publicHolidays[8].EnglishName} is wrong");
            Assert.AreEqual(new DateTime(year, 11, 1), publicHolidays[9].Date, $"{publicHolidays[9].EnglishName} is wrong");
            Assert.AreEqual(new DateTime(year, 12, 8), publicHolidays[10].Date, $"{publicHolidays[10].EnglishName} is wrong");
            Assert.AreEqual(new DateTime(year, 12, 25), publicHolidays[11].Date, $"{publicHolidays[11].EnglishName} is wrong");
            Assert.AreEqual(new DateTime(year, 12, 26), publicHolidays[12].Date, $"{publicHolidays[12].EnglishName} is wrong");
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
            var isWeekend = date.IsWeekend(CountryCode.AT);
            Assert.AreEqual(expectedIsWeekend, isWeekend);
        }
    }
}
