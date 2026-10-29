using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class MongoliaTest() : BaseTest(CountryCode.MN)
    {
        [TestMethod]
        [DataRow(2020, 2020, 1, 1)]
        [DataRow(2021, 2021, 1, 1)]
        [DataRow(2022, 2022, 1, 1)]
        [DataRow(2023, 2023, 1, 1)]
        [DataRow(2024, 2024, 1, 1)]
        [DataRow(2025, 2025, 1, 1)]
        [DataRow(2026, 2026, 1, 1)]
        [DataRow(2027, 2027, 1, 1)]
        public void TestNewYearsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NEWYEARSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 2, 24)]
        [DataRow(2021, 2021, 2, 12)]
        [DataRow(2022, 2022, 2, 2)]
        [DataRow(2023, 2023, 2, 21)]
        [DataRow(2024, 2024, 2, 10)]
        [DataRow(2025, 2025, 3, 1)]
        [DataRow(2026, 2026, 2, 18)]
        [DataRow(2027, 2027, 2, 7)]
        public void TestTsagaanSarDay1(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "TSAGAANSAR-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 2, 25)]
        [DataRow(2021, 2021, 2, 13)]
        [DataRow(2022, 2022, 2, 3)]
        [DataRow(2023, 2023, 2, 22)]
        [DataRow(2024, 2024, 2, 11)]
        [DataRow(2025, 2025, 3, 2)]
        [DataRow(2026, 2026, 2, 19)]
        [DataRow(2027, 2027, 2, 8)]
        public void TestTsagaanSarDay2(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "TSAGAANSAR-02", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 2, 26)]
        [DataRow(2021, 2021, 2, 14)]
        [DataRow(2022, 2022, 2, 4)]
        [DataRow(2023, 2023, 2, 23)]
        [DataRow(2024, 2024, 2, 12)]
        [DataRow(2025, 2025, 3, 3)]
        [DataRow(2026, 2026, 2, 20)]
        [DataRow(2027, 2027, 2, 9)]
        public void TestTsagaanSarDay3(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "TSAGAANSAR-03", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 3, 8)]
        [DataRow(2021, 2021, 3, 8)]
        [DataRow(2022, 2022, 3, 8)]
        [DataRow(2023, 2023, 3, 8)]
        [DataRow(2024, 2024, 3, 8)]
        [DataRow(2025, 2025, 3, 8)]
        [DataRow(2026, 2026, 3, 8)]
        [DataRow(2027, 2027, 3, 8)]
        public void TestInternationalWomensDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "INTERNATIONALWOMENSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 6, 5)]
        [DataRow(2021, 2021, 5, 26)]
        [DataRow(2022, 2022, 6, 14)]
        [DataRow(2023, 2023, 6, 4)]
        [DataRow(2024, 2024, 5, 23)]
        [DataRow(2025, 2025, 6, 11)]
        [DataRow(2026, 2026, 5, 31)]
        [DataRow(2027, 2027, 5, 20)]
        public void TestBuddhaDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "BUDDHADAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 6, 1)]
        [DataRow(2021, 2021, 6, 1)]
        [DataRow(2022, 2022, 6, 1)]
        [DataRow(2023, 2023, 6, 1)]
        [DataRow(2024, 2024, 6, 1)]
        [DataRow(2025, 2025, 6, 1)]
        [DataRow(2026, 2026, 6, 1)]
        [DataRow(2027, 2027, 6, 1)]
        public void TestChildrensDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CHILDRENSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2022, 2022, 7, 10)]
        [DataRow(2023, 2023, 7, 10)]
        [DataRow(2024, 2024, 7, 10)]
        [DataRow(2025, 2025, 7, 10)]
        [DataRow(2026, 2026, 7, 10)]
        [DataRow(2027, 2027, 7, 10)]
        public void TestNaadamJuly10(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NAADAM-06", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 7, 11)]
        [DataRow(2021, 2021, 7, 11)]
        [DataRow(2022, 2022, 7, 11)]
        [DataRow(2023, 2023, 7, 11)]
        [DataRow(2024, 2024, 7, 11)]
        [DataRow(2025, 2025, 7, 11)]
        [DataRow(2026, 2026, 7, 11)]
        [DataRow(2027, 2027, 7, 11)]
        public void TestNaadamDay1(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NAADAM-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 7, 12)]
        [DataRow(2021, 2021, 7, 12)]
        [DataRow(2022, 2022, 7, 12)]
        [DataRow(2023, 2023, 7, 12)]
        [DataRow(2024, 2024, 7, 12)]
        [DataRow(2025, 2025, 7, 12)]
        [DataRow(2026, 2026, 7, 12)]
        [DataRow(2027, 2027, 7, 12)]
        public void TestNaadamDay2(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NAADAM-02", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 7, 13)]
        [DataRow(2021, 2021, 7, 13)]
        [DataRow(2022, 2022, 7, 13)]
        [DataRow(2023, 2023, 7, 13)]
        [DataRow(2024, 2024, 7, 13)]
        [DataRow(2025, 2025, 7, 13)]
        [DataRow(2026, 2026, 7, 13)]
        [DataRow(2027, 2027, 7, 13)]
        public void TestNaadamDay3(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NAADAM-03", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 7, 14)]
        [DataRow(2021, 2021, 7, 14)]
        [DataRow(2022, 2022, 7, 14)]
        [DataRow(2023, 2023, 7, 14)]
        [DataRow(2024, 2024, 7, 14)]
        [DataRow(2025, 2025, 7, 14)]
        [DataRow(2026, 2026, 7, 14)]
        [DataRow(2027, 2027, 7, 14)]
        public void TestNaadamDay4(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NAADAM-04", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 7, 15)]
        [DataRow(2021, 2021, 7, 15)]
        [DataRow(2022, 2022, 7, 15)]
        [DataRow(2023, 2023, 7, 15)]
        [DataRow(2024, 2024, 7, 15)]
        [DataRow(2025, 2025, 7, 15)]
        [DataRow(2026, 2026, 7, 15)]
        [DataRow(2027, 2027, 7, 15)]
        public void TestNaadamDay5(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NAADAM-05", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 11, 16)]
        [DataRow(2021, 2021, 11, 5)]
        [DataRow(2022, 2022, 11, 24)]
        [DataRow(2023, 2023, 11, 14)]
        [DataRow(2024, 2024, 11, 2)]
        [DataRow(2025, 2025, 11, 21)]
        [DataRow(2026, 2026, 11, 10)]
        [DataRow(2027, 2027, 11, 29)]
        public void TestChinggisKhaansBirthday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CHINGGISKHAANSBIRTHDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 11, 26)]
        [DataRow(2021, 2021, 11, 26)]
        [DataRow(2022, 2022, 11, 26)]
        [DataRow(2023, 2023, 11, 26)]
        [DataRow(2024, 2024, 11, 26)]
        [DataRow(2025, 2025, 11, 26)]
        [DataRow(2026, 2026, 11, 26)]
        [DataRow(2027, 2027, 11, 26)]
        public void TestRepublicDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "REPUBLICDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2020, 2020, 12, 29)]
        [DataRow(2021, 2021, 12, 29)]
        [DataRow(2022, 2022, 12, 29)]
        [DataRow(2023, 2023, 12, 29)]
        [DataRow(2024, 2024, 12, 29)]
        [DataRow(2025, 2025, 12, 29)]
        [DataRow(2026, 2026, 12, 29)]
        [DataRow(2027, 2027, 12, 29)]
        public void TestIndependenceDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "INDEPENDENCEDAY-01", observedYear, month, day);
        }
    }
}
