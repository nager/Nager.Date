using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class ElSalvadorTest() : BaseTest(CountryCode.SV)
    {
        [TestMethod]
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
        [DataRow(2021, 2021, 4, 1)]
        [DataRow(2022, 2022, 4, 14)]
        [DataRow(2023, 2023, 4, 6)]
        [DataRow(2024, 2024, 3, 28)]
        [DataRow(2025, 2025, 4, 17)]
        [DataRow(2026, 2026, 4, 2)]
        [DataRow(2027, 2027, 3, 25)]
        public void TestMaundyThursday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "MAUNDYTHURSDAY-01", observedYear, month, day);
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
            this.AssertObservedDate(year, "GOODFRIDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 4, 3)]
        [DataRow(2022, 2022, 4, 16)]
        [DataRow(2023, 2023, 4, 8)]
        [DataRow(2024, 2024, 3, 30)]
        [DataRow(2025, 2025, 4, 19)]
        [DataRow(2026, 2026, 4, 4)]
        [DataRow(2027, 2027, 3, 27)]
        public void TestEasterSaturday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CHOLYSATURDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 5, 1)]
        [DataRow(2022, 2022, 5, 1)]
        [DataRow(2023, 2023, 5, 1)]
        [DataRow(2024, 2024, 5, 1)]
        [DataRow(2025, 2025, 5, 1)]
        [DataRow(2026, 2026, 5, 1)]
        [DataRow(2027, 2027, 5, 1)]
        public void TestLabourDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "LABOURDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 8, 3)]
        [DataRow(2022, 2022, 8, 3)]
        [DataRow(2023, 2023, 8, 3)]
        [DataRow(2024, 2024, 8, 3)]
        [DataRow(2025, 2025, 8, 3)]
        [DataRow(2026, 2026, 8, 3)]
        [DataRow(2027, 2027, 8, 3)]
        public void TestAugustFestivalsFirstDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "AUGUSTFESTIVALS-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 8, 5)]
        [DataRow(2022, 2022, 8, 5)]
        [DataRow(2023, 2023, 8, 5)]
        [DataRow(2024, 2024, 8, 5)]
        [DataRow(2025, 2025, 8, 5)]
        [DataRow(2026, 2026, 8, 5)]
        [DataRow(2027, 2027, 8, 5)]
        public void TestAugustFestivalsSecondDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "AUGUSTFESTIVALS-02", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 8, 6)]
        [DataRow(2022, 2022, 8, 6)]
        [DataRow(2023, 2023, 8, 6)]
        [DataRow(2024, 2024, 8, 6)]
        [DataRow(2025, 2025, 8, 6)]
        [DataRow(2026, 2026, 8, 6)]
        [DataRow(2027, 2027, 8, 6)]
        public void TestDivineSaviour(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "DIVINESAVIOUR-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 9, 15)]
        [DataRow(2022, 2022, 9, 15)]
        [DataRow(2023, 2023, 9, 15)]
        [DataRow(2024, 2024, 9, 15)]
        [DataRow(2025, 2025, 9, 15)]
        [DataRow(2026, 2026, 9, 15)]
        [DataRow(2027, 2027, 9, 15)]
        public void TestIndependenceDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "INDEPENDENCEDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 11, 2)]
        [DataRow(2022, 2022, 11, 2)]
        [DataRow(2023, 2023, 11, 2)]
        [DataRow(2024, 2024, 11, 2)]
        [DataRow(2025, 2025, 11, 2)]
        [DataRow(2026, 2026, 11, 2)]
        [DataRow(2027, 2027, 11, 2)]
        public void TestAllSoulsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "ALLSOULSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 12, 25)]
        [DataRow(2022, 2022, 12, 25)]
        [DataRow(2023, 2023, 12, 25)]
        [DataRow(2024, 2024, 12, 25)]
        [DataRow(2025, 2025, 12, 25)]
        [DataRow(2026, 2026, 12, 25)]
        [DataRow(2027, 2027, 12, 25)]
        public void TestChristmasDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CHRISTMASDAY-01", observedYear, month, day);
        }
    }
}
