using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Turkey
    /// </summary>
    public class TurkeyProvider : IPublicHolidayProvider
    {
        /// <summary>
        /// TurkeyProvider
        /// </summary>
        public TurkeyProvider()
        {
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.TR;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Yılbaşı", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 23, "Ulusal Egemenlik ve Çocuk Bayramı", "National Independence & Children's Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "İşçi Bayramı", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 19, "Atatürk'ü Anma, Gençlik ve Spor Bayramı", "Atatürk Commemoration & Youth Day", countryCode));
            items.Add(new PublicHoliday(year, 7, 15, "Demokrasi Bayramı", "Democracy Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 30, "Zafer Bayramı", "Victory Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 28, "Cumhuriyet Bayramı Arifesi", "Republic Day Eve", countryCode));
            items.Add(new PublicHoliday(year, 10, 29, "Cumhuriyet Bayramı", "Republic Day", countryCode));


            HijriCalendar hijri = new HijriCalendar();
            CultureInfo arSA = new CultureInfo("ar-SA");
            arSA.DateTimeFormat.Calendar = new HijriCalendar();
            
            var nowHijriYear = hijri.GetYear(new DateTime(year, 1, 1));

            //I balanced it by adding 1 day.

            //Add Feast of Ramadan
            var gregorianCalendarRamadanEve = DateTime.ParseExact($"30/09/{nowHijriYear}", "dd/MM/yyyy", arSA).AddDays(1);
            items.Add(new PublicHoliday(gregorianCalendarRamadanEve.Year, gregorianCalendarRamadanEve.Month, gregorianCalendarRamadanEve.Day, "Ramazan Bayramı Arifesi", "Ramadan Holiday Eve", countryCode));

            var gregorianCalendarRamadan1 = DateTime.ParseExact($"01/10/{nowHijriYear}", "dd/MM/yyyy", arSA).AddDays(1);
            items.Add(new PublicHoliday(gregorianCalendarRamadan1.Year, gregorianCalendarRamadan1.Month, gregorianCalendarRamadan1.Day, "Ramazan Bayramı 1. Günü", "Ramadan Holiday First Day", countryCode));

            var gregorianCalendarRamadan2 = DateTime.ParseExact($"02/10/{nowHijriYear}", "dd/MM/yyyy", arSA).AddDays(1);
            items.Add(new PublicHoliday(gregorianCalendarRamadan2.Year, gregorianCalendarRamadan2.Month, gregorianCalendarRamadan2.Day, "Ramazan Bayramı 2. Günü", "Ramadan Holiday Second Day", countryCode));

            var gregorianCalendarRamadan3 = DateTime.ParseExact($"03/10/{nowHijriYear}", "dd/MM/yyyy", arSA).AddDays(1);
            items.Add(new PublicHoliday(gregorianCalendarRamadan3.Year, gregorianCalendarRamadan3.Month, gregorianCalendarRamadan3.Day, "Ramazan Bayramı 3. Günü", "Ramadan Holiday Third Day", countryCode));

            //Add Feast of Eid
            var gregorianCalendarSacrificeArife = DateTime.ParseExact($"09/12/{nowHijriYear}", "dd/MM/yyyy", arSA).AddDays(1);
            items.Add(new PublicHoliday(gregorianCalendarSacrificeArife.Year, gregorianCalendarSacrificeArife.Month, gregorianCalendarSacrificeArife.Day, "Kurban Bayramı Arifesi", "Eid Holiday Eve", countryCode));

            var gregorianCalendarSacrifice1 = DateTime.ParseExact($"10/12/{nowHijriYear}", "dd/MM/yyyy", arSA).AddDays(1);
            items.Add(new PublicHoliday(gregorianCalendarSacrifice1.Year, gregorianCalendarSacrifice1.Month, gregorianCalendarSacrifice1.Day, "Kurban Bayramı 1. Günü", "Eid Holiday First Day", countryCode));

            var gregorianCalendarSacrifice2 = DateTime.ParseExact($"11/12/{nowHijriYear}", "dd/MM/yyyy", arSA).AddDays(1);
            items.Add(new PublicHoliday(gregorianCalendarSacrifice2.Year, gregorianCalendarSacrifice2.Month, gregorianCalendarSacrifice2.Day, "Kurban Bayramı 2. Günü", "Eid Holiday Second Day", countryCode));

            var gregorianCalendarSacrifice3 = DateTime.ParseExact($"12/12/{nowHijriYear}", "dd/MM/yyyy", arSA).AddDays(1);
            items.Add(new PublicHoliday(gregorianCalendarSacrifice3.Year, gregorianCalendarSacrifice3.Month, gregorianCalendarSacrifice3.Day, "Kurban Bayramı 3. Günü", "Eid Holiday Third Day", countryCode));

            var gregorianCalendarSacrifice4 = DateTime.ParseExact($"13/12/{nowHijriYear}", "dd/MM/yyyy", arSA).AddDays(1);
            items.Add(new PublicHoliday(gregorianCalendarSacrifice4.Year, gregorianCalendarSacrifice4.Month, gregorianCalendarSacrifice4.Day, "Kurban Bayramı 4. Günü", "Eid Holiday Fourth Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Turkey"
            };
        }
    }
}
