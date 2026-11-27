using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Weekends;
using System;

namespace Nager.Date.UnitTest.Weekends
{
    [TestClass]
    public class WeekendProviderFirstLastDayTest
    {
        [TestMethod]
        public void Universal_FirstIsSaturday_LastIsSunday()
        {
            var weekendProvider = WeekendProvider.Universal;

            Assert.AreEqual(DayOfWeek.Saturday, weekendProvider.FirstWeekendDay);
            Assert.AreEqual(DayOfWeek.Sunday, weekendProvider.LastWeekendDay);
        }

        [TestMethod]
        public void SemiUniversal_FirstIsFriday_LastIsSaturday()
        {
            var weekendProvider = WeekendProvider.SemiUniversal;

            Assert.AreEqual(DayOfWeek.Friday, weekendProvider.FirstWeekendDay);
            Assert.AreEqual(DayOfWeek.Saturday, weekendProvider.LastWeekendDay);
        }

        [TestMethod]
        public void FridaySunday_FirstIsFriday_LastIsSunday()
        {
            var weekendProvider = WeekendProvider.FridaySunday;

            Assert.AreEqual(DayOfWeek.Friday, weekendProvider.FirstWeekendDay);
            Assert.AreEqual(DayOfWeek.Sunday, weekendProvider.LastWeekendDay);
        }

        [TestMethod]
        public void FridayOnly_FirstAndLastAreFriday()
        {
            var weekendProvider = WeekendProvider.FridayOnly;

            Assert.AreEqual(DayOfWeek.Friday, weekendProvider.FirstWeekendDay);
            Assert.AreEqual(DayOfWeek.Friday, weekendProvider.LastWeekendDay);
        }

        [TestMethod]
        public void SaturdayOnly_FirstAndLastAreSaturday()
        {
            var weekendProvider = WeekendProvider.SaturdayOnly;

            Assert.AreEqual(DayOfWeek.Saturday, weekendProvider.FirstWeekendDay);
            Assert.AreEqual(DayOfWeek.Saturday, weekendProvider.LastWeekendDay);
        }

        [TestMethod]
        public void SundayOnly_FirstAndLastAreSunday()
        {
            var weekendProvider = WeekendProvider.SundayOnly;

            Assert.AreEqual(DayOfWeek.Sunday, weekendProvider.FirstWeekendDay);
            Assert.AreEqual(DayOfWeek.Sunday, weekendProvider.LastWeekendDay);
        }

        [TestMethod]
        [DataRow(DayOfWeek.Saturday, DayOfWeek.Sunday, DayOfWeek.Saturday, DayOfWeek.Sunday)]
        [DataRow(DayOfWeek.Sunday, DayOfWeek.Saturday, DayOfWeek.Saturday, DayOfWeek.Sunday)]
        [DataRow(DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Friday, DayOfWeek.Saturday)]
        [DataRow(DayOfWeek.Saturday, DayOfWeek.Friday, DayOfWeek.Friday, DayOfWeek.Saturday)]
        [DataRow(DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Thursday, DayOfWeek.Friday)]
        [DataRow(DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Sunday, DayOfWeek.Monday)]
        [DataRow(DayOfWeek.Friday, DayOfWeek.Sunday, DayOfWeek.Friday, DayOfWeek.Sunday)]
        public void CustomWeekend_FirstAndLastAreInWeekOrder(
            DayOfWeek day1,
            DayOfWeek day2,
            DayOfWeek expectedFirst,
            DayOfWeek expectedLast)
        {
            var weekendProvider = new WeekendProvider(day1, day2);

            Assert.AreEqual(expectedFirst, weekendProvider.FirstWeekendDay);
            Assert.AreEqual(expectedLast, weekendProvider.LastWeekendDay);
        }
    }
}
