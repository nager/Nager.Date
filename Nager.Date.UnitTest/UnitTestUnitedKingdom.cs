using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest
{
    [TestClass]
    public class UnitTestUnitedKingdom
    {
        [TestMethod]
        public void TestUnitedKingdom()
        {
            var testDate = new DateTime(2017, 08, 28);
            var isPublicHoliday = DateSystem.IsOfficialPublicHolidayByCounty(testDate, CountryCode.GB, "GB-ENG");
            Assert.AreEqual(true, isPublicHoliday);
        }
    }
}
