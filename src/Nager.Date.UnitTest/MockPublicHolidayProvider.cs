using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.UnitTest
{
    public class MockPublicHolidayProvider : IPublicHolidayProvider
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

        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetSources()
        {
            throw new NotImplementedException();
        }
    }
}

