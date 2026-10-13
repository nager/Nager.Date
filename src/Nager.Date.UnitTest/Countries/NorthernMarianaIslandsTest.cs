using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class NorthernMarianaIslandsTest
    {
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
    }
}
