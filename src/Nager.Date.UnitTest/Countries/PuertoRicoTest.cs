using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using Nager.Date.ReligiousProviders;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class PuertoRicoTest
    {
        [TestMethod]
        public void PuertoRicoHasGoodFridayHoliday()
        {
            var holidays = HolidaySystem.GetHolidays(2017, CountryCode.PR);

            var catholicProvider = new CatholicProvider();
            var expectedGoodFriday = catholicProvider.EasterSunday(2017).AddDays(-2);

            var goodFriday = holidays.First(holiday => holiday.EnglishName == "Good Friday");
            Assert.IsNotNull(goodFriday);
            Assert.AreEqual(expectedGoodFriday.Day, goodFriday.Date.Day);
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
            var isWeekend = date.IsWeekend(CountryCode.PR);
            Assert.AreEqual(expectedIsWeekend, isWeekend);
        }
    }
}
