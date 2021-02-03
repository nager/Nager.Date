namespace Nager.Date.Website.Models
{
    public class CountryInfoDto
    {
        public string CommonName { get; set; }
        public string OfficialName { get; set; }
        public string CountryCode { get; set; }
        public string Region { get; set; }
        public CountryInfoDto[] Borders { get; set; }
    }
}