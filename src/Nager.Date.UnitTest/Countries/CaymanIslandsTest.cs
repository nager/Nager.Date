using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class CaymanIslandsTest() : BaseTest(CountryCode.KY)
    {
        [TestMethod]
        [DataRow(2021, 2021, 1, 1)]
        [DataRow(2022, 2022, 1, 3)]
        [DataRow(2023, 2023, 1, 2)]
        [DataRow(2024, 2024, 1, 1)]
        [DataRow(2025, 2025, 1, 1)]
        [DataRow(2026, 2026, 1, 1)]
        public void TestNewYearsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NEWYEARSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 1, 25)]
        [DataRow(2022, 2022, 1, 24)]
        [DataRow(2023, 2023, 1, 23)]
        [DataRow(2024, 2024, 1, 22)]
        [DataRow(2025, 2025, 1, 27)]
        [DataRow(2026, 2026, 1, 26)]
        public void TestNationalHeroesDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NATIONALHEROESDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 2, 17)]
        [DataRow(2022, 2022, 3, 2)]
        [DataRow(2023, 2023, 2, 22)]
        [DataRow(2024, 2024, 2, 14)]
        [DataRow(2025, 2025, 3, 5)]
        [DataRow(2026, 2026, 2, 18)]
        public void TestAshWednesday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "ASHWEDNESDAY-01", observedYear, month, day);
        }

        [TestMethod]
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
        [DataRow(2021, 2021, 4, 14)]
        [DataRow(2025, 2025, 4, 30)]
        public void TestGeneralElectionDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "GENERALELECTIONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2024, 2024, 5, 6)]
        [DataRow(2025, 2025, 5, 5)]
        [DataRow(2026, 2026, 5, 4)]
        public void TestEmancipationDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "EMANCIPATIONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2023, 2023, 5, 8)]
        public void TestCoronationDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CORONATIONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2022, 2022, 6, 3)]
        public void TestPlatinumJubilee(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "PLATINUMJUBILEE-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 5, 17)]
        [DataRow(2022, 2022, 5, 16)]
        [DataRow(2023, 2023, 5, 15)]
        [DataRow(2024, 2024, 5, 20)]
        [DataRow(2025, 2025, 5, 19)]
        [DataRow(2026, 2026, 5, 18)]
        public void TestDiscoveryDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "DISCOVERYDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 6, 14)]
        [DataRow(2022, 2022, 6, 6)]
        [DataRow(2023, 2023, 6, 19)]
        [DataRow(2024, 2024, 6, 17)]
        [DataRow(2025, 2025, 6, 23)]
        [DataRow(2026, 2026, 6, 15)]
        public void TestMonarchBirthday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "MONARCHBIRTHDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 7, 5)]
        [DataRow(2022, 2022, 7, 4)]
        [DataRow(2023, 2023, 7, 3)]
        [DataRow(2024, 2024, 7, 1)]
        [DataRow(2025, 2025, 7, 7)]
        [DataRow(2026, 2026, 7, 6)]
        public void TestConstitutionDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CONSTITUTIONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 11, 15)]
        [DataRow(2022, 2022, 11, 14)]
        [DataRow(2023, 2023, 11, 13)]
        [DataRow(2024, 2024, 11, 11)]
        [DataRow(2025, 2025, 11, 10)]
        [DataRow(2026, 2026, 11, 9)]
        public void TestRemembranceDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "REMEMBRANCEDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 12, 27)]
        [DataRow(2022, 2022, 12, 26)]
        [DataRow(2023, 2023, 12, 25)]
        [DataRow(2024, 2024, 12, 25)]
        [DataRow(2025, 2025, 12, 25)]
        [DataRow(2026, 2026, 12, 25)]
        public void TestChristmasDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CHRISTMASDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 12, 28)]
        [DataRow(2022, 2022, 12, 27)]
        [DataRow(2023, 2023, 12, 26)]
        [DataRow(2024, 2024, 12, 26)]
        [DataRow(2025, 2025, 12, 26)]
        [DataRow(2026, 2026, 12, 28)]
        public void TestBoxingDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "STSTEPHENSDAY-01", observedYear, month, day);
        }
    }
}
