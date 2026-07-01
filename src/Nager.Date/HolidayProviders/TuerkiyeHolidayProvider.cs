using Nager.Date.Extensions;
using Nager.Date.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Türkiye HolidayProvider
    /// </summary>
    internal sealed class TuerkiyeHolidayProvider : AbstractHolidayProvider
    {
        private readonly HijriCalendar _hijriCalendar;

        /// <summary>
        /// Türkiye HolidayProvider
        /// </summary>
        public TuerkiyeHolidayProvider() : base(CountryCode.TR)
        {
            this._hijriCalendar = new HijriCalendar();
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Yılbaşı",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "NATIONALINDEPENDENCE-01",
                    Date = new DateTime(year, 4, 23),
                    EnglishName = "National Independence & Children's Day",
                    LocalName = "Ulusal Egemenlik ve Çocuk Bayramı",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "İşçi Bayramı",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "ATATUERKCOMMEMORATIONYOUTHDAY-01",
                    Date = new DateTime(year, 5, 19),
                    EnglishName = "Atatürk Commemoration & Youth Day",
                    LocalName = "Atatürk'ü Anma, Gençlik ve Spor Bayramı",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "VICTORYDAY-01",
                    Date = new DateTime(year, 8, 30),
                    EnglishName = "Victory Day",
                    LocalName = "Zafer Bayramı",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "REPUBLICDAY-01",
                    Date = new DateTime(year, 10, 29),
                    EnglishName = "Republic Day",
                    LocalName = "Cumhuriyet Bayramı",
                    HolidayTypes = HolidayTypes.Public
                }
            };

            holidaySpecifications.AddIfNotNull(this.DemocracyAndNationalUnityDay(year));

            //INFO: Cannot be calculated with certainty in advance, the exact date is determined by the lunar observations
            holidaySpecifications.AddRange(this.GetEidAlFitr(year));
            holidaySpecifications.AddRange(this.GetEidAlAdha(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? DemocracyAndNationalUnityDay(int year)
        {
            if (year >= 2017)
            {
                return new HolidaySpecification
                {
                    Id = "DEMOCRACYNATIONALUNITYDAY-01",
                    Date = new DateTime(year, 7, 15),
                    EnglishName = "Democracy and National Unity Day",
                    LocalName = "Demokrasi ve Millî Birlik Günü",
                    HolidayTypes = HolidayTypes.Public
                };
            }

            return null;
        }

        private static readonly Dictionary<(int HijriYear, int HijriMonth), int> _hijriAdjustments = new()
        {
            // Correction data for Türkiye (Alignment between .NET standard algorithm and official Diyanet dates)
            // Format: { (HijriYear, HijriMonth), Offset }
            // Month 10 = Eid al-Fitr (Shawwal), Month 12 = Eid al-Adha (Dhu al-Hijjah)
            { (1431, 10), 1 },  // September 2010
            { (1431, 12), 1 },  // November 2010
            { (1432, 10), 1 },  // August 2011
            { (1432, 12), 1 },  // October 2011
            { (1433, 10), 1 },  // August 2012
            { (1433, 12), 1 },  // October 2012
            { (1434, 10), 1 },  // August 2013
            { (1434, 12), 1 },  // October 2013
            { (1435, 10), 1 },  // July 2014
            { (1435, 12), 0 },  // September 2014
            { (1436, 10), 1 },  // July 2015
            { (1436, 12), -1 },  // September 2015
            { (1437, 10), 1 },  // July 2016
            { (1437, 12), 0 },  // September 2016
            { (1438, 10), 0 },  // June 2017
            { (1438, 12), 0 },  // August 2017
            { (1439, 10), 0 },  // June 2018
            { (1439, 12), 0 },  // August 2018
            { (1440, 10), 0 },  // June 2019
            { (1440, 12), 0 },  // August 2019
            { (1441, 10), 1 },  // May 2020
            { (1441, 12), -1 },  // July 2020
            { (1442, 10), 1 },  // May 2021
            { (1442, 12), -1 },  // July 2021
            { (1443, 10), 1 },  // May 2022
            { (1443, 12), 0 },  // July 2022
            { (1444, 10), 0 },  // April 2023
            { (1444, 12), 0 },  // June 2023
            { (1445, 10), 0 },  // April 2024
            { (1445, 12), 0 },  // June 2024
            { (1446, 10), 1 },  // March 2025
            { (1446, 12), 0 },  // May 2025
            { (1447, 10), -1 }, // March 2026
            { (1447, 12), -1 }, // May 2026
            { (1448, 10), 1 },  // February 2027
            { (1448, 12), 1 },  // April 2027
            { (1449, 10), 1 },  // February 2028
            { (1449, 12), 1 },  // April 2028
            { (1450, 10), 1 },  // January 2029
            { (1450, 12), 1 },  // March 2029
            { (1451, 10), 1 },  // January 2030
            { (1451, 12), 1 },  // March 2030
            { (1452, 10), 1 },  // December 2030
            { (1452, 12), 1 },  // February 2031
            { (1453, 10), 1 },  // November 2031
            { (1453, 12), 0 },  // January 2032
            { (1454, 10), 0 },  // November 2032
            { (1454, 12), 0 },  // January 2033
            { (1455, 10), 0 },  // October 2033
            { (1455, 12), 0 },  // December 2033
            { (1456, 10), 1 },  // October 2034
            { (1456, 12), 1 },  // December 2034
            { (1457, 10), 1 },  // September 2035
            { (1457, 12), 1 },  // November 2035
            { (1458, 10), 1 },  // September 2036
            { (1458, 12), 1 },  // November 2036
            { (1459, 10), 1 },  // August 2037
            { (1459, 12), 1 },  // October 2037
            { (1460, 10), 1 },  // August 2038
            { (1460, 12), 0 },  // October 2038
            { (1461, 10), 0 },  // July 2039
            { (1461, 12), 0 },  // September 2039
            { (1462, 10), 0 },  // July 2040
            { (1462, 12), 0 }   // September 2040
        };

        /*
         * | Month | Name              | Description                                                        |
         * | ----: | ----------------- | ------------------------------------------------------------------ |
         * |     1 | Muharram          | Marks the Islamic New Year and is considered a sacred month.       |
         * |     2 | Safar             | Follows the initial sacred month.                                  |
         * |     3 | Rabi' al-Awwal    | Traditionally associated with the birth of Prophet Muhammad.       |
         * |     4 | Rabi' al-Thani    | The second month of spring.                                        |
         * |     5 | Jumada al-Ula     | The first month of dry land.                                       |
         * |     6 | Jumada al-Akhirah | The last month of dry land.                                        |
         * |     7 | Rajab             | A sacred month during which fighting was traditionally prohibited. |
         * |     8 | Sha'ban           | The month preceding Ramadan.                                       |
         * |     9 | Ramadan           | The month of fasting observed by Muslims worldwide.                |
         * |    10 | Shawwal           | Begins with Eid al-Fitr.                                           |
         * |    11 | Dhu al-Qa'dah     | A sacred month traditionally dedicated to peace.                   |
         * |    12 | Dhu al-Hijjah     | The month of Hajj pilgrimage and                                   |
         */

        /// <summary>
        /// Eid al-Fitr (Feast Of Ramadan) Holidays
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private HolidaySpecification[] GetEidAlFitr(int year)
        {
            if (year > this._hijriCalendar.MinSupportedDateTime.Year && year < this._hijriCalendar.MaxSupportedDateTime.Year)
            {
                this._hijriCalendar.HijriAdjustment = 0;
                var startHijriYear = this._hijriCalendar.GetYear(new DateTime(year, 1, 1));

                for (var hijriYear = startHijriYear; hijriYear <= startHijriYear + 2; hijriYear++)
                {
                    this._hijriCalendar.HijriAdjustment = _hijriAdjustments.TryGetValue((hijriYear, 10), out var adjustment)
                        ? adjustment
                        : 0;

                    var eidalFitrFirstDayDate = this._hijriCalendar.ToDateTime(hijriYear, 10, 1, 0, 0, 0, 0);
                    if (eidalFitrFirstDayDate.Year == year)
                    {
                        return
                        [
                            new HolidaySpecification
                            {
                                Id = "EIDALFITRFIRSTDAY-01",
                                Date = eidalFitrFirstDayDate,
                                EnglishName = "Eid al-Fitr First Day",
                                LocalName = "Ramazan Bayramı 1. Gün",
                                HolidayTypes = HolidayTypes.Public
                            },
                            new HolidaySpecification
                            {
                                Id = "EIDALFITRFIRSTDAY-02",
                                Date = eidalFitrFirstDayDate.AddDays(1),
                                EnglishName = "Eid al-Fitr Second Day",
                                LocalName = "Ramazan Bayramı 2. Gün",
                                HolidayTypes = HolidayTypes.Public
                            },
                            new HolidaySpecification
                            {
                                Id = "EIDALFITRFIRSTDAY-03",
                                Date = eidalFitrFirstDayDate.AddDays(2),
                                EnglishName = "Eid al-Fitr Third Day",
                                LocalName = "Ramazan Bayramı 3. Gün",
                                HolidayTypes = HolidayTypes.Public
                            }
                        ];
                    }
                }
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
            if (year > this._hijriCalendar.MinSupportedDateTime.Year && year < this._hijriCalendar.MaxSupportedDateTime.Year)
            {
                this._hijriCalendar.HijriAdjustment = 0;
                var startHijriYear = this._hijriCalendar.GetYear(new DateTime(year, 1, 1));

                for (var hijriYear = startHijriYear; hijriYear <= startHijriYear + 2; hijriYear++)
                {
                    this._hijriCalendar.HijriAdjustment = _hijriAdjustments.TryGetValue((hijriYear, 12), out var adjustment)
                        ? adjustment
                        : 0;

                    var eidalAdhaFirstDayDate = this._hijriCalendar.ToDateTime(hijriYear, 12, 10, 0, 0, 0, 0);
                    if (eidalAdhaFirstDayDate.Year == year)
                    {
                        return
                        [
                            new HolidaySpecification
                            {
                                Id = "EIDALADHAFIRSTDAY-01",
                                Date = eidalAdhaFirstDayDate,
                                EnglishName = "Eid al-Adha First Day",
                                LocalName = "Kurban Bayramı 1. Gün",
                                HolidayTypes = HolidayTypes.Public
                            },
                            new HolidaySpecification
                            {
                                Id = "EIDALADHAFIRSTDAY-02",
                                Date = eidalAdhaFirstDayDate.AddDays(1),
                                EnglishName = "Eid al-Adha Second Day",
                                LocalName = "Kurban Bayramı 2. Gün",
                                HolidayTypes = HolidayTypes.Public
                            },
                            new HolidaySpecification
                            {
                                Id = "EIDALADHAFIRSTDAY-03",
                                Date = eidalAdhaFirstDayDate.AddDays(2),
                                EnglishName = "Eid al-Adha Third Day",
                                LocalName = "Kurban Bayramı 3. Gün",
                                HolidayTypes = HolidayTypes.Public
                            },
                            new HolidaySpecification
                            {
                                Id = "EIDALADHAFIRSTDAY-04",
                                Date = eidalAdhaFirstDayDate.AddDays(3),
                                EnglishName = "Eid al-Adha Fourth Day",
                                LocalName = "Kurban Bayramı 4. Gün",
                                HolidayTypes = HolidayTypes.Public
                            }
                        ];
                    }
                }
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
