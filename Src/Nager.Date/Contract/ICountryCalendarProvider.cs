using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nager.Date.Contract
{
    public interface ICountryCalendarProvider : IPublicHolidayProvider
    {
        DayOfWeek FirstDayOfWeek { get; }
    }
}
