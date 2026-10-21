using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class PanamaTest() : BaseTest(CountryCode.PA)
    {
        [TestMethod]
        [DataRow(2026, 2026, 1, 1)]
        public void TestNewYearsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NEWYEARSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2026, 2026, 1, 9)]
        public void TestMartyrsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "MARTYRSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2026, 2026, 5, 1)]
        public void TestLabourDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "LABOURDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2026, 2026, 11, 3)]
        public void TestSeparationDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "SEPARATIONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2026, 2026, 11, 4)]
        public void TestFlagDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "FLAGDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2026, 2026, 11, 5)]
        public void TestConsolidationOfTheSeparationDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "COLONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2026, 2026, 11, 10)]
        public void TestShoutInVillaDeLosSantos(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "SHOUTVILLADELOSSANTOS-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2026, 2026, 12, 8)]
        public void TestMothersDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "MOTHERSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2026, 2026, 12, 21)]
        public void TestNationalDayOfMourning(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NATIONALDAYOFMOURNING-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2026, 2026, 12, 25)]
        public void TestChristmasDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CHRISTMASDAY-01", observedYear, month, day);
        }
    }
}
