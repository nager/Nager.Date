using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class SpainTest
    {
        [TestMethod]
        public void TestSpain()
        {
            for (var year = DateTime.Now.Year; year < 3000; year++)
            {
                var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.ES, year);
                Assert.AreEqual(35, publicHolidays.Count());
            }
        }
    }
}
