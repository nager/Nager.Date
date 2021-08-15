using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class SingaporeTest
    {
        [TestMethod]
        public void TestSingapore()
        {
            var publicHolidays = DateSystem.GetPublicHolidays(2022, CountryCode.SG).ToArray();

            Assert.AreEqual("New Year’s Day", publicHolidays[0].Name);
        }

        [TestMethod]
        public void HolidayCount()
        {
            for (var year = 2018; year <= 2022; year++)
            {
                var publicHolidays = DateSystem.GetPublicHolidays(year, CountryCode.SG).ToArray();
                Assert.AreEqual(11, publicHolidays.Length);
            }
        }

        [TestMethod]
        [DataRow(2022, 1, 1, true)]
        [DataRow(2022, 1, 3, false)]
        [DataRow(2022, 5, 2, true)]
        [DataRow(2022, 7, 9, true)]
        public void Year2022(int year, int month, int day, bool expected)
        {
            // Arrange
            var date = new DateTime(year, month, day);

            // Act
            var result = DateSystem.IsPublicHoliday(date, CountryCode.SG);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
