using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    /*
     * Sources
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
        [DataRow(2023, 1, 26)] // 25 is Wednesday
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
        [DataRow(2021, 4, 29)] // 25 is Sunday
        [DataRow(2022, 4, 25)] // 25 is Monday
        [DataRow(2023, 4, 25)] // 25 is Tuesday
        [DataRow(2024, 4, 25)] // 25 is Thursday
        [DataRow(2025, 4, 24)] // 25 is Friday (Weekend)
        [DataRow(2026, 1, 25)] // 25 is Saturday (Weekend)
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
        public void TestLaborDay(int year, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.EG);
            var holiday = holidays.Single(x => x.Id == "EG-LABOURDAY-01");

            Assert.AreEqual(holiday.ObservedDate, new DateTime(year, month, day));
        }
    }
}
