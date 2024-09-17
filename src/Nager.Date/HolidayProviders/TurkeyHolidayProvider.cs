using Nager.Date.Extensions;
using Nager.Date.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Turkey HolidayProvider
    /// </summary>
    internal sealed class TurkeyHolidayProvider : AbstractHolidayProvider
    {
        private readonly UmAlQuraCalendar _umAlQuraCalendar;

        /// <summary>
        /// Turkey HolidayProvider
        /// </summary>
        public TurkeyHolidayProvider() : base(CountryCode.TR)
        {
            this._umAlQuraCalendar = new UmAlQuraCalendar();
        }

        /// <summary>
        /// Convert Hijri Date To Gregorian Date
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
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Yılbaşı",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 23),
                    EnglishName = "National Independence & Children's Day",
                    LocalName = "Ulusal Egemenlik ve Çocuk Bayramı",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "İşçi Bayramı",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 19),
                    EnglishName = "Atatürk Commemoration & Youth Day",
                    LocalName = "Atatürk'ü Anma, Gençlik ve Spor Bayramı",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 30),
                    EnglishName = "Victory Day",
                    LocalName = "Zafer Bayramı",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 29),
                    EnglishName = "Republic Day",
                    LocalName = "Cumhuriyet Bayramı",
                    HolidayTypes = HolidayTypes.Public
                }
            };

            holidaySpecifications.AddIfNotNull(this.DemocracyAndNationalUnityDay(year));

            //INFO: Cannot be calculated with certainty in advance, the exact date is determined by the lunar observations
            //holidaySpecifications.AddRange(this.GetEidAlFitr(year));
            //holidaySpecifications.AddRange(this.GetEidAlAdha(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? DemocracyAndNationalUnityDay(int year)
        {
            if (year >= 2017)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 15),
                    EnglishName = "Democracy and National Unity Day",
                    LocalName = "Demokrasi ve Millî Birlik Günü",
                    HolidayTypes = HolidayTypes.Public
                };
            }

            return null;
        }

        /// <summary>
        /// Eid al-Fitr (Feast Of Ramadan) Holidays
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private HolidaySpecification[] GetEidAlFitr(int year)
        {
            if (year > this._umAlQuraCalendar.MinSupportedDateTime.Year && year < this._umAlQuraCalendar.MaxSupportedDateTime.Year)
            {
                var hijriYear = this.GetHijriYear(year);
                var calculateDate1 = this.ConvertHijriToGregorian(hijriYear, 10, 1);
                var calculateDate2 = this.ConvertHijriToGregorian(hijriYear, 10, 2);
                var calculateDate3 = this.ConvertHijriToGregorian(hijriYear, 10, 3);

                return
                [
                    new HolidaySpecification
                    {
                        Date = new DateTime(year, calculateDate1.Month, calculateDate1.Day),
                        EnglishName = "Eid al-Fitr First Day",
                        LocalName = "Ramazan Bayramı 1. Gün",
                        HolidayTypes = HolidayTypes.Public
                    },
                    new HolidaySpecification
                    {
                        Date = new DateTime(year, calculateDate2.Month, calculateDate2.Day),
                        EnglishName = "Eid al-Fitr Second Day",
                        LocalName = "Ramazan Bayramı 2. Gün",
                        HolidayTypes = HolidayTypes.Public
                    },
                    new HolidaySpecification
                    {
                        Date = new DateTime(year, calculateDate3.Month, calculateDate3.Day),
                        EnglishName = "Eid al-Fitr Third Day",
                        LocalName = "Ramazan Bayramı 3. Gün",
                        HolidayTypes = HolidayTypes.Public
                    }
                ];
            }

            return [];
        }

        /// <summary>
        /// Eid al-Adha (Feast Of Sacrifice) Holidays
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private HolidaySpecification[] GetEidAlAdha(int year)
        {
            if (year > this._umAlQuraCalendar.MinSupportedDateTime.Year && year < this._umAlQuraCalendar.MaxSupportedDateTime.Year)
            {
                var hijriYear = this.GetHijriYear(year);
                var calculateDate1 = this.ConvertHijriToGregorian(hijriYear, 12, 10);
                var calculateDate2 = this.ConvertHijriToGregorian(hijriYear, 12, 11);
                var calculateDate3 = this.ConvertHijriToGregorian(hijriYear, 12, 12);
                var calculateDate4 = this.ConvertHijriToGregorian(hijriYear, 12, 13);

                return
                [
                    new HolidaySpecification
                    {
                        Date = new DateTime(year, calculateDate1.Month, calculateDate1.Day),
                        EnglishName = "Eid al-Adha First Day",
                        LocalName = "Kurban Bayramı 1. Gün",
                        HolidayTypes = HolidayTypes.Public
                    },
                    new HolidaySpecification
                    {
                        Date = new DateTime(year, calculateDate2.Month, calculateDate2.Day),
                        EnglishName = "Eid al-Adha Second Day",
                        LocalName = "Kurban Bayramı 2. Gün",
                        HolidayTypes = HolidayTypes.Public
                    },
                    new HolidaySpecification
                    {
                        Date = new DateTime(year, calculateDate3.Month, calculateDate3.Day),
                        EnglishName = "Eid al-Adha Third Day",
                        LocalName = "Kurban Bayramı 3. Gün",
                        HolidayTypes = HolidayTypes.Public
                    },
                    new HolidaySpecification
                    {
                        Date = new DateTime(year, calculateDate4.Month, calculateDate4.Day),
                        EnglishName = "Eid al-Adha Fourth Day",
                        LocalName = "Kurban Bayramı 4. Gün",
                        HolidayTypes = HolidayTypes.Public
                    }
                ];
            }

            return [];
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Turkey"
            ];
        }
    }
}
