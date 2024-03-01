using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Greece HolidayProvider
    /// </summary>
    internal class GreeceHolidayProvider : IHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// Greece HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public GreeceHolidayProvider(
            IOrthodoxProvider orthodoxProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.GR;
            var easterSunday = this._orthodoxProvider.EasterSunday(year);

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Πρωτοχρονιά", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 1, 6, "Θεοφάνεια", "Epiphany", countryCode));
            items.Add(new Holiday(easterSunday.AddDays(-48), "Καθαρά Δευτέρα", "Clean Monday", countryCode));
            items.Add(new Holiday(year, 3, 25, "Ευαγγελισμός της Θεοτόκου", "Annunciation", countryCode));
            items.Add(new Holiday(year, 3, 25, "Εικοστή Πέμπτη Μαρτίου", "Independence Day", countryCode));
            items.Add(this._orthodoxProvider.GoodFriday("Μεγάλη Παρασκευή", year, countryCode));
            items.Add(this._orthodoxProvider.EasterSunday("Κυριακή του Πάσχα", year, countryCode));
            items.Add(this._orthodoxProvider.EasterMonday("Δευτέρα του Πάσχα", year, countryCode));
            items.Add(new Holiday(year, 5, 1, "Εργατική Πρωτομαγιά", "Labour Day", countryCode));
            items.Add(this._orthodoxProvider.Pentecost("Πεντηκοστή", year, countryCode));
            items.Add(this._orthodoxProvider.WhitMonday("Δευτέρα Πεντηκοστής", year, countryCode));
            items.Add(new Holiday(year, 8, 15, "Κοίμηση της Θεοτόκου", "Assumption Day", countryCode));
            items.Add(new Holiday(year, 10, 28, "Το Όχι", "Ochi Day", countryCode));
            items.Add(new Holiday(year, 12, 25, "Χριστούγεννα", "Christmas Day", countryCode));
            items.Add(new Holiday(year, 12, 26, "Σύναξις Υπεραγίας Θεοτόκου Μαρίας", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Greece",
            };
        }
    }
}