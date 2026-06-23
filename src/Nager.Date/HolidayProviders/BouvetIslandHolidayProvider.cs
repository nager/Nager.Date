using Nager.Date.Models;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Bouvet Island HolidayProvider
    /// </summary>
    internal sealed class BouvetIslandHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Bouvet Island HolidayProvider
        /// </summary>
        public BouvetIslandHolidayProvider() : base(CountryCode.BV)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            /*
            * Bouvet Island (Bouvetøya) is not an independent country, but a Norwegian overseas territory.
            * Bouvet Island has no population therefore no official holidays.
            */

            return [];
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Bouvet_Island"
            ];
        }
    }
}
