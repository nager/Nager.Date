using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class DominicaTest() : BaseTest(CountryCode.DM)
    {
        [TestMethod]
        [DataRow(2021, 2021, 1, 1)]
        [DataRow(2022, 2022, 1, 1)]
        [DataRow(2023, 2023, 1, 2)] // in lieu of Sunday 1st January
        [DataRow(2024, 2024, 1, 1)]
        [DataRow(2025, 2025, 1, 1)]
        [DataRow(2026, 2026, 1, 1)]
        [DataRow(2027, 2027, 1, 1)]
        public void TestNewYearsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NEWYEARSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 2, 15)]
        [DataRow(2022, 2022, 2, 28)]
        [DataRow(2023, 2023, 2, 20)]
        [DataRow(2024, 2024, 2, 12)]
        [DataRow(2025, 2025, 3, 3)]
        [DataRow(2026, 2026, 2, 16)]
        [DataRow(2027, 2027, 2, 8)]
        public void TestCarnivalMonday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CARNIVAL-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 2, 16)]
        [DataRow(2022, 2022, 3, 1)]
        [DataRow(2023, 2023, 2, 21)]
        [DataRow(2024, 2024, 2, 13)]
        [DataRow(2025, 2025, 3, 4)]
        [DataRow(2026, 2026, 2, 17)]
        [DataRow(2027, 2027, 2, 9)]
        public void TestCarnivalTuesday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CARNIVAL-02", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 4, 2)]
        [DataRow(2022, 2022, 4, 15)]
        [DataRow(2023, 2023, 4, 7)]
        [DataRow(2024, 2024, 3, 29)]
        [DataRow(2025, 2025, 4, 18)]
        [DataRow(2026, 2026, 4, 3)]
        [DataRow(2027, 2027, 3, 26)]
        public void TestGoodFriday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CGOODFRIDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 4, 5)]
        [DataRow(2022, 2022, 4, 18)]
        [DataRow(2023, 2023, 4, 10)]
        [DataRow(2024, 2024, 4, 1)]
        [DataRow(2025, 2025, 4, 21)]
        [DataRow(2026, 2026, 4, 6)]
        [DataRow(2027, 2027, 3, 29)]
        public void TestEasterMonday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CEASTERMONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 5, 3)]
        [DataRow(2022, 2022, 5, 2)]
        [DataRow(2023, 2023, 5, 1)]
        [DataRow(2024, 2024, 5, 6)]
        [DataRow(2025, 2025, 5, 5)]
        [DataRow(2026, 2026, 5, 4)]
        [DataRow(2027, 2027, 5, 3)]
        public void TestLabourDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "LABOURDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 5, 24)]
        [DataRow(2022, 2022, 6, 6)]
        [DataRow(2023, 2023, 5, 29)]
        [DataRow(2024, 2024, 5, 20)]
        [DataRow(2025, 2025, 6, 9)]
        [DataRow(2026, 2026, 5, 25)]
        [DataRow(2027, 2027, 5, 17)]
        public void TestWhitMonday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CWHITMONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 8, 2)]
        [DataRow(2022, 2022, 8, 1)]
        [DataRow(2023, 2023, 8, 7)]
        [DataRow(2024, 2024, 8, 5)]
        [DataRow(2025, 2025, 8, 4)]
        [DataRow(2026, 2026, 8, 3)]
        [DataRow(2027, 2027, 8, 2)]
        public void TestEmancipationDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "EMANCIPATIONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 11, 3)]
        [DataRow(2022, 2022, 11, 3)]
        [DataRow(2023, 2023, 11, 3)]
        [DataRow(2024, 2024, 11, 4)] // in lieu of Sunday 3rd November
        [DataRow(2025, 2025, 11, 3)]
        [DataRow(2026, 2026, 11, 3)]
        [DataRow(2027, 2027, 11, 3)]
        public void TestIndependenceDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "INDEPENDENCEDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 11, 4)]
        [DataRow(2022, 2022, 11, 4)]
        [DataRow(2023, 2023, 11, 4)]
        [DataRow(2024, 2024, 11, 5)] // Independence Day observed on Monday 4th November
        [DataRow(2025, 2025, 11, 4)]
        [DataRow(2026, 2026, 11, 4)]
        [DataRow(2027, 2027, 11, 4)]
        public void TestNationalDayOfCommunityService(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "COMMUNITYSERVICEDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 12, 25)]
        [DataRow(2022, 2022, 12, 26)] // in lieu of Sunday 25th December
        [DataRow(2023, 2023, 12, 25)]
        [DataRow(2024, 2024, 12, 25)]
        [DataRow(2025, 2025, 12, 25)]
        [DataRow(2026, 2026, 12, 25)]
        [DataRow(2027, 2027, 12, 25)]
        public void TestChristmasDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CHRISTMASDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 12, 27)] // in lieu of Sunday 26th December
        [DataRow(2022, 2022, 12, 27)] // Christmas Day observed on Monday 26th December
        [DataRow(2023, 2023, 12, 26)]
        [DataRow(2024, 2024, 12, 26)]
        [DataRow(2025, 2025, 12, 26)]
        [DataRow(2026, 2026, 12, 26)]
        [DataRow(2027, 2027, 12, 27)] // in lieu of Sunday 26th December
        public void TestBoxingDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "STSTEPHENSDAY-01", observedYear, month, day);
        }
    }
}
