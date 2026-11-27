using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Models;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    /// <summary>
    /// Expected days off from the government office calendars of the DGPA,
    /// https://data.gov.tw/dataset/14718
    /// </summary>
    [TestClass]
    public class TaiwanTest
    {
        [TestMethod]
        [DataRow(2020, 4, 4)]
        [DataRow(2021, 4, 4)]
        [DataRow(2023, 4, 5)]
        [DataRow(2024, 4, 4)]
        [DataRow(2026, 4, 5)]
        [DataRow(2027, 4, 5)]
        [DataRow(2100, 4, 5)]
        public void TombSweepingDay(int year, int expectedMonth, int expectedDay)
        {
            var holiday = HolidaySystem.GetHolidays(year, CountryCode.TW).Single(o => o.Id == "TW-TOMBSWEEPINGDAY-01");

            Assert.AreEqual(new DateTime(year, expectedMonth, expectedDay), holiday.Date);
        }

        [TestMethod]
        [DataRow(2017, "2017-04-03", "2017-04-04")] // same day, Tuesday
        [DataRow(2020, "2020-04-03", "2020-04-02")] // same day, Saturday
        [DataRow(2021, "2021-04-02", "2021-04-05")] // same day, Sunday
        [DataRow(2024, "2024-04-05", "2024-04-04")] // same day, Thursday
        [DataRow(2025, "2025-04-03", "2025-04-04")] // same day, Friday
        [DataRow(2026, "2026-04-03", "2026-04-06")] // Saturday and Sunday
        [DataRow(2027, "2027-04-06", "2027-04-05")] // Sunday and Monday
        public void ChildrensDayAndTombSweepingDayObserved(int year, string childrensDayObserved, string tombSweepingDayObserved)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.TW).ToArray();

            Assert.AreEqual(DateTime.Parse(childrensDayObserved), holidays.Single(o => o.Id == "TW-CHILDRENSDAY-01").ObservedDate);
            Assert.AreEqual(DateTime.Parse(tombSweepingDayObserved), holidays.Single(o => o.Id == "TW-TOMBSWEEPINGDAY-01").ObservedDate);
        }

        [TestMethod]
        [DataRow(2018, new[] { "2018-02-15", "2018-02-16", "2018-02-19", "2018-02-20" })]
        [DataRow(2023, new[] { "2023-01-23", "2023-01-24", "2023-01-25", "2023-01-26" })]
        [DataRow(2025, new[] { "2025-01-28", "2025-01-29", "2025-01-30", "2025-01-31" })]
        [DataRow(2026, new[] { "2026-02-16", "2026-02-17", "2026-02-18", "2026-02-19", "2026-02-20" })]
        [DataRow(2027, new[] { "2027-02-04", "2027-02-05", "2027-02-08", "2027-02-09", "2027-02-10" })]
        public void LunarNewYearDaysOff(int year, string[] expectedDaysOff)
        {
            var daysOff = HolidaySystem.GetHolidays(year, CountryCode.TW)
                .Where(o => o.Id.StartsWith("TW-LUNARNEWYEAR-"))
                .Select(o => o.ObservedDate)
                .OrderBy(o => o)
                .ToArray();

            CollectionAssert.AreEqual(expectedDaysOff.Select(DateTime.Parse).ToArray(), daysOff);
        }

        [TestMethod]
        public void HolidaysAddedIn2025()
        {
            var holidays2025 = HolidaySystem.GetHolidays(2025, CountryCode.TW).ToArray();

            Assert.AreEqual(new DateTime(2025, 9, 29), holidays2025.Single(o => o.Id == "TW-TEACHERSDAY-01").ObservedDate);
            Assert.AreEqual(new DateTime(2025, 10, 24), holidays2025.Single(o => o.Id == "TW-RETROCESSIONDAY-01").ObservedDate);
            Assert.AreEqual(new DateTime(2025, 12, 25), holidays2025.Single(o => o.Id == "TW-CONSTITUTIONDAY-01").ObservedDate);
            Assert.AreEqual(HolidayTypes.Optional, holidays2025.Single(o => o.Id == "TW-LABOURDAY-01").HolidayTypes);

            var holidays2024 = HolidaySystem.GetHolidays(2024, CountryCode.TW).ToArray();
            Assert.IsFalse(holidays2024.Any(o => o.Id == "TW-TEACHERSDAY-01"));

            var holidays2027 = HolidaySystem.GetHolidays(2027, CountryCode.TW).ToArray();
            var labourDay = holidays2027.Single(o => o.Id == "TW-LABOURDAY-01");
            Assert.AreEqual(HolidayTypes.Public, labourDay.HolidayTypes);
            Assert.AreEqual(new DateTime(2027, 4, 30), labourDay.ObservedDate);
            Assert.AreEqual(new DateTime(2027, 12, 24), holidays2027.Single(o => o.Id == "TW-CONSTITUTIONDAY-01").ObservedDate);
        }

        [TestMethod]
        public void NewYearsDayOnSaturdayIsObservedInThePreviousYear()
        {
            var holiday = HolidaySystem.GetHolidays(2028, CountryCode.TW).Single(o => o.Id == "TW-NEWYEARSDAY-01");

            Assert.AreEqual(new DateTime(2027, 12, 31), holiday.ObservedDate);
        }
    }
}
