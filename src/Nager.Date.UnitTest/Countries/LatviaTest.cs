using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Models;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class LatviaTest
    {
        [TestMethod]
        public void TestLatviaPublicHolidays2024()
        {
            var publicHolidays = HolidaySystem.GetHolidays(2024, CountryCode.LV)
                .Where(holiday => holiday.HolidayTypes.HasFlag(HolidayTypes.Public))
                .ToArray();

            Assert.AreEqual(16, publicHolidays.Length);

            //4 May 2024 falls on a Saturday, the next working day is a holiday
            var restorationDay = publicHolidays.Single(holiday => holiday.Id == "LV-RESTORATIONOFINDEPENDENCE-01");
            Assert.AreEqual(new DateTime(2024, 5, 4), restorationDay.Date);
            Assert.AreEqual(new DateTime(2024, 5, 6), restorationDay.ObservedDate);
        }

        [TestMethod]
        [DataRow(2018, 7, 8, 9)]
        [DataRow(2023, 7, 9, 10)]
        [DataRow(2028, 7, 9, 10)]
        public void TestSongAndDanceCelebrationFinalDay(int year, int month, int day, int observedDay)
        {
            var holiday = HolidaySystem.GetHolidays(year, CountryCode.LV)
                .Single(h => h.Id == "LV-SONGANDDANCECELEBRATION-01");

            Assert.AreEqual(new DateTime(year, month, day), holiday.Date);
            Assert.AreEqual(new DateTime(year, month, observedDay), holiday.ObservedDate);
            Assert.IsTrue(holiday.HolidayTypes.HasFlag(HolidayTypes.Public));
        }

        [TestMethod]
        [DataRow(2017)]
        [DataRow(2019)]
        [DataRow(2024)]
        public void TestNoSongAndDanceCelebrationDayInOtherYears(int year)
        {
            var holidayExists = HolidaySystem.GetHolidays(year, CountryCode.LV)
                .Any(h => h.Id == "LV-SONGANDDANCECELEBRATION-01");

            Assert.IsFalse(holidayExists);
        }

        [TestMethod]
        public void TestOneOffPublicHolidays()
        {
            var holidays2018 = HolidaySystem.GetHolidays(2018, CountryCode.LV).ToArray();
            var popeVisitDay = holidays2018.Single(h => h.Id == "LV-POPEFRANCISVISIT-01");
            Assert.AreEqual(new DateTime(2018, 9, 24), popeVisitDay.Date);
            Assert.IsTrue(popeVisitDay.HolidayTypes.HasFlag(HolidayTypes.Public));

            var holidays2023 = HolidaySystem.GetHolidays(2023, CountryCode.LV).ToArray();
            var iceHockeyDay = holidays2023.Single(h => h.Id == "LV-ICEHOCKEYBRONZEMEDAL-01");
            Assert.AreEqual(new DateTime(2023, 5, 29), iceHockeyDay.Date);
            Assert.IsTrue(iceHockeyDay.HolidayTypes.HasFlag(HolidayTypes.Public));

            var holidays2019 = HolidaySystem.GetHolidays(2019, CountryCode.LV).ToArray();
            Assert.IsFalse(holidays2019.Any(h => h.Id == "LV-POPEFRANCISVISIT-01"));
            Assert.IsFalse(holidays2019.Any(h => h.Id == "LV-ICEHOCKEYBRONZEMEDAL-01"));
        }

        [TestMethod]
        [DataRow(2020, "LV-LANGUAGEDAY-01", false)]
        [DataRow(2021, "LV-LANGUAGEDAY-01", true)]
        [DataRow(2020, "LV-NOVEMBER21TRAGEDY-01", false)]
        [DataRow(2021, "LV-NOVEMBER21TRAGEDY-01", true)]
        [DataRow(2021, "LV-NATIONALPARTISANS-01", false)]
        [DataRow(2022, "LV-NATIONALPARTISANS-01", true)]
        [DataRow(2021, "LV-NATIONALRESISTANCEMOVEMENT-01", false)]
        [DataRow(2022, "LV-NATIONALRESISTANCEMOVEMENT-01", true)]
        [DataRow(2025, "LV-WORLDNGODAY-01", false)]
        [DataRow(2026, "LV-WORLDNGODAY-01", true)]
        public void TestCommemorationDayIntroductionYears(int year, string holidayId, bool expected)
        {
            var holidayExists = HolidaySystem.GetHolidays(year, CountryCode.LV)
                .Any(h => h.Id == holidayId);

            Assert.AreEqual(expected, holidayExists);
        }

        [TestMethod]
        public void TestTeachersDayMovedToFixedDate()
        {
            //First Sunday of October until 2023, fixed 5 October from 2024
            var teachersDay2023 = HolidaySystem.GetHolidays(2023, CountryCode.LV)
                .Single(h => h.Id == "LV-TEACHERSDAY-01");
            Assert.AreEqual(new DateTime(2023, 10, 1), teachersDay2023.Date);

            var teachersDay2024 = HolidaySystem.GetHolidays(2024, CountryCode.LV)
                .Single(h => h.Id == "LV-TEACHERSDAY-01");
            Assert.AreEqual(new DateTime(2024, 10, 5), teachersDay2024.Date);
        }

        [TestMethod]
        public void TestCommemorationDaysAreObservances()
        {
            var holidays = HolidaySystem.GetHolidays(2026, CountryCode.LV).ToArray();

            var observanceDays = holidays
                .Where(holiday => holiday.HolidayTypes.HasFlag(HolidayTypes.Observance))
                .ToArray();

            Assert.AreEqual(33, observanceDays.Length);
            Assert.IsFalse(observanceDays.Any(holiday => holiday.HolidayTypes.HasFlag(HolidayTypes.Public)));
        }
    }
}
