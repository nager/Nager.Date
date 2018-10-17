using Nager.Date.Model;
using Nager.Date.PublicHolidays;
using System;
using System.Collections.Generic;

namespace Nager.Date.UnitTest
{
    public class MockPublicHolidayProvider : CatholicBaseProvider
    {
        public MockPublicHolidayProvider() : base(new MockWeekendProvider())
        {
        }

        public override IEnumerable<PublicHoliday> Get(int year)
        {
            throw new NotImplementedException();
        }
    }
}
