using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class SingaporeTest
    {
        [TestMethod]
        public void TestSingapore()
        {
            var publicHolidays = DateSystem.GetHolidays(2022, CountryCode.SG).ToArray();

            Assert.AreEqual("New Year's Day", publicHolidays[0].EnglishName);
        }

        [TestMethod]
        public void HolidayCount()
        {
            for (var year = 2018; year <= 2022; year++)
            {
                var publicHolidays = DateSystem.GetHolidays(year, CountryCode.SG).ToArray();
                Assert.AreEqual(11, publicHolidays.Length);
            }
        }
    }
}
