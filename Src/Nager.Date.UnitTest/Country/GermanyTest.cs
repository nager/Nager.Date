using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Contract;
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
            var catholicProvider = new MockProvider(new CatholicProvider());
            var publicHolidays = DateSystem.GetPublicHoliday(yearToTest, CountryCode.DE);
            var easterSunday = catholicProvider.EasterSunday(yearToTest);
            var corpusChristi = publicHolidays.First(x => x.LocalName == "Fronleichnam").Date;
            Assert.AreEqual(easterSunday.AddDays(60), corpusChristi);
        }

        [TestMethod]
        public void TestGermanyCorpusChristi2017()
        {
            var yearToTest = 2017;
            var publicHolidays = DateSystem.GetPublicHoliday(yearToTest, CountryCode.DE);
            var corpusChristi = publicHolidays.First(x => x.LocalName == "Fronleichnam").Date;
            var expectedDate2017 = new DateTime(yearToTest, 6, 15);
            Assert.AreEqual(expectedDate2017, corpusChristi);
        }

        [TestMethod]
        public void TestGermanyCorpusChristi2026()
        {
            var yearToTest = 2026;
            var publicHolidays = DateSystem.GetPublicHoliday(yearToTest, CountryCode.DE);
            var corpusChristi = publicHolidays.First(x => x.LocalName == "Fronleichnam").Date;
            var expectedDate2026 = new DateTime(yearToTest, 6, 4);
            Assert.AreEqual(expectedDate2026, corpusChristi);
        }

        [TestMethod]
        public void TestGermanyLiberationDay2020()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(
                new DateTime(2019, 5, 8),
                new DateTime(2021, 5, 8),
                CountryCode.DE);
            var liberationDays = publicHolidays.Where(x => x.LocalName == "Tag der Befreiung").ToList();

            Assert.AreEqual(1, liberationDays.Count);
            var liberationDay = liberationDays.FirstOrDefault();
            Assert.IsNotNull(liberationDay);
            Assert.AreEqual(new DateTime(2020, 5, 8), liberationDay.Date);
            Assert.IsNotNull(liberationDay.Counties);
            Assert.AreEqual(1, liberationDay.Counties.Length);
            Assert.AreEqual("DE-BE", liberationDay.Counties[0]);
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
        public void TestGermanyIsOfficialPublicHolidayByCountyWithCountySpecificWorldChildrensDay()
        {
            var isPublicHolidayInTH2018 = DateSystem.IsOfficialPublicHolidayByCounty(new DateTime(2018, 9, 20), CountryCode.DE, "DE-TH");
            var isPublicHolidayInTH2019 = DateSystem.IsOfficialPublicHolidayByCounty(new DateTime(2019, 9, 20), CountryCode.DE, "DE-TH");
            var isPublicHolidayInTH2020 = DateSystem.IsOfficialPublicHolidayByCounty(new DateTime(2020, 9, 20), CountryCode.DE, "DE-TH");

            Assert.IsFalse(isPublicHolidayInTH2018);
            Assert.IsTrue(isPublicHolidayInTH2019);
            Assert.IsTrue(isPublicHolidayInTH2020);
        }

        [TestMethod]
        public void TestGermanyIsOfficialPublicHolidayByCountyLiberationDay()
        {
            const string CountyCodeBerlin = "DE-BE";

            var isPublicHolidayInBerlin2019 = DateSystem.IsOfficialPublicHolidayByCounty(new DateTime(2019, 5, 8), CountryCode.DE, CountyCodeBerlin);
            var isPublicHolidayInBerlin2020 = DateSystem.IsOfficialPublicHolidayByCounty(new DateTime(2020, 5, 8), CountryCode.DE, CountyCodeBerlin);
            var isPublicHolidayInBerlin2021 = DateSystem.IsOfficialPublicHolidayByCounty(new DateTime(2021, 5, 8), CountryCode.DE, CountyCodeBerlin);

            Assert.IsFalse(isPublicHolidayInBerlin2019);
            Assert.IsTrue(isPublicHolidayInBerlin2020);
            Assert.IsFalse(isPublicHolidayInBerlin2021);
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
