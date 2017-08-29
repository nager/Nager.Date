using Nager.Date.Model;
using System.Collections.Generic;

namespace Nager.Date.Contract
{
    public interface IPublicHolidayProvider
    {
        IEnumerable<PublicHoliday> Get(int year);
    }
}
