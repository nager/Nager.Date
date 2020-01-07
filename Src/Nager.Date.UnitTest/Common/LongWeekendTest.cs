using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Contract;
using Nager.Date.Model;
using Nager.Date.Weekends;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.UnitTest.Common
{
    [TestClass]
    public class LongWeekendTest
    {
        [TestMethod]
        public void LongWeekend1()
        {
            var longWeekends = DateSystem.GetLongWeekend(2017, CountryCode.AT).ToArray();

            Assert.AreEqual(10, longWeekends.Length);
        }

        [TestMethod]
        public void LongWeekend2()
        {
            var publicHolidays = new PublicHoliday[]
            {
                new PublicHoliday(2020, 01, 10, "Mock1", "Mock1", CountryCode.AT),
                new PublicHoliday(2020, 01, 13, "Mock2", "Mock2", CountryCode.AT),
            };

            ILongWeekendCalculator longWeekendCalculator = new LongWeekendCalculator(WeekendProvider.Universal);
            var longWeekends = longWeekendCalculator.Calculate(publicHolidays);

            Assert.AreEqual(1, longWeekends.Count());
            Assert.AreEqual(4, longWeekends.First().DayCount);
        }
    }
}
