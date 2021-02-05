using System;

namespace Nager.Date.Website.Models
{
    public class RegionStatisticDto
    {
        public string RegionName { get; set; }
        public CountryInfoDto[] AvailableCountries { get; set; }
        public CountryInfoDto[] MissingCountries { get; set; }
        public double Coverage
        {
            get
            {
                if (this.MissingCountries == null)
                {
                    return 0;
                }

                if (this.AvailableCountries == null)
                {
                    return 0;
                }

                var total = this.AvailableCountries.Length + this.MissingCountries.Length;

                return Math.Round(100 - 100.0 * this.MissingCountries.Length / total, 2);
            }
        }
    }
}
