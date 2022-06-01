using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class MexicoTest
    {
        [DataTestMethod]
        [DataRow(2018, 10, 8, false)]
        [DataRow(2018, 10, 9, false)]
        [DataRow(2018, 10, 10, false)]
        [DataRow(2018, 10, 11, false)]
        [DataRow(2018, 10, 12, false)]
        [DataRow(2018, 10, 13, false)]
        [DataRow(2018, 10, 14, true)]
        public void ChecksThatSundayOnlyWeekendIsUsed(int year, int month, int day, bool expected)
        {
            // Arrange
            var date = new DateTime(year, month, day);

            // Act
            var result = date.IsWeekend(CountryCode.MX);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
