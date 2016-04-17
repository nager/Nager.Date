using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest
{
    [TestClass]
    public class UnitTestCountry
    {
        [TestMethod]
        public void TestAustria()
        {
            for (var year = DateTime.Now.Year; year < 3000; year++)
            {
                var publicHolidays = DateSystem.GetPublicHoliday("AT", year);
                Assert.AreEqual(publicHolidays.Count, 13);
            }
        }

        [TestMethod]
        public void TestGermany()
        {
            for (var year = DateTime.Now.Year; year < 3000; year++)
            {
                var publicHolidays = DateSystem.GetPublicHoliday("DE", year);
                Assert.AreEqual(publicHolidays.Count, 9);
            }
        }

        [TestMethod]
        public void TestSwitzerland()
        {
            for (var year = DateTime.Now.Year; year < 3000; year++)
            {
                var publicHolidays = DateSystem.GetPublicHoliday("CH", year);
                Assert.AreEqual(publicHolidays.Count, 16);
            }
        }

        [TestMethod]
        public void TestSpain()
        {
            for (var year = DateTime.Now.Year; year < 3000; year++)
            {
                var publicHolidays = DateSystem.GetPublicHoliday("ES", year);
                Assert.AreEqual(publicHolidays.Count, 34);
            }
        }
    }
}
