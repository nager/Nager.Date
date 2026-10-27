using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class GeorgiaTest() : BaseTest(CountryCode.GE)
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
            this.AssertObservedDate(year, "NEWYEARSDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 1, 2)]
        [DataRow(2022, 2022, 1, 2)]
        [DataRow(2023, 2023, 1, 2)]
        [DataRow(2024, 2024, 1, 2)]
        [DataRow(2025, 2025, 1, 2)]
        [DataRow(2026, 2026, 1, 2)]
        [DataRow(2027, 2027, 1, 2)]
        [TestMethod]
        public void TestNewYearsDay2(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NEWYEARSDAY-02", observedYear, month, day);
        }

        [DataRow(2021, 2021, 1, 7)]
        [DataRow(2022, 2022, 1, 7)]
        [DataRow(2023, 2023, 1, 7)]
        [DataRow(2024, 2024, 1, 7)]
        [DataRow(2025, 2025, 1, 7)]
        [DataRow(2026, 2026, 1, 7)]
        [DataRow(2027, 2027, 1, 7)]
        [TestMethod]
        public void TestOrthodoxChristmas(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "OCHRISTMAS-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 1, 19)]
        [DataRow(2022, 2022, 1, 19)]
        [DataRow(2023, 2023, 1, 19)]
        [DataRow(2024, 2024, 1, 19)]
        [DataRow(2025, 2025, 1, 19)]
        [DataRow(2026, 2026, 1, 19)]
        [DataRow(2027, 2027, 1, 19)]
        [TestMethod]
        public void TestEpiphany(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "OEPIPHANY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 3, 3)]
        [DataRow(2022, 2022, 3, 3)]
        [DataRow(2023, 2023, 3, 3)]
        [DataRow(2024, 2024, 3, 3)]
        [DataRow(2025, 2025, 3, 3)]
        [DataRow(2026, 2026, 3, 3)]
        [DataRow(2027, 2027, 3, 3)]
        [TestMethod]
        public void TestMothersDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "MOTHERSDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 3, 8)]
        [DataRow(2022, 2022, 3, 8)]
        [DataRow(2023, 2023, 3, 8)]
        [DataRow(2024, 2024, 3, 8)]
        [DataRow(2025, 2025, 3, 8)]
        [DataRow(2026, 2026, 3, 8)]
        [DataRow(2027, 2027, 3, 8)]
        [TestMethod]
        public void TestInternationalWomensDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "INTERNATIONALWOMENSDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 4, 9)]
        [DataRow(2022, 2022, 4, 9)]
        [DataRow(2023, 2023, 4, 9)]
        [DataRow(2024, 2024, 4, 9)]
        [DataRow(2025, 2025, 4, 9)]
        [DataRow(2026, 2026, 4, 9)]
        [DataRow(2027, 2027, 4, 9)]
        [TestMethod]
        public void TestNationalUnityDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NATIONALUNITYDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 4, 30)]
        [DataRow(2022, 2022, 4, 22)]
        [DataRow(2023, 2023, 4, 14)]
        [DataRow(2024, 2024, 5, 3)]
        [DataRow(2025, 2025, 4, 18)]
        [DataRow(2026, 2026, 4, 10)]
        [DataRow(2027, 2027, 4, 30)]
        [TestMethod]
        public void TestGoodFriday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "OGOODFRIDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 5, 1)]
        [DataRow(2022, 2022, 4, 23)]
        [DataRow(2023, 2023, 4, 15)]
        [DataRow(2024, 2024, 5, 4)]
        [DataRow(2025, 2025, 4, 19)]
        [DataRow(2026, 2026, 4, 11)]
        [DataRow(2027, 2027, 5, 1)]
        [TestMethod]
        public void TestHolySaturday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "OHOLYSATURDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 5, 2)]
        [DataRow(2022, 2022, 4, 24)]
        [DataRow(2023, 2023, 4, 16)]
        [DataRow(2024, 2024, 5, 5)]
        [DataRow(2025, 2025, 4, 20)]
        [DataRow(2026, 2026, 4, 12)]
        [DataRow(2027, 2027, 5, 2)]
        [TestMethod]
        public void TestEasterSunday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "OEASTERSUNDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 5, 3)]
        [DataRow(2022, 2022, 4, 25)]
        [DataRow(2023, 2023, 4, 17)]
        [DataRow(2024, 2024, 5, 6)]
        [DataRow(2025, 2025, 4, 21)]
        [DataRow(2026, 2026, 4, 13)]
        [DataRow(2027, 2027, 5, 3)]
        [TestMethod]
        public void TestEasterMonday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "OEASTERMONDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 5, 9)]
        [DataRow(2022, 2022, 5, 9)]
        [DataRow(2023, 2023, 5, 9)]
        [DataRow(2024, 2024, 5, 9)]
        [DataRow(2025, 2025, 5, 9)]
        [DataRow(2026, 2026, 5, 9)]
        [DataRow(2027, 2027, 5, 9)]
        [TestMethod]
        public void TestVictoryDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "DAYOFVICTORYOVERFASCISM-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 5, 12)]
        [DataRow(2022, 2022, 5, 12)]
        [DataRow(2023, 2023, 5, 12)]
        [DataRow(2024, 2024, 5, 12)]
        [DataRow(2025, 2025, 5, 12)]
        [DataRow(2026, 2026, 5, 12)]
        [DataRow(2027, 2027, 5, 12)]
        [TestMethod]
        public void TestSaintAndrewDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "SAINTANDREWTHEFIRSTCALLEDDAY-01", observedYear, month, day);
        }

        [DataRow(2025, 2025, 5, 17)]
        [DataRow(2026, 2026, 5, 17)]
        [DataRow(2027, 2027, 5, 17)]
        [TestMethod]
        public void TestDayOfFamilySanctity(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "FAMILYSANCTITYDAY-01", observedYear, month, day);
        }

        [DataRow(2021)]
        [DataRow(2022)]
        [DataRow(2023)]
        [TestMethod]
        public void TestDayOfFamilySanctityNotPresentBeforeIntroduction(int year)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.GE);

            Assert.IsFalse(holidays.Any(o => o.Id.EndsWith("FAMILYSANCTITYDAY-01")));
        }

        [DataRow(2021, 2021, 5, 26)]
        [DataRow(2022, 2022, 5, 26)]
        [DataRow(2023, 2023, 5, 26)]
        [DataRow(2024, 2024, 5, 26)]
        [DataRow(2025, 2025, 5, 26)]
        [DataRow(2026, 2026, 5, 26)]
        [DataRow(2027, 2027, 5, 26)]
        [TestMethod]
        public void TestIndependenceDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "INDEPENDENCEDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 8, 28)]
        [DataRow(2022, 2022, 8, 28)]
        [DataRow(2023, 2023, 8, 28)]
        [DataRow(2024, 2024, 8, 28)]
        [DataRow(2025, 2025, 8, 28)]
        [DataRow(2026, 2026, 8, 28)]
        [DataRow(2027, 2027, 8, 28)]
        [TestMethod]
        public void TestSaintMarysDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "SAINTMARYSDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 10, 14)]
        [DataRow(2022, 2022, 10, 14)]
        [DataRow(2023, 2023, 10, 14)]
        [DataRow(2024, 2024, 10, 14)]
        [DataRow(2025, 2025, 10, 14)]
        [DataRow(2026, 2026, 10, 14)]
        [DataRow(2027, 2027, 10, 14)]
        [TestMethod]
        public void TestSvetitskhovloba(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "DAYOFSVETITSKHOVELICATHEDRA-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 11, 23)]
        [DataRow(2022, 2022, 11, 23)]
        [DataRow(2023, 2023, 11, 23)]
        [DataRow(2024, 2024, 11, 23)]
        [DataRow(2025, 2025, 11, 23)]
        [DataRow(2026, 2026, 11, 23)]
        [DataRow(2027, 2027, 11, 23)]
        [TestMethod]
        public void TestSaintGeorgesDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "SAINTGEORGESDAY-01", observedYear, month, day);
        }
    }
}
