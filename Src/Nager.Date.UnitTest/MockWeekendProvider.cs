using Nager.Date.Contract;
using System;

namespace Nager.Date.UnitTest
{
    public class MockWeekendProvider : IWeekendProvider
    {
        public bool IsWeekend(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
