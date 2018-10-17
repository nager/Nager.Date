using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    public class MacedoniaProvider : OrthodoxBaseProvider
    {
        public MacedoniaProvider(IWeekendProvider weekendProvider) : base(weekendProvider)
        {
        }

        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //Macedonia
            //https://en.wikipedia.org/wiki/Public_holidays_in_Macedonia

            var countryCode = CountryCode.MK;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Нова Година, Nova Godina", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 7, "Прв ден Божик, Prv den Božik", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Велики Петок, Veliki Petok", "Good Friday", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Прв ден Велигден, Prv den Veligden", "Easter Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Втор ден Велигден, Vtor den Veligden", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Ден на трудот, Den na trudot", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 24, "Св. Кирил и Методиј, Ден на сèсловенските просветители", "Saints Cyril and Methodius Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 2, "Ден на Републиката, Den na Republikata", "Day of the Republic", countryCode));
            items.Add(new PublicHoliday(year, 9, 8, "Ден на независноста, Den na nezavisnosta", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 11, "Ден на востанието, Den na vostanieto", "Revolution Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 23, "Ден на македонската револуционерна борба,Den na makedonskata revolucionarna borba", "Day of the Macedonian Revolutionary Struggle", countryCode));
            items.Add(new PublicHoliday(year, 12, 8, "Св. Климент Охридски, Sv. Kliment Ohridski", "Saint Clement of Ohrid Day", countryCode));
            //items.Add(new PublicHoliday(year, ??, ??, "Рамазан Бајрам, Ramazan Bajram", "Eid al-Fitr", countryCode)); //Islamic

            return items.OrderBy(o => o.Date);
        }
    }
}
