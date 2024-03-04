using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Greenland HolidayProvider
    /// </summary>
    internal class GreenlandHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Greenland HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public GreenlandHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.GL;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Ukiortaaq",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Kunngit pingasut ulluat",
                    HolidayTypes = HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(26),
                    EnglishName = "General Prayer Day",
                    LocalName = "Tussiarfik",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(40),
                    EnglishName = "Bank closing day",
                    LocalName = "Atuanngiffik",
                    HolidayTypes = HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 21),
                    EnglishName = "Ullortuneq",
                    LocalName = "Ullortuneq",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Juulliaraq",
                    HolidayTypes = HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Juullip ullua",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Juullip-aappaa",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "New Year's Eve",
                    LocalName = "Ukiutoqaq",
                    HolidayTypes = HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional
                },
                this._catholicProvider.MaundyThursday("Sisamanngortoq illernartoq", year),
                this._catholicProvider.GoodFriday("Tallimanngorneq tannaartoq", year),
                this._catholicProvider.EasterSunday("Poorskip ullua", year),
                this._catholicProvider.EasterMonday("Poorskip-aappaa", year),
                this._catholicProvider.AscensionDay("Qilaliarfik", year),
                this._catholicProvider.Pentecost("Piinsi", year),
                this._catholicProvider.WhitMonday("Piinsip-aappaa", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Ukiortaaq", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 6, "Kunngit pingasut ulluat", "Epiphany", countryCode, type: HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional));
            //items.Add(this._catholicProvider.MaundyThursday("Sisamanngortoq illernartoq", year, countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Tallimanngorneq tannaartoq", year, countryCode));
            //items.Add(this._catholicProvider.EasterSunday("Poorskip ullua", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Poorskip-aappaa", year, countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(26), "Tussiarfik", "General Prayer Day", countryCode));
            //items.Add(this._catholicProvider.AscensionDay("Qilaliarfik", year, countryCode));
            //items.Add(new Holiday(easterSunday.AddDays(40), "Atuanngiffik", "Bank closing day", countryCode, type: HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional));
            //items.Add(this._catholicProvider.Pentecost("Piinsi", year, countryCode));
            //items.Add(this._catholicProvider.WhitMonday("Piinsip-aappaa", year, countryCode));
            //items.Add(new Holiday(year, 6, 21, "Ullortuneq", "Ullortuneq", countryCode));
            //items.Add(new Holiday(year, 12, 24, "Juulliaraq", "Christmas Eve", countryCode, type: HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional));
            //items.Add(new Holiday(year, 12, 25, "Juullip ullua", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Juullip-aappaa", "St. Stephen's Day", countryCode));
            //items.Add(new Holiday(year, 12, 31, "Ukiutoqaq", "New Year's Eve", countryCode, type: HolidayTypes.Bank | HolidayTypes.School | HolidayTypes.Optional));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Greenland"
            };
        }
    }
}
