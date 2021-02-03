namespace Nager.Date.Website.Models
{
    public class RegionStatisticDto
    {
        public string RegionName { get; set; }
        public CountryInfoDto[] AvailableCountries { get; set; }
        public CountryInfoDto[] MissingCountries { get; set; }
    }
}
