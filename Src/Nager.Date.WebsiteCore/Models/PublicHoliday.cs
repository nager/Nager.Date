namespace Nager.Date.WebsiteCore.Models
{
    public class PublicHoliday
    {
        public string Date { get; set; }
        public string LocalName { get; set; }
        public string Name { get; set; }
        //ISO 3166-1 alpha-2
        public string CountryCode { get; set; }
        public bool Fixed { get; set; }
        public bool Global { get; set; }
        //ISO_3166-2
        public string[] Counties { get; set; }
        public int? LaunchYear { get; set; }

        public PublicHoliday()
        { }

        public PublicHoliday(Date.Model.PublicHoliday item)
        {
            this.Date = item.Date.ToString("yyyy-MM-dd");
            this.LocalName = item.LocalName;
            this.Name = item.Name;
            this.CountryCode = item.CountryCode.ToString();
            this.Fixed = item.Fixed;
            this.Global = item.Global;
            this.Counties = item.Counties;
            this.LaunchYear = item.LaunchYear;
        }
    }
}