using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Contract;
using Nager.Date.Model;
using Nager.Date.Weekends;
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
                new PublicHoliday(2020, 01, 10, "Holiday Friday", "Holiday Friday", CountryCode.AT),
                new PublicHoliday(2020, 01, 13, "Holiday Monday", "Holiday Monday", CountryCode.AT),
            };

            ILongWeekendCalculator longWeekendCalculator = new LongWeekendCalculator(WeekendProvider.Universal);
            var longWeekends = longWeekendCalculator.Calculate(publicHolidays);

            Assert.AreEqual(1, longWeekends.Count());

            var firstLongWeekend = longWeekends.First();
            Assert.AreEqual(4, firstLongWeekend.DayCount);
            Assert.IsFalse(firstLongWeekend.Bridge);
        }

        [TestMethod]
        public void LongWeekend3()
        {
            var publicHolidays = new PublicHoliday[]
            {
                new PublicHoliday(2020, 01, 10, "Holiday Friday", "Holiday Friday", CountryCode.AT),
                new PublicHoliday(2020, 01, 13, "Holiday Monday", "Holiday Monday", CountryCode.AT),
                new PublicHoliday(2020, 01, 14, "Holiday Tuesday", "Holiday Tuesday", CountryCode.AT),
            };

            ILongWeekendCalculator longWeekendCalculator = new LongWeekendCalculator(WeekendProvider.Universal);
            var longWeekends = longWeekendCalculator.Calculate(publicHolidays);

            Assert.AreEqual(1, longWeekends.Count());

            var firstLongWeekend = longWeekends.First();
            Assert.AreEqual(5, firstLongWeekend.DayCount);
            Assert.IsFalse(firstLongWeekend.Bridge);
        }

        [TestMethod]
        public void LongWeekend4()
        {
            var publicHolidays = new PublicHoliday[]
            {
                new PublicHoliday(2020, 01, 10, "Holiday Friday", "Holiday Friday", CountryCode.AT),
                new PublicHoliday(2020, 01, 14, "Holiday Tuesday", "Holiday Tuesday", CountryCode.AT),
            };

            ILongWeekendCalculator longWeekendCalculator = new LongWeekendCalculator(WeekendProvider.Universal);
            var longWeekends = longWeekendCalculator.Calculate(publicHolidays);

            Assert.AreEqual(1, longWeekends.Count());

            var firstLongWeekend = longWeekends.First();
            Assert.AreEqual(5, firstLongWeekend.DayCount);
            Assert.IsTrue(firstLongWeekend.Bridge);
        }

        [TestMethod]
        public void LongWeekend5()
        {
            var publicHolidays = new PublicHoliday[]
            {
                new PublicHoliday(2020, 01, 9, "Holiday Thursday", "Holiday Thursday", CountryCode.AT),
                new PublicHoliday(2020, 01, 14, "Holiday Tuesday", "Holiday Tuesday", CountryCode.AT),
            };

            ILongWeekendCalculator longWeekendCalculator = new LongWeekendCalculator(WeekendProvider.Universal);
            var longWeekends = longWeekendCalculator.Calculate(publicHolidays);

            Assert.AreEqual(2, longWeekends.Count());

            var firstLongWeekend = longWeekends.First();
            Assert.AreEqual(4, firstLongWeekend.DayCount);
            Assert.IsTrue(firstLongWeekend.Bridge);

            var lastLongWeekend = longWeekends.First();
            Assert.AreEqual(4, lastLongWeekend.DayCount);
            Assert.IsTrue(lastLongWeekend.Bridge);
        }

        [TestMethod]
        public void LongWeekend6()
        {
            var publicHolidays = new PublicHoliday[]
            {
                new PublicHoliday(2020, 01, 11, "Holiday Sunday", "Holiday Sunday", CountryCode.AT),
            };

            ILongWeekendCalculator longWeekendCalculator = new LongWeekendCalculator(WeekendProvider.Universal);
            var longWeekends = longWeekendCalculator.Calculate(publicHolidays);

            Assert.AreEqual(0, longWeekends.Count());
        }
    }
}
