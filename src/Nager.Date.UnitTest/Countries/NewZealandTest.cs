using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class NewZealandTest
    {
        [DataTestMethod]
        [DataRow(2022, 6, 24)]
        [DataRow(2023, 7, 14)]
        [DataRow(2024, 6, 28)]
        [DataRow(2025, 6, 20)]
        [DataRow(2026, 7, 10)]
        [DataRow(2027, 6, 25)]
        [DataRow(2028, 7, 14)]
        [DataRow(2029, 7, 6)]
        [DataRow(2030, 6, 21)]
        [DataRow(2031, 7, 11)]
        [DataRow(2032, 7, 2)]
        [DataRow(2033, 6, 24)]
        [DataRow(2034, 7, 7)]
        [DataRow(2035, 6, 29)]
        [DataRow(2036, 7, 18)]
        [DataRow(2037, 7, 10)]
        [DataRow(2038, 6, 25)]
        [DataRow(2039, 7, 15)]
        [DataRow(2040, 7, 6)]
        [DataRow(2041, 7, 19)]
        [DataRow(2042, 7, 11)]
        [DataRow(2043, 7, 3)]
        [DataRow(2044, 6, 24)]
        [DataRow(2045, 7, 7)]
        [DataRow(2046, 6, 29)]
        [DataRow(2047, 7, 19)]
        [DataRow(2048, 7, 3)]
        [DataRow(2049, 6, 25)]
        [DataRow(2050, 7, 15)]
        [DataRow(2051, 6, 30)]
        [DataRow(2052, 6, 21)]
        public void ChecksIsMatarikiPublicHoliday(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            var isPublicHoliday = HolidaySystem.IsPublicHoliday(date, CountryCode.NZ);

            Assert.IsTrue(isPublicHoliday);
            Assert.AreEqual(DayOfWeek.Friday, date.DayOfWeek);
        }
    }
}
