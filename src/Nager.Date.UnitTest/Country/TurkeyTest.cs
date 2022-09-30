using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class TurkeyTest
    {
        [TestMethod]
        public void TestTurkey2017()
        {
            var year = 2017;
            var publicHolidays = DateSystem.GetPublicHolidays(year, CountryCode.TR).ToArray();

            Assert.AreEqual(new DateTime(year, 1, 1), publicHolidays[0].Date, $"{publicHolidays[0].Name} is wrong");
            Assert.AreEqual(new DateTime(year, 4, 23), publicHolidays[1].Date, $"{publicHolidays[1].Name} is wrong");
            Assert.AreEqual(new DateTime(year, 5, 1), publicHolidays[2].Date, $"{publicHolidays[2].Name} is wrong");
            Assert.AreEqual(new DateTime(year, 5, 19), publicHolidays[3].Date, $"{publicHolidays[3].Name} is wrong");
            Assert.AreEqual(new DateTime(year, 7, 15), publicHolidays[4].Date, $"{publicHolidays[4].Name} is wrong");
            Assert.AreEqual(new DateTime(year, 8, 30), publicHolidays[5].Date, $"{publicHolidays[5].Name} is wrong");
            Assert.AreEqual(new DateTime(year, 10, 29), publicHolidays[6].Date, $"{publicHolidays[6].Name} is wrong");
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
            var isWeekend = date.IsWeekend(CountryCode.TR);
            Assert.AreEqual(expectedIsWeekend, isWeekend);
        }
    }
}
