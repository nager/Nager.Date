using Nager.Date.Models;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Heard Island and McDonald Islands HolidayProvider
    /// </summary>
    internal sealed class HeardIslandAndMcDonaldIslandsHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Heard Island and McDonald Islands HolidayProvider
        /// </summary>
        public HeardIslandAndMcDonaldIslandsHolidayProvider() : base(CountryCode.HM)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            /*
            * Heard Island and McDonald Islands has no population therefore no official holidays.
            */

            var holidaySpecifications = new List<HolidaySpecification>();
            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Heard_Island_and_McDonald_Islands"
            ];
        }
    }
}
