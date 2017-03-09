using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Nager.Date.UnitTest
{
    [TestClass]
    public class UnitTestRelation
    {
        [TestMethod]
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
