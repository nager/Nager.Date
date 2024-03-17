using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class ChileTest
    {
        [DataTestMethod]
        [DataRow(2015, 10, 12)]
        [DataRow(2016, 10, 10)]
        [DataRow(2017, 10, 9)]
        [DataRow(2018, 10, 13)]
        [DataRow(2019, 10, 12)]
        [DataRow(2020, 10, 12)]
        [DataRow(2021, 10, 11)]
        [DataRow(2022, 10, 10)]
        [DataRow(2023, 10, 9)]
        [DataRow(2024, 10, 12)]
        [DataRow(2025, 10, 12)]

        public void TestColumbusDay(int year, int month, int expectedDay)
        {
            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.CL).ToArray();

            var publicHoliday = publicHolidays.FirstOrDefault(holiday => holiday.EnglishName == "Columbus Day");
            Assert.IsNotNull(publicHoliday);
            Assert.AreEqual(new DateTime(year, month, expectedDay), publicHoliday.ObservedDate);
        }

        [DataTestMethod]
        [DataRow(2015, 10, 31)]
        [DataRow(2016, 10, 31)]
        [DataRow(2017, 10, 27)]
        [DataRow(2018, 11, 2)]
        [DataRow(2019, 10, 31)]
        [DataRow(2020, 10, 31)]
        [DataRow(2021, 10, 31)]
        [DataRow(2022, 10, 31)]
        [DataRow(2023, 10, 27)]
        [DataRow(2024, 10, 31)]
        [DataRow(2025, 10, 31)]

        public void TestReformationDay(int year, int month, int expectedDay)
        {
            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.CL).ToArray();

            var publicHoliday = publicHolidays.FirstOrDefault(holiday => holiday.EnglishName == "Reformation Day");
            Assert.IsNotNull(publicHoliday);
            Assert.AreEqual(new DateTime(year, month, expectedDay), publicHoliday.ObservedDate);
        }
    }
}
