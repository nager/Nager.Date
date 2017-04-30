using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Nager.Date.UnitTest.UnitTestLogic;

namespace Nager.Date.UnitTest
{
    [TestClass]
    public class UnitTestGermany
    {
        [TestMethod]
        public void TestGermanyCorpusChristi()
        {
            var catholicProvider = new MockProvider();
            var yearToTest = 2017;
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.DE, yearToTest).ToArray();
            var EasterSunday = catholicProvider.EasterSunday(yearToTest);
            var CorpusChristi = publicHolidays
                .Where(x => x.LocalName == "Fronleichnam")
                .First().Date;
            Assert.AreEqual(EasterSunday.AddDays(60), CorpusChristi);
        }

        [TestMethod]
        public void TestGermanyCorpusChristi2017()
        {
            var yearToTest = 2017;

            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.DE, yearToTest).ToArray();
           
            var CorpusChristi = publicHolidays
                .Where(x => x.LocalName == "Fronleichnam")
                .First().Date;

            var expectedDate2017 = new DateTime(yearToTest, 6, 15);

            Assert.AreEqual(expectedDate2017, CorpusChristi);
        }

        [TestMethod]
        public void TestGermanyCorpusChristi2026()
        {
            var yearToTest = 2026;

            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.DE, yearToTest).ToArray();

            var CorpusChristi = publicHolidays
                .Where(x => x.LocalName == "Fronleichnam")
                .First().Date;

            var expectedDate2026 = new DateTime(yearToTest, 6, 4);

            Assert.AreEqual(expectedDate2026, CorpusChristi);
        }

        
        private DateTime GetGermanyDayOfPrayerDate(int yearToTest)
        {
   
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.DE, yearToTest).ToArray();

            var dayOfPrayer = publicHolidays
                .Where(x => x.LocalName == "Buß- und Bettag")
                .First().Date;

            return dayOfPrayer;

        }

        [TestMethod]
        public void TestGermanyDayOfPrayer2017()
        {
            int yearToTest = 2017;
            var dayOfPrayer = GetGermanyDayOfPrayerDate(yearToTest);
            var expectedDate = new DateTime(yearToTest, 11, 22);

            Assert.AreEqual(expectedDate, dayOfPrayer);
        }

        [TestMethod]
        public void TestGermanyDayOfPrayer2018()
        {
            int yearToTest = 2018;
            var dayOfPrayer = GetGermanyDayOfPrayerDate(yearToTest);
            var expectedDate = new DateTime(yearToTest, 11, 21);

            Assert.AreEqual(expectedDate, dayOfPrayer);
        }
    }
}
