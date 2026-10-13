using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class NorthernMarianaIslandsTest
    {
        [DataRow(2012, 2012, 1, 2)]
        [DataRow(2013, 2013, 1, 1)]
        [DataRow(2014, 2014, 1, 1)]
        [DataRow(2015, 2015, 1, 1)]
        [DataRow(2016, 2016, 1, 1)]
        [DataRow(2017, 2017, 1, 2)]
        [DataRow(2018, 2018, 1, 1)]
        [DataRow(2019, 2019, 1, 1)]
        [DataRow(2020, 2020, 1, 1)]
        [DataRow(2021, 2021, 1, 1)]
        [DataRow(2022, 2021, 12, 31)]
        [DataRow(2023, 2023, 1, 2)]
        [DataRow(2024, 2024, 1, 1)]
        [DataRow(2025, 2025, 1, 1)]
        [DataRow(2026, 2026, 1, 1)]
        [TestMethod]
        public void TestNewYearsDay(int year, int observedYear, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.MP);
            var holiday = holidays.Single(o => o.Id.EndsWith("NEWYEARSDAY-01"));

            Assert.AreEqual(new DateTime(observedYear, month, day), holiday.ObservedDate);
        }

        [DataRow(2012, 1, 16)]
        [DataRow(2013, 1, 21)]
        [DataRow(2014, 1, 20)]
        [DataRow(2015, 1, 19)]
        [DataRow(2016, 1, 18)]
        [DataRow(2017, 1, 16)]
        [DataRow(2018, 1, 15)]
        [DataRow(2019, 1, 21)]
        [DataRow(2020, 1, 20)]
        [DataRow(2021, 1, 18)]
        [DataRow(2022, 1, 17)]
        [DataRow(2023, 1, 16)]
        [DataRow(2024, 1, 15)]
        [DataRow(2025, 1, 20)]
        [DataRow(2026, 1, 19)]
        [TestMethod]
        public void TestMartinLutherKingJuniorDay(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.MP);
            var holiday = holidays.Single(o => o.Id.EndsWith("MARTINLUTHERKINGJRDAY-01"));

            Assert.AreEqual(new DateTime(year, month, day), holiday.Date);
        }

        [DataRow(2012, 2, 20)]
        [DataRow(2013, 2, 18)]
        [DataRow(2014, 2, 17)]
        [DataRow(2015, 2, 16)]
        [DataRow(2016, 2, 15)]
        [DataRow(2017, 2, 20)]
        [DataRow(2018, 2, 19)]
        [DataRow(2019, 2, 18)]
        [DataRow(2020, 2, 17)]
        [DataRow(2021, 2, 15)]
        [DataRow(2022, 2, 21)]
        [DataRow(2023, 2, 20)]
        [DataRow(2024, 2, 19)]
        [DataRow(2025, 2, 17)]
        [DataRow(2026, 2, 16)]
        [TestMethod]
        public void TestPresidentsDay(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.MP);
            var holiday = holidays.Single(o => o.Id.EndsWith("PRESIDENTSDAY-01"));

            Assert.AreEqual(new DateTime(year, month, day), holiday.Date);
        }

        [DataRow(2017, 3, 24)]
        [DataRow(2018, 3, 23)]
        [DataRow(2019, 3, 25)]
        [DataRow(2020, 3, 24)]
        [DataRow(2021, 3, 24)]
        [DataRow(2022, 3, 24)]
        [DataRow(2023, 3, 24)]
        [DataRow(2024, 3, 25)]
        [DataRow(2025, 3, 24)]
        [DataRow(2026, 3, 24)]
        [TestMethod]
        public void TestCommonwealthCovenantDay(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.MP);
            var holiday = holidays.Single(o => o.Id.EndsWith("COMMONWEALTHCOVENANTDAY-01"));

            Assert.AreEqual(new DateTime(year, month, day), holiday.ObservedDate);
        }

        [DataRow(2012, 5, 28)]
        [DataRow(2013, 5, 27)]
        [DataRow(2014, 5, 26)]
        [DataRow(2015, 5, 25)]
        [DataRow(2016, 5, 30)]
        [DataRow(2017, 5, 29)]
        [DataRow(2018, 5, 28)]
        [DataRow(2019, 5, 27)]
        [DataRow(2020, 5, 25)]
        [DataRow(2021, 5, 31)]
        [DataRow(2022, 5, 30)]
        [DataRow(2023, 5, 29)]
        [DataRow(2024, 5, 27)]
        [DataRow(2025, 5, 26)]
        [DataRow(2026, 5, 25)]
        [TestMethod]
        public void TestMemorialDay(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.MP);
            var holiday = holidays.Single(o => o.Id.EndsWith("MEMORIALDAY-01"));

            Assert.AreEqual(new DateTime(year, month, day), holiday.Date);
        }

        [DataRow(2021, 6, 18)]
        [DataRow(2022, 6, 20)]
        [DataRow(2023, 6, 19)]
        [DataRow(2024, 6, 19)]
        [DataRow(2025, 6, 19)]
        [DataRow(2026, 6, 19)]
        [TestMethod]
        public void TestJuneteenth(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.MP);
            var holiday = holidays.Single(o => o.Id.EndsWith("JUNETEENTH-01"));

            Assert.AreEqual(new DateTime(year, month, day), holiday.ObservedDate);
        }

        [DataRow(2012, 7, 4)]
        [DataRow(2013, 7, 4)]
        [DataRow(2014, 7, 4)]
        [DataRow(2015, 7, 3)]
        [DataRow(2016, 7, 4)]
        [DataRow(2017, 7, 4)]
        [DataRow(2018, 7, 4)]
        [DataRow(2019, 7, 4)]
        [DataRow(2020, 7, 3)]
        [DataRow(2021, 7, 5)]
        [DataRow(2022, 7, 4)]
        [DataRow(2023, 7, 4)]
        [DataRow(2024, 7, 4)]
        [DataRow(2025, 7, 4)]
        [DataRow(2026, 7, 3)]
        [TestMethod]
        public void TestIndependenceDay(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.MP);
            var holiday = holidays.Single(o => o.Id.EndsWith("INDEPENDENCEDAY-01"));

            Assert.AreEqual(new DateTime(year, month, day), holiday.ObservedDate);
        }

        [DataRow(2012, 9, 3)]
        [DataRow(2013, 9, 2)]
        [DataRow(2014, 9, 1)]
        [DataRow(2015, 9, 7)]
        [DataRow(2016, 9, 5)]
        [DataRow(2017, 9, 4)]
        [DataRow(2018, 9, 3)]
        [DataRow(2019, 9, 2)]
        [DataRow(2020, 9, 7)]
        [DataRow(2021, 9, 6)]
        [DataRow(2022, 9, 5)]
        [DataRow(2023, 9, 4)]
        [DataRow(2024, 9, 2)] // the source lists September 4, 2024, which is a Wednesday
        [DataRow(2025, 9, 1)]
        [DataRow(2026, 9, 7)]
        [TestMethod]
        public void TestLaborDay(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.MP);
            var holiday = holidays.Single(o => o.Id.EndsWith("LABOURDAY-01"));

            Assert.AreEqual(new DateTime(year, month, day), holiday.Date);
        }

        [DataRow(2012, 10, 8)]
        [DataRow(2013, 10, 14)]
        [DataRow(2014, 10, 13)]
        [DataRow(2015, 10, 12)]
        [DataRow(2016, 10, 10)]
        [DataRow(2017, 10, 9)]
        [DataRow(2018, 10, 8)]
        [DataRow(2019, 10, 14)]
        [DataRow(2020, 10, 12)]
        [DataRow(2021, 10, 11)]
        [DataRow(2022, 10, 10)]
        [DataRow(2023, 10, 9)]
        [DataRow(2024, 10, 14)]
        [DataRow(2025, 10, 13)]
        [DataRow(2026, 10, 12)]
        [TestMethod]
        public void TestCommonwealthCulturalDay(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.MP);
            var holiday = holidays.Single(o => o.Id.EndsWith("COMMONWEALTHCULTURALDAY-01"));

            Assert.AreEqual(new DateTime(year, month, day), holiday.Date);
        }

        [DataRow(2012, 11, 12)]
        [DataRow(2013, 11, 11)]
        [DataRow(2014, 11, 11)]
        [DataRow(2015, 11, 11)]
        [DataRow(2016, 11, 11)]
        [DataRow(2017, 11, 10)]
        [DataRow(2018, 11, 12)]
        [DataRow(2019, 11, 11)]
        [DataRow(2020, 11, 11)]
        [DataRow(2021, 11, 11)]
        [DataRow(2022, 11, 11)]
        [DataRow(2023, 11, 10)]
        [DataRow(2024, 11, 11)]
        [DataRow(2025, 11, 11)]
        [DataRow(2026, 11, 11)]
        [TestMethod]
        public void TestVeteransDay(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.MP);
            var holiday = holidays.Single(o => o.Id.EndsWith("VETERANSDAY-01"));

            Assert.AreEqual(new DateTime(year, month, day), holiday.ObservedDate);
        }

        [DataRow(2012, 11, 22)]
        [DataRow(2013, 11, 28)]
        [DataRow(2014, 11, 27)]
        [DataRow(2015, 11, 26)]
        [DataRow(2016, 11, 24)]
        [DataRow(2017, 11, 23)]
        [DataRow(2018, 11, 22)]
        [DataRow(2019, 11, 28)]
        [DataRow(2020, 11, 26)]
        [DataRow(2021, 11, 25)]
        [DataRow(2022, 11, 24)]
        [DataRow(2023, 11, 23)]
        [DataRow(2024, 11, 28)]
        [DataRow(2025, 11, 27)]
        [DataRow(2026, 11, 26)]
        [TestMethod]
        public void TestThanksgiving(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.MP);
            var holiday = holidays.Single(o => o.Id.EndsWith("THANKSGIVING-01"));

            Assert.AreEqual(new DateTime(year, month, day), holiday.Date);
        }

        [DataRow(2012, 12, 25)]
        [DataRow(2013, 12, 25)]
        [DataRow(2014, 12, 25)]
        [DataRow(2015, 12, 25)]
        [DataRow(2016, 12, 26)]
        [DataRow(2017, 12, 25)]
        [DataRow(2018, 12, 25)]
        [DataRow(2019, 12, 25)]
        [DataRow(2020, 12, 25)]
        [DataRow(2021, 12, 24)]
        [DataRow(2022, 12, 26)]
        [DataRow(2023, 12, 25)]
        [DataRow(2024, 12, 25)]
        [DataRow(2025, 12, 25)]
        [DataRow(2026, 12, 25)]
        [TestMethod]
        public void TestChristmasDay(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.MP);
            var holiday = holidays.Single(o => o.Id.EndsWith("CHRISTMASDAY-01"));

            Assert.AreEqual(new DateTime(year, month, day), holiday.ObservedDate);
        }
    }
}
