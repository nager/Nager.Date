using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest
{
    [TestClass]
    public class UnitTestAustria
    {
        [TestMethod]
        public void TestAustria()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.AT, 2017).ToArray();

            //New Year's Day
            Assert.AreEqual(new DateTime(2017, 1, 1), publicHolidays[0].Date);
            //Epiphany
            Assert.AreEqual(new DateTime(2017, 1, 6), publicHolidays[1].Date);
            //Easter Monday
            Assert.AreEqual(new DateTime(2017, 4, 17), publicHolidays[2].Date);
            //National Holiday
            Assert.AreEqual(new DateTime(2017, 5, 1), publicHolidays[3].Date);
            //Ascension Day
            Assert.AreEqual(new DateTime(2017, 5, 25), publicHolidays[4].Date);
            //Whit Monday
            Assert.AreEqual(new DateTime(2017, 6, 5), publicHolidays[5].Date);
            //Corpus Christi
            Assert.AreEqual(new DateTime(2017, 6, 15), publicHolidays[6].Date);
            //Assumption Day
            Assert.AreEqual(new DateTime(2017, 8, 15), publicHolidays[7].Date);
            //National Holiday
            Assert.AreEqual(new DateTime(2017, 10, 26), publicHolidays[8].Date);
            //All Saints' Day
            Assert.AreEqual(new DateTime(2017, 11, 1), publicHolidays[9].Date);
            //Immaculate Conception
            Assert.AreEqual(new DateTime(2017, 12, 8), publicHolidays[10].Date);
            //Christmas Day
            Assert.AreEqual(new DateTime(2017, 12, 25), publicHolidays[11].Date);
            //St. Stephen's Day
            Assert.AreEqual(new DateTime(2017, 12, 26), publicHolidays[12].Date);
        }
    }
}
