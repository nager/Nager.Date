using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class GuernseyTest
    {
        [DataRow(2021, 2021, 1, 1)]
        [DataRow(2022, 2022, 1, 3)]
        [DataRow(2023, 2023, 1, 2)]
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
            AssertObservedDate(year, "GOODFRIDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 4, 5)]
        [DataRow(2022, 2022, 4, 18)]
        [DataRow(2023, 2023, 4, 10)]
        [DataRow(2024, 2024, 4, 1)]
        [DataRow(2025, 2025, 4, 21)]
        [DataRow(2026, 2026, 4, 6)]
        [DataRow(2027, 2027, 3, 29)]
        [TestMethod]
        public void TestEasterMonday(int year, int observedYear, int month, int day)
        {
            AssertObservedDate(year, "EASTERMONDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 5, 3)]
        [DataRow(2022, 2022, 5, 2)]
        [DataRow(2023, 2023, 5, 1)]
        [DataRow(2024, 2024, 5, 6)]
        [DataRow(2025, 2025, 5, 5)]
        [DataRow(2026, 2026, 5, 4)]
        [DataRow(2027, 2027, 5, 3)]
        [TestMethod]
        public void TestEarlyMayBankHoliday(int year, int observedYear, int month, int day)
        {
            AssertObservedDate(year, "EARLYMAYBANKHOLIDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 5, 9)]
        [DataRow(2022, 2022, 5, 9)]
        [DataRow(2023, 2023, 5, 9)]
        [DataRow(2024, 2024, 5, 9)]
        [DataRow(2025, 2025, 5, 9)]
        [DataRow(2026, 2026, 5, 9)]
        [DataRow(2027, 2027, 5, 9)]
        [TestMethod]
        public void TestLiberationDay(int year, int observedYear, int month, int day)
        {
            AssertObservedDate(year, "LIBERATIONDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 5, 31)]
        [DataRow(2022, 2022, 6, 2)]
        [DataRow(2023, 2023, 5, 29)]
        [DataRow(2024, 2024, 5, 27)]
        [DataRow(2025, 2025, 5, 26)]
        [DataRow(2026, 2026, 5, 25)]
        [DataRow(2027, 2027, 5, 31)]
        [TestMethod]
        public void TestSpringBankHoliday(int year, int observedYear, int month, int day)
        {
            AssertObservedDate(year, "SPRINGBANKHOLIDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 8, 30)]
        [DataRow(2022, 2022, 8, 29)]
        [DataRow(2023, 2023, 8, 28)]
        [DataRow(2024, 2024, 8, 26)]
        [DataRow(2025, 2025, 8, 25)]
        [DataRow(2026, 2026, 8, 31)]
        [DataRow(2027, 2027, 8, 30)]
        [TestMethod]
        public void TestSummerBankHoliday(int year, int observedYear, int month, int day)
        {
            AssertObservedDate(year, "SUMMERBANKHOLIDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 12, 27)]
        [DataRow(2022, 2022, 12, 27)]
        [DataRow(2023, 2023, 12, 25)]
        [DataRow(2024, 2024, 12, 25)]
        [DataRow(2025, 2025, 12, 25)]
        [DataRow(2026, 2026, 12, 25)]
        [DataRow(2027, 2027, 12, 27)]
        [TestMethod]
        public void TestChristmasDay(int year, int observedYear, int month, int day)
        {
            AssertObservedDate(year, "CHRISTMASDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 12, 28)]
        [DataRow(2022, 2022, 12, 26)]
        [DataRow(2023, 2023, 12, 26)]
        [DataRow(2024, 2024, 12, 26)]
        [DataRow(2025, 2025, 12, 26)]
        [DataRow(2026, 2026, 12, 28)]
        [DataRow(2027, 2027, 12, 28)]
        [TestMethod]
        public void TestBoxingDay(int year, int observedYear, int month, int day)
        {
            AssertObservedDate(year, "BOXINGDAY-01", observedYear, month, day);
        }

        [DataRow(2022, 2022, 6, 3)]
        [TestMethod]
        public void TestQueensPlatinumJubilee(int year, int observedYear, int month, int day)
        {
            AssertObservedDate(year, "QUEENSPLATINUMJUBILEE-01", observedYear, month, day);
        }

        [DataRow(2023, 2023, 5, 8)]
        [TestMethod]
        public void TestCoronationBankHoliday(int year, int observedYear, int month, int day)
        {
            AssertObservedDate(year, "CORONATIONBANKHOLIDAY-01", observedYear, month, day);
        }

        [DataRow(2021, "QUEENSPLATINUMJUBILEE-01")]
        [DataRow(2023, "QUEENSPLATINUMJUBILEE-01")]
        [DataRow(2022, "CORONATIONBANKHOLIDAY-01")]
        [DataRow(2024, "CORONATIONBANKHOLIDAY-01")]
        [TestMethod]
        public void TestOneOffHolidayNotPresentInOtherYears(int year, string holidayId)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.GG);

            Assert.IsFalse(holidays.Any(o => o.Id.EndsWith(holidayId)));
        }

        private static void AssertObservedDate(int year, string holidayId, int observedYear, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.GG);
            var holiday = holidays.Single(o => o.Id.EndsWith(holidayId));

            Assert.AreEqual(new DateTime(observedYear, month, day), holiday.ObservedDate);
        }
    }
}
