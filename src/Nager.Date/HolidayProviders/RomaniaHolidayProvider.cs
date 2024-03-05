using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Romania HolidayProvider
    /// </summary>
    internal class RomaniaHolidayProvider : IHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// Romania HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public RomaniaHolidayProvider(
            IOrthodoxProvider orthodoxProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.RO;

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

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Anul Nou", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 2, "Anul Nou", "Day after New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 24, "Unirea Principatelor Române/Mica Unire", "Union Day/Small Union", countryCode));
            //items.Add(this._orthodoxProvider.GoodFriday("Vinerea mare", year, countryCode).SetLaunchYear(2018));
            //items.Add(this._orthodoxProvider.EasterSunday("Paștele", year, countryCode));
            //items.Add(this._orthodoxProvider.EasterMonday("Paștele", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Ziua Muncii", "Labour Day", countryCode));
            //items.Add(new Holiday(year, 6, 1, "Ziua Copilului", "Children's Day", countryCode, 2017));
            //items.Add(this._orthodoxProvider.Pentecost("Rusaliile", year, countryCode));
            //items.Add(this._orthodoxProvider.WhitMonday("Rusaliile", year, countryCode));
            //items.Add(new Holiday(year, 8, 15, "Adormirea Maicii Domnului/Sfânta Maria Mare", "Dormition of the Theotokos", countryCode));
            //items.Add(new Holiday(year, 11, 30, "Sfântul Andrei", "St. Andrew's Day", countryCode));
            //items.Add(new Holiday(year, 12, 1, "Ziua Națională/Marea Unire", "National Day/Great Union", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Crăciunul", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Crăciunul", "St. Stephen's Day", countryCode));
            //items.AddIfNotNull(this.Epiphany(year, countryCode));
            //items.AddIfNotNull(this.SaintJohnTheBaptist(year, countryCode));
            //return items.OrderBy(o => o.Date);
        }

        private HolidaySpecification Epiphany(int year)
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

                //return new Holiday(year, 1, 6, "Bobotează", "Epiphany", countryCode);
            }

            return null;
        }

        private HolidaySpecification SaintJohnTheBaptist(int year)
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

                //return new Holiday(year, 1, 7, "Sfântul Ion", "Saint John the Baptist", countryCode);
            }

            return null;
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Romania"
            };
        }
    }
}
