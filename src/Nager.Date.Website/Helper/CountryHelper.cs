using Nager.Country;
using Nager.Date.Website.Models;
using System.Collections.Generic;

namespace Nager.Date.Website.Helper
{
    internal static class CountryHelper
    {
        internal static CountryInfoDto Convert(ICountryInfo country)
        {
            return new CountryInfoDto
            {
                CommonName = country.CommonName,
                OfficialName = country.OfficialName,
                CountryCode = country.Alpha2Code.ToString(),
                Region = country.Region.ToString(),
                Borders = GetBorderCountryInfos(country.BorderCountries)
            };
        }

        private static CountryInfoDto[] GetBorderCountryInfos(Alpha2Code[] countryCodes)
        {
            var countryProvider = new Country.CountryProvider();
            var items = new List<CountryInfoDto>();

            foreach (var countryCode in countryCodes)
            {
                var country = countryProvider.GetCountry(countryCode);

                var countryInfo = new CountryInfoDto
                {
                    CommonName = country.CommonName,
                    OfficialName = country.OfficialName,
                    CountryCode = country.Alpha2Code.ToString(),
                    Region = country.Region.ToString()
                };

                items.Add(countryInfo);
            }

            return items.ToArray();
        }
    }
}
