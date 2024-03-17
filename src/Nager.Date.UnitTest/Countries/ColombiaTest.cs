using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class ColombiaTest
    {
        [TestMethod]
        public void TestColombia_2022()
        {
            var publicHolidays = HolidaySystem.GetHolidays(2022, CountryCode.CO).ToArray();

            var saintJosephsDay = publicHolidays.SingleOrDefault(o => o.EnglishName == "Saint Joseph's Day");
            Assert.AreEqual(new DateTime(2022, 03, 21), saintJosephsDay.ObservedDate);

            var ascensionDay = publicHolidays.SingleOrDefault(o => o.EnglishName == "Ascension Day");
            Assert.AreEqual(new DateTime(2022, 05, 30), ascensionDay.ObservedDate);

            var assumptionOfMaryDay = publicHolidays.SingleOrDefault(o => o.EnglishName == "Assumption of Mary");
            Assert.AreEqual(new DateTime(2022, 08, 15), assumptionOfMaryDay.ObservedDate);

            var independenceOfCartagenaDay = publicHolidays.SingleOrDefault(o => o.EnglishName == "Independence of Cartagena");
            Assert.AreEqual(new DateTime(2022, 11, 14), independenceOfCartagenaDay.ObservedDate);
        }
    }
}
