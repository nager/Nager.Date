using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class MontserratTest() : BaseTest(CountryCode.MS)
    {
        [TestMethod]
        [DataRow(2021, 2021, 1, 1)]
        [DataRow(2022, 2022, 1, 3)]
        [DataRow(2023, 2023, 1, 3)]
        [DataRow(2024, 2024, 1, 1)]
        [DataRow(2025, 2025, 1, 1)]
        [DataRow(2026, 2026, 1, 1)]
        [DataRow(2027, 2027, 1, 1)]
        public void TestNewYearsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NEWYEARSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 3, 17)]
        [DataRow(2022, 2022, 3, 17)]
        [DataRow(2023, 2023, 3, 17)]
        [DataRow(2024, 2024, 3, 18)]
        [DataRow(2025, 2025, 3, 17)]
        [DataRow(2026, 2026, 3, 17)]
        [DataRow(2027, 2027, 3, 17)]
        public void TestSaintPatricksDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "SAINTPATRICKSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 4, 2)]
        [DataRow(2022, 2022, 4, 15)]
        [DataRow(2023, 2023, 4, 7)]
        [DataRow(2024, 2024, 3, 29)]
        [DataRow(2025, 2025, 4, 18)]
        [DataRow(2026, 2026, 4, 3)]
        [DataRow(2027, 2027, 3, 26)]
        public void TestGoodFriday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CGOODFRIDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 4, 5)]
        [DataRow(2022, 2022, 4, 18)]
        [DataRow(2023, 2023, 4, 10)]
        [DataRow(2024, 2024, 4, 1)]
        [DataRow(2025, 2025, 4, 21)]
        [DataRow(2026, 2026, 4, 6)]
        [DataRow(2027, 2027, 3, 29)]
        public void TestEasterMonday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CEASTERMONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 5, 3)]
        [DataRow(2022, 2022, 5, 2)]
        [DataRow(2023, 2023, 5, 1)]
        [DataRow(2024, 2024, 5, 6)]
        [DataRow(2025, 2025, 5, 5)]
        [DataRow(2026, 2026, 5, 4)]
        [DataRow(2027, 2027, 5, 3)]
        public void TestLabourDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "LABOURDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 5, 24)]
        [DataRow(2022, 2022, 6, 6)]
        [DataRow(2023, 2023, 5, 29)]
        [DataRow(2024, 2024, 5, 20)]
        [DataRow(2025, 2025, 6, 9)]
        [DataRow(2026, 2026, 5, 25)]
        [DataRow(2027, 2027, 5, 17)]
        public void TestWhitMonday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CWHITMONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 6, 14)]
        [DataRow(2022, 2022, 6, 13)]
        [DataRow(2023, 2023, 6, 12)]
        [DataRow(2024, 2024, 6, 10)]
        [DataRow(2025, 2025, 6, 16)]
        [DataRow(2026, 2026, 6, 15)]
        [DataRow(2027, 2027, 6, 14)]
        public void TestKingsBirthday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "QUEENSBIRTHDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2024, 2024, 7, 10)]
        [DataRow(2025, 2025, 7, 9)]
        [DataRow(2026, 2026, 7, 8)]
        [DataRow(2027, 2027, 7, 14)]
        public void TestDayOfPrayerAndThanksgiving(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "DAYOFPRAYERANDTHANKSGIVING-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 8, 2)]
        [DataRow(2022, 2022, 8, 1)]
        [DataRow(2023, 2023, 8, 7)]
        [DataRow(2024, 2024, 8, 5)]
        [DataRow(2025, 2025, 8, 4)]
        [DataRow(2026, 2026, 8, 3)]
        [DataRow(2027, 2027, 8, 2)]
        public void TestEmancipationDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "EMANCIPATIONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 12, 27)]
        [DataRow(2022, 2022, 12, 27)]
        [DataRow(2023, 2023, 12, 25)]
        [DataRow(2024, 2024, 12, 25)]
        [DataRow(2025, 2025, 12, 25)]
        [DataRow(2026, 2026, 12, 25)]
        [DataRow(2027, 2027, 12, 27)]
        public void TestChristmasDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CHRISTMASDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 12, 28)]
        [DataRow(2022, 2022, 12, 26)]
        [DataRow(2023, 2023, 12, 26)]
        [DataRow(2024, 2024, 12, 26)]
        [DataRow(2025, 2025, 12, 26)]
        [DataRow(2026, 2026, 12, 28)]
        [DataRow(2027, 2027, 12, 28)]
        public void TestBoxingDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "BOXINGDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 12, 31)]
        [DataRow(2022, 2023, 1, 2)]
        [DataRow(2023, 2024, 1, 2)]
        [DataRow(2024, 2024, 12, 31)]
        [DataRow(2025, 2025, 12, 31)]
        [DataRow(2026, 2026, 12, 31)]
        [DataRow(2027, 2027, 12, 31)]
        public void TestFestivalDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "FESTIVALDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 6, 12)]
        [DataRow(2022, 2022, 6, 11)]
        [DataRow(2023, 2023, 6, 10)]
        [DataRow(2024, 2024, 6, 8)]
        [DataRow(2025, 2025, 6, 14)]
        [DataRow(2026, 2026, 6, 13)]
        [DataRow(2027, 2027, 6, 12)]
        public void TestKingsBirthdayDate(int year, int dateYear, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.MS);
            var holiday = holidays.Single(o => o.Id.EndsWith("QUEENSBIRTHDAY-01"));

            Assert.AreEqual(new DateTime(dateYear, month, day), holiday.Date);
        }

        [TestMethod]
        [DataRow(2022, "Queen's Birthday")]
        [DataRow(2023, "King's Birthday")]
        [DataRow(2026, "King's Birthday")]
        public void TestSovereignsBirthdayName(int year, string expectedName)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.MS);
            var holiday = holidays.Single(o => o.Id.EndsWith("QUEENSBIRTHDAY-01"));

            Assert.AreEqual(expectedName, holiday.EnglishName);
        }

        [TestMethod]
        [DataRow(2021)]
        [DataRow(2022)]
        [DataRow(2023)]
        public void TestDayOfPrayerAndThanksgivingNotPresentBefore2024(int year)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.MS);

            Assert.IsFalse(holidays.Any(o => o.Id.EndsWith("DAYOFPRAYERANDTHANKSGIVING-01")));
        }
    }
}
