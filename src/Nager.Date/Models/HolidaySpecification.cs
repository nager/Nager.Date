using System;
using System.Collections.Generic;

namespace Nager.Date.Models
{
    /// <summary>
    /// Holiday Specification
    /// </summary>
    public class HolidaySpecification
    {

#if NET8_0_OR_GREATER

        /// <summary>
        /// Unique Id for the Holiday
        /// </summary>
        //public required string Id { get; set; }
        public string Id { get; set; } = string.Empty;
#else

        /// <summary>
        /// Unique Id for the Holiday
        /// </summary>
        public string Id { get; set; } = string.Empty;

#endif

        /// <summary>
        /// The date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// English name
        /// </summary>
        public string EnglishName { get; set; } = string.Empty;

        /// <summary>
        /// Local name
        /// </summary>
        public string LocalName { get; set; } = string.Empty;

        /// <summary>
        /// Initial subdivision of a country (ISO 3166-2)
        /// </summary>
        /// <remarks>States, Province, Territories, Federal districts, Cantons</remarks>
        public string[]? SubdivisionCodes { get; set; }

        /// <summary>
        /// A list of types the holiday it is valid
        /// </summary>
        public HolidayTypes HolidayTypes { get; set; } = HolidayTypes.Public;

        /// <summary>
        /// The ruleset to calculate the observed date for the holiday
        /// </summary>
        public ObservedRuleSet? ObservedRuleSet { get; set; }

        /// <summary>
        /// Additional holiday translations
        /// </summary>
        public Dictionary<string, string>? AdditionalTranslations { get; set; }

        /// <summary>
        /// Holiday Source
        /// </summary>
        public HolidaySources HolidaySources { get; set; }


        internal HolidaySpecification SetSubdivisionCodes(params string[] subdivisionCodes)
        {
            this.SubdivisionCodes = subdivisionCodes;

            return this;
        }

        internal HolidaySpecification SetHolidayTypes(HolidayTypes holidayType)
        {
            this.HolidayTypes = holidayType;

            return this;
        }
    }
}
