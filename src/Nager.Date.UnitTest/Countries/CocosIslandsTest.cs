using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class CocosIslandsTest() : BaseTest(CountryCode.CC)
    {
        [TestMethod]
        [DataRow(2021, 2021, 1, 1)]
        [DataRow(2023, 2023, 1, 2)]
        [DataRow(2024, 2024, 1, 1)]
        [DataRow(2025, 2025, 1, 1)]
        [DataRow(2026, 2026, 1, 1)]
        [DataRow(2027, 2027, 1, 1)]
        public void TestNewYearsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NEWYEARSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 1, 26)]
        [DataRow(2023, 2023, 1, 26)]
        [DataRow(2024, 2024, 1, 26)]
        [DataRow(2025, 2025, 1, 27)]
        [DataRow(2026, 2026, 1, 26)]
        [DataRow(2027, 2027, 1, 26)]
        public void TestAustraliaDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "AUSTRALIADAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 4, 2)]
        [DataRow(2023, 2023, 4, 7)]
        [DataRow(2024, 2024, 3, 29)]
        [DataRow(2025, 2025, 4, 18)]
        [DataRow(2026, 2026, 4, 3)]
        [DataRow(2027, 2027, 3, 26)]
        public void TestGoodFriday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "GOODFRIDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 4, 5)]
        [DataRow(2023, 2023, 4, 10)]
        [DataRow(2024, 2024, 4, 1)]
        [DataRow(2025, 2025, 4, 21)]
        [DataRow(2026, 2026, 4, 6)]
        [DataRow(2027, 2027, 3, 29)]
        public void TestEasterMonday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "EASTERMONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 4, 6)]
        [DataRow(2023, 2023, 4, 6)]
        [DataRow(2024, 2024, 4, 8)]
        [DataRow(2025, 2025, 4, 7)]
        [DataRow(2026, 2026, 4, 7)]
        [DataRow(2027, 2027, 4, 6)]
        public void TestActOfSelfDeterminationDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "SELFDETERMINATIONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 4, 26)]
        [DataRow(2023, 2023, 4, 25)]
        [DataRow(2024, 2024, 4, 25)]
        [DataRow(2025, 2025, 4, 25)]
        [DataRow(2026, 2026, 4, 27)]
        [DataRow(2027, 2027, 4, 26)]
        public void TestAnzacDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "ANZACDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 6, 7)]
        [DataRow(2023, 2023, 6, 6)]
        [DataRow(2024, 2024, 6, 6)]
        [DataRow(2025, 2025, 6, 9)]
        [DataRow(2026, 2026, 6, 8)]
        [DataRow(2027, 2027, 6, 7)]
        public void TestMonarchBirthday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "MONARCHBIRTHDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 12, 27)]
        [DataRow(2023, 2023, 12, 25)]
        [DataRow(2024, 2024, 12, 25)]
        [DataRow(2025, 2025, 12, 25)]
        [DataRow(2026, 2026, 12, 25)]
        [DataRow(2027, 2027, 12, 27)]
        public void TestChristmasDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CHRISTMASDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 12, 28)]
        [DataRow(2023, 2023, 12, 26)]
        [DataRow(2024, 2024, 12, 26)]
        [DataRow(2025, 2025, 12, 26)]
        [DataRow(2026, 2026, 12, 28)]
        [DataRow(2027, 2027, 12, 28)]
        public void TestStStephensDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "STSTEPHENSDAY-01", observedYear, month, day);
        }

        //[TestMethod]
        //[DataRow(2021, 2021, 5, 13)]
        //[DataRow(2026, 2026, 3, 20)]
        //[DataRow(2027, 2027, 3, 9)]
        //public void TestHariRayaPuasa(int year, int observedYear, int month, int day)
        //{
        //    this.AssertObservedDate(year, "HARIRAYAPUASA-01", observedYear, month, day);
        //}

        //[TestMethod]
        //[DataRow(2021, 2021, 7, 20)]
        //[DataRow(2026, 2026, 5, 27)]
        //[DataRow(2027, 2027, 5, 17)]
        //public void TestHariRayaHaji(int year, int observedYear, int month, int day)
        //{
        //    this.AssertObservedDate(year, "HARIRAYAHAJI-01", observedYear, month, day);
        //}

        //[TestMethod]
        //[DataRow(2021, 2021, 10, 19)]
        //[DataRow(2026, 2026, 8, 26)]
        //[DataRow(2027, 2027, 8, 16)]
        //public void TestHariMaulaudNabi(int year, int observedYear, int month, int day)
        //{
        //    this.AssertObservedDate(year, "HARIMAULAUDNABI-01", observedYear, month, day);
        //}
    }
}
