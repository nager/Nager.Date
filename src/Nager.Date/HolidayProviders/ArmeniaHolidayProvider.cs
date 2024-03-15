using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Armenia HolidayProvider
    /// </summary>
    internal sealed class ArmeniaHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Armenia HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ArmeniaHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.AM;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Ամանոր",
                    HolidayTypes = HolidayTypes.Public,
                    HolidaySources = HolidaySources.CulturalHolidays
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "New Year's Day",
                    LocalName = "Ամանոր",
                    HolidayTypes = HolidayTypes.Public,
                    HolidaySources = HolidaySources.CulturalHolidays
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 5),
                    EnglishName = "Christmas Day",
                    LocalName = "Սուրբ Ծնունդ",
                    HolidayTypes = HolidayTypes.Public,
                    HolidaySources = HolidaySources.ReligiousHolidays
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Christmas Day",
                    LocalName = "Սուրբ Ծնունդ",
                    HolidayTypes = HolidayTypes.Public,
                    HolidaySources = HolidaySources.ReligiousHolidays
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 28),
                    EnglishName = "Army Day",
                    LocalName = "Բանակի օր",
                    HolidayTypes = HolidayTypes.Public,
                    HolidaySources = HolidaySources.HistoricalHolidays
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "Women's Day",
                    LocalName = "Կանանց տոն",
                    HolidayTypes = HolidayTypes.Public,
                    HolidaySources = HolidaySources.UndefinedHoliday
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 24),
                    EnglishName = "Armenian Genocide Remembrance Day",
                    LocalName = "Եղեռնի զոհերի հիշատակի օր",
                    HolidayTypes = HolidayTypes.Public,
                    HolidaySources = HolidaySources.HistoricalHolidays
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Աշխատանքի օր",
                    HolidayTypes = HolidayTypes.Public,
                    HolidaySources = HolidaySources.HistoricalHolidays
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 9),
                    EnglishName = "Victory and Peace Day",
                    LocalName = "Հաղթանակի և Խաղաղության տոն",
                    HolidayTypes = HolidayTypes.Public,
                    HolidaySources = HolidaySources.HistoricalHolidays
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 28),
                    EnglishName = "Republic Day",
                    LocalName = "Հանրապետության օր",
                    HolidayTypes = HolidayTypes.Public,
                    HolidaySources = HolidaySources.HistoricalHolidays
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 5),
                    EnglishName = "Constitution Day",
                    LocalName = "Սահմանադրության օր",
                    HolidayTypes = HolidayTypes.Public,
                    HolidaySources = HolidaySources.HistoricalHolidays
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 21),
                    EnglishName = "Independence Day",
                    LocalName = "Անկախության օր",
                    HolidayTypes = HolidayTypes.Public,
                    HolidaySources = HolidaySources.HistoricalHolidays
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "New Year's Eve",
                    LocalName = "Ամանոր",
                    HolidayTypes = HolidayTypes.Public,
                    HolidaySources = HolidaySources.CulturalHolidays
                },
                this._catholicProvider.EasterSunday("Ամանոր", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Armenia"
            };
        }
    }
}
