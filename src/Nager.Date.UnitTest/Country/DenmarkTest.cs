using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class DenmarkTest
    {
        [DataTestMethod]
        [DataRow(2021, 5, 13, true)]
        [DataRow(2021, 5, 14, false)]
        public void ChecksIsPublicHoliday(int year, int month, int day, bool expected)
        {
            // Arrange
            var date = new DateTime(year, month, day);

            // Act
            var result = DateSystem.IsPublicHoliday(date, CountryCode.DK);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
