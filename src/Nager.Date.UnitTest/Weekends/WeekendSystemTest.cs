using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Nager.Date.UnitTest.Weekends
{
    [TestClass]
    public class WeekendSystemTest
    {
        [TestMethod]
        public void CheckIsWeekend()
        {
            var isPublicHoliday = WeekendSystem.IsWeekend(new DateTime(2021, 10, 20), CountryCode.AT);
            Assert.IsFalse(isPublicHoliday);

            isPublicHoliday = WeekendSystem.IsWeekend(new DateTime(2021, 10, 20), "AT");
            Assert.IsFalse(isPublicHoliday);

            isPublicHoliday = WeekendSystem.IsWeekend(new DateTime(2021, 10, 24), CountryCode.AT);
            Assert.IsTrue(isPublicHoliday);

            isPublicHoliday = WeekendSystem.IsWeekend(new DateTime(2021, 10, 24), "AT");
            Assert.IsTrue(isPublicHoliday);
        }
    }
}
