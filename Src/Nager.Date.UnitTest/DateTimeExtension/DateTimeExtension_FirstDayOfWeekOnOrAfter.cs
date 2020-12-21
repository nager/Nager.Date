using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;

namespace Nager.Date.UnitTest.DateTimeExtension
{
    [TestClass]
    public class DateTimeExtension_FirstDayOfWeekOnOrAfter
    {
        [TestMethod]
        [DataRow(2020, 11, 1, 1)]
        [DataRow(2020, 11, 2, 8)]
        [DataRow(2020, 11, 3, 8)]
        [DataRow(2020, 11, 4, 8)]
        [DataRow(2020, 11, 5, 8)]
        [DataRow(2020, 11, 6, 8)]
        [DataRow(2020, 11, 7, 8)]
        public void ShouldReturnValue(int year, int month, int day, int expectedDay)
        {
            var date = new DateTime(year, month, day);
            var expectedDate = new DateTime(year, month, expectedDay);

            Assert.AreEqual(expectedDate, date.FirstDayOfWeekOnOrAfter(DayOfWeek.Sunday));
        }
    }
}
