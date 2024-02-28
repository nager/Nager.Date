using Nager.Date.HolidayProviders;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.UnitTest
{
    public class MockPublicHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        public MockPublicHolidayProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        public DateTime EasterSunday(int year)
        {
            return this._catholicProvider.EasterSunday(year);
        }

        public IEnumerable<Holiday> GetHolidays(int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetSources()
        {
            throw new NotImplementedException();
        }
    }
}

