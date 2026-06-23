using Nager.Date.Models;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// South Georgia HolidayProvider
    /// </summary>
    internal sealed class SouthGeorgiaHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// South Georgia HolidayProvider
        /// </summary>
        public SouthGeorgiaHolidayProvider() : base(CountryCode.GS)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            /*
            * South Georgia has no population therefore no official holidays.
            */

            return [];
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/South_Georgia"
            ];
        }
    }
}
