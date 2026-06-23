using Nager.Date.Models;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Antarctica HolidayProvider
    /// </summary>
    internal sealed class AntarcticaHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Antarctica HolidayProvider
        /// </summary>
        public AntarcticaHolidayProvider() : base(CountryCode.AQ)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            /*
             * Antarctica is governed by about 30 countries
             * Antarctica has no population or government of its own and therefore no official holidays.
            */

            return [];
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Antarctica"
            ];
        }
    }
}
