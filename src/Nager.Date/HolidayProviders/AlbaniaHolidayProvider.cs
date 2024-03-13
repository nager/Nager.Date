using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Albania HolidayProvider
    /// </summary>
    internal sealed class AlbaniaHolidayProvider : IHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Albania HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        /// <param name="orthodoxProvider"></param>
        public AlbaniaHolidayProvider(
            ICatholicProvider catholicProvider,
            IOrthodoxProvider orthodoxProvider)
        {
            this._catholicProvider = catholicProvider;
            this._orthodoxProvider = orthodoxProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.AL;

            var observedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1),
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new()
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Viti i Ri",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new()
                {
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "New Year's Day",
                    LocalName = "Viti i Ri",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new()
                {
                    Date = new DateTime(year, 3, 14),
                    EnglishName = "Summer Day",
                    LocalName = "Dita e Verës",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new()
                {
                    Date = new DateTime(year, 3, 22),
                    EnglishName = "Nowruz",
                    LocalName = "Dita e Sulltan Nevruzit",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new()
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "May Day",
                    LocalName = "Dita Ndërkombëtare e Punonjësve",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new()
                {
                    Date = new DateTime(year, 9, 05),
                    EnglishName = "Mother Teresa Day",
                    LocalName = "Dita e Nënë Terezës",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new()
                {
                    Date = new DateTime(year, 11, 28),
                    EnglishName = "Independence Day",
                    LocalName = "Dita e Pavarësisë",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new()
                {
                    Date = new DateTime(year, 11, 29),
                    EnglishName = "Liberation Day",
                    LocalName = "Dita e Çlirimit",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new()
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Youth Day",
                    LocalName = "Dita Kombëtare e Rinisë",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new()
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Krishtlindjet",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                this._catholicProvider.EasterSunday("Pashkët Katolike", year),
                this._catholicProvider.EasterMonday("E hëna e Pashkëve Katolike", year),
                this._orthodoxProvider.EasterSunday("Pashkët Ortodokse", year),
                this._orthodoxProvider.EasterMonday("E hëna e Pashkëve Ortodokse", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //TODO: Eid ul-Fitr is not implemented
            //TODO: Eid ul-Adha is not implemented


        }


        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Albania",
                "https://www.bankofalbania.org/Shtypi/Kalendari_i_festave_zyrtare_2024"
            };
        }
    }
}
