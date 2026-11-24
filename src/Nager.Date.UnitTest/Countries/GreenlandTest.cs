using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Models;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class GreenlandTest
    {
        [TestMethod]
        [DataRow(2026)]
        [DataRow(2027)]
        public void CheckThatEpiphanyIsAnObservanceOnly(int year)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.GL).ToArray();
            var epiphany = holidays.SingleOrDefault(holiday => holiday.Date == new DateTime(year, 1, 6));

            Assert.IsNotNull(epiphany);
            Assert.AreEqual(HolidayTypes.Observance, epiphany.HolidayTypes);
        }

        [TestMethod]
        [DataRow(2027, 1, 6, false)]
        [DataRow(2027, 4, 23, true)]
        [DataRow(2027, 6, 21, true)]
        public void ChecksIsPublicHoliday(int year, int month, int day, bool expectedIsPublicHoliday)
        {
            var date = new DateTime(year, month, day);
            var isPublicHoliday = HolidaySystem.IsPublicHoliday(date, CountryCode.GL);
            Assert.AreEqual(expectedIsPublicHoliday, isPublicHoliday, date.ToString("yyyy-MM-dd"));
        }

        [TestMethod]
        [DataRow(2027, 5, 7)]
        [DataRow(2027, 12, 24)]
        [DataRow(2027, 12, 31)]
        public void CheckThatBankClosingDaysKeepTheBankType(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.GL).ToArray();
            var holiday = holidays.SingleOrDefault(o => o.Date == date);

            Assert.IsNotNull(holiday, date.ToString("yyyy-MM-dd"));
            Assert.IsTrue(holiday.HolidayTypes.HasFlag(HolidayTypes.Bank), date.ToString("yyyy-MM-dd"));
        }
    }
}
