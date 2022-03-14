using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class ColombiaTest
    {
        [TestMethod]
        public void TestColombia_2022()
        {
            var publicHolidays = DateSystem.GetPublicHolidays(2022, CountryCode.CO).ToArray();

            var saintJosephsDay = publicHolidays.SingleOrDefault(o => o.Name == "Saint Joseph's Day");
            Assert.AreEqual(new DateTime(2022, 03, 21), saintJosephsDay.Date);

            var ascensionDay = publicHolidays.SingleOrDefault(o => o.Name == "Ascension Day");
            Assert.AreEqual(new DateTime(2022, 05, 30), ascensionDay.Date);

            var assumptionOfMaryDay = publicHolidays.SingleOrDefault(o => o.Name == "Assumption of Mary");
            Assert.AreEqual(new DateTime(2022, 08, 15), assumptionOfMaryDay.Date);

            var independenceOfCartagenaDay = publicHolidays.SingleOrDefault(o => o.Name == "Independence of Cartagena");
            Assert.AreEqual(new DateTime(2022, 11, 14), independenceOfCartagenaDay.Date);
        }
    }
}
