using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest
{
    [TestClass]
    public class UnitTestCountry
    {
        [TestMethod]
        public void TestGermany1()
        {
            for (var year = DateTime.Now.Year; year < 3000; year++)
            {
                var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.DE, year);
                Assert.AreEqual(12, publicHolidays.Count());
            }
        }

        [TestMethod]
        public void TestGermany2()
        {
            for (var year = DateTime.Now.Year; year < 3000; year++)
            {
                var publicHolidays = DateSystem.GetPublicHoliday("DE", year);
                Assert.AreEqual(12, publicHolidays.Count());
            }
        }

        [TestMethod]
        public void TestSwitzerland()
        {
            for (var year = DateTime.Now.Year; year < 3000; year++)
            {
                var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.CH, year);
                Assert.AreEqual(18, publicHolidays.Count());
            }
        }

        [TestMethod]
        public void TestSpain()
        {
            for (var year = DateTime.Now.Year; year < 3000; year++)
            {
                var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.ES, year);
                Assert.AreEqual(34, publicHolidays.Count());
            }
        }
    }
}