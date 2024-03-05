using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Svalbard and Jan Mayen HolidayProvider
    /// </summary>
    internal class SvalbardAndJanMayenHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Svalbard and Jan Mayen HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SvalbardAndJanMayenHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.SJ;

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Første nyttårsdag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "May Day",
                    LocalName = "Første mai",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 17),
                    EnglishName = "Constitution Day",
                    LocalName = "Syttende mai",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Første juledag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Second day of Christmas",
                    LocalName = "Andre juledag",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.MaundyThursday("Skjærtorsdag", year),
                this._catholicProvider.GoodFriday("Langfredag", year),
                this._catholicProvider.EasterSunday("Første påskedag", year),
                this._catholicProvider.EasterMonday("Andre påskedag", year),
                this._catholicProvider.AscensionDay("Kristi himmelfartsdag", year),
                this._catholicProvider.Pentecost("Første pinsedag", year),
                this._catholicProvider.WhitMonday("Andre pinsedag", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Første nyttårsdag", "New Year's Day", countryCode));
            //items.Add(this._catholicProvider.MaundyThursday("Skjærtorsdag", year, countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Langfredag", year, countryCode));
            //items.Add(this._catholicProvider.EasterSunday("Første påskedag", year, countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Andre påskedag", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Første mai", "May Day", countryCode));
            //items.Add(new Holiday(year, 5, 17, "Syttende mai", "Constitution Day", countryCode));
            //items.Add(this._catholicProvider.AscensionDay("Kristi himmelfartsdag", year, countryCode));
            //items.Add(this._catholicProvider.Pentecost("Første pinsedag", year, countryCode));
            //items.Add(this._catholicProvider.WhitMonday("Andre pinsedag", year, countryCode));
            //items.Add(new Holiday(year, 12, 25, "Første juledag", "Christmas Day", countryCode));
            //items.Add(new Holiday(year, 12, 26, "Andre juledag", "Second day of Christmas", countryCode));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Svalbard"
            };
        }
    }
}
