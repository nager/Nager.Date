using Nager.Date.Model;
using System;
using System.Collections.Generic;

namespace Nager.Date.Contract
{
    public interface IPublicHolidayProvider
    {
        IEnumerable<PublicHoliday> Get(DateTime easterSunday, int year);
    }
}
