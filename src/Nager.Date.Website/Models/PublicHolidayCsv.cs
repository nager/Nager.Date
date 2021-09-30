using Nager.Date.Model;

namespace Nager.Date.Website.Models
{
    /// <summary>
    /// PublicHoliday Csv
    /// </summary>
    public class PublicHolidayCsv
    {
        /// <summary>
        /// Date
        /// </summary>
        public string Date { get; }
        /// <summary>
        /// LocalName
        /// </summary>
        public string LocalName { get; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// CountryCode (ISO 3166-1 alpha-2)
        /// </summary>
        public string CountryCode { get; }
        /// <summary>
        /// Fixed
        /// </summary>
        public bool Fixed { get; }
        /// <summary>
        /// Global
        /// </summary>
        public bool Global { get; }
        /// <summary>
        /// LaunchYear
        /// </summary>
        public int? LaunchYear { get; }
        /// <summary>
        /// Type
        /// </summary>
        public PublicHolidayType Type { get; }
        /// <summary>
        /// Counties in ISO_3166-2
        /// </summary>
        public string Counties { get; }

        /// <summary>
        /// PublicHoliday Csv
        /// </summary>
        public PublicHolidayCsv()
        {
        }

        /// <summary>
        /// PublicHoliday Csv
        /// </summary>
        /// <param name="item"></param>
        public PublicHolidayCsv(PublicHoliday item)
        {
            this.Date = item.Date.ToString("yyyy-MM-dd");
            this.LocalName = item.LocalName;
            this.Name = item.Name;
            this.CountryCode = item.CountryCode.ToString();
            this.Fixed = item.Fixed;
            this.Global = item.Global;
            this.LaunchYear = item.LaunchYear;
            this.Type = item.Type;
            this.Counties = item.Counties == null ? "" : $"{string.Join(',', item.Counties)}";
        }
    }
}