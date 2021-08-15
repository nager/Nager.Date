using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class SingaporeTest
    {
        [TestMethod]
        public void TestSingapore()
        {
            var publicHolidays = DateSystem.GetPublicHolidays(2022, CountryCode.SG).ToArray();

            Assert.AreEqual("New Year’s Day", publicHolidays[0].Name);
        }
    }
}
