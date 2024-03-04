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
        /// The observed date
        /// </summary>
        public DateTime ObservedDate { get; set; }

        /// <summary>
        /// Local name
        /// </summary>
        public string LocalName { get; set; }

        /// <summary>
        /// English name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ISO 3166-1 alpha-2
        /// </summary>
        public CountryCode CountryCode { get; set; }

        /// <summary>
        /// Is the holiday every year on the same date
        /// </summary>
        public bool Fixed { get; set; }

        /// <summary>
        /// Is a national holiday
        /// </summary>
        public bool NationalHoliday { get { return this.SubdivisionCodes?.Length > 0 ? false : true; } }

        /// <summary>
        /// Initial subdivision of a country (ISO 3166-2)
        /// </summary>
        /// <remarks>States, Province, Territories, Federal districts, Cantons</remarks>
        public string[] SubdivisionCodes { get; set; }

        /// <summary>
        /// A list of valid holiday types
        /// </summary>
        public HolidayTypes HolidayTypes { get; set; }

        /// <summary>
        /// Date and Name of the PublicHoliday
        /// </summary>
        /// <returns>Public holiday info formated</returns>
        public override string ToString()
        {
            return $"{this.Date:yyyy-MM-dd} {this.Name}";
        }
    }
}
