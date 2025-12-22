using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Extensions;
using Nager.Date.ReligiousProviders;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class FranceTest
    {
        [TestMethod]
        public void TestFrance2025()
        {
            var year = 2025;
            var publicHolidays = HolidaySystem.GetHolidays(year, CountryCode.FR).ToArray();

            // 11 national + 2 regional (Alsace-Moselle)
            Assert.AreEqual(13, publicHolidays.Length);
        }

        [TestMethod]
        public void TestGoodFridayExistsForAlsaceMoselle()
        {
            var publicHolidays = HolidaySystem.GetHolidays(2025, CountryCode.FR);
            var goodFriday = publicHolidays.FirstOrDefault(x => x.LocalName == "Vendredi saint");

            Assert.IsNotNull(goodFriday);
            Assert.IsNotNull(goodFriday.SubdivisionCodes);
            Assert.AreEqual(3, goodFriday.SubdivisionCodes.Length);
            CollectionAssert.Contains(goodFriday.SubdivisionCodes, "FR-57");
            CollectionAssert.Contains(goodFriday.SubdivisionCodes, "FR-67");
            CollectionAssert.Contains(goodFriday.SubdivisionCodes, "FR-68");
        }

        [TestMethod]
        public void TestStStephensDayExistsForAlsaceMoselle()
        {
            var publicHolidays = HolidaySystem.GetHolidays(2025, CountryCode.FR);
            var stStephensDay = publicHolidays.FirstOrDefault(x => x.LocalName == "Saint-Étienne");

            Assert.IsNotNull(stStephensDay);
            Assert.AreEqual(new DateTime(2025, 12, 26), stStephensDay.Date);
            Assert.IsNotNull(stStephensDay.SubdivisionCodes);
            CollectionAssert.Contains(stStephensDay.SubdivisionCodes, "FR-57");
        }

        [TestMethod]
        public void TestGoodFridayIsPublicHolidayInMoselle()
        {
            // Good Friday 2025 is April 18
            var isHoliday = HolidaySystem.IsPublicHoliday(new DateTime(2025, 4, 18), CountryCode.FR, "FR-57");
            Assert.IsTrue(isHoliday);
        }

        [TestMethod]
        public void TestGoodFridayIsNotPublicHolidayInParis()
        {
            // Good Friday 2025 is April 18
            var isHoliday = HolidaySystem.IsPublicHoliday(new DateTime(2025, 4, 18), CountryCode.FR, "FR-IDF");
            Assert.IsFalse(isHoliday);
        }

        [TestMethod]
        public void TestStStephensDayIsPublicHolidayInBasRhin()
        {
            var isHoliday = HolidaySystem.IsPublicHoliday(new DateTime(2025, 12, 26), CountryCode.FR, "FR-67");
            Assert.IsTrue(isHoliday);
        }

        [TestMethod]
        public void TestStStephensDayIsNotPublicHolidayInBretagne()
        {
            var isHoliday = HolidaySystem.IsPublicHoliday(new DateTime(2025, 12, 26), CountryCode.FR, "FR-BRE");
            Assert.IsFalse(isHoliday);
        }

        [TestMethod]
        public void TestGoodFridayDate2025()
        {
            var catholicProvider = new CatholicProvider();
            var easterSunday = catholicProvider.EasterSunday(2025);

            var publicHolidays = HolidaySystem.GetHolidays(2025, CountryCode.FR);
            var goodFriday = publicHolidays.First(x => x.LocalName == "Vendredi saint");

            Assert.AreEqual(easterSunday.AddDays(-2), goodFriday.Date);
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
            var isWeekend = date.IsWeekend(CountryCode.FR);
            Assert.AreEqual(expectedIsWeekend, isWeekend);
        }
    }
}
