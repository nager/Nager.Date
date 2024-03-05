using Nager.Date.Models;
using System.Collections.Generic;

namespace Nager.Date.Extensions
{
    internal static class ListExtension
    {
        internal static void AddIfNotNull(
            this List<HolidaySpecification> holidaySpecificationList,
            HolidaySpecification holidaySpecification)
        {
            if (holidaySpecification == null)
            {
                return;
            }

            holidaySpecificationList.Add(holidaySpecification);
        }

        internal static void AddRangeIfNotNull(
            this List<HolidaySpecification> holidaySpecificationList,
            HolidaySpecification[] holidaySpecifications)
        {
            if (holidaySpecifications == null)
            {
                return;
            }

            if (holidaySpecifications.Length == 0)
            {
                return;
            }

            holidaySpecificationList.AddRange(holidaySpecifications);
        }
    }
}
