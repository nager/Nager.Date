using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Common
{
    [TestClass]
    public class CountryRelationTest
    {
        [TestMethod]
        [Ignore("Until decision about unhandled country codes")]
        public void TestAllRelationsExist()
        {
            foreach (CountryCode countryCode in Enum.GetValues(typeof(CountryCode)))
            {
                var items = DateSystem.GetPublicHoliday(countryCode, DateTime.UtcNow.Year).ToList();
                Assert.AreNotEqual(0, items.Count);
            }
        }
    }
}
