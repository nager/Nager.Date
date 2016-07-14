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
            Assert.AreEqual(new DateTime(1900, 4, 15), easterSunday);

            easterSunday = DateSystem.EasterSunday(2014);
            Assert.AreEqual(new DateTime(2014, 4, 20), easterSunday);

            easterSunday = DateSystem.EasterSunday(2015);
            Assert.AreEqual(new DateTime(2015, 4, 5), easterSunday);

            easterSunday = DateSystem.EasterSunday(2016);
            Assert.AreEqual(new DateTime(2016, 3, 27), easterSunday);

            easterSunday = DateSystem.EasterSunday(2017);
            Assert.AreEqual(new DateTime(2017, 4, 16), easterSunday);

            easterSunday = DateSystem.EasterSunday(2018);
            Assert.AreEqual(new DateTime(2018, 4, 1), easterSunday);

            easterSunday = DateSystem.EasterSunday(2019);
            Assert.AreEqual(new DateTime(2019, 4, 21), easterSunday);

            easterSunday = DateSystem.EasterSunday(2020);
            Assert.AreEqual(new DateTime(2020, 4, 12), easterSunday);

            easterSunday = DateSystem.EasterSunday(2200);
            Assert.AreEqual(new DateTime(2200, 4, 6), easterSunday);
        }

        [TestMethod]
        public void CheckIsPublicHoliday()
        {
            var isPublicHoliday = DateSystem.IsPublicHoliday(new DateTime(2016, 5, 1), "AT");
            Assert.AreEqual(true, isPublicHoliday);

            isPublicHoliday = DateSystem.IsPublicHoliday(new DateTime(2016, 1, 6), "AT");
            Assert.AreEqual(true, isPublicHoliday);
        }
    }
}