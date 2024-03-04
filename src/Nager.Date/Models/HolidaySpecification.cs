using System;

namespace Nager.Date.Models
{
    /// <summary>
    /// Holiday Specification
    /// </summary>
    public class HolidaySpecification
    {
        /// <summary>
        /// The date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// English name
        /// </summary>
        public string EnglishName { get; set; }

        /// <summary>
        /// Local name
        /// </summary>
        public string LocalName { get; set; }

        /// <summary>
        /// Initial subdivision of a country (ISO 3166-2)
        /// </summary>
        /// <remarks>States, Province, Territories, Federal districts, Cantons</remarks>
        public string[] SubdivisionCodes { get; set; }

        /// <summary>
        /// A list of types the holiday it is valid
        /// </summary>
        public HolidayTypes HolidayTypes { get; set; }

        /// <summary>
        /// The ruleset to calculate the observed date for the holiday
        /// </summary>
        public ObservedRuleSet ObservedRuleSet { get; set; }

        /// <summary>
        /// Additional holiday translations
        /// </summary>
        public object AdditionalTranslations { get; set; }

        /// <summary>
        /// Holiday Source
        /// </summary>
        //Holiday source
        //Religious Christian holidays
        //Religious orthodox holidays
        //Historical holidays
        //Cultural holidays
        public string Source { get; set; }


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
