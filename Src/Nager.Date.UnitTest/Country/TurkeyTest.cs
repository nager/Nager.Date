using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class TurkeyTest
    {
        [TestMethod]
        public void TestTurkey()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(2017, CountryCode.TR).ToArray();

            //New Year's Day
            Assert.AreEqual(new DateTime(2017, 1, 1), publicHolidays[0].Date);

            //National Independence & Children's Day
            Assert.AreEqual(new DateTime(2017, 4, 23), publicHolidays[1].Date);

            //Labour Day
            Assert.AreEqual(new DateTime(2017, 5, 1), publicHolidays[2].Date);

            //Atatürk Commemoration & Youth Day
            Assert.AreEqual(new DateTime(2017, 5, 19), publicHolidays[3].Date);

            //Democracy Day
            Assert.AreEqual(new DateTime(2017, 7, 15), publicHolidays[4].Date);

            //Victory Day
            Assert.AreEqual(new DateTime(2017, 8, 30), publicHolidays[5].Date);

            //Republic Day
            Assert.AreEqual(new DateTime(2017, 10, 29), publicHolidays[6].Date);

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
            var result = date.IsWeekend(CountryCode.TR);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
