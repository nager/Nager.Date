using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Models;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class BeninTest() : BaseTest(CountryCode.BJ)
    {
        [TestMethod]
        [DataRow(2025, 1, 10)]
        [DataRow(2026, 1, 9)]
        [DataRow(2027, 1, 8)]
        public void TestVodounFestivalFrom2025(int year, int month, int day)
        {
            this.AssertObservedDate(year, "TRADITIONALDAY-01", year, month, day);
        }

        [TestMethod]
        [DataRow(2025, 1, 9)]
        [DataRow(2026, 1, 8)]
        [DataRow(2027, 1, 7)]
        public void TestVodounFestivalSecondDayFrom2025(int year, int month, int day)
        {
            this.AssertObservedDate(year, "TRADITIONALDAY-02", year, month, day);
        }

        [TestMethod]
        [DataRow(1998)]
        [DataRow(2024)]
        public void TestVodounFestivalFrom1998To2024(int year)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.BJ);

            Assert.AreEqual(new DateTime(year, 1, 10), holidays.Single(o => o.Id.EndsWith("TRADITIONALDAY-01")).Date);
            Assert.IsFalse(holidays.Any(o => o.Id.EndsWith("TRADITIONALDAY-02")));
        }

        [TestMethod]
        public void TestNoVodounFestivalBefore1998()
        {
            var holidays = HolidaySystem.GetHolidays(1997, CountryCode.BJ);

            Assert.IsFalse(holidays.Any(o => o.Id.Contains("TRADITIONALDAY")));
            Assert.IsFalse(HolidaySystem.IsPublicHoliday(new DateTime(1997, 1, 10), CountryCode.BJ));
        }

        [TestMethod]
        public void TestPublicHolidays2026()
        {
            var publicHolidays = HolidaySystem.GetHolidays(2026, CountryCode.BJ)
                .Where(o => o.HolidayTypes.HasFlag(HolidayTypes.Public))
                .Select(o => o.Date)
                .OrderBy(o => o)
                .ToArray();

            var expected = new[]
            {
                new DateTime(2026, 1, 1),
                new DateTime(2026, 1, 8),
                new DateTime(2026, 1, 9),
                new DateTime(2026, 4, 6),
                new DateTime(2026, 5, 1),
                new DateTime(2026, 5, 14),
                new DateTime(2026, 5, 25),
                new DateTime(2026, 8, 1),
                new DateTime(2026, 8, 15),
                new DateTime(2026, 11, 1),
                new DateTime(2026, 12, 25),
            };

            CollectionAssert.AreEqual(expected, publicHolidays);
        }

        [TestMethod]
        [DataRow(2026, 4, 5)]
        [DataRow(2026, 10, 26)]
        [DataRow(2026, 11, 30)]
        [DataRow(2026, 12, 26)]
        public void TestNotAPublicHoliday(int year, int month, int day)
        {
            Assert.IsFalse(HolidaySystem.IsPublicHoliday(new DateTime(year, month, day), CountryCode.BJ));
        }

        [TestMethod]
        [DataRow("REMEMBRANCEDAY-01", 1, 16)]
        [DataRow("PEOPLESSOVEREIGNTYDAY-01", 2, 28)]
        [DataRow("INTERNATIONALWOMENSDAY-01", 3, 8)]
        public void TestNationalDaysAreObservances(string holidayId, int month, int day)
        {
            var holiday = HolidaySystem.GetHolidays(2026, CountryCode.BJ).Single(o => o.Id.EndsWith(holidayId));

            Assert.AreEqual(new DateTime(2026, month, day), holiday.Date);
            Assert.AreEqual(HolidayTypes.Observance, holiday.HolidayTypes);
            Assert.IsFalse(HolidaySystem.IsPublicHoliday(holiday.Date, CountryCode.BJ));
        }
    }
}
