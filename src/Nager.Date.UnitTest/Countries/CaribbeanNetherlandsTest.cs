using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class CaribbeanNetherlandsTest
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

        [DataRow(2021, 2021, 4, 2)]
        [DataRow(2022, 2022, 4, 15)]
        [DataRow(2023, 2023, 4, 7)]
        [DataRow(2024, 2024, 3, 29)]
        [DataRow(2025, 2025, 4, 18)]
        [DataRow(2026, 2026, 4, 3)]
        [DataRow(2027, 2027, 3, 26)]
        [TestMethod]
        public void TestGoodFriday(int year, int observedYear, int month, int day)
        {
            AssertObservedDate(year, "CGOODFRIDAY-01", observedYear, month, day);
        }


        [DataRow(2025, 2025, 4, 27)]
        [DataRow(2026, 2026, 4, 27)]
        [TestMethod]
        public void TestKingsBirthday(int year, int observedYear, int month, int day)
        {
            AssertObservedDate(year, "KINGSBIRTHDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 5, 1)]
        [DataRow(2022, 2022, 5, 1)]
        [DataRow(2023, 2023, 5, 1)]
        [DataRow(2024, 2024, 5, 1)]
        [DataRow(2025, 2025, 5, 1)]
        [DataRow(2026, 2026, 5, 1)]
        [DataRow(2027, 2027, 5, 1)]
        [TestMethod]
        public void TestLabourDay(int year, int observedYear, int month, int day)
        {
            AssertObservedDate(year, "LABOURDAY-01", observedYear, month, day);
        }

        [DataRow(2025, 2025, 5, 29)]
        [DataRow(2026, 2026, 5, 14)]
        [TestMethod]
        public void TestAscensionDay(int year, int observedYear, int month, int day)
        {
            AssertObservedDate(year, "CASCENSIONDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 12, 25)]
        [DataRow(2022, 2022, 12, 25)]
        [DataRow(2023, 2023, 12, 25)]
        [DataRow(2024, 2024, 12, 25)]
        [DataRow(2025, 2025, 12, 25)]
        [DataRow(2026, 2026, 12, 25)]
        [DataRow(2027, 2027, 12, 25)]
        [TestMethod]
        public void TestChristmasDay(int year, int observedYear, int month, int day)
        {
            AssertObservedDate(year, "CHRISTMASDAY-01", observedYear, month, day);
        }

        [DataRow(2025, 2025, 8, 4)]
        [DataRow(2026, 2026, 8, 3)]
        [TestMethod]
        public void TestCarnivalMonday(int year, int observedYear, int month, int day)
        {
            AssertObservedDate(year, "CARNIVAL-01", observedYear, month, day);
        }

        [DataRow(2025, 2025, 12, 5)]
        [DataRow(2026, 2026, 12, 4)]
        [TestMethod]
        public void TestSabaDay(int year, int observedYear, int month, int day)
        {
            AssertObservedDate(year, "SABADAY-01", observedYear, month, day);
        }

        private static void AssertObservedDate(int year, string holidayId, int observedYear, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.BQ);
            var holiday = holidays.Single(o => o.Id.EndsWith(holidayId));

            Assert.AreEqual(new DateTime(observedYear, month, day), holiday.ObservedDate);
        }
    }
}
