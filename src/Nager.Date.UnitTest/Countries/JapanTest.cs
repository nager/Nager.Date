using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class JapanTest
    {
        [DataTestMethod]
        [DataRow(1955, 1955, 03, 21)]
        [DataRow(1956, 1956, 03, 21)]
        [DataRow(1964, 1964, 03, 20)]
        [DataRow(1965, 1965, 03, 21)]
        [DataRow(1968, 1968, 03, 20)]
        [DataRow(2017, 2017, 03, 20)]
        [DataRow(2018, 2018, 03, 21)]
        [DataRow(2022, 2022, 03, 21)]
        public void Check_VernalEquinoxDay(int year, int expectedYear, int expectedMonth, int expectedDay)
        {
            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.JP).ToArray();
            var publicHoliday = publicHolidays.Where(o => o.EnglishName == "Vernal Equinox Day").SingleOrDefault();

            Assert.AreEqual(new DateTime(expectedYear, expectedMonth, expectedDay), publicHoliday.Date);
        }

        [DataTestMethod]
        [DataRow(1955, 1955, 09, 24)]
        [DataRow(1956, 1956, 09, 23)]
        [DataRow(1964, 1964, 09, 23)]
        [DataRow(1965, 1965, 09, 23)]
        [DataRow(1968, 1968, 09, 23)]
        [DataRow(2017, 2017, 09, 23)]
        [DataRow(2016, 2016, 09, 22)]
        [DataRow(2018, 2018, 09, 23)]
        [DataRow(2020, 2020, 09, 22)]
        [DataRow(2022, 2022, 09, 23)]
        public void Check_AutumnalEquinoxDay(int year, int expectedYear, int expectedMonth, int expectedDay)
        {
            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.JP).ToArray();
            var publicHoliday = publicHolidays.Where(o => o.EnglishName == "Autumnal Equinox Day").SingleOrDefault();

            Assert.AreEqual(new DateTime(expectedYear, expectedMonth, expectedDay), publicHoliday.Date);
        }
    }
}
