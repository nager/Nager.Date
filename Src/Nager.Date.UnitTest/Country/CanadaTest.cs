using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class CanadaTest
    {
        [TestMethod]
        public void TestCanada()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(2017, CountryCode.CA).ToArray();

            //New Year's Day
            Assert.AreEqual(new DateTime(2017, 1, 1), publicHolidays[0].Date);
        }

        [TestMethod]
        [DataRow(2018, 10, 8, false)]
        [DataRow(2018, 10, 9, false)]
        [DataRow(2018, 10, 10, false)]
        [DataRow(2018, 10, 11, false)]
        [DataRow(2018, 10, 12, false)]
        [DataRow(2018, 10, 13, true)]
        [DataRow(2018, 10, 14, true)]
        public void ChecksThatUniversalWeekendIsUsed(int year, int month, int day, bool expected)
        {
            // Arrange
            var date = new DateTime(year, month, day);

            // Act
            var result = date.IsWeekend(CountryCode.CA);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
