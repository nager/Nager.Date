using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class TurkeyTest
    {
        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 23)]
        [DataRow(5, 1)]
        [DataRow(5, 2)]
        [DataRow(5, 3)]
        [DataRow(5, 4)]
        [DataRow(5, 19)]
        [DataRow(7, 9)]
        [DataRow(7, 10)]
        [DataRow(7, 11)]
        [DataRow(7, 12)]
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

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 23)]
        [DataRow(5, 1)]
        [DataRow(5, 19)]
        [DataRow(5, 24)]
        [DataRow(5, 25)]
        [DataRow(5, 26)]
        [DataRow(7, 15)]
        [DataRow(7, 31)]
        [DataRow(8, 1)]
        [DataRow(8, 2)]
        [DataRow(8, 3)]
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

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 23)]
        [DataRow(5, 1)]
        [DataRow(5, 19)]
        [DataRow(6, 25)]
        [DataRow(6, 26)]
        [DataRow(6, 27)]
        [DataRow(7, 15)]
        [DataRow(8, 30)]
        [DataRow(9, 1)]
        [DataRow(9, 2)]
        [DataRow(9, 3)]
        [DataRow(9, 4)]
        [DataRow(10, 29)]
        public void TestHolidays2017(int month, int day)
        {
            var year = 2017;
            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.TR);

            var holiday = new DateTime(year, month, day);
            var isHolidayFound = publicHolidays.Any(x => x.Date == holiday);
            Assert.IsTrue(isHolidayFound, $"{holiday.ToString("D")} is not a holiday");
        }

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(4, 23)]
        [DataRow(5, 1)]
        [DataRow(5, 19)]
        [DataRow(7, 28)]
        [DataRow(7, 29)]
        [DataRow(7, 30)]
        [DataRow(8, 30)]
        [DataRow(10, 4)]
        [DataRow(10, 5)]
        [DataRow(10, 6)]
        [DataRow(10, 7)]
        [DataRow(10, 29)]
        public void TestHolidays2014(int month, int day)
        {
            var year = 2014;
            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.TR);

            var holiday = new DateTime(year, month, day);
            var isHolidayFound = publicHolidays.Any(x => x.Date == holiday);
            Assert.IsTrue(isHolidayFound, $"{holiday.ToString("D")} is not a holiday");
        }

        [DataRow(2010, 09, 09)]
        [DataRow(2011, 08, 30)]
        [DataRow(2012, 08, 19)]
        [DataRow(2013, 08, 08)]
        [DataRow(2014, 07, 28)]
        [DataRow(2015, 07, 17)]
        [DataRow(2016, 07, 05)]
        [DataRow(2017, 06, 25)]
        [DataRow(2018, 06, 15)]
        [DataRow(2019, 06, 04)]
        [DataRow(2020, 05, 24)]
        [DataRow(2021, 05, 13)]
        [DataRow(2022, 05, 02)]
        [DataRow(2023, 04, 21)]
        [DataRow(2024, 04, 10)]
        [DataRow(2025, 03, 30)]
        [DataRow(2026, 03, 20)]
        [DataRow(2027, 03, 10)]
        [DataRow(2028, 02, 27)]
        [DataRow(2029, 02, 15)]
        [DataRow(2030, 02, 05)]
        [TestMethod]
        public void EidAlFitrHoliday(int year, int month, int day)
        {
            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.TR);
            var holiday = publicHolidays.First(o => o.Id == "TR-EIDALFITR-01");

            Assert.AreEqual(new DateTime(year, month, day), holiday.Date);
        }

        [DataRow(2010, 11, 16)]
        [DataRow(2011, 11, 06)]
        [DataRow(2012, 10, 26)]
        [DataRow(2013, 10, 15)]
        [DataRow(2014, 10, 04)]
        [DataRow(2015, 09, 24)]
        [DataRow(2016, 09, 12)]
        [DataRow(2017, 09, 01)]
        [DataRow(2018, 08, 21)]
        [DataRow(2019, 08, 11)]
        [DataRow(2020, 07, 31)]
        [DataRow(2021, 07, 20)]
        [DataRow(2022, 07, 09)]
        [DataRow(2023, 06, 28)]
        [DataRow(2024, 06, 16)]
        [DataRow(2025, 06, 06)]
        [DataRow(2026, 05, 27)]
        [DataRow(2027, 05, 16)]
        [DataRow(2028, 05, 05)]
        [DataRow(2029, 04, 24)]
        [DataRow(2030, 04, 14)]
        [TestMethod]
        public void EidAlAdhaHoliday(int year, int month, int day)
        {
            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.TR);
            var holiday = publicHolidays.First(o => o.Id == "TR-EIDALADHA-01");

            Assert.AreEqual(new DateTime(year, month, day), holiday.Date);
        }

        [TestMethod]
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
