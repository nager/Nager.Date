using Nager.Date.Models;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// United States Minor Outlying Islands HolidayProvider
    /// </summary>
    internal sealed class UnitedStatesMinorOutlyingIslandsHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// United States Minor Outlying Islands HolidayProvider
        /// </summary>
        public UnitedStatesMinorOutlyingIslandsHolidayProvider() : base(CountryCode.UM)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            /*
             * United States Minor Outlying Islands are territories of the United States.
             * They have no permanent population or local government, and therefore no official regional holidays.
             * Theoretically, US Federal Holidays apply.
             */

            var holidaySpecifications = new List<HolidaySpecification>();
            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/United_States_Minor_Outlying_Islands"
            ];
        }
    }
}
