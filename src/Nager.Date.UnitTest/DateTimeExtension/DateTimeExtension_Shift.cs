using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;

namespace Nager.Date.UnitTest.DateTimeExtension
{
    [TestClass]
    public class DateTimeExtension_Shift
    {
        [TestMethod]
        [DataRow(2018, 10, 8)]
        [DataRow(2018, 10, 9)]
        [DataRow(2018, 10, 10)]
        [DataRow(2018, 10, 11)]
        [DataRow(2018, 10, 12)]
        [DataRow(2018, 10, 13)]
        [DataRow(2018, 10, 14)]
        public void ShouldReturnValueIfShiftFuncIsNull(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            Assert.AreEqual(date, date.Shift(DayOfWeek.Monday, null));
        }

        [TestMethod]
        [DataRow(2018, 10, 8, DayOfWeek.Tuesday)]
        [DataRow(2018, 10, 9, DayOfWeek.Monday)]
        [DataRow(2018, 10, 10, DayOfWeek.Tuesday)]
        [DataRow(2018, 10, 11, DayOfWeek.Tuesday)]
        [DataRow(2018, 10, 12, DayOfWeek.Tuesday)]
        [DataRow(2018, 10, 13, DayOfWeek.Tuesday)]
        [DataRow(2018, 10, 14, DayOfWeek.Tuesday)]
        public void ShouldReturnValueIfProvidedDayOfWeekIsNotTheRightOne(int year, int month, int day, DayOfWeek dayOfWeek)
        {
            var date = new DateTime(year, month, day);
            Assert.AreEqual(date, date.Shift(dayOfWeek, d => d.AddDays(1)));
        }

        [TestMethod]
        [DataRow(2018, 10, 8, DayOfWeek.Monday)]
        [DataRow(2018, 10, 9, DayOfWeek.Tuesday)]
        [DataRow(2018, 10, 10, DayOfWeek.Wednesday)]
        [DataRow(2018, 10, 11, DayOfWeek.Thursday)]
        [DataRow(2018, 10, 12, DayOfWeek.Friday)]
        [DataRow(2018, 10, 13, DayOfWeek.Saturday)]
        [DataRow(2018, 10, 14, DayOfWeek.Sunday)]
        public void ShouldReturnAlteredValueIfProvidedDayOfWeekIsTheRightOne(int year, int month, int day, DayOfWeek dayOfWeek)
        {
            var date = new DateTime(year, month, day);
            Assert.AreEqual(date.AddDays(1), date.Shift(dayOfWeek, d => d.AddDays(1)));
        }
    }
}
