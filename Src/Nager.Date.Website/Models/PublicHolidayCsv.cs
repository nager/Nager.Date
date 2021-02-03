using Nager.Date.Model;

namespace Nager.Date.Website.Models
{
    public class PublicHolidayCsv
    {
        public string Date { get; }
        public string LocalName { get; }
        public string Name { get; }
        //ISO 3166-1 alpha-2
        public string CountryCode { get; }
        public bool Fixed { get; }
        public bool Global { get; }
        public int? LaunchYear { get; }
        public PublicHolidayType Type { get; }
        /// <summary>
        /// Counties in ISO_3166-2
        /// </summary>
        public string Counties { get; }

        public PublicHolidayCsv()
        {
        }

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