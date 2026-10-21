using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class PanamaTest() : BaseTest(CountryCode.PA)
    {
        [DataRow(2026, 2026, 1, 1)]
        [TestMethod]
        public void TestNewYearsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NEWYEARSDAY-01", observedYear, month, day);
        }

        [DataRow(2026, 2026, 1, 9)]
        [TestMethod]
        public void TestMartyrsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "MARTYRSDAY-01", observedYear, month, day);
        }

        [DataRow(2026, 2026, 5, 1)]
        [TestMethod]
        public void TestLabourDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "LABOURDAY-01", observedYear, month, day);
        }

        [DataRow(2026, 2026, 11, 3)]
        [TestMethod]
        public void TestSeparationDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "SEPARATIONDAY-01", observedYear, month, day);
        }

        [DataRow(2026, 2026, 11, 4)]
        [TestMethod]
        public void TestFlagDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "FLAGDAY-01", observedYear, month, day);
        }

        [DataRow(2026, 2026, 11, 5)]
        [TestMethod]
        public void TestConsolidationOfTheSeparationDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "COLONDAY-01", observedYear, month, day);
        }

        [DataRow(2026, 2026, 11, 10)]
        [TestMethod]
        public void TestShoutInVillaDeLosSantos(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "SHOUTVILLADELOSSANTOS-01", observedYear, month, day);
        }

        [DataRow(2026, 2026, 12, 8)]
        [TestMethod]
        public void TestMothersDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "MOTHERSDAY-01", observedYear, month, day);
        }

        [DataRow(2026, 2026, 12, 21)]
        [TestMethod]
        public void TestNationalDayOfMourning(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NATIONALDAYOFMOURNING-01", observedYear, month, day);
        }

        [DataRow(2026, 2026, 12, 25)]
        [TestMethod]
        public void TestChristmasDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CHRISTMASDAY-01", observedYear, month, day);
        }
    }
}
