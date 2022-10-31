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
    internal class TurkeyProvider : IPublicHolidayProvider
    {
        /// <summary>
        /// TurkeyProvider
        /// </summary>
        public TurkeyProvider()
        {
        }

        /// <summary>
        /// Convert Hijri Date To Geregorian Date
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        private DateTime ConvertHijriToGregorian(int year, int month, int day)
        {
            var calender = new UmAlQuraCalendar();
            return calender.ToDateTime(year, month, day, 0, 0, 0, 0);
        }

        /// <summary>
        /// Eid al-Fitr(Feast Of Ramadan) Holidays
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private List<PublicHoliday> GetEidAlFitr(int year)
        {
            var countryCode = CountryCode.TR;
            var items = new List<PublicHoliday>();
            var diff = year - 621;
            var hijriYear = Convert.ToInt32(Math.Round(diff + decimal.Divide(diff, 33)));

            var calculateDate = this.ConvertHijriToGregorian(hijriYear, 10, 1);
            items.Add(new PublicHoliday(year, calculateDate.Month, calculateDate.Day, "Ramazan Bayramı 1. Gün", "Eid al-Fitr First Day", countryCode));

            calculateDate = this.ConvertHijriToGregorian(hijriYear, 10, 2);
            items.Add(new PublicHoliday(year, calculateDate.Month, calculateDate.Day, "Ramazan Bayramı 2. Gün", "Eid al-Fitr Second Day", countryCode));

            calculateDate = this.ConvertHijriToGregorian(hijriYear, 10, 3);
            items.Add(new PublicHoliday(year, calculateDate.Month, calculateDate.Day, "Ramazan Bayramı 3. Gün", "Eid al-Fitr Third Day", countryCode));

            return items;
        }

        /// <summary>
        /// Eid al-Adha(Feast Of Sacrifice) Holidays
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private List<PublicHoliday> GetEidAlAdha(int year)
        {
            var countryCode = CountryCode.TR;
            var items = new List<PublicHoliday>();
            var diff = year - 621;
            var hijriYear = Convert.ToInt32(Math.Round(diff + decimal.Divide(diff, 33)));

            var calculateDate = this.ConvertHijriToGregorian(hijriYear, 12, 10);
            items.Add(new PublicHoliday(year, calculateDate.Month, calculateDate.Day, "Kurban Bayramı 1. Gün", "Eid al-Adha First Day", countryCode));

            calculateDate = this.ConvertHijriToGregorian(hijriYear, 12, 11);
            items.Add(new PublicHoliday(year, calculateDate.Month, calculateDate.Day, "Kurban Bayramı 2. Gün", "Eid al-Adha Second Day", countryCode));

            calculateDate = this.ConvertHijriToGregorian(hijriYear, 12, 12);
            items.Add(new PublicHoliday(year, calculateDate.Month, calculateDate.Day, "Kurban Bayramı 3. Gün", "Eid al-Adhae Third Day", countryCode));

            calculateDate = this.ConvertHijriToGregorian(hijriYear, 12, 13);
            items.Add(new PublicHoliday(year, calculateDate.Month, calculateDate.Day, "Kurban Bayramı 4. Gün", "Eid al-Adha Fourth Day", countryCode));
            return items;
        }

        /// <summary>
        /// Get Public Holidays for Turkey
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            var countryCode = CountryCode.TR;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Yılbaşı", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 23, "Ulusal Egemenlik ve Çocuk Bayramı", "National Independence & Children's Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "İşçi Bayramı", "Labour Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 19, "Atatürk'ü Anma, Gençlik ve Spor Bayramı", "Atatürk Commemoration & Youth Day", countryCode));
            items.Add(new PublicHoliday(year, 8, 30, "Zafer Bayramı", "Victory Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 29, "Cumhuriyet Bayramı", "Republic Day", countryCode));

            items.AddRange(this.GetEidAlFitr(year));
            items.AddRange(this.GetEidAlAdha(year));

            if (year >= 2017)
            {
                items.Add(new PublicHoliday(year, 7, 15, "Demokrasi ve Millî Birlik Günü", "Democracy and National Unity Day", countryCode));
            }

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
