using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class DominicanRepublicTest() : BaseTest(CountryCode.DO)
    {
        [TestMethod]
        [DataRow(2021, 2021, 1, 1)]
        [DataRow(2022, 2022, 1, 1)]
        [DataRow(2023, 2023, 1, 1)] // Sunday, not moved
        [DataRow(2024, 2024, 1, 1)]
        [DataRow(2025, 2025, 1, 1)]
        [DataRow(2026, 2026, 1, 1)]
        [DataRow(2027, 2027, 1, 1)]
        public void TestNewYearsDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "NEWYEARSDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 1, 4)] // Wednesday, moved to preceding Monday
        [DataRow(2022, 2022, 1, 10)] // Thursday, moved to following Monday
        [DataRow(2023, 2023, 1, 9)] // Friday, moved to following Monday
        [DataRow(2024, 2024, 1, 6)] // Saturday, not moved
        [DataRow(2025, 2025, 1, 6)]
        [DataRow(2026, 2026, 1, 5)] // Tuesday, moved to preceding Monday
        [DataRow(2027, 2027, 1, 4)] // Wednesday, moved to preceding Monday
        public void TestDayOfKings(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "DAYOFKINGS-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 1, 21)]
        [DataRow(2022, 2022, 1, 21)]
        [DataRow(2023, 2023, 1, 21)]
        [DataRow(2024, 2024, 1, 21)]
        [DataRow(2025, 2025, 1, 21)]
        [DataRow(2026, 2026, 1, 21)]
        [DataRow(2027, 2027, 1, 21)]
        public void TestOurLadyOfAltagracia(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "OURLADYOFALTAGRACIA-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 1, 25)] // Tuesday, moved to preceding Monday
        [DataRow(2022, 2022, 1, 24)] // Wednesday, moved to preceding Monday
        [DataRow(2023, 2023, 1, 30)] // Thursday, moved to following Monday
        [DataRow(2024, 2024, 1, 29)] // Friday, moved to following Monday
        [DataRow(2025, 2025, 1, 26)] // Sunday, not moved
        [DataRow(2026, 2026, 1, 26)]
        [DataRow(2027, 2027, 1, 25)] // Tuesday, moved to preceding Monday
        public void TestDuartesBirthday(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "DUARTESBIRTHDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 2, 27)]
        [DataRow(2022, 2022, 2, 27)]
        [DataRow(2023, 2023, 2, 27)]
        [DataRow(2024, 2024, 2, 27)]
        [DataRow(2025, 2025, 2, 27)]
        [DataRow(2026, 2026, 2, 27)]
        [DataRow(2027, 2027, 2, 27)]
        public void TestIndependenceDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "INDEPENDENCEDAY-01", observedYear, month, day);
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
            this.AssertObservedDate(year, "CGOODFRIDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 5, 1)] // Saturday, not moved
        [DataRow(2022, 2022, 5, 2)] // Sunday, moved to Monday
        [DataRow(2023, 2023, 5, 1)]
        [DataRow(2024, 2024, 4, 29)] // Wednesday, moved to preceding Monday
        [DataRow(2025, 2025, 5, 5)] // Thursday, moved to following Monday
        [DataRow(2026, 2026, 5, 4)] // Friday, moved to following Monday
        [DataRow(2027, 2027, 5, 1)] // Saturday, not moved
        public void TestLabourDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "LABOURDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 6, 3)]
        [DataRow(2022, 2022, 6, 16)]
        [DataRow(2023, 2023, 6, 8)]
        [DataRow(2024, 2024, 5, 30)]
        [DataRow(2025, 2025, 6, 19)]
        [DataRow(2026, 2026, 6, 4)]
        [DataRow(2027, 2027, 5, 27)]
        public void TestCorpusChristi(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CCORPUSCHRISTI-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 8, 16)]
        [DataRow(2022, 2022, 8, 16)]
        [DataRow(2023, 2023, 8, 16)]
        [DataRow(2024, 2024, 8, 16)]
        [DataRow(2025, 2025, 8, 16)]
        [DataRow(2026, 2026, 8, 16)]
        [DataRow(2027, 2027, 8, 16)]
        public void TestRestorationDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "RESTORATIONDAY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 9, 24)]
        [DataRow(2022, 2022, 9, 24)]
        [DataRow(2023, 2023, 9, 24)]
        [DataRow(2024, 2024, 9, 24)]
        [DataRow(2025, 2025, 9, 24)]
        [DataRow(2026, 2026, 9, 24)]
        [DataRow(2027, 2027, 9, 24)]
        public void TestOurLadyOfMercy(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "OURLADYOFMERCY-01", observedYear, month, day);
        }

        [TestMethod]
        [DataRow(2021, 2021, 11, 6)] // Saturday, not moved
        [DataRow(2022, 2022, 11, 6)] // Sunday, not moved
        [DataRow(2023, 2023, 11, 6)]
        [DataRow(2024, 2024, 11, 4)] // Wednesday, moved to preceding Monday
        [DataRow(2025, 2025, 11, 10)] // Thursday, moved to following Monday
        [DataRow(2026, 2026, 11, 9)] // Friday, moved to following Monday
        [DataRow(2027, 2027, 11, 6)] // Saturday, not moved
        public void TestConstitutionDay(int year, int observedYear, int month, int day)
        {
            this.AssertObservedDate(year, "CONSTITUTIONDAY-01", observedYear, month, day);
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
