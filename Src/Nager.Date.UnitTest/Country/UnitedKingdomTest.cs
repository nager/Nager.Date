using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class UnitedKingdomTest
    {
        [TestMethod]
        public void TestUnitedKingdom()
        {
            var testDate = new DateTime(2017, 08, 28);
            var isPublicHoliday = DateSystem.IsOfficialPublicHolidayByCounty(testDate, CountryCode.GB, "GB-ENG");
            Assert.AreEqual(true, isPublicHoliday);
        }

        [TestMethod]
        public void TestUnitedKingdomStPatricksDay()
        {
            var testDate = new DateTime(2017, 03, 17);
            var isPublicHoliday = DateSystem.IsOfficialPublicHolidayByCounty(testDate, CountryCode.GB, "GB-NIR");
            Assert.AreEqual(true, isPublicHoliday);
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
            var result = date.IsWeekend(CountryCode.US);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
