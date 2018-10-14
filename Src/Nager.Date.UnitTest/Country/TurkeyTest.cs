using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.TR, 2017).ToArray();

            //New Year's Day
            Assert.AreEqual(new DateTime(2017, 1, 1), publicHolidays[0].Date);

            //National Independence & Children's Day
            Assert.AreEqual(new DateTime(2017, 4, 23), publicHolidays[1].Date);

            //Labour Day
            Assert.AreEqual(new DateTime(2017, 5, 1), publicHolidays[2].Date);

            //Atatürk Commemoration & Youth Day
            Assert.AreEqual(new DateTime(2017, 5, 19), publicHolidays[3].Date);

            //Victory Day
            Assert.AreEqual(new DateTime(2017, 8, 30), publicHolidays[5].Date);

            //Republic Day
            Assert.AreEqual(new DateTime(2017, 10, 29), publicHolidays[6].Date);

        }
    }
}
