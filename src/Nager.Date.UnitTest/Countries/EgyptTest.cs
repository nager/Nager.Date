using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    /*
     * Source: Government website
     * For the links, the only way they work is to copy and paste them directly into the browser window
     * 2021 - https://web.archive.org/web/20211128090013/https://www.presidency.eg/en/%D9%85%D8%B5%D8%B1/%D8%A7%D9%84%D8%B9%D8%B7%D9%84%D8%A7%D8%AA-%D8%A7%D9%84%D8%B1%D8%B3%D9%85%D9%8A%D8%A9/
     * 2022 - https://web.archive.org/web/20221031121019/https://www.presidency.eg/en/%D9%85%D8%B5%D8%B1/%D8%A7%D9%84%D8%B9%D8%B7%D9%84%D8%A7%D8%AA-%D8%A7%D9%84%D8%B1%D8%B3%D9%85%D9%8A%D8%A9/
     * 2023 - https://web.archive.org/web/20230617063507/https://www.presidency.eg/EN/%D9%85%D8%B5%D8%B1/%D8%A7%D9%84%D8%B9%D8%B7%D9%84%D8%A7%D8%AA-%D8%A7%D9%84%D8%B1%D8%B3%D9%85%D9%8A%D8%A9/
     * 2024 - https://web.archive.org/web/20240803134112/https://www.presidency.eg/en/%D9%85%D8%B5%D8%B1/%D8%A7%D9%84%D8%B9%D8%B7%D9%84%D8%A7%D8%AA-%D8%A7%D9%84%D8%B1%D8%B3%D9%85%D9%8A%D8%A9/
     * 2025 - https://web.archive.org/web/20250804193259/https://www.presidency.eg/en/%D9%85%D8%B5%D8%B1/%D8%A7%D9%84%D8%B9%D8%B7%D9%84%D8%A7%D8%AA-%D8%A7%D9%84%D8%B1%D8%B3%D9%85%D9%8A%D8%A9/
     * 2026 - https://www.presidency.eg/en/%D9%85%D8%B5%D8%B1/%D8%A7%D9%84%D8%B9%D8%B7%D9%84%D8%A7%D8%AA-%D8%A7%D9%84%D8%B1%D8%B3%D9%85%D9%8A%D8%A9/
    */

    [TestClass]
    public class EgyptTest
    {
        [TestMethod]
        [DataRow(2021, 1, 7)] // 7 is Thursday
        [DataRow(2022, 1, 6)] // 7 is Friday (Weekend)
        [DataRow(2023, 1, 8)] // 7 is Saturday (Weekend)
        [DataRow(2024, 1, 7)] // 7 is Sunday
        [DataRow(2025, 1, 7)] // 7 is Tuesday
        [DataRow(2026, 1, 7)] // 7 is Wednesday
        public void TestCopticChristmasDay(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.EG);
            var holiday = holidays.Single(x => x.Id == "EG-ORTHODOXCHRISTMASDAY-01");

            Assert.AreEqual(holiday.ObservedDate, new DateTime(year, month, day));
        }

        [TestMethod]
        [DataRow(2021, 1, 28)] // 25 is Thursday
        [DataRow(2022, 1, 27)] // 25 is Thursday
        [DataRow(2023, 1, 26)] // 25 is Wednesday (Shift to Thursday LongWeekend)
        [DataRow(2024, 1, 25)] // 25 is Thursday
        [DataRow(2025, 1, 25)] // 25 is Saturday (Weekend)
        [DataRow(2026, 1, 29)] // 25 is Sunday
        public void TestRevolutionDay(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.EG);
            var holiday = holidays.Single(x => x.Id == "EG-REVOLUTIONDAY2011-01");

            Assert.AreEqual(holiday.ObservedDate, new DateTime(year, month, day));
        }

        [TestMethod]
        [DataRow(2021, 4, 29)] // 25 is Sunday (Shift to Thursday LongWeekend)
        [DataRow(2022, 4, 25)] // 25 is Monday
        [DataRow(2023, 4, 25)] // 25 is Tuesday
        [DataRow(2024, 4, 25)] // 25 is Thursday
        [DataRow(2025, 4, 24)] // 25 is Friday (Weekend)  (Shift to Thursday LongWeekend)
        [DataRow(2026, 4, 25)] // 25 is Saturday (Weekend)
        public void TestSinaiLiberationDay(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.EG);
            var holiday = holidays.Single(x => x.Id == "EG-SINAILIBERATIONDAY-01");

            Assert.AreEqual(holiday.ObservedDate, new DateTime(year, month, day));
        }

        [TestMethod]
        [DataRow(2021, 5, 1)] // 1 is Saturday (Weekend)
        [DataRow(2022, 5, 1)] // 1 is Sunday (Eid Al-Fitr and Labor Day / Overlap of the Two Holidays)
        [DataRow(2023, 5, 4)] // 1 is Monday (Shift to Thursday LongWeekend)
        [DataRow(2024, 5, 5)] // 1 is Wednesday (Shift to Sunday LongWeekend)
        [DataRow(2025, 5, 1)] // 1 is Thursday (Automatic LongWeekend)
        [DataRow(2026, 5, 7)] // 1 is Friday (Weekend) (Shift to Thursday LongWeekend)
        public void TestLabourDay(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.EG);
            var holiday = holidays.Single(x => x.Id == "EG-LABOURDAY-01");

            Assert.AreEqual(holiday.ObservedDate, new DateTime(year, month, day));
        }

        [TestMethod]
        [DataRow(2021, 5, 3)]  // Monday
        [DataRow(2022, 4, 25)] // Monday
        [DataRow(2023, 4, 17)] // Monday
        [DataRow(2024, 5, 6)]  // Monday
        [DataRow(2025, 4, 21)] // Monday
        [DataRow(2026, 4, 13)] // Monday
        public void TestShamElNessim(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.EG);
            var holiday = holidays.Single(x => x.Id == "EG-XXXXXXX-01");

            Assert.AreEqual(holiday.ObservedDate, new DateTime(year, month, day));
        }

        [TestMethod]
        [DataRow(2021, 7, 1)]  // Thursday
        [DataRow(2022, 6, 30)] // Thursday
        [DataRow(2023, 6, 30)] // Friday
        [DataRow(2024, 6, 30)] // Sunday
        [DataRow(2025, 7, 3)]  // Thursday 
        [DataRow(2026, 7, 2)]  // Thursday
        public void TestJune30Revolution(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.EG);
            var holiday = holidays.Single(x => x.Id == "EG-JUNE30REVOLUTION-01");

            Assert.AreEqual(holiday.ObservedDate, new DateTime(year, month, day));
        }

        [TestMethod]
        [DataRow(2021, 7, 17)]  // Saturday 17 July - Friday 23 July
        [DataRow(2022, 7, 9)]   // Saturday 09 July - Thursday 14 July
        [DataRow(2023, 6, 27)]  // Tuesday 27 June - Saturday 01 July
        [DataRow(2024, 6, 15)]  // Saturday 15 June - Thursday 20 June
        [DataRow(2025, 6, 6)]   // Friday 06 June - Monday 09 June
        [DataRow(2026, 5, 27)]  // Wednesday 27 May - Sunday 31 May
        public void TestEidAlAdha(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.EG);
            var holiday = holidays.Single(x => x.Id == "EG-EIDALADHA-01");

            Assert.AreEqual(holiday.ObservedDate, new DateTime(year, month, day));
        }

        [TestMethod]
        [DataRow(2021, 7, 24)]  // Saturday
        [DataRow(2022, 7, 23)]  // Saturday
        [DataRow(2023, 7, 23)]  // Sunday
        [DataRow(2024, 7, 25)]  // Thursday
        [DataRow(2025, 7, 24)]  // Thursday
        [DataRow(2026, 7, 23)]  // Thursday
        public void TestTheJuly23RevolutionDay(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.EG);
            var holiday = holidays.Single(x => x.Id == "EG-REVOLUTIONDAY-01");

            Assert.AreEqual(holiday.ObservedDate, new DateTime(year, month, day));
        }

        [TestMethod]
        [DataRow(2021, 8, 21)]  // Thursday
        [DataRow(2022, 7, 30)]  // Saturday
        [DataRow(2023, 7, 19)]  // Wednesday
        [DataRow(2024, 7, 11)]  // Thursday
        [DataRow(2025, 6, 26)]  // Thursday
        [DataRow(2026, 6, 18)]  // Thursday
        public void TestIslamicNewYear(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.EG);
            var holiday = holidays.Single(x => x.Id == "EG-ISLAMICNEWYEAR-01");

            Assert.AreEqual(holiday.ObservedDate, new DateTime(year, month, day));
        }

        [TestMethod]
        [DataRow(2021, 10, 7)]  // Thursday
        [DataRow(2022, 10, 6)]  // Thursday
        [DataRow(2023, 10, 6)]  // Friday
        [DataRow(2024, 10, 6)]  // Sunday
        [DataRow(2025, 10, 6)]  // Monday
        [DataRow(2026, 10, 6)]  // Tuesday
        public void TestArmedForcesDay(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.EG);
            var holiday = holidays.Single(x => x.Id == "EG-ARMEDFORCESDAY-01");

            Assert.AreEqual(holiday.ObservedDate, new DateTime(year, month, day));
        }

        [TestMethod]
        [DataRow(2021, 10, 18)] // Monday
        [DataRow(2022, 10, 8)]  // Saturday
        [DataRow(2023, 9, 27)]  // Wednesday
        [DataRow(2024, 9, 16)]  // Monday
        [DataRow(2025, 9, 4)]   // Thursday
        [DataRow(2026, 8, 26)]  // Wednesday
        public void TestProphetMuhammadsBirthday(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.EG);
            var holiday = holidays.Single(x => x.Id == "EG-PROPHETMUHAMMADSBIRTHDAY-01");

            Assert.AreEqual(holiday.ObservedDate, new DateTime(year, month, day));
        }
    }
}
