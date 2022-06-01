using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Weekends;
using System;

namespace Nager.Date.UnitTest.Weekends
{
    [TestClass]
    public class UniversalWeekendProviderTest
    {
        [DataTestMethod]
        [DataRow(2018, 10, 8, false)]
        [DataRow(2018, 10, 9, false)]
        [DataRow(2018, 10, 10, false)]
        [DataRow(2018, 10, 11, false)]
        [DataRow(2018, 10, 12, false)]
        [DataRow(2018, 10, 13, true)]
        [DataRow(2018, 10, 14, true)]
        public void ReturnsTrueOnSaturdayOrSunday(int year, int month, int day, bool expected)
        {
            // Arrange
            var date = new DateTime(year, month, day);
            var weekendProvider = WeekendProvider.Universal;

            // Act
            var result = weekendProvider.IsWeekend(date);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
