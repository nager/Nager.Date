using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class SpainTest
    {
        [TestMethod]
        public void TestSpain()
        {
            var holidayCount = 34;

            for (var year = DateTime.Today.Year; year < 3000; year++)
            {
                var publicHolidays = DateSystem.GetPublicHolidays(year, CountryCode.ES);
                Assert.AreEqual(holidayCount, publicHolidays.Count());
            }
        }

        [DataTestMethod]
        public void CheckDayOfMadridIsThirdMayIn2021()
        {
            var yearToTest = 2021;
            var expectedDate2021 = new DateTime(2021, 5, 3);

            var publicHolidays = DateSystem.GetPublicHolidays(yearToTest, CountryCode.ES);
            var dayOfMadrid = publicHolidays.Where(publicHoliday => publicHoliday.Name == "Day of Madrid").FirstOrDefault();
            Assert.AreEqual(expectedDate2021, dayOfMadrid.Date);
        }

        [DataTestMethod]
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
            var result = date.IsWeekend(CountryCode.ES);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
