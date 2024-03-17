using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class UnitedKingdomTest
    {
        [TestMethod]
        public void TestUnitedKingdom()
        {
            var testDate = new DateTime(2017, 08, 28);
            var isPublicHoliday = HolidaySystem.IsPublicHoliday(testDate, CountryCode.GB, "GB-ENG");
            Assert.IsTrue(isPublicHoliday);
        }

        [TestMethod]
        public void TestUnitedKingdomStPatricksDay()
        {
            var testDate = new DateTime(2017, 03, 17);
            var isPublicHoliday = HolidaySystem.IsPublicHoliday(testDate, CountryCode.GB, "GB-NIR");
            Assert.IsTrue(isPublicHoliday);
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
            var isWeekend = date.IsWeekend(CountryCode.US);
            Assert.AreEqual(expectedIsWeekend, isWeekend);
        }

        [DataTestMethod]
        [DataRow(2019, 5, 6, true)]
        [DataRow(2020, 5, 1, false)]
        [DataRow(2020, 5, 8, true)]
        public void CheckMayDay(int year, int month, int day, bool expectedIsPublicHoliday)
        {
            var date = new DateTime(year, month, day);
            var isPublicHoliday = HolidaySystem.IsPublicHoliday(date, CountryCode.GB);
            Assert.AreEqual(expectedIsPublicHoliday, isPublicHoliday);
        }

        [DataTestMethod]
        [DataRow(2015, 12, 25, 28)]
        [DataRow(2016, 12, 27, 26)]
        [DataRow(2017, 12, 25, 26)]
        [DataRow(2018, 12, 25, 26)]
        [DataRow(2019, 12, 25, 26)]
        [DataRow(2020, 12, 25, 28)]
        [DataRow(2021, 12, 27, 28)]
        public void CheckChristmasDayAndBoxingDay(int year, int month, int expectedChristmasDay, int expectedBoxingDay)
        {
            Assert.IsTrue(HolidaySystem.IsPublicHoliday(new DateTime(year, month, expectedChristmasDay), CountryCode.GB));
            Assert.IsTrue(HolidaySystem.IsPublicHoliday(new DateTime(year, month, expectedBoxingDay), CountryCode.GB));
        }

        [DataTestMethod]
        [DataRow(2021, 9, 19, false)]
        [DataRow(2022, 9, 19, true)]
        [DataRow(2023, 9, 19, false)]
        public void CheckQueensStateFuneral(int year, int month, int day, bool isBankHoliday)
        {
            Assert.AreEqual(HolidaySystem.IsPublicHoliday(new DateTime(year, month, day), CountryCode.GB), isBankHoliday);
        }

        [DataTestMethod]
        [DataRow(2021, 5, 8, false)]
        [DataRow(2022, 5, 8, false)]
        [DataRow(2023, 5, 8, true)]
        [DataRow(2024, 5, 8, false)]
        public void CheckKingCharlesCoronation(int year, int month, int day, bool isBankHoliday)
        {
            Assert.AreEqual(HolidaySystem.IsPublicHoliday(new DateTime(year, month, day), CountryCode.GB), isBankHoliday);
        }
    }
}
