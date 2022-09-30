using Nager.Date.Extensions;
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
        public DateTime Date { get; private set; }
        /// <summary>
        /// Local name
        /// </summary>
        public string LocalName { get; private set; }
        /// <summary>
        /// English name
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// ISO 3166-1 alpha-2
        /// </summary>
        public CountryCode CountryCode { get; private set; }
        /// <summary>
        /// Is this public holiday every year on the same date
        /// </summary>
        public bool Fixed { get; private set; }
        /// <summary>
        /// Is this public holiday in every county (federal state)
        /// </summary>
        public bool Global { get { return this.Counties?.Length > 0 ? false : true; } }
        /// <summary>
        /// ISO-3166-2 - Federal states
        /// </summary>
        public string[] Counties { get; private set; }
        /// <summary>
        /// A list of types the public holiday it is valid
        /// </summary>
        public PublicHolidayType Type { get; private set; }
        /// <summary>
        /// The launch year of the public holiday
        /// </summary>
        public int? LaunchYear { get; private set; }

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
        /// <param name="type">The type of the public holiday</param>
        public PublicHoliday(int year, int month, int day, string localName, string englishName, CountryCode countryCode, int? launchYear = null, string[] counties = null, PublicHolidayType type = PublicHolidayType.Public)
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

        /// <summary>
        /// Date and Name of the PublicHoliday
        /// </summary>
        /// <returns>Public holiday info formated</returns>
        public override string ToString()
        {
            return $"{this.Date:yyyy-MM-dd} {this.Name}";
        }

        internal PublicHoliday SetCounties(params string[] counties)
        {
            this.Counties = counties;

            return this;
        }

        internal PublicHoliday SetType(PublicHolidayType publicHolidayType)
        {
            this.Type = publicHolidayType;

            return this;
        }

        internal PublicHoliday SetLaunchYear(int launchYear)
        {
            this.LaunchYear = launchYear;

            return this;
        }

        internal PublicHoliday Shift(Func<DateTime, DateTime> shiftSaturday, Func<DateTime, DateTime> shiftSunday)
        {
            this.Date = this.Date.Shift(shiftSaturday, shiftSunday);

            return this;
        }

        internal PublicHoliday ShiftWeekdays(Func<DateTime, DateTime> monday = null, Func<DateTime, DateTime> tuesday = null, Func<DateTime, DateTime> wednesday = null, Func<DateTime, DateTime> thursday = null, Func<DateTime, DateTime> friday = null)
        {
            this.Date = this.Date.ShiftWeekdays(monday, tuesday, wednesday, thursday, friday);

            return this;
        }
    }
}
