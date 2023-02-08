using Nager.Date.Model;
using System.Collections.Generic;

namespace Nager.Date.Extensions
{
    internal static class ListExtension
    {
        internal static void AddIfNotNull(this List<PublicHoliday> holidays, PublicHoliday publicHoliday)
        {
            if (publicHoliday == null)
            {
                return;
            }

            holidays.Add(publicHoliday);
        }

        internal static void AddRangeIfNotNull(this List<PublicHoliday> holidays, PublicHoliday[] publicHolidays)
        {
            if (publicHolidays == null)
            {
                return;
            }

            if (publicHolidays.Length == 0)
            {
                return;
            }

            holidays.AddRange(publicHolidays);
        }
    }
}
