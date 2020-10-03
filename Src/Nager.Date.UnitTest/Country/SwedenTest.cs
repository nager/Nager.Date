using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class SwedenTest
    {
        [TestMethod]
        [DataRow(2000, false)]
        [DataRow(2004, false)]
        [DataRow(2005, true)]
        [DataRow(2020, true)]
        public void CheckThatNationalDayIsAddedAsPublicHolidayYear2005AndOnwards(int year, bool expected)
        {
            // Arrange
            var date = new DateTime(year, 6, 6);

            // Act
            var result = DateSystem.IsPublicHoliday(date, CountryCode.SE);

            // Assert
            Assert.AreEqual(expected, result, date.ToString());
        }

        [TestMethod]
        [DataRow(2000, 6, 12, true)]
        [DataRow(2004, 5, 31, true)]
        [DataRow(2005, 5, 16, false)]
        [DataRow(2020, 6, 01, false)]
        public void CheckThatPentecostMondayIsRemovedAsPublicHolidayAfterYear2004(int year, int month, int day, bool expected)
        {
            // Arrange
            var date = new DateTime(year, month, day);

            // Act
            var result = DateSystem.IsPublicHoliday(date, CountryCode.SE);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
