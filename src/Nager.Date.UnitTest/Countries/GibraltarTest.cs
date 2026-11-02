using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class GibraltarTest() : BaseTest(CountryCode.GI)
    {
        [TestMethod]
        [DataRow(2020, 2020, 1, 1)]
        [DataRow(2021, 2021, 1, 1)]
        [DataRow(2022, 2022, 1, 3)] // in lieu of Saturday 1st January
        [DataRow(2023, 2023, 1, 2)] // in lieu of Sunday 1st January
        [DataRow(2024, 2024, 1, 1)]
        [DataRow(2025, 2025, 1, 1)]
        [DataRow(2026, 2026, 1, 1)]
        public void TestNewYearsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NEWYEARSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 3, 9)]
        [DataRow(2021, 2021, 2, 15)]
        public void TestCommonwealthDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "COMMONWEALTHDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2022, 2022, 2, 21)]
        [DataRow(2023, 2023, 2, 20)]
        [DataRow(2024, 2024, 2, 12)]
        [DataRow(2025, 2025, 2, 17)]
        [DataRow(2026, 2026, 2, 16)]
        public void TestWinterMidtermBankHoliday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "WINTERMIDTERMBANKHOLIDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 4, 10)]
        [DataRow(2021, 2021, 4, 2)]
        [DataRow(2022, 2022, 4, 15)]
        [DataRow(2023, 2023, 4, 7)]
        [DataRow(2024, 2024, 3, 29)]
        [DataRow(2025, 2025, 4, 18)]
        [DataRow(2026, 2026, 4, 3)]
        public void TestGoodFriday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "GOODFRIDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 4, 13)]
        [DataRow(2021, 2021, 4, 5)]
        [DataRow(2022, 2022, 4, 18)]
        [DataRow(2023, 2023, 4, 10)]
        [DataRow(2024, 2024, 4, 1)]
        [DataRow(2025, 2025, 4, 21)]
        [DataRow(2026, 2026, 4, 6)]
        public void TestEasterMonday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "EASTERMONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 4, 28)]
        [DataRow(2021, 2021, 4, 28)]
        [DataRow(2022, 2022, 4, 28)]
        [DataRow(2023, 2023, 4, 28)]
        [DataRow(2024, 2024, 4, 29)] // in lieu of Sunday 28th April
        [DataRow(2025, 2025, 4, 28)]
        [DataRow(2026, 2026, 4, 28)]
        public void TestWorkersMemorialDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "WORKERSMEMORIALDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 5, 1)]
        [DataRow(2021, 2021, 5, 3)] // in lieu of Saturday 1st May
        [DataRow(2022, 2022, 5, 2)] // in lieu of Sunday 1st May
        [DataRow(2023, 2023, 5, 1)]
        [DataRow(2024, 2024, 5, 1)]
        [DataRow(2025, 2025, 5, 1)]
        [DataRow(2026, 2026, 5, 1)]
        public void TestMayDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "MAYDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 5, 8)]
        public void TestVEDay75thAnniversary(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "VEDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2023, 2023, 5, 8)]
        public void TestKingsCoronationBankHoliday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CORONATIONBANKHOLIDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 5, 25)]
        [DataRow(2021, 2021, 5, 31)]
        [DataRow(2022, 2022, 6, 2)] // moved for Platinum Jubilee
        [DataRow(2023, 2023, 5, 29)]
        [DataRow(2024, 2024, 5, 27)]
        [DataRow(2025, 2025, 5, 26)]
        [DataRow(2026, 2026, 5, 25)]
        public void TestSpringBankHoliday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "SPRINGBANKHOLIDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2022, 2022, 6, 3)]
        public void TestPlatinumJubilee(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "PLATINUMJUBILEE-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 6, 15)] // Queen's Birthday
        [DataRow(2021, 2021, 6, 14)] // Queen's Birthday
        [DataRow(2022, 2022, 6, 13)] // Queen's Birthday
        [DataRow(2023, 2023, 6, 19)]
        [DataRow(2024, 2024, 6, 17)]
        [DataRow(2025, 2025, 6, 16)]
        [DataRow(2026, 2026, 6, 15)]
        public void TestMonarchBirthday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "MONARCHBIRTHDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 8, 31)]
        [DataRow(2021, 2021, 8, 30)]
        [DataRow(2022, 2022, 8, 29)]
        [DataRow(2023, 2023, 8, 28)]
        [DataRow(2024, 2024, 8, 26)]
        [DataRow(2025, 2025, 8, 25)]
        [DataRow(2026, 2026, 8, 31)]
        public void TestLateSummerBankHoliday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "SUMMERBANKHOLIDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 9, 10)]
        [DataRow(2021, 2021, 9, 10)]
        [DataRow(2022, 2022, 9, 12)] // in lieu of Saturday 10th September
        [DataRow(2023, 2023, 9, 11)] // in lieu of Sunday 10th September
        [DataRow(2024, 2024, 9, 10)]
        [DataRow(2025, 2025, 9, 10)]
        [DataRow(2026, 2026, 9, 10)]
        public void TestGibraltarNationalDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NATIONALDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 12, 25)]
        [DataRow(2021, 2021, 12, 27)] // in lieu of Saturday 25th December
        [DataRow(2022, 2022, 12, 26)] // in lieu of Sunday 25th December
        [DataRow(2023, 2023, 12, 25)]
        [DataRow(2024, 2024, 12, 25)]
        [DataRow(2025, 2025, 12, 25)]
        [DataRow(2026, 2026, 12, 25)]
        public void TestChristmasDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CHRISTMASDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 12, 28)] // in lieu of Saturday 26th December
        [DataRow(2021, 2021, 12, 28)] // in lieu of Sunday 26th December
        [DataRow(2022, 2022, 12, 27)] // in lieu of Monday 26th December
        [DataRow(2023, 2023, 12, 26)]
        [DataRow(2024, 2024, 12, 26)]
        [DataRow(2025, 2025, 12, 26)]
        [DataRow(2026, 2026, 12, 28)] // in lieu of Saturday 26th December
        public void TestBoxingDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "BOXINGDAY-01", observedYear, month, day);
        }
    }
}
