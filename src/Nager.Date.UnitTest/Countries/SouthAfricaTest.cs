using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class SouthAfricaTest
    {
        [DataTestMethod]
        [DataRow(2021, 25)]
        [DataRow(2022, 27)]
        public void CheckChristmasDayShiftIn2022(int year, int day)
        {
            var expectedDate = new DateTime(year, 12, day);

            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.ZA);
            var publicHoliday = publicHolidays.Where(publicHoliday => publicHoliday.EnglishName == "Christmas Day").FirstOrDefault();

            Assert.AreEqual(expectedDate, publicHoliday.ObservedDate);
        }
    }
}
