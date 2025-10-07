using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nager.Date.Models;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class SlovakiaTest
    {
        [TestMethod]
        public void TestSlovakia2024()
        {
            var year = 2024;
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.SK).ToArray();

            var constitutionDay = holidays.FirstOrDefault(h => h.Id == "CONSTITUTIONDAY-01");
            var ladySorrowsDay = holidays.FirstOrDefault(h => h.Id == "DAYOURLADYSEVENSORROWS-01");
            var victoryDay = holidays.FirstOrDefault(h => h.Id == "DAYOFVICTORYOVERFASCISM-01");
            var freedomDay = holidays.FirstOrDefault(h => h.Id == "STRUGGLEFREEDOMDEMOCRACYDAY-01");

            Assert.IsNotNull(constitutionDay);
            Assert.AreEqual(HolidayTypes.Public, constitutionDay.HolidayTypes, "Constitution Day type is wrong for 2024");

            Assert.IsNotNull(ladySorrowsDay);
            Assert.AreEqual(HolidayTypes.Public, ladySorrowsDay.HolidayTypes, "Our Lady of Seven Sorrows type is wrong for 2024");

            Assert.IsNotNull(victoryDay);
            Assert.AreEqual(HolidayTypes.Public, victoryDay.HolidayTypes, "Victory over Fascism type is wrong for 2024");

            Assert.IsNotNull(freedomDay);
            Assert.AreEqual(HolidayTypes.Public, freedomDay.HolidayTypes, "Freedom and Democracy Day type is wrong for 2024");
        }

        [TestMethod]
        public void TestSlovakia2025()
        {
            var year = 2025;
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.SK).ToArray();

            var constitutionDay = holidays.FirstOrDefault(h => h.Id == "CONSTITUTIONDAY-01");
            var ladySorrowsDay = holidays.FirstOrDefault(h => h.Id == "DAYOURLADYSEVENSORROWS-01");
            var victoryDay = holidays.FirstOrDefault(h => h.Id == "DAYOFVICTORYOVERFASCISM-01");
            var freedomDay = holidays.FirstOrDefault(h => h.Id == "STRUGGLEFREEDOMDEMOCRACYDAY-01");

            Assert.IsNotNull(constitutionDay);
            Assert.AreEqual(HolidayTypes.Observance, constitutionDay.HolidayTypes, "Constitution Day type is wrong for 2025");

            Assert.IsNotNull(ladySorrowsDay);
            Assert.AreEqual(HolidayTypes.Public, ladySorrowsDay.HolidayTypes, "Our Lady of Seven Sorrows type is wrong for 2025");

            Assert.IsNotNull(victoryDay);
            Assert.AreEqual(HolidayTypes.Public, victoryDay.HolidayTypes, "Victory over Fascism type is wrong for 2025");

            Assert.IsNotNull(freedomDay);
            Assert.AreEqual(HolidayTypes.Public, freedomDay.HolidayTypes, "Freedom and Democracy Day type is wrong for 2025");
        }

        [TestMethod]
        public void TestSlovakia2026()
        {
            var year = 2026;
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.SK).ToArray();

            var constitutionDay = holidays.FirstOrDefault(h => h.Id == "CONSTITUTIONDAY-01");
            var ladySorrowsDay = holidays.FirstOrDefault(h => h.Id == "DAYOURLADYSEVENSORROWS-01");
            var victoryDay = holidays.FirstOrDefault(h => h.Id == "DAYOFVICTORYOVERFASCISM-01");
            var freedomDay = holidays.FirstOrDefault(h => h.Id == "STRUGGLEFREEDOMDEMOCRACYDAY-01");

            Assert.IsNotNull(constitutionDay);
            Assert.AreEqual(HolidayTypes.Observance, constitutionDay.HolidayTypes, "Constitution Day type is wrong for 2026");

            Assert.IsNotNull(ladySorrowsDay);
            Assert.AreEqual(HolidayTypes.Observance, ladySorrowsDay.HolidayTypes, "Our Lady of Seven Sorrows type is wrong for 2026");

            Assert.IsNotNull(victoryDay);
            Assert.AreEqual(HolidayTypes.Observance, victoryDay.HolidayTypes, "Victory over Fascism type is wrong for 2026");

            Assert.IsNotNull(freedomDay);
            Assert.AreEqual(HolidayTypes.Observance, freedomDay.HolidayTypes, "Freedom and Democracy Day type is wrong for 2026");
        }
    }
}
