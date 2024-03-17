using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class BrazilTest
    {
        [TestMethod]
        public void TestBrazil()
        {
            var testDate = new DateTime(2022, 10, 12);
            var isPublicHoliday = HolidaySystem.IsPublicHoliday(testDate, CountryCode.BR);
            Assert.AreEqual(true, isPublicHoliday);
        }

        [DataTestMethod]
        [DataRow("BR-SP", true)]
        public void TestBrazilSPRevolutionOf1932(string countyCode, bool expected)
        {
            var testDate = new DateTime(2022, 07, 09);
            var isPublicHoliday = HolidaySystem.IsPublicHoliday(testDate, CountryCode.BR, countyCode);
            Assert.AreEqual(expected, isPublicHoliday);
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
            var isWeekend = date.IsWeekend(CountryCode.BR);
            Assert.AreEqual(expectedIsWeekend, isWeekend);
        }
    }
}
