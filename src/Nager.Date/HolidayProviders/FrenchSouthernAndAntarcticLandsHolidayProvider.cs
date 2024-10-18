using Nager.Date.Models;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// French Southern and Antarctic Lands HolidayProvider
    /// </summary>
    internal sealed class FrenchSouthernAndAntarcticLandsHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// French Southern and Antarctic Lands HolidayProvider
        /// </summary>
        public FrenchSouthernAndAntarcticLandsHolidayProvider() : base(CountryCode.TF)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            /*
            * French Southern and Antarctic Lands has no population therefore no official holidays.
            */

            var holidaySpecifications = new List<HolidaySpecification>();
            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/French_Southern_and_Antarctic_Lands"
            ];
        }
    }
}
