using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class UnitedKingdomTest
    {
        [TestMethod]
        public void TestUnitedKingdom()
        {
            var testDate = new DateTime(2017, 08, 28);
            var isPublicHoliday = DateSystem.IsOfficialPublicHolidayByCounty(testDate, CountryCode.GB, "GB-ENG");
            Assert.AreEqual(true, isPublicHoliday);
        }

        [TestMethod]
        public void TestUnitedKingdomStPatricksDay()
        {
            var testDate = new DateTime(2017, 03, 17);
            var isPublicHoliday = DateSystem.IsOfficialPublicHolidayByCounty(testDate, CountryCode.GB, "GB-NIR");
            Assert.AreEqual(true, isPublicHoliday);
        }

    }
}
