using Nager.Date.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Nager.Date.WebsiteCore.Models
{
    public class PublicHolidayDto
    {
        public DateTime Date { get; set; }
        public string LocalName { get; set; }
        public string Name { get; set; }
        //ISO 3166-1 alpha-2
        public string CountryCode { get; set; }
        public bool Fixed { get; set; }
        public bool Global { get; set; }
        //ISO_3166-2
        public string[] Counties { get; set; }
        public int? LaunchYear { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PublicHolidayType Type { get; set; }
    }
}