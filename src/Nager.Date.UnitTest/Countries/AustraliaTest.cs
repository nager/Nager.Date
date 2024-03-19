using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class AustraliaTest
    {
        [TestMethod]
        public void TestEasterSunday2021()
        {
            var year = 2021;
            var expectedSubdivisionCodes = new string[] { "AU-ACT", "AU-NSW", "AU-QLD", "AU-VIC" };

            this.TestEasterSunday(year, expectedSubdivisionCodes);
        }

        [TestMethod]
        public void TestEasterSunday2022()
        {
            var year = 2022;
            var expectedSubdivisionCodes = new string[] { "AU-ACT", "AU-NSW", "AU-QLD", "AU-VIC", "AU-WA" };

            this.TestEasterSunday(year, expectedSubdivisionCodes);
        }

        [TestMethod]
        public void TestEasterSunday2023()
        {
            var year = 2023;
            var expectedSubdivisionCodes = new string[] { "AU-ACT", "AU-NSW", "AU-NT", "AU-QLD", "AU-VIC", "AU-WA" };

            this.TestEasterSunday(year, expectedSubdivisionCodes);
        }

        [TestMethod]
        public void TestEasterSunday2024()
        {
            var year = 2024;
            var expectedSubdivisionCodes = new string[] { "AU-ACT", "AU-NSW", "AU-NT", "AU-QLD", "AU-SA", "AU-VIC", "AU-WA" };

            this.TestEasterSunday(year, expectedSubdivisionCodes);
        }

        [TestMethod]
        public void TestEasterSunday2025()
        {
            var year = 2025;
            var expectedSubdivisionCodes = new string[] { "AU-ACT", "AU-NSW", "AU-NT", "AU-QLD", "AU-SA", "AU-VIC", "AU-WA" };

            this.TestEasterSunday(year, expectedSubdivisionCodes);
        }

        private void TestEasterSunday(int year, string[] expectedSubdivisionCodes)
        {
            var englishName = "Easter Sunday";

            var holidays = HolidaySystem.GetHolidays(year, CountryCode.AU);
            var easterSundayHoliday = holidays.FirstOrDefault(holiday => holiday.EnglishName == englishName);
            Assert.IsNotNull(easterSundayHoliday);
            CollectionAssert.AreEquivalent(expectedSubdivisionCodes, easterSundayHoliday.SubdivisionCodes);
        }
    }
}
