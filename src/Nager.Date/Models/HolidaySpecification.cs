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
        /// <remarks>
        /// Database / format rules:
        /// <para>- Starts with ISO country code (e.g., "DE")</para>
        /// <para>- Separator: hyphen ("-")</para>
        /// <para>- Holiday name in uppercase letters, optionally with hyphens (e.g., "CHRISTMASEVE")</para>
        /// <para>- Ends with a two-digit numeric index (e.g., "01")</para>
        /// <para>- Maximum total length: 40 characters</para>
        /// <para>- Allowed characters: A-Z, 0-9, and hyphens</para>
        /// <para>Examples: "DE-CCHRISTMASEVE-01", "DE-NEWYEARSDAY-01"</para>
        /// </remarks>
        public required string Id { get; set; }

#else

        /// <summary>
        /// Unique Id for the Holiday
        /// </summary>
        /// <remarks>
        /// Database / format rules:
        /// <para>- Starts with ISO country code (e.g., "DE")</para>
        /// <para>- Separator: hyphen ("-")</para>
        /// <para>- Holiday name in uppercase letters, optionally with hyphens (e.g., "CHRISTMASEVE")</para>
        /// <para>- Ends with a two-digit numeric index (e.g., "01")</para>
        /// <para>- Maximum total length: 40 characters</para>
        /// <para>- Allowed characters: A-Z, 0-9, and hyphens</para>
        /// <para>Examples: "DE-CCHRISTMASEVE-01", "DE-NEWYEARSDAY-01"</para>
        /// </remarks>
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

        internal HolidaySpecification SetId(string id)
        {
            this.Id = id;

            return this;
        }
    }
}
