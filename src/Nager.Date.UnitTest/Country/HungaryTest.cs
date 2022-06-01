using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class HungaryTest
    {
        [TestMethod]
        public void TestHungaryHoliday2018()
        {
            var publicHolidays = DateSystem.GetPublicHolidays(2018, CountryCode.HU).ToArray();

            //New Year's Day
            Assert.AreEqual(new DateTime(2018, 1, 1), publicHolidays[0].Date);
            //1848 Revolution Memorial Day
            Assert.AreEqual(new DateTime(2018, 3, 15), publicHolidays[1].Date);
            //Good Friday
            Assert.AreEqual(new DateTime(2018, 3, 30), publicHolidays[2].Date);
            //Easter Sunday
            Assert.AreEqual(new DateTime(2018, 4, 1), publicHolidays[3].Date);
            //Easter Monday
            Assert.AreEqual(new DateTime(2018, 4, 2), publicHolidays[4].Date);
            //Labour day
            Assert.AreEqual(new DateTime(2018, 5, 1), publicHolidays[5].Date);
            //Pentecost
            Assert.AreEqual(new DateTime(2018, 5, 20), publicHolidays[6].Date);
            //Whit Monday
            Assert.AreEqual(new DateTime(2018, 5, 21), publicHolidays[7].Date);
            //State Foundation Day
            Assert.AreEqual(new DateTime(2018, 8, 20), publicHolidays[8].Date);
            //1956 Revolution Memorial Day
            Assert.AreEqual(new DateTime(2018, 10, 23), publicHolidays[9].Date);
            //All Saints Day
            Assert.AreEqual(new DateTime(2018, 11, 1), publicHolidays[10].Date);
            //Christmas Day
            Assert.AreEqual(new DateTime(2018, 12, 25), publicHolidays[11].Date);
            //St. Stephen's Day
            Assert.AreEqual(new DateTime(2018, 12, 26), publicHolidays[12].Date);
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
            var result = date.IsWeekend(CountryCode.HU);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
