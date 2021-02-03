using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class PapuaNewGuineaTest
    {
        [TestMethod]
        public void CheckQueensBirthdayFor2018()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(2018, CountryCode.PG).ToArray();

            var publicHoliday = publicHolidays.FirstOrDefault(holiday => holiday.Name.Equals("Queen's Birthday"));
            Assert.AreEqual(new DateTime(2018, 6, 11), publicHoliday.Date);
        }

        [TestMethod]
        public void CheckQueensBirthdayFor2021()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(2021, CountryCode.PG).ToArray();

            var publicHoliday = publicHolidays.FirstOrDefault(holiday => holiday.Name.Equals("Queen's Birthday"));
            Assert.AreEqual(new DateTime(2021, 6, 14), publicHoliday.Date);
        }
    }
}
