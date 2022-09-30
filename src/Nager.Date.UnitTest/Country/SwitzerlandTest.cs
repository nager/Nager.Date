using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class SwitzerlandTest
    {
        [Ignore]
        [TestMethod]
        public void TestSwitzerland()
        {
            for (var year = DateTime.Now.Year; year < 3000; year++)
            {
                var publicHolidays = DateSystem.GetPublicHolidays(year, CountryCode.CH);
                Assert.AreEqual(16, publicHolidays.Count());
            }
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
            var isWeekend = date.IsWeekend(CountryCode.CH);
            Assert.AreEqual(expectedIsWeekend, isWeekend);
        }
    }
}
