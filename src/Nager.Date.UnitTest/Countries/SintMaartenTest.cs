using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    [TestClass]
    public class SintMaartenTest
    {
        [DataRow(2026, 2026, 10, 12)]
        [DataRow(2027, 2027, 10, 11)]
        [DataRow(2028, 2028, 10, 9)]
        [TestMethod]
        public void TestConstitutionDay(int year, int observedYear, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.SX);
            var holiday = holidays.Single(o => o.Id.EndsWith("CONSTITUTIONDAY-01"));

            Assert.AreEqual(new DateTime(observedYear, month, day), holiday.ObservedDate);
        }

        [DataRow(2026, 2026, 5, 1)]
        [DataRow(2027, 2027, 5, 1)]
        [DataRow(2028, 2028, 5, 1)]
        [TestMethod]
        public void TestLabourDay(int year, int observedYear, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.SX);
            var holiday = holidays.Single(o => o.Id.EndsWith("LABOURDAY-01"));

            Assert.AreEqual(new DateTime(observedYear, month, day), holiday.ObservedDate);
        }

        [DataRow(2026, 2026, 7, 1)]
        [DataRow(2027, 2027, 7, 1)]
        [DataRow(2028, 2028, 7, 1)]
        [TestMethod]
        public void TestEmancipationDay(int year, int observedYear, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.SX);
            var holiday = holidays.Single(o => o.Id.EndsWith("EMANCIPATIONDAY-01"));

            Assert.AreEqual(new DateTime(observedYear, month, day), holiday.ObservedDate);
        }

        [DataRow(2026, 2026, 11, 11)]
        [DataRow(2027, 2027, 11, 11)]
        [DataRow(2028, 2028, 11, 11)]
        [TestMethod]
        public void TestStMaartensDay(int year, int observedYear, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, CountryCode.SX);
            var holiday = holidays.Single(o => o.Id.EndsWith("SINTMAARTENDAY-01"));

            Assert.AreEqual(new DateTime(observedYear, month, day), holiday.ObservedDate);
        }
    }
}
