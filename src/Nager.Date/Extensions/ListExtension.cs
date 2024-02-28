using Nager.Date.Models;
using System.Collections.Generic;

namespace Nager.Date.Extensions
{
    internal static class ListExtension
    {
        internal static void AddIfNotNull(
            this List<Holiday> holidays,
            Holiday publicHoliday)
        {
            if (publicHoliday == null)
            {
                return;
            }

            holidays.Add(publicHoliday);
        }

        internal static void AddRangeIfNotNull(
            this List<Holiday> holidays,
            Holiday[] publicHolidays)
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
