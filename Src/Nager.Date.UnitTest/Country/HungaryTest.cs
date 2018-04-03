using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class HungaryTest
    {
        [TestMethod]
        public void TestHungary()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.HU, 2018).ToArray();

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
    }
}
