using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Ukraine HolidayProvider
    /// </summary>
    internal sealed class UkraineHolidayProvider : AbstractHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// Ukraine HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public UkraineHolidayProvider(
            IOrthodoxProvider orthodoxProvider) : base(CountryCode.UA)
        {
            this._orthodoxProvider = orthodoxProvider;
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
                    LocalName = "Новий Рік",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "(Julian) Christmas",
                    LocalName = "Різдво",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "Міжнародний жіночий день",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "International Workers' Day",
                    LocalName = "День праці",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 9),
                    EnglishName = "Victory day over Nazism in World War II",
                    LocalName = "День перемоги над нацизмом у Другій світовій війні",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 28),
                    EnglishName = "Constitution Day",
                    LocalName = "День Конституції",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 24),
                    EnglishName = "Independence Day",
                    LocalName = "День Незалежності",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 14),
                    EnglishName = "Defender of Ukraine Day",
                    LocalName = "День захисника України",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "(Gregorian and Revised Julian) Christmas",
                    LocalName = "Різдво",
                    HolidayTypes = HolidayTypes.Public
                },
                this._orthodoxProvider.EasterSunday("Великдень", year),
                this._orthodoxProvider.Pentecost("Трійця", year)
            };

            holidaySpecifications.AddIfNotNull(this.StatehoodDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? StatehoodDay(int year)
        {
            var englishName = "Statehood Day";
            var localName = "Statehood Day";

            if (year == 2022 || year == 2023)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 28),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public
                };
            }
            else if (year >= 2024)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 15),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public
                };
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Ukraine"
            ];
        }
    }
}
