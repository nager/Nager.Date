using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class MoroccoTest
    {
        [TestMethod]
        public void TestAmazighNewYearAfter2024()
        {
            var newAmazighYear = new DateTime(2026, 1, 14);
            var isPublicHoliday = HolidaySystem.IsPublicHoliday(newAmazighYear, CountryCode.MA);
            Assert.IsTrue(isPublicHoliday);
        }

        [TestMethod]
        public void TestAmazighNewYearAt2024()
        {
            var newAmazighYear = new DateTime(2024, 1, 14);
            var isPublicHoliday = HolidaySystem.IsPublicHoliday(newAmazighYear, CountryCode.MA);
            Assert.IsTrue(isPublicHoliday);
        }

        [TestMethod]
        public void TestAmazighNewYearBefore2024()
        {
            var newAmazighYear = new DateTime(2023, 1, 14);
            var isPublicHoliday = HolidaySystem.IsPublicHoliday(newAmazighYear, CountryCode.MA);
            Assert.IsFalse(isPublicHoliday);
        }

        [TestMethod]
        public void TestUnityDayFrom2026()
        {
            Assert.IsTrue(HolidaySystem.IsPublicHoliday(new DateTime(2026, 10, 31), CountryCode.MA));
            Assert.IsTrue(HolidaySystem.IsPublicHoliday(new DateTime(2027, 10, 31), CountryCode.MA));
        }

        [TestMethod]
        public void TestUnityDayBefore2026()
        {
            Assert.IsFalse(HolidaySystem.IsPublicHoliday(new DateTime(2025, 10, 31), CountryCode.MA));
        }
    }
}
