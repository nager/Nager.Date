using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class ChileTest
    {
        [TestMethod]
        [DataRow(1999, 10, 12)]
        [DataRow(2015, 10, 12)]
        [DataRow(2016, 10, 10)]
        [DataRow(2017, 10, 9)]
        [DataRow(2018, 10, 15)]
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

        [TestMethod]
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
        [TestMethod]
        [DataRow(1999, 6, 29)]
        [DataRow(2017, 6, 26)]
        [DataRow(2018, 7, 2)]
        [DataRow(2019, 6, 29)]
        [DataRow(2023, 6, 26)]
        [DataRow(2024, 6, 29)]
        [DataRow(2029, 7, 2)]
        public void TestSaintPeterAndSaintPaul(int year, int month, int expectedDay)
        {
            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.CL).ToArray();

            var publicHoliday = publicHolidays.FirstOrDefault(holiday => holiday.EnglishName == "Saint Peter and Saint Paul");
            Assert.IsNotNull(publicHoliday);
            Assert.AreEqual(new DateTime(year, month, expectedDay), publicHoliday.ObservedDate);
        }

        [TestMethod]
        [DataRow(2018, 9, 17)]
        [DataRow(2019, 9, 20)]
        [DataRow(2021, 9, 17)]
        [DataRow(2022, 9, 16)]
        [DataRow(2024, 9, 20)]
        [DataRow(2027, 9, 17)]
        public void TestAdditionalNationalHoliday(int year, int month, int expectedDay)
        {
            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.CL).ToArray();

            var publicHoliday = publicHolidays.FirstOrDefault(holiday => holiday.EnglishName == "Additional National holiday");
            Assert.IsNotNull(publicHoliday);
            Assert.AreEqual(new DateTime(year, month, expectedDay), publicHoliday.Date);
        }

        [TestMethod]
        [DataRow(2020)]
        [DataRow(2023)]
        [DataRow(2025)]
        [DataRow(2026)]
        public void TestNoAdditionalNationalHoliday(int year)
        {
            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.CL).ToArray();

            var publicHoliday = publicHolidays.FirstOrDefault(holiday => holiday.EnglishName == "Additional National holiday");
            Assert.IsNull(publicHoliday);
        }

        [TestMethod]
        public void TestNationalCensus2017()
        {
            var isHoliday = HolidaySystem.IsPublicHoliday(new DateTime(2017, 4, 19), CountryCode.CL);
            Assert.IsTrue(isHoliday);
        }

        [TestMethod]
        public void TestPapalVisit2018IsRegional()
        {
            var publicHolidays = HolidaySystem.GetHolidays(2018, CountryCode.CL).ToArray();

            var papalVisit = publicHolidays.Where(holiday => holiday.EnglishName == "Papal visit").ToArray();
            Assert.AreEqual(3, papalVisit.Length);
            Assert.IsTrue(papalVisit.All(holiday => !holiday.NationalHoliday));
        }
    }
}
