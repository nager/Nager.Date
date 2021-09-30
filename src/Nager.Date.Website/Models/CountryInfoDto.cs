namespace Nager.Date.Website.Models
{
    /// <summary>
    /// CountryInfo Dto
    /// </summary>
    public class CountryInfoDto
    {
        /// <summary>
        /// CommonName
        /// </summary>
        public string CommonName { get; set; }
        /// <summary>
        /// OfficialName
        /// </summary>
        public string OfficialName { get; set; }
        /// <summary>
        /// CountryCode
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        /// Region
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// Country Borders
        /// </summary>
        public CountryInfoDto[] Borders { get; set; }
    }
}