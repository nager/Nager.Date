using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using Nager.Date.ReligiousProviders;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class GermanyTest
    {
        [TestMethod]
        public void TestGermanyCorpusChristi()
        {
            var yearToTest = 2017;

            var catholicProvider = new CatholicProvider();
            var publicHolidays = HolidaySystem.GetHolidays(yearToTest, CountryCode.DE);
            var easterSunday = catholicProvider.EasterSunday(yearToTest);
            var corpusChristi = publicHolidays.First(x => x.LocalName == "Fronleichnam").Date;
            Assert.AreEqual(easterSunday.AddDays(60), corpusChristi);
        }

        [TestMethod]
        public void TestGermanyCorpusChristi2017()
        {
            var yearToTest = 2017;

            var publicHolidays = HolidaySystem.GetHolidays(yearToTest, CountryCode.DE);
            var corpusChristi = publicHolidays.First(x => x.LocalName == "Fronleichnam").Date;
            var expectedDate = new DateTime(yearToTest, 6, 15);
            Assert.AreEqual(expectedDate, corpusChristi);
        }

        [TestMethod]
        public void TestGermanyCorpusChristi2026()
        {
            var yearToTest = 2026;

            var publicHolidays = HolidaySystem.GetHolidays(yearToTest, CountryCode.DE);
            var corpusChristi = publicHolidays.First(x => x.LocalName == "Fronleichnam").Date;
            var expectedDate = new DateTime(yearToTest, 6, 4);
            Assert.AreEqual(expectedDate, corpusChristi);
        }

        [DataTestMethod]
        [DataRow(2019, 2021, 2020)]
        [DataRow(2024, 2026, 2025)]
        public void TestGermanyLiberationDay(int startYear, int endYear, int expectedYear)
        {
            var publicHolidays = HolidaySystem.GetHolidays(
                new DateTime(startYear, 5, 8),
                new DateTime(endYear, 5, 8),
                CountryCode.DE);

            var liberationDays = publicHolidays.Where(x => x.LocalName == "Tag der Befreiung").ToList();
            var liberationDay = liberationDays.FirstOrDefault();

            Assert.AreEqual(1, liberationDays.Count);
            Assert.IsNotNull(liberationDay);
            Assert.AreEqual(new DateTime(expectedYear, 5, 8), liberationDay.Date);
            Assert.IsNotNull(liberationDay.SubdivisionCodes);
            Assert.AreEqual(1, liberationDay.SubdivisionCodes.Length);
            Assert.AreEqual("DE-BE", liberationDay.SubdivisionCodes[0]);
        }

        [TestMethod]
        public void TestGermanyIsOfficialPublicHolidayByCountyWithCountySpecificEpiphany2017()
        {
            var isPublicHolidayInBW = HolidaySystem.IsPublicHoliday(new DateTime(2017, 1, 6), CountryCode.DE, "DE-BW");
            var isPublicHolidayInNW = HolidaySystem.IsPublicHoliday(new DateTime(2017, 1, 6), CountryCode.DE, "DE-NW");

            Assert.IsTrue(isPublicHolidayInBW);
            Assert.IsFalse(isPublicHolidayInNW);
        }

        [TestMethod]
        public void TestGermanyIsOfficialPublicHolidayByCountyWithGlobalChristmasDay2017()
        {
            var isPublicHolidayInBW = HolidaySystem.IsPublicHoliday(new DateTime(2017, 12, 25), CountryCode.DE, "DE-BW");

            Assert.IsTrue(isPublicHolidayInBW);
        }

        [TestMethod]
        public void TestGermanyIsOfficialPublicHolidayByCountyWithCountySpecificWorldChildrensDay()
        {
            var isPublicHolidayInTH2018 = HolidaySystem.IsPublicHoliday(new DateTime(2018, 9, 20), CountryCode.DE, "DE-TH");
            var isPublicHolidayInTH2019 = HolidaySystem.IsPublicHoliday(new DateTime(2019, 9, 20), CountryCode.DE, "DE-TH");
            var isPublicHolidayInTH2020 = HolidaySystem.IsPublicHoliday(new DateTime(2020, 9, 20), CountryCode.DE, "DE-TH");

            Assert.IsFalse(isPublicHolidayInTH2018);
            Assert.IsTrue(isPublicHolidayInTH2019);
            Assert.IsTrue(isPublicHolidayInTH2020);
        }

        [TestMethod]
        public void TestGermanyIsOfficialPublicHolidayByCountyLiberationDay()
        {
            const string CountyCodeBerlin = "DE-BE";

            var isPublicHolidayInBerlin2019 = HolidaySystem.IsPublicHoliday(new DateTime(2019, 5, 8), CountryCode.DE, CountyCodeBerlin);
            var isPublicHolidayInBerlin2020 = HolidaySystem.IsPublicHoliday(new DateTime(2020, 5, 8), CountryCode.DE, CountyCodeBerlin);
            var isPublicHolidayInBerlin2021 = HolidaySystem.IsPublicHoliday(new DateTime(2021, 5, 8), CountryCode.DE, CountyCodeBerlin);

            Assert.IsFalse(isPublicHolidayInBerlin2019);
            Assert.IsTrue(isPublicHolidayInBerlin2020);
            Assert.IsFalse(isPublicHolidayInBerlin2021);
        }

        [DataTestMethod]
        [DataRow(2018, 10, 8, false)]
        [DataRow(2018, 10, 9, false)]
        [DataRow(2018, 10, 10, false)]
        [DataRow(2018, 10, 11, false)]
        [DataRow(2018, 10, 12, false)]
        [DataRow(2018, 10, 13, true)]
        [DataRow(2018, 10, 14, true)]
        public void ChecksThatUniversalWeekendIsUsed(int year, int month, int day, bool expectedIsWeekend)
        {
            var date = new DateTime(year, month, day);
            var isWeekend = date.IsWeekend(CountryCode.DE);
            Assert.AreEqual(expectedIsWeekend, isWeekend);
        }
    }
}
