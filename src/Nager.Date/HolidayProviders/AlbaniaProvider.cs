using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Albania
    /// </summary>
    internal class AlbaniaProvider : IHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// AlbaniaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        /// <param name="orthodoxProvider"></param>
        public AlbaniaProvider(ICatholicProvider catholicProvider, IOrthodoxProvider orthodoxProvider)
        {
            this._catholicProvider = catholicProvider;
            this._orthodoxProvider = orthodoxProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.AL;

            var items = new List<Holiday>();
            items.Add(this.ApplyShiftingRules(new Holiday(year, 1, 1, "Viti i Ri", "New Year's Day", countryCode)));
            items.Add(this.ApplyShiftingRules(new Holiday(year, 1, 2, "Viti i Ri", "New Year's Day", countryCode)));
            items.Add(this.ApplyShiftingRules(new Holiday(year, 3, 14, "Dita e Verës", "Summer Day", countryCode)));
            items.Add(this.ApplyShiftingRules(new Holiday(year, 3, 22, "Dita e Sulltan Nevruzit", "Nowruz", countryCode)));
            //Catholic Easter and monday
            items.Add(this._catholicProvider.EasterSunday("Pashkët Katolike", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Hënen e Pashkët Katolike", year, countryCode));
            //Orthodox easter and monday            
            items.Add(this._orthodoxProvider.EasterSunday("Pashkët Ortodokse", year, countryCode));
            items.Add(this._orthodoxProvider.EasterMonday("Hënen e Pashkët Ortodokse", year, countryCode));
            items.Add(new Holiday(year, 5, 1, "Dita Ndërkombëtare e Punonjësve", "May Day", countryCode));
            //TODO: Eid ul-Fitr is not implemented
            //TODO: Eid ul-Adha is not implemented

            items.Add(this.ApplyShiftingRules(new Holiday(year, 10, 19, "Dita e Nënë Terezës", "Mother Teresa Day", countryCode)));
            items.Add(this.ApplyShiftingRules(new Holiday(year, 11, 28, "Dita e Pavarësisë", "Independence Day", countryCode)));
            items.Add(this.ApplyShiftingRules(new Holiday(year, 11, 29, "Dita e Çlirimit", "Liberation Day", countryCode)));
            items.Add(this.ApplyShiftingRules(new Holiday(year, 12, 08, "Dita Kombëtare e Rinisë", "Youth Day", countryCode)));
            items.Add(this.ApplyShiftingRules(new Holiday(year, 12, 25, "Krishtlindjet", "Christmas Day", countryCode)));

            return items.OrderBy(o => o.Date);
        }

        private Holiday ApplyShiftingRules(Holiday holiday)
        {
            return holiday
                .Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Albania"
            };
        }
    }
}
