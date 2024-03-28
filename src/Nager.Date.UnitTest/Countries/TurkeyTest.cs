using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class TurkeyTest
    {
        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 23)]
        [DataRow(5, 1)]
        //[DataRow(5, 2)]
        //[DataRow(5, 3)]
        //[DataRow(5, 4)]
        [DataRow(5, 19)]
        //[DataRow(7, 9)]
        //[DataRow(7, 10)]
        //[DataRow(7, 11)]
        //[DataRow(7, 12)]
        [DataRow(7, 15)]
        [DataRow(8, 30)]
        [DataRow(10, 29)]
        public void TestHolidays2022(int month, int day)
        {
            var year = 2022;
            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.TR);

            var holiday = new DateTime(year, month, day);
            var isHolidayFound = publicHolidays.Any(x => x.Date == holiday);
            Assert.IsTrue(isHolidayFound, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 23)]
        [DataRow(5, 1)]
        [DataRow(5, 19)]
        //[DataRow(5, 24)]
        //[DataRow(5, 25)]
        //[DataRow(5, 26)]
        [DataRow(7, 15)]
        //[DataRow(7, 31)]
        //[DataRow(8, 1)]
        //[DataRow(8, 2)]
        //[DataRow(8, 3)]
        [DataRow(8, 30)]
        [DataRow(10, 29)]
        public void TestHolidays2020(int month, int day)
        {
            var year = 2020;
            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.TR);

            var holiday = new DateTime(year, month, day);
            var isHolidayFound = publicHolidays.Any(x => x.Date == holiday);
            Assert.IsTrue(isHolidayFound, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 23)]
        [DataRow(5, 1)]
        [DataRow(5, 19)]
        //[DataRow(6, 25)]
        //[DataRow(6, 26)]
        //[DataRow(6, 27)]
        [DataRow(7, 15)]
        [DataRow(8, 30)]
        //[DataRow(9, 1)]
        //[DataRow(9, 2)]
        //[DataRow(9, 3)]
        //[DataRow(9, 4)]
        [DataRow(10, 29)]
        public void TestHolidays2017(int month, int day)
        {
            var year = 2017;
            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.TR);

            var holiday = new DateTime(year, month, day);
            var isHolidayFound = publicHolidays.Any(x => x.Date == holiday);
            Assert.IsTrue(isHolidayFound, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 23)]
        [DataRow(5, 1)]
        [DataRow(5, 19)]
        //[DataRow(7, 28)]
        //[DataRow(7, 29)]
        //[DataRow(7, 30)]
        [DataRow(8, 30)]
        //[DataRow(10, 4)]
        //[DataRow(10, 5)]
        //[DataRow(10, 6)]
        //[DataRow(10, 7)]
        [DataRow(10, 29)]
        public void TestHolidays2014(int month, int day)
        {
            var year = 2014;
            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.TR);

            var holiday = new DateTime(year, month, day);
            var isHolidayFound = publicHolidays.Any(x => x.Date == holiday);
            Assert.IsTrue(isHolidayFound, $"{holiday.ToString("D")} is not a holiday");
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
            var isWeekend = date.IsWeekend(CountryCode.TR);
            Assert.AreEqual(expectedIsWeekend, isWeekend);
        }
    }
}
