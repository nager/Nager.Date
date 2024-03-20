using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Models;
using System;

namespace Nager.Date.UnitTest.Common
{
    [TestClass]
    public class LogicTest
    {
        [TestMethod]
        public void CheckHolidayNationalWork()
        {
            var publicHoliday = new Holiday
            {
                Date = new DateTime(2020, 01, 30),
                EnglishName = "Test",
                LocalName = "Test",
                CountryCode = CountryCode.AT,
                HolidayTypes = HolidayTypes.Public
            };
            Assert.IsTrue(publicHoliday.NationalHoliday);

            var publicHolidayWithSubdivisionCodes = new Holiday
            {
                Date = new DateTime(2020, 01, 30),
                EnglishName = "Test",
                LocalName = "Test",
                CountryCode = CountryCode.AT,
                HolidayTypes = HolidayTypes.Public,
                SubdivisionCodes = ["AT-1"]
            };
            Assert.IsFalse(publicHolidayWithSubdivisionCodes.NationalHoliday);
        }
    }
}
