using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Countries
{
    public abstract class BaseTest
    {
        private readonly CountryCode _countryCode;

        public BaseTest(CountryCode countryCode)
        {
            this._countryCode = countryCode;
        }

        protected void AssertObservedDate(int year, string holidayId, int observedYear, int month, int day)
        {
            var holidays = HolidaySystem.GetHolidays(year, this._countryCode);
            var holiday = holidays.Single(o => o.Id.EndsWith(holidayId));

            Assert.AreEqual(new DateTime(observedYear, month, day), holiday.ObservedDate);
        }

        protected void AssertSubdivisionCodes(int year, string holidayId, params string[] expectedSubdivisionCodes)
        {
            var holidays = HolidaySystem.GetHolidays(year, this._countryCode);
            var holiday = holidays.Single(holiday => holiday.Id.EndsWith(holidayId));

            Assert.IsFalse(holiday.NationalHoliday);
            CollectionAssert.AreEquivalent(expectedSubdivisionCodes, holiday.SubdivisionCodes);
        }

        protected void AssertNoHoliday(int year, string holidayId)
        {
            var holidays = HolidaySystem.GetHolidays(year, this._countryCode);
            Assert.DoesNotContain(holiday => holiday.Id.EndsWith(holidayId), holidays, $"Holiday {holidayId} should not exist in {year}");
        }
    }
}
