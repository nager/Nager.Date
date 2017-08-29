using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class GreeceProvider : OrthodoxBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Greece
            //https://en.wikipedia.org/wiki/Public_holidays_in_Greece

            var countryCode = CountryCode.GR;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Πρωτοχρονιά", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Θεοφάνεια", "Epiphany", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(48), "Καθαρά Δευτέρα", "Clean Monday", countryCode));
            items.Add(new PublicHoliday(year, 3, 25, "Ευαγγελισμός της Θεοτόκου", "Annunciation", countryCode));
            items.Add(new PublicHoliday(year, 3, 25, "Εικοστή Πέμπτη Μαρτίου", "Independence Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Μεγάλη Παρασκευή", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Κυριακή του Πάσχα", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Δευτέρα του Πάσχα", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Εργατική Πρωτομαγιά", "Labour Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(49), "Πεντηκοστή'", "Pentecost", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(50), "Δευτέρα Πεντηκοστής", "Whit Monday", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Κοίμηση της Θεοτόκου", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 28, "Το Όχι", "Ochi Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Χριστούγεννα", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Σύναξις Υπεραγίας Θεοτόκου Μαρίας", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }
    }
}
