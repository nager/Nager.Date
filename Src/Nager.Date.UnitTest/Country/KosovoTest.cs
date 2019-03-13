using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class KosovoTest
    {
        [TestMethod]
        public void TestKosova()

        {
            var publicHolidays = DateSystem.GetPublicHoliday(2019, CountryCode.XK).ToArray();

            //New Year's Day
            Assert.AreEqual(new DateTime(2019, 1, 1), publicHolidays[0].Date);
            //Orthodox Christmas
            Assert.AreEqual(new DateTime(2019, 1, 7), publicHolidays[1].Date);
            //Independence Day
            Assert.AreEqual(new DateTime(2019, 2, 17), publicHolidays[2].Date);
            //Constitution Day
            Assert.AreEqual(new DateTime(2019, 4, 9), publicHolidays[3].Date);
            //Catholic Easter
            Assert.AreEqual(new DateTime(2019, 4, 21), publicHolidays[4].Date);
            //Orthodox Easter
            Assert.AreEqual(new DateTime(2019, 4, 28), publicHolidays[5].Date);
            //International Workers' Day
            Assert.AreEqual(new DateTime(2019, 5, 1), publicHolidays[6].Date);
            //Europe Day
            Assert.AreEqual(new DateTime(2019, 5, 9), publicHolidays[7].Date);

            //Eid ul-Fitr is not implemented
            //Eid ul-Adha is not implemented

            //Catholic Christmas
            Assert.AreEqual(new DateTime(2019, 12, 25), publicHolidays[8].Date);
        }
    }
}
