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
        private readonly UmAlQuraCalendar _umAlQuraCalendar;

        /// <summary>
        /// TurkeyProvider
        /// </summary>
        public TurkeyProvider()
        {
            this._umAlQuraCalendar = new UmAlQuraCalendar();
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
            return this._umAlQuraCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
        }

        private int GetHijriYear(int year)
        {
            var diff = year - 621;
            return Convert.ToInt32(Math.Round(diff + decimal.Divide(diff, 33)));
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

            items.AddRange(this.GetEidAlFitr(year, countryCode));
            items.AddRange(this.GetEidAlAdha(year, countryCode));

            if (year >= 2017)
            {
                items.Add(new PublicHoliday(year, 7, 15, "Demokrasi ve Millî Birlik Günü", "Democracy and National Unity Day", countryCode));
            }

            return items.OrderBy(o => o.Date);
        }

        /// <summary>
        /// Eid al-Fitr (Feast Of Ramadan) Holidays
        /// </summary>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        private PublicHoliday[] GetEidAlFitr(int year, CountryCode countryCode)
        {
            if (year > this._umAlQuraCalendar.MinSupportedDateTime.Year && year < this._umAlQuraCalendar.MaxSupportedDateTime.Year)
            {
                var hijriYear = this.GetHijriYear(year);
                var calculateDate1 = this.ConvertHijriToGregorian(hijriYear, 10, 1);
                var calculateDate2 = this.ConvertHijriToGregorian(hijriYear, 10, 2);
                var calculateDate3 = this.ConvertHijriToGregorian(hijriYear, 10, 3);

                return new PublicHoliday[]
                {
                    new PublicHoliday(year, calculateDate1.Month, calculateDate1.Day, "Ramazan Bayramı 1. Gün", "Eid al-Fitr First Day", countryCode),
                    new PublicHoliday(year, calculateDate2.Month, calculateDate2.Day, "Ramazan Bayramı 2. Gün", "Eid al-Fitr Second Day", countryCode),
                    new PublicHoliday(year, calculateDate3.Month, calculateDate3.Day, "Ramazan Bayramı 3. Gün", "Eid al-Fitr Third Day", countryCode)
                };
            }

            return Array.Empty<PublicHoliday>();
        }

        /// <summary>
        /// Eid al-Adha (Feast Of Sacrifice) Holidays
        /// </summary>
        /// <param name="year"></param>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        private PublicHoliday[] GetEidAlAdha(int year, CountryCode countryCode)
        {
            if (year > this._umAlQuraCalendar.MinSupportedDateTime.Year && year < this._umAlQuraCalendar.MaxSupportedDateTime.Year)
            {
                var hijriYear = this.GetHijriYear(year);
                var calculateDate1 = this.ConvertHijriToGregorian(hijriYear, 12, 10);
                var calculateDate2 = this.ConvertHijriToGregorian(hijriYear, 12, 11);
                var calculateDate3 = this.ConvertHijriToGregorian(hijriYear, 12, 12);
                var calculateDate4 = this.ConvertHijriToGregorian(hijriYear, 12, 13);

                return new PublicHoliday[]
                {
                    new PublicHoliday(year, calculateDate1.Month, calculateDate1.Day, "Kurban Bayramı 1. Gün", "Eid al-Adha First Day", countryCode),
                    new PublicHoliday(year, calculateDate2.Month, calculateDate2.Day, "Kurban Bayramı 2. Gün", "Eid al-Adha Second Day", countryCode),
                    new PublicHoliday(year, calculateDate3.Month, calculateDate3.Day, "Kurban Bayramı 3. Gün", "Eid al-Adha Third Day", countryCode),
                    new PublicHoliday(year, calculateDate4.Month, calculateDate4.Day, "Kurban Bayramı 4. Gün", "Eid al-Adha Fourth Day", countryCode)
                };
            }

            return Array.Empty<PublicHoliday>();
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
