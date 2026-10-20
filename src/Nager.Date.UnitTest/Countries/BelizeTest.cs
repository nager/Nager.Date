using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class BelizeTest() : BaseTest(CountryCode.BZ)
    {
        [DataRow(2020, 2020, 1, 1)]
        [DataRow(2021, 2021, 1, 1)]
        [DataRow(2022, 2022, 1, 1)]
        [DataRow(2023, 2023, 1, 2)]
        [DataRow(2024, 2024, 1, 1)]
        [DataRow(2025, 2025, 1, 1)]
        [DataRow(2026, 2026, 1, 1)]
        [TestMethod]
        public void TestNewYearsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NEWYEARSDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 1, 15)]
        [DataRow(2022, 2022, 1, 15)]
        [DataRow(2023, 2023, 1, 16)]
        [DataRow(2024, 2024, 1, 15)]
        [DataRow(2025, 2025, 1, 15)]
        [DataRow(2026, 2026, 1, 15)]
        [TestMethod]
        public void TestGeorgePriceDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "GEORGEPRICEDAY-01", observedYear, month, day);
        }

        [DataRow(2020, 2020, 3, 9)]
        [DataRow(2021, 2021, 3, 8)]
        [DataRow(2022, 2022, 3, 7)]
        [DataRow(2023, 2023, 3, 6)]
        [DataRow(2024, 2024, 3, 11)]
        [DataRow(2025, 2025, 3, 10)]
        [DataRow(2026, 2026, 3, 9)]
        [TestMethod]
        public void TestNationalHeroesDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NATIONALHEROESDAY-01", observedYear, month, day);
        }

        [DataRow(2020, 2020, 5, 1)]
        [DataRow(2021, 2021, 5, 1)]
        [DataRow(2022, 2022, 5, 2)]
        [DataRow(2023, 2023, 5, 1)]
        [DataRow(2024, 2024, 4, 29)]
        [DataRow(2025, 2025, 5, 1)]
        [DataRow(2026, 2026, 5, 1)]
        [TestMethod]
        public void TestLabourDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "LABOURDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 8, 2)]
        [DataRow(2022, 2022, 8, 1)]
        [DataRow(2023, 2023, 7, 31)]
        [DataRow(2024, 2024, 8, 1)]
        [DataRow(2025, 2025, 8, 1)]
        [DataRow(2026, 2026, 8, 1)]
        [TestMethod]
        public void TestEmancipationDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "EMANCIPATIONDAY-01", observedYear, month, day);
        }

        [DataRow(2020, 2020, 9, 10)]
        [DataRow(2021, 2021, 9, 10)]
        [DataRow(2022, 2022, 9, 10)]
        [DataRow(2023, 2023, 9, 11)]
        [DataRow(2024, 2024, 9, 10)]
        [DataRow(2025, 2025, 9, 10)]
        [DataRow(2026, 2026, 9, 10)]
        [TestMethod]
        public void TestSaintGeorgesCayeDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "SAINTGEORGESCAYEDAY-01", observedYear, month, day);
        }

        [DataRow(2020, 2020, 9, 21)]
        [DataRow(2021, 2021, 9, 21)]
        [DataRow(2022, 2022, 9, 21)]
        [DataRow(2023, 2023, 9, 21)]
        [DataRow(2024, 2024, 9, 21)]
        [DataRow(2025, 2025, 9, 22)]
        [DataRow(2026, 2026, 9, 21)]
        [TestMethod]
        public void TestIndependenceDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "INDEPENDENCEDAY-01", observedYear, month, day);
        }

        [DataRow(2021, 2021, 11, 19)]
        [DataRow(2022, 2022, 11, 19)]
        [DataRow(2023, 2023, 11, 20)]
        [DataRow(2024, 2024, 11, 19)]
        [DataRow(2025, 2025, 11, 19)]
        [DataRow(2026, 2026, 11, 19)]
        [TestMethod]
        public void TestGarifunaSettlementDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "GARIFUNASETTLEMENTDAY-01", observedYear, month, day);
        }

        [DataRow(2020, 2020, 12, 25)]
        [DataRow(2021, 2021, 12, 25)]
        [DataRow(2022, 2022, 12, 25)]
        [DataRow(2023, 2023, 12, 25)]
        [DataRow(2024, 2024, 12, 25)]
        [DataRow(2025, 2025, 12, 25)]
        [DataRow(2026, 2026, 12, 25)]
        [TestMethod]
        public void TestChristmasDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CHRISTMASDAY-01", observedYear, month, day);
        }

        [DataRow(2020, 2020, 12, 28)]
        [DataRow(2021, 2021, 12, 27)]
        [DataRow(2022, 2022, 12, 26)]
        [DataRow(2023, 2023, 12, 26)]
        [DataRow(2024, 2024, 12, 26)]
        [DataRow(2025, 2025, 12, 26)]
        [DataRow(2026, 2026, 12, 26)]
        [TestMethod]
        public void TestBoxingDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "BOXINGDAY-01", observedYear, month, day);
        }

        [DataRow(2020, 2020, 5, 25)]
        [TestMethod]
        public void TestCommonwealthDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "COMMONWEALTHDAY-01", observedYear, month, day);
        }

        [DataRow(2020, 2020, 10, 12)]
        [TestMethod]
        public void TestPanAmericanDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "DAYOFTHEAMERICAS-01", observedYear, month, day);
        }

        [DataRow(2022, 2022, 10, 10)]
        [DataRow(2023, 2023, 10, 9)]
        [DataRow(2024, 2024, 10, 14)]
        [DataRow(2025, 2025, 10, 13)]
        [DataRow(2026, 2026, 10, 12)]
        [TestMethod]
        public void TestIndigenousPeoplesResistanceDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "INDIGENOUSPEOPLESRESISTANCEDAY-01", observedYear, month, day);
        }
    }
}
