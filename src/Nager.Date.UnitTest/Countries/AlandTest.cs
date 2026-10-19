using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class AlandTest
    {
        [DataRow(2021, 2021, 1, 1)]
        [DataRow(2022, 2022, 1, 1)]
        [DataRow(2023, 2023, 1, 1)]
        [DataRow(2024, 2024, 1, 1)]
        [DataRow(2025, 2025, 1, 1)]
        [DataRow(2026, 2026, 1, 1)]
        [DataRow(2027, 2027, 1, 1)]
        [TestMethod]
        public void TestNewYearsDay(int year, int observedYear, int month, int day)
        {
            AssertObservedDate(year, "NEWYEARSDAY-01", observedYear, month, day);
        }

        [DataRow(2024, 2024, 11, 2)]
        [DataRow(2025, 2025, 11, 1)]
        [DataRow(2026, 2026, 10, 31)]
        [DataRow(2027, 2027, 11, 6)]
        [TestMethod]
        public void TestAllSaintsDay(int year, int observedYear, int month, int day)
        {
            AssertObservedDate(year, "ALLSAINTSDAY-01", observedYear, month, day);
        }

        private static void AssertObservedDate(int year, string holidayId, int observedYear, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.AX);
            var holiday = holidays.Single(o => o.Id.EndsWith(holidayId));

            Assert.AreEqual(new DateTime(observedYear, month, day), holiday.ObservedDate);
        }
    }
}
