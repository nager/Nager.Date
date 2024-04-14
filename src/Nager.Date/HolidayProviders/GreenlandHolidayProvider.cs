using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Greenland HolidayProvider
    /// </summary>
    internal sealed class GreenlandHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Greenland HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public GreenlandHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.GL)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
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

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Greenland"
            ];
        }
    }
}
