using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.UnitTest
{
    public class MockProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        public MockProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        public DateTime EasterSunday(int year)
        {
            return this._catholicProvider.EasterSunday(year);
        }

        public IEnumerable<PublicHoliday> Get(int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetSources()
        {
            throw new NotImplementedException();
        }
    }
}
