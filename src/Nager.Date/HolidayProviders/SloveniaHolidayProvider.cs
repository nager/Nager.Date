using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Slovenia HolidayProvider
    /// </summary>
    internal class SloveniaHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Slovenia HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SloveniaHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.SI;

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "novo leto", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 1, 2, "novo leto", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 2, 8, "Prešernov dan", "Prešeren Day", countryCode));
            items.Add(this._catholicProvider.EasterSunday("velikonočna nedelja in ponedeljek", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("velikonočna nedelja in ponedeljek", year, countryCode));
            items.Add(new Holiday(year, 4, 27, "dan upora proti okupatorju", "Day of Uprising Against Occupation", countryCode));
            items.Add(new Holiday(year, 5, 1, "praznik dela", "May Day Holiday", countryCode, 1949));
            items.Add(new Holiday(year, 5, 2, "praznik dela", "May Day Holiday", countryCode, 1949));
            items.Add(this._catholicProvider.Pentecost("binkoštna nedelja, binkošti", year, countryCode));
            //items.Add(new PublicHoliday(year, 6, 8, "dan Primoža Trubarja", "Primož Trubar Day", countryCode)); not work-free
            items.Add(new Holiday(year, 6, 25, "dan državnosti", "Statehood Day", countryCode));
            items.Add(new Holiday(year, 8, 15, "Marijino vnebovzetje", "Assumption Day", countryCode, 1992));
            items.Add(new Holiday(year, 10, 31, "dan reformacije", "Reformation Day", countryCode, 1992));
            items.Add(new Holiday(year, 11, 1, "dan spomina na mrtve", "Day of the Dead", countryCode));
            items.Add(new Holiday(year, 12, 25, "božič", "Christmas Day", countryCode));
            items.Add(new Holiday(year, 12, 26, "dan samostojnosti in enotnosti", "Independence and Unity Day", countryCode));

            items.AddIfNotNull(this.SolidarityDay(year, countryCode));

            return items.OrderBy(o => o.Date);
        }

        private Holiday SolidarityDay(int year, CountryCode countryCode)
        {
            if (year == 2023)
            {
                return new Holiday(new DateTime(year, 8, 14), "dan solidarnosti", "Solidarity Day", countryCode);
            }

            return null;
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Slovenia"
            };
        }
    }
}
