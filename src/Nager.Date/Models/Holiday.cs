using System;

namespace Nager.Date.Models
{
    /// <summary>
    /// Holiday
    /// </summary>
    public class Holiday
    {
        /// <summary>
        /// The date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The date on which the holiday is observed
        /// </summary>
        public DateTime ObservedDate { get; set; }

        /// <summary>
        /// The name of the holiday in English
        /// </summary>
        public string EnglishName { get; set; } = string.Empty;

        /// <summary>
        /// The name of the holiday in the local language
        /// </summary>
        public string LocalName { get; set; } = string.Empty;

        /// <summary>
        /// Represents the country where the holiday is observed
        /// </summary>
        /// <remarks>ISO 3166-1 alpha-2</remarks>
        public CountryCode CountryCode { get; set; }

        /// <summary>
        /// Indicates whether the holiday is a national holiday
        /// </summary>
        public bool NationalHoliday { get { return this.SubdivisionCodes?.Length > 0 ? false : true; } }

        /// <summary>
        /// The initial subdivision of the country (ISO 3166-2) where the holiday is observed
        /// </summary>
        /// <remarks>States, Province, Territories, Federal districts, Cantons</remarks>
        public string[]? SubdivisionCodes { get; set; }

        /// <summary>
        /// The types of the holiday
        /// </summary>
        public HolidayTypes HolidayTypes { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.Date:yyyy-MM-dd} {this.EnglishName}";
        }
    }
}
