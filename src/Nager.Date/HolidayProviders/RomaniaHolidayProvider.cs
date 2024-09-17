using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Romania HolidayProvider
    /// </summary>
    internal sealed class RomaniaHolidayProvider : AbstractHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// Romania HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public RomaniaHolidayProvider(
            IOrthodoxProvider orthodoxProvider) : base(CountryCode.RO)
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
                    LocalName = "Anul Nou",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "Day after New Year's Day",
                    LocalName = "Anul Nou",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 24),
                    EnglishName = "Union Day/Small Union",
                    LocalName = "Unirea Principatelor Române/Mica Unire",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Ziua Muncii",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 1),
                    EnglishName = "Children's Day",
                    LocalName = "Ziua Copilului",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Dormition of the Theotokos",
                    LocalName = "Adormirea Maicii Domnului/Sfânta Maria Mare",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 30),
                    EnglishName = "St. Andrew's Day",
                    LocalName = "Sfântul Andrei",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 1),
                    EnglishName = "National Day/Great Union",
                    LocalName = "Ziua Națională/Marea Unire",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Crăciunul",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Crăciunul",
                    HolidayTypes = HolidayTypes.Public
                },
                this._orthodoxProvider.GoodFriday("Vinerea mare", year),
                this._orthodoxProvider.EasterSunday("Paștele", year),
                this._orthodoxProvider.EasterMonday("Paștele", year),
                this._orthodoxProvider.Pentecost("Rusaliile", year),
                this._orthodoxProvider.WhitMonday("Rusaliile", year)
            };

            holidaySpecifications.AddIfNotNull(this.Epiphany(year));
            holidaySpecifications.AddIfNotNull(this.SaintJohnTheBaptist(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? Epiphany(int year)
        {
            if (year >= 2024)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Bobotează",
                    HolidayTypes = HolidayTypes.Public
                };
            }

            return null;
        }

        private HolidaySpecification? SaintJohnTheBaptist(int year)
        {
            if (year >= 2024)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "Saint John the Baptist",
                    LocalName = "Sfântul Ion",
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
                "https://en.wikipedia.org/wiki/Public_holidays_in_Romania"
            ];
        }
    }
}
