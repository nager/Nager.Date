using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class PeruTest() : BaseTest(CountryCode.PE)
    {
        [DataRow(2023, 2023, 1, 1)]
        [DataRow(2024, 2024, 1, 1)]
        [DataRow(2025, 2025, 1, 1)]
        [DataRow(2026, 2026, 1, 1)]
        [TestMethod]
        public void TestNewYearsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NEWYEARSDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 5, 1)]
        [DataRow(2022, 2022, 5, 1)]
        [DataRow(2023, 2023, 5, 1)]
        [DataRow(2024, 2024, 5, 1)]
        [DataRow(2025, 2025, 5, 1)]
        [DataRow(2026, 2026, 5, 1)]
        [DataRow(2027, 2027, 5, 1)]
        [TestMethod]
        public void TestLabourDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "LABOURDAY-01", observedYear, month, day);
        }


        [DataRow(2021, 2021, 6, 29)]
        [DataRow(2022, 2022, 6, 29)]
        [DataRow(2023, 2023, 6, 29)]
        [DataRow(2024, 2024, 6, 29)]
        [DataRow(2025, 2025, 6, 29)]
        [DataRow(2026, 2026, 6, 29)]
        [TestMethod]
        public void TestSaintPeterAndSaintPaul(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "SAINTSPETERPAUL-01", observedYear, month, day);
        }

        [DataRow(2023, 2023, 7, 23)]
        [DataRow(2024, 2024, 7, 23)]
        [DataRow(2025, 2025, 7, 23)]
        [DataRow(2026, 2026, 7, 23)]
        [TestMethod]
        public void TestAirForceDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "AIRFORCEDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 7, 28)]
        [DataRow(2022, 2022, 7, 28)]
        [DataRow(2023, 2023, 7, 28)]
        [DataRow(2024, 2024, 7, 28)]
        [DataRow(2025, 2025, 7, 28)]
        [DataRow(2026, 2026, 7, 28)]
        [TestMethod]
        public void TestIndependence01Day(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "FIESTASPATRIAS-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 7, 29)]
        [DataRow(2022, 2022, 7, 29)]
        [DataRow(2023, 2023, 7, 29)]
        [DataRow(2024, 2024, 7, 29)]
        [DataRow(2025, 2025, 7, 29)]
        [DataRow(2026, 2026, 7, 29)]
        [TestMethod]
        public void TestIndependence02Day(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "FIESTASPATRIAS-02", observedYear, month, day);
        }

        [DataRow(2022, 2022, 8, 6)]
        [DataRow(2023, 2023, 8, 6)]
        [DataRow(2024, 2024, 8, 6)]
        [DataRow(2025, 2025, 8, 6)]
        [DataRow(2026, 2026, 8, 6)]
        [TestMethod]
        public void TestBattleOfJunin(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "BATTLEOFJUNIN-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 8, 30)]
        [DataRow(2022, 2022, 8, 30)]
        [DataRow(2023, 2023, 8, 30)]
        [DataRow(2024, 2024, 8, 30)]
        [DataRow(2025, 2025, 8, 30)]
        [DataRow(2026, 2026, 8, 30)]
        [TestMethod]
        public void TestSantaRosaDeLima(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "SANTAROSADELIMA-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 10, 8)]
        [DataRow(2022, 2022, 10, 8)]
        [DataRow(2023, 2023, 10, 8)]
        [DataRow(2024, 2024, 10, 8)]
        [DataRow(2025, 2025, 10, 8)]
        [DataRow(2026, 2026, 10, 8)]
        [TestMethod]
        public void TestBattleOfAngamos(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "BATTLEOFANGAMOS-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 11, 1)]
        [DataRow(2022, 2022, 11, 1)]
        [DataRow(2023, 2023, 11, 1)]
        [DataRow(2024, 2024, 11, 1)]
        [DataRow(2025, 2025, 11, 1)]
        [DataRow(2026, 2026, 11, 1)]
        [TestMethod]
        public void TestAllSaintsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "ALLSAINTSDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 12, 8)]
        [DataRow(2022, 2022, 12, 8)]
        [DataRow(2023, 2023, 12, 8)]
        [DataRow(2024, 2024, 12, 8)]
        [DataRow(2025, 2025, 12, 8)]
        [DataRow(2026, 2026, 12, 8)]
        [TestMethod]
        public void TestImmaculateConception(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "IMMACULATECONCEPTION-01", observedYear, month, day);
        }

        [DataRow(2024, 2024, 6, 7)]
        [DataRow(2025, 2025, 6, 7)]
        [DataRow(2026, 2026, 6, 7)]
        [TestMethod]
        public void TestBattleOfAricaAndFlagDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "FLAGDAY-01", observedYear, month, day);
        }
    }
}
