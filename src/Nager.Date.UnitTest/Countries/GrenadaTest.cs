using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class GrenadaTest() : BaseTest(CountryCode.GD)
    {
        [TestMethod]
        [DataRow(2023, 2023, 1, 2)]
        [DataRow(2025, 2025, 1, 1)]
        [DataRow(2026, 2026, 1, 1)]
        public void TestNewYearsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NEWYEARSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2023, 2023, 2, 7)]
        [DataRow(2025, 2025, 2, 7)]
        [DataRow(2026, 2026, 2, 7)]
        public void TestIndependenceDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "INDEPENDENCEDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2023, 2023, 4, 7)]
        [DataRow(2025, 2025, 4, 18)]
        [DataRow(2026, 2026, 4, 3)]
        public void TestGoodFriday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "GOODFRIDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2023, 2023, 4, 10)]
        [DataRow(2025, 2025, 4, 21)]
        [DataRow(2026, 2026, 4, 6)]
        public void TestEasterMonday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "EASTERMONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2023, 2023, 5, 1)]
        [DataRow(2025, 2025, 5, 1)]
        [DataRow(2026, 2026, 5, 1)]
        public void TestLabourDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "LABOURDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2023, 2023, 5, 29)]
        [DataRow(2025, 2025, 6, 9)]
        [DataRow(2026, 2026, 5, 25)]
        public void TestWhitMonday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "WHITMONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2023, 2023, 6, 8)]
        [DataRow(2025, 2025, 6, 19)]
        [DataRow(2026, 2026, 6, 4)]
        public void TestCorpusChristi(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CORPUSCHRISTI-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2023, 2023, 8, 7)]
        [DataRow(2025, 2025, 8, 1)]
        [DataRow(2026, 2026, 8, 1)]
        public void TestEmancipationDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "EMANCIPATIONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2023, 2023, 8, 14)]
        [DataRow(2025, 2025, 8, 11)]
        [DataRow(2026, 2026, 8, 10)]
        public void TestCarnivalMonday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CARNIVALMONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2023, 2023, 8, 15)]
        [DataRow(2025, 2025, 8, 12)]
        [DataRow(2026, 2026, 8, 11)]
        public void TestCarnivalTuesday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CARNIVALTUESDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2025, 2025, 10, 20)]
        [DataRow(2026, 2026, 10, 19)]
        public void TestNationalHeroesDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NATIONALHEROESDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2023, 2023, 10, 25)]
        [DataRow(2025, 2025, 10, 25)]
        [DataRow(2026, 2026, 10, 26)]
        public void TestThanksgivingDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "THANKSGIVINGDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2023, 2023, 12, 25)]
        [DataRow(2025, 2025, 12, 25)]
        [DataRow(2026, 2026, 12, 25)]
        public void TestChristmasDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CHRISTMASDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2023, 2023, 12, 26)]
        [DataRow(2025, 2025, 12, 26)]
        [DataRow(2026, 2026, 12, 26)]
        public void TestBoxingDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "BOXINGDAY-01", observedYear, month, day);
        }
    }
}
