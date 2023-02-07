using Nager.Date.Model;
using System.Collections.Generic;

namespace Nager.Date.Extensions
{
    internal static class ListExtension
    {
        internal static void AddIfNotNull(this List<PublicHoliday> publicHolidays, PublicHoliday publicHoliday)
        {
            if (publicHoliday == null)
            {
                return;
            }

            publicHolidays.Add(publicHoliday);
        }
    }
}
