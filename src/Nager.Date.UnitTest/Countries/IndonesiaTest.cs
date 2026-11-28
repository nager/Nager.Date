using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class IndonesiaTest
    {
        [TestMethod]
        [DataRow(2025, 1, 29)]
        [DataRow(2026, 2, 17)]
        [DataRow(2027, 2, 6)]
        public void TestChineseNewYear(int year, int month, int day)
        {
            var holiday = HolidaySystem.GetHolidays(year, CountryCode.ID).Single(o => o.Id.EndsWith("CHINESENEWYEAR-01"));

            Assert.AreEqual(new DateTime(year, month, day), holiday.Date);
            Assert.AreEqual("Tahun Baru Imlek", holiday.LocalName);
        }

        [TestMethod]
        [DataRow(2025, 3, 29)]
        [DataRow(2026, 3, 19)]
        [DataRow(2027, 3, 8)]
        public void TestDayOfSilence(int year, int month, int day)
        {
            var holiday = HolidaySystem.GetHolidays(year, CountryCode.ID).Single(o => o.Id.EndsWith("DAYOFSILENCE-01"));

            Assert.AreEqual(new DateTime(year, month, day), holiday.Date);
            Assert.AreEqual("Hari Suci Nyepi", holiday.LocalName);
        }

        [TestMethod]
        [DataRow(2025, 5, 12)]
        [DataRow(2026, 5, 31)]
        [DataRow(2027, 5, 20)]
        public void TestVesakDay(int year, int month, int day)
        {
            var holiday = HolidaySystem.GetHolidays(year, CountryCode.ID).Single(o => o.Id.EndsWith("VESAKDAY-01"));

            Assert.AreEqual(new DateTime(year, month, day), holiday.Date);
            Assert.AreEqual("Hari Raya Waisak", holiday.LocalName);
        }

        [TestMethod]
        [DataRow(2024)]
        [DataRow(2020)]
        public void TestNoDayOfSilenceOrVesakWithoutSource(int year)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.ID);

            Assert.IsFalse(holidays.Any(o => o.Id.EndsWith("DAYOFSILENCE-01")));
            Assert.IsFalse(holidays.Any(o => o.Id.EndsWith("VESAKDAY-01")));
        }

        [TestMethod]
        public void TestChristianHolidayNamesFrom2024()
        {
            var holidays = HolidaySystem.GetHolidays(2026, CountryCode.ID).ToArray();

            Assert.AreEqual("Wafat Yesus Kristus", holidays.Single(o => o.Date == new DateTime(2026, 4, 3)).LocalName);
            Assert.AreEqual("Kebangkitan Yesus Kristus (Paskah)", holidays.Single(o => o.Date == new DateTime(2026, 4, 5)).LocalName);
            Assert.AreEqual("Kenaikan Yesus Kristus", holidays.Single(o => o.Date == new DateTime(2026, 5, 14)).LocalName);
        }

        [TestMethod]
        public void TestChristianHolidayNamesBefore2024()
        {
            var holidays = HolidaySystem.GetHolidays(2023, CountryCode.ID).ToArray();

            Assert.AreEqual("Wafat Isa Almasih", holidays.Single(o => o.Date == new DateTime(2023, 4, 7)).LocalName);
            Assert.AreEqual("Kenaikan Isa Almasih", holidays.Single(o => o.Date == new DateTime(2023, 5, 18)).LocalName);
        }

        [TestMethod]
        [DataRow(2023, false)]
        [DataRow(2024, true)]
        [DataRow(2026, true)]
        public void TestEasterSundayFrom2024(int year, bool expected)
        {
            var easterSunday = HolidaySystem.GetHolidays(year, CountryCode.ID).Any(o => o.Id.EndsWith("EASTERSUNDAY-01"));

            Assert.AreEqual(expected, easterSunday);
        }

        [TestMethod]
        [DataRow(2026, 11)]
        [DataRow(2027, 11)]
        public void TestHolidayCount(int year, int expected)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.ID).ToArray();

            Assert.HasCount(expected, holidays);
        }
    }
}
