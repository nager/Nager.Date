using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Vatican City
    /// </summary>
    internal class VaticanCityProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// VaticanCityProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public VaticanCityProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.VA;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Maria Santissima Madre di Dio", "Solemnity of Mary, Mother of God", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Epifania del Signore", "Epiphany", countryCode));
            items.Add(new PublicHoliday(year, 2, 11, "Anniversario della istituzione dello Stato della Città del Vaticano", "Anniversary of the foundation of Vatican City", countryCode));
            items.Add(new PublicHoliday(year, 3, 13, "Anniversario dell'Elezione del Santo Padre", "Anniversary of the election of Pope Francis", countryCode));
            items.Add(new PublicHoliday(year, 3, 19, "San Giuseppe", "Saint Joseph's Day", countryCode));
            items.Add(this._catholicProvider.EasterMonday("Lunedì dell'Angelo", year, countryCode));
            items.Add(new PublicHoliday(year, 4, 23, "Onomastico del Santo Padre", "Saint George", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "San Giuseppe lavoratore", "Saint Joseph the Worker", countryCode));
            items.Add(new PublicHoliday(year, 6, 29, "Santi Pietro e Paolo", "Saints Peter and Paul", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Assunzione di Maria in Cielo", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 9, 8, "Festa della natività della madonna", "Nativity of Mary", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Tutti i santi, Ognissanti", "All Saints", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Immacolata Concezione", "Immaculate Conception", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Natale", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Santo Stefano", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Vatican_City"
            };
        }
    }
}
