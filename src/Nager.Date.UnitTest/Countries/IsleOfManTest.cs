using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class IsleOfManTest
    {
        [TestMethod]
        public void TestIsleOfMan()
        {
            var testDate = new DateTime(2017, 08, 28);
            var isPublicHoliday = HolidaySystem.IsPublicHoliday(testDate, CountryCode.IM);
            Assert.AreEqual(true, isPublicHoliday);
        }

        [DataTestMethod]
        [DataRow(2015, 5, 4, true)]
        [DataRow(2016, 5, 2, true)]
        [DataRow(2017, 5, 1, true)]
        [DataRow(2018, 5, 7, true)]
        [DataRow(2019, 5, 6, true)]
        [DataRow(2020, 5, 1, false)]
        [DataRow(2020, 5, 4, false)]
        [DataRow(2020, 5, 8, true)]
        [DataRow(2021, 5, 3, true)]
        [DataRow(2022, 5, 2, true)]
        public void CheckEarlyMayDay(int year, int month, int day, bool expected)
        {
            var date = new DateTime(year, month, day);

            var result = HolidaySystem.IsPublicHoliday(date, CountryCode.IM);

            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(2015, 5, 25, true)]
        [DataRow(2016, 5, 30, true)]
        [DataRow(2017, 5, 29, true)]
        [DataRow(2018, 5, 28, true)]
        [DataRow(2019, 5, 27, true)]
        [DataRow(2020, 5, 25, true)]
        [DataRow(2021, 5, 31, true)]
        [DataRow(2022, 6, 2, true)]
        public void CheckLateMaySpringDay(int year, int month, int day, bool expected)
        {
            var date = new DateTime(year, month, day);

            var result = HolidaySystem.IsPublicHoliday(date, CountryCode.IM);

            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(2015, 6, 12, true)]
        [DataRow(2016, 6, 10, true)]
        [DataRow(2017, 6, 9, true)]
        [DataRow(2018, 6, 8, true)]
        [DataRow(2019, 6, 7, true)]
        [DataRow(2020, 6, 12, false)]
        [DataRow(2020, 8, 28, true)]
        [DataRow(2021, 6, 11, true)]
        [DataRow(2022, 6, 10, true)]
        public void CheckTTRaceDay(int year, int month, int day, bool expected)
        {
            var date = new DateTime(year, month, day);

            var result = HolidaySystem.IsPublicHoliday(date, CountryCode.IM);

            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(2015, 7, 6, true)]
        [DataRow(2016, 7, 5, true)]
        [DataRow(2017, 7, 5, true)]
        [DataRow(2018, 7, 5, true)]
        [DataRow(2019, 7, 5, true)]
        [DataRow(2020, 7, 6, true)]
        [DataRow(2021, 7, 5, true)]
        [DataRow(2022, 7, 5, true)]
        public void CheckTynwaldDay(int year, int month, int day, bool expected)
        {
            var date = new DateTime(year, month, day);

            var result = HolidaySystem.IsPublicHoliday(date, CountryCode.IM);

            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(2015, 8, 31, true)]
        [DataRow(2016, 8, 29, true)]
        [DataRow(2017, 8, 28, true)]
        [DataRow(2018, 8, 27, true)]
        [DataRow(2019, 8, 26, true)]
        [DataRow(2020, 8, 31, true)]
        [DataRow(2021, 8, 30, true)]
        [DataRow(2022, 8, 29, true)]
        public void CheckSummerDay(int year, int month, int day, bool expected)
        {
            var date = new DateTime(year, month, day);

            var result = HolidaySystem.IsPublicHoliday(date, CountryCode.IM);

            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(2015, 12, 25, 28)]
        [DataRow(2016, 12, 27, 26)]
        [DataRow(2017, 12, 25, 26)]
        [DataRow(2018, 12, 25, 26)]
        [DataRow(2019, 12, 25, 26)]
        [DataRow(2020, 12, 25, 28)]
        [DataRow(2021, 12, 27, 28)]
        [DataRow(2022, 12, 27, 26)]
        public void CheckChristmasDayAndBoxingDay(int year, int month, int expectedChristmasDay, int expectedBoxingDay)
        {
            Assert.IsTrue(HolidaySystem.IsPublicHoliday(new DateTime(year, month, expectedChristmasDay), CountryCode.IM));
            Assert.IsTrue(HolidaySystem.IsPublicHoliday(new DateTime(year, month, expectedBoxingDay), CountryCode.IM));
        }

        [DataTestMethod]
        [DataRow(2015, 1, 1)]
        [DataRow(2016, 1, 1)]
        [DataRow(2017, 1, 2)]
        [DataRow(2018, 1, 1)]
        [DataRow(2019, 1, 1)]
        [DataRow(2020, 1, 1)]
        [DataRow(2021, 1, 1)]
        [DataRow(2022, 1, 3)]
        public void CheckNewYearsDay(int year, int month, int expectedNewYearsDay)
        {
            Assert.IsTrue(HolidaySystem.IsPublicHoliday(new DateTime(year, month, expectedNewYearsDay), CountryCode.IM));
        }


        [DataTestMethod]
        [DataRow(2021, 9, 19, false)]
        [DataRow(2022, 9, 19, true)]
        [DataRow(2023, 9, 19, false)]
        public void CheckQueensStateFuneral(int year, int month, int day, bool isBankHoliday)
        {
            Assert.AreEqual(HolidaySystem.IsPublicHoliday(new DateTime(year, month, day), CountryCode.IM), isBankHoliday);
        }

        [DataTestMethod]
        [DataRow(2021, 5, 8, false)]
        [DataRow(2022, 5, 8, false)]
        [DataRow(2023, 5, 8, true)]
        [DataRow(2024, 5, 8, false)]
        public void CheckKingCharlesCoronation(int year, int month, int day, bool isBankHoliday)
        {
            Assert.AreEqual(HolidaySystem.IsPublicHoliday(new DateTime(year, month, day), CountryCode.IM), isBankHoliday);
        }
    }
}
