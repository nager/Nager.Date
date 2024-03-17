using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class DenmarkTest
    {
        [DataTestMethod]
        [DataRow(2021, 5, 13, true)]
        [DataRow(2021, 5, 14, false)]
        public void ChecksIsPublicHoliday(int year, int month, int day, bool expectedIsPublicHoliday)
        {
            var date = new DateTime(year, month, day);
            var isPublicHoliday = HolidaySystem.IsPublicHoliday(date, CountryCode.DK);
            Assert.AreEqual(expectedIsPublicHoliday, isPublicHoliday);
        }
    }
}
