using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;

namespace Nager.Date.UnitTest.DateTimeExtension
{
    [TestClass]
    public class DateTimeExtension_ShiftToClosest
    {
        [TestMethod]
        [DataRow(2018, 10, 8, DayOfWeek.Monday)]
        [DataRow(2018, 10, 9, DayOfWeek.Tuesday)]
        [DataRow(2018, 10, 10, DayOfWeek.Wednesday)]
        [DataRow(2018, 10, 11, DayOfWeek.Thursday)]
        [DataRow(2018, 10, 12, DayOfWeek.Friday)]
        [DataRow(2018, 10, 13, DayOfWeek.Saturday)]
        [DataRow(2018, 10, 14, DayOfWeek.Sunday)]
        public void ShouldReturnClosestMatchingWeekday(int year, int month, int day, DayOfWeek dayOfWeek)
        {
            var date = new DateTime(year, month, day);
            for (var i = -7; i <= 7; ++i)
            {
                var starting = date.AddDays(i);
                var closestMatchingWeekday = starting.ShiftToClosest(dayOfWeek);
                Assert.AreEqual(closestMatchingWeekday.DayOfWeek, dayOfWeek);
                var daysBetween = (starting - closestMatchingWeekday).Days;
                Assert.IsTrue(Math.Abs(daysBetween) <= 3, "More than 3 days between dates (the closest matching weekday was not identified)");
            }
        }
    }
}
