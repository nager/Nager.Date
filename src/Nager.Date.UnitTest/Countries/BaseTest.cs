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
    }
}
