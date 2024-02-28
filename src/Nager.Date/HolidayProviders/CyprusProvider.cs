using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Cyprus
    /// </summary>
    internal class CyprusProvider : IHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// CyprusProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public CyprusProvider(IOrthodoxProvider orthodoxProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.CY;
            var easterSunday = this._orthodoxProvider.EasterSunday(year);

            var items = new List<Holiday>();
            items.Add(new Holiday(year, 1, 1, "Πρωτοχρονιά", "New Year's Day", countryCode));
            items.Add(new Holiday(year, 1, 6, "Θεοφάνεια", "Epiphany", countryCode));
            items.Add(new Holiday(easterSunday.AddDays(-48), "Καθαρή Δευτέρα", "Green Monday", countryCode));
            items.Add(new Holiday(year, 3, 25, "Επέτειος Ελληνικής Ανεξαρτησίας", "Greek Independence Day", countryCode));
            items.Add(new Holiday(year, 4, 1, "Κυπριακή Εθνική Επέτειος", "Cyprus National Day", countryCode));
            items.Add(this._orthodoxProvider.GoodFriday("Μεγάλη Παρασκευή", year, countryCode));
            //Holy Saturday // Μεγάλο Σάββατο??
            items.Add(this._orthodoxProvider.EasterMonday("Δευτέρα της Διακαινησίμου", year, countryCode));
            items.Add(new Holiday(easterSunday.AddDays(2), "Τρίτη της Διακαινησίμου", "Easter Tuesday", countryCode));
            items.Add(new Holiday(year, 5, 1, "Πρωτομαγιά", "Labour Day", countryCode));
            items.Add(this._orthodoxProvider.Pentecost("Αγίου Πνεύματος", year, countryCode));
            items.Add(this._orthodoxProvider.WhitMonday("Δευτέρα Πεντηκοστής", year, countryCode));
            items.Add(new Holiday(year, 8, 15, "Η Κοίμησις της Θεοτόκου", "Assumption of the Virgin Mary", countryCode));
            items.Add(new Holiday(year, 10, 1, "Επέτειος Κυπριακής Ανεξαρτησίας", "Cyprus Independence Day", countryCode));
            items.Add(new Holiday(year, 10, 28, "Το Όχι", "Ohi Day", countryCode));
            items.Add(new Holiday(year, 12, 24, "Παραμονή Χριστουγέννων", "Christmas Eve", countryCode));
            items.Add(new Holiday(year, 12, 25, "Χριστούγεννα", "Christmas Day", countryCode));
            items.Add(new Holiday(year, 12, 26, "Δεύτερη μέρα των Χριστουγέννων", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Cyprus",
            };
        }
    }
}
