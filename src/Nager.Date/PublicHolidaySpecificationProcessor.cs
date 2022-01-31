using Nager.Date.Model;
using System.Collections.Generic;

namespace Nager.Date
{
    /// <summary>
    /// PublicHoliday Specification Processor
    /// </summary>
    public class PublicHolidaySpecificationProcessor
    {
        /// <summary>
        /// Process specification to public holiday
        /// </summary>
        /// <param name="publicHolidaySpecifications"></param>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Process(
                IEnumerable<PublicHolidaySpecification> publicHolidaySpecifications,
                CountryCode countryCode)
        {
            foreach (var specification in publicHolidaySpecifications)
            {
                yield return new PublicHoliday(
                    specification.Date,
                    specification.LocalName,
                    specification.EnglishName,
                    countryCode,
                    specification.LaunchYear,
                    specification.Counties,
                    specification.Type);

                if (specification.ObservedRuleSet == null)
                {
                    continue;
                }

                var observedDate = specification.ObservedRuleSet.GetObservedData(specification.Date);

                if (observedDate.HasValue)
                {
                    yield return new PublicHoliday(
                        observedDate.Value,
                        $"{specification.LocalName} (Observed)",
                        $"{specification.EnglishName} (Observed)",
                        countryCode,
                        specification.LaunchYear,
                        specification.Counties,
                        specification.Type);
                }
            }
        }
    }
}
