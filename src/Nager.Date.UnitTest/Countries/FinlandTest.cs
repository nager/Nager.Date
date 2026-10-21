using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class FinlandTest() : BaseTest(CountryCode.FI)
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
        [DataRow(2024, 2024, 11, 2)]
        [DataRow(2025, 2025, 11, 1)]
        [DataRow(2026, 2026, 10, 31)]
        [DataRow(2027, 2027, 11, 6)]
        public void TestAllSaintsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "ALLSAINTSDAY-01", observedYear, month, day);
        }
    }
}
