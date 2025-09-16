using Nager.Date.Models;
using System.Collections.Generic;

namespace Nager.Date
{
    /// <summary>
    /// Holiday Specification Processor
    /// </summary>
    internal static class HolidaySpecificationProcessor
    {
        /// <summary>
        /// Process holiday specification to holiday
        /// </summary>
        /// <param name="holidaySpecifications"></param>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        internal static IEnumerable<Holiday> Process(
            IEnumerable<HolidaySpecification> holidaySpecifications,
            CountryCode countryCode)
        {
            foreach (var holidaySpecification in holidaySpecifications)
            {
                var holidayDate = holidaySpecification.Date;
                var id = string.Empty;

                if (!string.IsNullOrEmpty(holidaySpecification.Id))
                {
                    id = $"{countryCode}-{holidaySpecification.Id}";
                }

                yield return new Holiday
                {
                    Id = id,
                    Date = holidayDate,
                    EnglishName = holidaySpecification.EnglishName,
                    LocalName = holidaySpecification.LocalName,
                    HolidayTypes = holidaySpecification.HolidayTypes,
                    SubdivisionCodes = holidaySpecification.SubdivisionCodes,
                    ObservedDate = holidaySpecification.ObservedRuleSet?.GetObservedDate(holidayDate) ?? holidayDate,
                    CountryCode = countryCode
                };
            }
        }
    }
}
