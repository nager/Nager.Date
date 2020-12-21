using System;

namespace Nager.Date.Model
{
    /// <summary>
    /// Public Holiday
    /// </summary>
    public class PublicHoliday
    {
        /// <summary>
        /// The date
        /// </summary>
        public DateTime Date { get; set; }
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
        /// Is this public holiday every year on the same date
        /// </summary>
        public bool Fixed { get; set; }
        /// <summary>
        /// Is this public holiday in every county (federal state)
        /// </summary>
        public bool Global { get { return this.Counties?.Length > 0 || this.Cities?.Length > 0 ? false : true; } }
        /// <summary>
        /// ISO-3166-2 - Federal states
        /// </summary>
        public string[] Counties { get; set; }
        /// <summary>
        /// Cities - Local name
        /// </summary>
        public string[] Cities { get; set; }
        /// <summary>
        /// A list of types the public holiday it is valid
        /// </summary>
        public PublicHolidayType Type { get; set; }
        /// <summary>
        /// The launch year of the public holiday
        /// </summary>
        public int? LaunchYear { get; set; }

        /// <summary>
        /// Add Public Holiday (fixed is true)
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="localName"></param>
        /// <param name="englishName"></param>
        /// <param name="countryCode">ISO 3166-1 ALPHA-2</param>
        /// <param name="launchYear"></param>
        /// <param name="counties">ISO-3166-2</param>
        /// <param name="cities"></param>
        /// <param name="type">The type of the public holiday</param>
        public PublicHoliday(int year, int month, int day, string localName, string englishName, CountryCode countryCode, int? launchYear = null, string[] counties = null, string[] cities = null, PublicHolidayType type = PublicHolidayType.Public)
        {
            this.Date = new DateTime(year, month, day);
            this.LocalName = localName;
            this.Name = englishName;
            this.CountryCode = countryCode;
            this.Fixed = true;
            this.Type = type;
            this.LaunchYear = launchYear;
            if (counties?.Length > 0)
            {
                this.Counties = counties;
            }
            if (cities?.Length > 0)
            {
                this.Cities = cities;
            }
        }

        /// <summary>
        /// Add Public Holiday (fixed is false)
        /// </summary>
        /// <param name="date"></param>
        /// <param name="localName"></param>
        /// <param name="englishName"></param>
        /// <param name="countryCode">ISO 3166-1 ALPHA-2</param>
        /// <param name="launchYear"></param>
        /// <param name="counties">ISO-3166-2</param>
        /// /// <param name="type">The type of the public holiday</param>
        public PublicHoliday(DateTime date, string localName, string englishName, CountryCode countryCode, int? launchYear = null, string[] counties = null, PublicHolidayType type = PublicHolidayType.Public)
        {
            this.Date = date;
            this.LocalName = localName;
            this.Name = englishName;
            this.CountryCode = countryCode;
            this.Fixed = false;
            this.Type = type;
            this.LaunchYear = launchYear;
            if (counties?.Length > 0)
            {
                this.Counties = counties;
            }
        }

        public override string ToString()
        {
            return $"{this.Date:yyyy-MM-dd} {this.Name}";
        }
    }
}
