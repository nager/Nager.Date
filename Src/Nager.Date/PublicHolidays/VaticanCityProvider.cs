using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nager.Date.PublicHolidays 
{
    public class VaticanCityProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Vatican City
            //https://en.wikipedia.org/wiki/Public_holidays_in_Vatican_City

            var countryCode = CountryCode.IT;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();

            items.Add(new PublicHoliday(year, 1, 1, "Maria Santissima Madre di Dio", "Solemnity of Mary, Mother of God", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Epifania del Signore", "Epiphany", countryCode));
            items.Add(new PublicHoliday(year, 2, 11, "Anniversario della istituzione dello Stato della Città del Vaticano", "Anniversary of the foundation of Vatican City", countryCode));
            items.Add(new PublicHoliday(year, 3, 13, "Anniversario dell'Elezione del Santo Padre", "Anniversary of the election of Pope Francis	", countryCode));
            items.Add(new PublicHoliday(year, 3, 19, "San Giuseppe", "Saint Joseph's Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Lunedì dell'Angelo", "Easter Monday", countryCode));
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
    }
}
