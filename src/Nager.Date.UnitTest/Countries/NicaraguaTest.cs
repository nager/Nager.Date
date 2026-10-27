using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Models;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class NicaraguaTest() : BaseTest(CountryCode.NI)
    {
        [TestMethod]
        [DataRow(2021, 2021, 1, 1)]
        [DataRow(2022, 2022, 1, 1)]
        [DataRow(2023, 2023, 1, 1)]
        [DataRow(2024, 2024, 1, 1)]
        [DataRow(2025, 2025, 1, 1)]
        [DataRow(2026, 2026, 1, 1)]
        [DataRow(2027, 2027, 1, 1)]
        public void TestNewYearsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NEWYEARSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 4, 1)]
        [DataRow(2022, 2022, 4, 14)]
        [DataRow(2023, 2023, 4, 6)]
        [DataRow(2024, 2024, 3, 28)]
        [DataRow(2025, 2025, 4, 17)]
        [DataRow(2026, 2026, 4, 2)]
        [DataRow(2027, 2027, 3, 25)]
        public void TestMaundyThursday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CMAUNDYTHURSDAY-01", observedYear, month, day);
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
        [DataRow(2021, 2021, 5, 1)]
        [DataRow(2022, 2022, 5, 1)]
        [DataRow(2023, 2023, 5, 1)]
        [DataRow(2024, 2024, 5, 1)]
        [DataRow(2025, 2025, 5, 1)]
        [DataRow(2026, 2026, 5, 1)]
        [DataRow(2027, 2027, 5, 1)]
        public void TestLabourDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "LABOURDAY-01", observedYear, month, day);
        }

        /// <summary>
        /// Ley N.º 1118, La Gaceta N.º 92 of 20 May 2022
        /// </summary>
        [TestMethod]
        [DataRow(2022, 2022, 5, 30)]
        [DataRow(2023, 2023, 5, 30)]
        [DataRow(2024, 2024, 5, 30)]
        [DataRow(2025, 2025, 5, 30)]
        [DataRow(2026, 2026, 5, 30)]
        [DataRow(2027, 2027, 5, 30)]
        public void TestMothersDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "MOTHERSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        public void TestMothersDayBefore2022IsNotPublic()
        {
            //Before Ley 1118 only a day off for the public sector
            Assert.IsFalse(HolidaySystem.IsPublicHoliday(new DateTime(2021, 5, 30), CountryCode.NI));

            var mothersDay = HolidaySystem.GetHolidays(2021, CountryCode.NI).Single(o => o.Id.EndsWith("MOTHERSDAY-01"));
            Assert.AreEqual(HolidayTypes.Authorities, mothersDay.HolidayTypes);
        }

        [TestMethod]
        [DataRow(2021, 2021, 7, 19)]
        [DataRow(2022, 2022, 7, 19)]
        [DataRow(2023, 2023, 7, 19)]
        [DataRow(2024, 2024, 7, 19)]
        [DataRow(2025, 2025, 7, 19)]
        [DataRow(2026, 2026, 7, 19)]
        [DataRow(2027, 2027, 7, 19)]
        public void TestLiberationDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "LIBERATIONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 9, 14)]
        [DataRow(2022, 2022, 9, 14)]
        [DataRow(2023, 2023, 9, 14)]
        [DataRow(2024, 2024, 9, 14)]
        [DataRow(2025, 2025, 9, 14)]
        [DataRow(2026, 2026, 9, 14)]
        [DataRow(2027, 2027, 9, 14)]
        public void TestBattleOfSanJacinto(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "BATTLESANJACINTO-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 9, 15)]
        [DataRow(2022, 2022, 9, 15)]
        [DataRow(2023, 2023, 9, 15)]
        [DataRow(2024, 2024, 9, 15)]
        [DataRow(2025, 2025, 9, 15)]
        [DataRow(2026, 2026, 9, 15)]
        [DataRow(2027, 2027, 9, 15)]
        public void TestIndependenceDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "INDEPENDENCEDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 12, 8)]
        [DataRow(2022, 2022, 12, 8)]
        [DataRow(2023, 2023, 12, 8)]
        [DataRow(2024, 2024, 12, 8)]
        [DataRow(2025, 2025, 12, 8)]
        [DataRow(2026, 2026, 12, 8)]
        [DataRow(2027, 2027, 12, 8)]
        public void TestImmaculateConception(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "IMMACULATECONCEPTION-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 12, 25)]
        [DataRow(2022, 2022, 12, 25)]
        [DataRow(2023, 2023, 12, 25)]
        [DataRow(2024, 2024, 12, 25)]
        [DataRow(2025, 2025, 12, 25)]
        [DataRow(2026, 2026, 12, 25)]
        [DataRow(2027, 2027, 12, 25)]
        public void TestChristmasDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CHRISTMASDAY-01", observedYear, month, day);
        }

        /// <summary>
        /// Ley N.º 1272, La Gaceta N.º 11 of 20 January 2026
        /// </summary>
        [TestMethod]
        [DataRow(2026, 2026, 1, 18)]
        [DataRow(2027, 2027, 1, 18)]
        public void TestRubenDarioBirthday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "RUBENDARIOBIRTHDAY-01", observedYear, month, day);
        }

        /// <summary>
        /// Ley N.º 1272, La Gaceta N.º 11 of 20 January 2026
        /// </summary>
        [TestMethod]
        [DataRow(2026, 2026, 2, 2)]
        [DataRow(2027, 2027, 2, 2)]
        public void TestReconciliationAndPeaceDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "RECONCILIATIONANDPEACEDAY-01", observedYear, month, day);
        }

        /// <summary>
        /// Ley N.º 1272, La Gaceta N.º 11 of 20 January 2026
        /// </summary>
        [TestMethod]
        [DataRow(2026, 2026, 2, 21)]
        [DataRow(2027, 2027, 2, 21)]
        public void TestSandinoDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "SANDINODAY-01", observedYear, month, day);
        }

        /// <summary>
        /// Ley N.º 1272, La Gaceta N.º 11 of 20 January 2026
        /// </summary>
        [TestMethod]
        [DataRow(2026, 2026, 11, 8)]
        [DataRow(2027, 2027, 11, 8)]
        public void TestCarlosFonsecaDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CARLOSFONSECADAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow("RUBENDARIOBIRTHDAY-01")]
        [DataRow("RECONCILIATIONANDPEACEDAY-01")]
        [DataRow("SANDINODAY-01")]
        [DataRow("CARLOSFONSECADAY-01")]
        public void TestLey1272HolidaysNotBefore2026(string holidayId)
        {
            Assert.IsFalse(HolidaySystem.GetHolidays(2025, CountryCode.NI).Any(o => o.Id == holidayId));
        }

        [TestMethod]
        public void TestNoPublicHoliday()
        {
            //Not listed in article 66
            Assert.IsFalse(HolidaySystem.IsPublicHoliday(new DateTime(2025, 2, 1), CountryCode.NI));
            Assert.IsFalse(HolidaySystem.IsPublicHoliday(new DateTime(2025, 4, 3), CountryCode.NI));
            Assert.IsFalse(HolidaySystem.IsPublicHoliday(new DateTime(2025, 5, 27), CountryCode.NI));
            Assert.IsFalse(HolidaySystem.IsPublicHoliday(new DateTime(2025, 10, 12), CountryCode.NI));
            Assert.IsFalse(HolidaySystem.IsPublicHoliday(new DateTime(2025, 12, 31), CountryCode.NI));
        }
    }
}
