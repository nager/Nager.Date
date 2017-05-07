using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest
{
    [TestClass]
    public class UnitTestTurkey
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
            Assert.AreEqual(new DateTime(2017, 8, 30), publicHolidays[4].Date);

            //Republic Day
            Assert.AreEqual(new DateTime(2017, 10, 29), publicHolidays[5].Date);

        }
    }
}
