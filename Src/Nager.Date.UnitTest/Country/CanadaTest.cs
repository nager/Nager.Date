using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class CanadaTest
    {
        [TestMethod]
        public void TestCanada()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.CA, 2017).ToArray();

            //New Year's Day
            Assert.AreEqual(new DateTime(2017, 1, 1), publicHolidays[0].Date);
        }
    }
}
