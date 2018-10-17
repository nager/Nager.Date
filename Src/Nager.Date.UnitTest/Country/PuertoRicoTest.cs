﻿
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class PuertoRicoTest
    {

        [TestMethod]
        public void PuertoRicoHasGoodFridayHoliday()
        {
            var holidays = DateSystem.GetPublicHoliday(CountryCode.PR, 2017);

            var catholic = new MockPublicHolidayProvider();
            var expectedGoodFriday = catholic.EasterSunday(2017).AddDays(-2);

            var goodFriday = holidays.First(h => h.Name == "Good Friday");
            Assert.IsNotNull(goodFriday);
            Assert.AreEqual(expectedGoodFriday.Day, goodFriday.Date.Day);
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
            var result = date.IsWeekend(CountryCode.PR);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
