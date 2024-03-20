using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Slovenia HolidayProvider
    /// </summary>
    internal sealed class SloveniaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Slovenia HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SloveniaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.SI)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "novo leto",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "New Year's Day",
                    LocalName = "novo leto",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 8),
                    EnglishName = "Prešeren Day",
                    LocalName = "Prešernov dan",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 27),
                    EnglishName = "Day of Uprising Against Occupation",
                    LocalName = "dan upora proti okupatorju",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "May Day Holiday",
                    LocalName = "praznik dela",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 2),
                    EnglishName = "May Day Holiday",
                    LocalName = "praznik dela",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 25),
                    EnglishName = "Statehood Day",
                    LocalName = "dan državnosti",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Marijino vnebovzetje",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 31),
                    EnglishName = "Reformation Day",
                    LocalName = "dan reformacije",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "Day of the Dead",
                    LocalName = "dan spomina na mrtve",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "božič",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Independence and Unity Day",
                    LocalName = "dan samostojnosti in enotnosti",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.EasterSunday("velikonočna nedelja in ponedeljek", year),
                this._catholicProvider.EasterMonday("velikonočna nedelja in ponedeljek", year),
                this._catholicProvider.Pentecost("binkoštna nedelja, binkošti", year)
            };

            holidaySpecifications.AddIfNotNull(this.SolidarityDay(year));

            return holidaySpecifications;

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "novo leto", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 2, "novo leto", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 2, 8, "Prešernov dan", "Prešeren Day", countryCode));
            //items.Add(this._catholicProvider.EasterSunday("velikonočna nedelja in ponedeljek", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("velikonočna nedelja in ponedeljek", year, countryCode));
            //items.Add(new Holiday(year, 4, 27, "dan upora proti okupatorju", "Day of Uprising Against Occupation", countryCode));
            //items.Add(new Holiday(year, 5, 1, "praznik dela", "May Day Holiday", countryCode, 1949));
            //items.Add(new Holiday(year, 5, 2, "praznik dela", "May Day Holiday", countryCode, 1949));
            //items.Add(this._catholicProvider.Pentecost("binkoštna nedelja, binkošti", year, countryCode));
            //items.Add(new PublicHoliday(year, 6, 8, "dan Primoža Trubarja", "Primož Trubar Day", countryCode)); not work-free
            //items.Add(new Holiday(year, 6, 25, "dan državnosti", "Statehood Day", countryCode));
            //items.Add(new Holiday(year, 8, 15, "Marijino vnebovzetje", "Assumption Day", countryCode, 1992));
            //items.Add(new Holiday(year, 10, 31, "dan reformacije", "Reformation Day", countryCode, 1992));
            //items.Add(new Holiday(year, 11, 1, "dan spomina na mrtve", "Day of the Dead", countryCode));
            //items.Add(new Holiday(year, 12, 25, "božič", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "dan samostojnosti in enotnosti", "Independence and Unity Day", countryCode));
            //items.AddIfNotNull(this.SolidarityDay(year, countryCode));
            //return items.OrderBy(o => o.Date);
        }

        private HolidaySpecification SolidarityDay(int year)
        {
            if (year == 2023)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 14),
                    EnglishName = "Solidarity Day",
                    LocalName = "dan solidarnosti",
                    HolidayTypes = HolidayTypes.Public
                };

                //return new Holiday(new DateTime(year, 8, 14), "dan solidarnosti", "Solidarity Day", countryCode);
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Slovenia"
            ];
        }
    }
}
