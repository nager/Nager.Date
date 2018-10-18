using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class GermanyTest
    {
        [TestMethod]
        public void TestGermanyCorpusChristi()
        {
            var yearToTest = 2017;
            var catholicProvider = new MockProvider();
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.DE, yearToTest);
            var easterSunday = catholicProvider.EasterSunday(yearToTest);
            var corpusChristi = publicHolidays.First(x => x.LocalName == "Fronleichnam").Date;
            Assert.AreEqual(easterSunday.AddDays(60), corpusChristi);
        }

        [TestMethod]
        public void TestGermanyCorpusChristi2017()
        {
            var yearToTest = 2017;
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.DE, yearToTest);
            var corpusChristi = publicHolidays.First(x => x.LocalName == "Fronleichnam").Date;
            var expectedDate2017 = new DateTime(yearToTest, 6, 15);
            Assert.AreEqual(expectedDate2017, corpusChristi);
        }

        [TestMethod]
        public void TestGermanyCorpusChristi2026()
        {
            var yearToTest = 2026;
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.DE, yearToTest);
            var corpusChristi = publicHolidays.First(x => x.LocalName == "Fronleichnam").Date;
            var expectedDate2026 = new DateTime(yearToTest, 6, 4);
            Assert.AreEqual(expectedDate2026, corpusChristi);
        }

        [TestMethod]
        public void TestGermanyIsOfficialPublicHolidayByCountyWithCountySpecificEpiphany2017()
        {
            var isPublicHolidayInBW = DateSystem.IsOfficialPublicHolidayByCounty(new DateTime(2017, 1, 6), CountryCode.DE, "DE-BW");
            var isPublicHolidayInNW = DateSystem.IsOfficialPublicHolidayByCounty(new DateTime(2017, 1, 6), CountryCode.DE, "DE-NW");

            Assert.IsTrue(isPublicHolidayInBW);
            Assert.IsFalse(isPublicHolidayInNW);
        }

        [TestMethod]
        public void TestGermanyIsOfficialPublicHolidayByCountyWithGlobalChristmasDay2017()
        {
            var isPublicHolidayInBW = DateSystem.IsOfficialPublicHolidayByCounty(new DateTime(2017, 12, 25), CountryCode.DE, "DE-BW");

            Assert.IsTrue(isPublicHolidayInBW);
        }

        [TestMethod]
        [DataRow(2018, 10, 8, false)]
        [DataRow(2018, 10, 9, false)]
        [DataRow(2018, 10, 10, false)]
        [DataRow(2018, 10, 11, false)]
        [DataRow(2018, 10, 12, false)]
        [DataRow(2018, 10, 13, true)]
        [DataRow(2018, 10, 14, true)]
        public void ChecksThatUniversalWeekendIsUsed(int year, int month, int day, bool expected)
        {
            // Arrange
            var date = new DateTime(year, month, day);

            // Act
            var result = date.IsWeekend(CountryCode.DE);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
