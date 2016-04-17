using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest
{
    [TestClass]
    public class UnitTestLogic
    {
        [TestMethod]
        public void CheckEasterSunday()
        {
            var easterSunday = DateSystem.EasterSunday(1900);
            Assert.AreEqual(easterSunday, new DateTime(1900, 4, 15));

            easterSunday = DateSystem.EasterSunday(2014);
            Assert.AreEqual(easterSunday, new DateTime(2014, 4, 20));

            easterSunday = DateSystem.EasterSunday(2015);
            Assert.AreEqual(easterSunday, new DateTime(2015, 4, 5));

            easterSunday = DateSystem.EasterSunday(2016);
            Assert.AreEqual(easterSunday, new DateTime(2016, 3, 27));

            easterSunday = DateSystem.EasterSunday(2017);
            Assert.AreEqual(easterSunday, new DateTime(2017, 4, 16));

            easterSunday = DateSystem.EasterSunday(2018);
            Assert.AreEqual(easterSunday, new DateTime(2018, 4, 1));

            easterSunday = DateSystem.EasterSunday(2019);
            Assert.AreEqual(easterSunday, new DateTime(2019, 4, 21));

            easterSunday = DateSystem.EasterSunday(2020);
            Assert.AreEqual(easterSunday, new DateTime(2020, 4, 12));

            easterSunday = DateSystem.EasterSunday(2200);
            Assert.AreEqual(easterSunday, new DateTime(2200, 4, 6));
        }
    }
}
