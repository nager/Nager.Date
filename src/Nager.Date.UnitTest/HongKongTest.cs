using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class HongKongTest
    {
        [TestMethod]
        public void TestFollowingEasterMonday2025()
        {
            var holidays = HolidaySystem.GetHolidays(2025, CountryCode.HK);
            var holiday = holidays.FirstOrDefault(h => h.EnglishName == "The day following Easter Monday");
            Assert.IsNotNull(holiday);
            Assert.AreEqual(new DateTime(2025, 4, 22), holiday.Date);
        }

        [TestMethod]
        public void TestFollowingEasterMonday2026()
        {
            var holidays = HolidaySystem.GetHolidays(2026, CountryCode.HK);
            var holiday = holidays.FirstOrDefault(h => h.EnglishName == "The day following Easter Monday");
            Assert.IsNotNull(holiday);
            Assert.AreEqual(new DateTime(2026, 4, 7), holiday.Date);
        }
    }
}