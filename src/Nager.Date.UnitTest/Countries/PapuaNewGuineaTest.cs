using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class PapuaNewGuineaTest() : BaseTest(CountryCode.PG)
    {
        [TestMethod]
        [DataRow(2021, 2021, 1, 1)]
        [DataRow(2022, 2022, 1, 1)]
        [DataRow(2026, 2026, 1, 1)]
        [DataRow(2027, 2027, 1, 1)]
        public void TestNewYearsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NEWYEARSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2022, 2022, 2, 26)]
        public void TestNationalRemembranceDaySomare(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NATIONALREMEMBRANCEDAYSOMARE-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 4, 2)]
        [DataRow(2022, 2022, 4, 15)]
        [DataRow(2026, 2026, 4, 3)]
        [DataRow(2027, 2027, 3, 26)]
        public void TestGoodFriday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "GOODFRIDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 4, 3)]
        [DataRow(2022, 2022, 4, 16)]
        [DataRow(2026, 2026, 4, 4)]
        [DataRow(2027, 2027, 3, 27)]
        public void TestEasterSaturday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CHOLYSATURDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 4, 4)]
        [DataRow(2022, 2022, 4, 17)]
        public void TestEasterSunday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "EASTERSUNDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 4, 5)]
        [DataRow(2022, 2022, 4, 18)]
        [DataRow(2026, 2026, 4, 6)]
        [DataRow(2027, 2027, 3, 29)]
        public void TestEasterMonday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "EASTERMONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 6, 14)]
        [DataRow(2022, 2022, 6, 13)]
        [DataRow(2026, 2026, 6, 17)]
        [DataRow(2027, 2027, 6, 17)]
        public void TestKingsBirthday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "MONARCHBIRTHDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 7, 23)]
        [DataRow(2022, 2022, 7, 23)]
        [DataRow(2026, 2026, 7, 23)]
        [DataRow(2027, 2027, 7, 23)]
        public void TestNationalRemembranceDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NATIONALREMEMBRANCEDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 8, 26)]
        [DataRow(2022, 2022, 8, 26)]
        [DataRow(2026, 2026, 8, 26)]
        [DataRow(2027, 2027, 8, 26)]
        public void TestNationalRepentanceDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NATIONALREPENTANCEDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 9, 16)]
        [DataRow(2022, 2022, 9, 16)]
        [DataRow(2026, 2026, 9, 16)]
        [DataRow(2027, 2027, 9, 16)]
        public void TestIndependenceDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "INDEPENDENCEDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 12, 25)]
        [DataRow(2022, 2022, 12, 27)]
        [DataRow(2026, 2026, 12, 25)]
        [DataRow(2027, 2027, 12, 25)]
        public void TestChristmasDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CHRISTMASDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 12, 27)]
        [DataRow(2022, 2022, 12, 26)]
        [DataRow(2026, 2026, 12, 26)]
        [DataRow(2027, 2027, 12, 27)]
        public void TestBoxingDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "BOXINGDAY-01", observedYear, month, day);
        }

        [TestMethod]
        public void CheckQueensBirthdayFor2018()
        {
            var publicHolidays = HolidaySystem.GetHolidays(2018, CountryCode.PG).ToArray();

            var publicHoliday = publicHolidays.FirstOrDefault(holiday => holiday.EnglishName.Equals("Queen's Birthday"));
            Assert.AreEqual(new DateTime(2018, 6, 11), publicHoliday.Date);
        }

        [TestMethod]
        public void CheckQueensBirthdayFor2021()
        {
            var publicHolidays = HolidaySystem.GetHolidays(2021, CountryCode.PG).ToArray();

            var publicHoliday = publicHolidays.FirstOrDefault(holiday => holiday.EnglishName.Equals("Queen's Birthday"));
            Assert.AreEqual(new DateTime(2021, 6, 14), publicHoliday.Date);
        }
    }
}
