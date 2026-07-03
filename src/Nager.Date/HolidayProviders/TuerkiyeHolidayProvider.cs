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

        private static readonly Dictionary<(int HijriYear, int HijriMonth), HijriAdjustmentInfo> _hijriAdjustments = new()
        {
            // Correction data for Türkiye (Alignment between .NET standard algorithm and official Diyanet dates)
            // Format: { (HijriYear, HijriMonth), new HijriAdjustmentInfo { Offset = X, IsVerified = true/false } }
            // Month 10 = Eid al-Fitr (Shawwal), Month 12 = Eid al-Adha (Dhu al-Hijjah)
            { (1431, 10), new() { Offset = 0, IsVerified = true } },  // 2010 September
            { (1431, 12), new() { Offset = 0, IsVerified = true } },  // 2010 November
            { (1432, 10), new() { Offset = 0, IsVerified = true } },  // 2011 August
            { (1432, 12), new() { Offset = 0, IsVerified = true } },  // 2011 October
            { (1433, 10), new() { Offset = -1, IsVerified = true } }, // 2012 August
            { (1433, 12), new() { Offset = -1, IsVerified = true } }, // 2012 October
            { (1434, 10), new() { Offset = -1, IsVerified = true } }, // 2013 August
            { (1434, 12), new() { Offset = -1, IsVerified = true } }, // 2013 October
            { (1435, 10), new() { Offset = 0, IsVerified = true } },  // 2014 July
            { (1435, 12), new() { Offset = 0, IsVerified = true } },  // 2014 September
            { (1436, 10), new() { Offset = 0, IsVerified = true } },  // 2015 July
            { (1436, 12), new() { Offset = -1, IsVerified = true } }, // 2015 September
            { (1437, 10), new() { Offset = 1, IsVerified = true } },  // 2016 July
            { (1437, 12), new() { Offset = 0, IsVerified = true } },  // 2016 September
            { (1438, 10), new() { Offset = 0, IsVerified = true } },  // 2017 June
            { (1438, 12), new() { Offset = 0, IsVerified = true } },  // 2017 August
            { (1439, 10), new() { Offset = -1, IsVerified = true } }, // 2018 June
            { (1439, 12), new() { Offset = 0, IsVerified = true } },  // 2018 August
            { (1440, 10), new() { Offset = 0, IsVerified = true } },  // 2019 June
            { (1440, 12), new() { Offset = 0, IsVerified = true } },  // 2019 August
            { (1441, 10), new() { Offset = -1, IsVerified = true } }, // 2020 May
            { (1441, 12), new() { Offset = -1, IsVerified = true } }, // 2020 July
            { (1442, 10), new() { Offset = -1, IsVerified = true } }, // 2021 May
            { (1442, 12), new() { Offset = -1, IsVerified = true } }, // 2021 July
            { (1443, 10), new() { Offset = 0, IsVerified = true } },  // 2022 May
            { (1443, 12), new() { Offset = 0, IsVerified = true } },  // 2022 July
            { (1444, 10), new() { Offset = 0, IsVerified = true } },  // 2023 April
            { (1444, 12), new() { Offset = 0, IsVerified = true } },  // 2023 June
            { (1445, 10), new() { Offset = -1, IsVerified = true } }, // 2024 April
            { (1445, 12), new() { Offset = 0, IsVerified = true } },  // 2024 June
            { (1446, 10), new() { Offset = 0, IsVerified = true } },  // 2025 March
            { (1446, 12), new() { Offset = 0, IsVerified = true } },  // 2025 May
            { (1447, 10), new() { Offset = -1, IsVerified = true } }, // 2026 March
            { (1447, 12), new() { Offset = -1, IsVerified = true } }, // 2026 May
            { (1448, 10), new() { Offset = -1, IsVerified = false } },// 2027 February
            { (1448, 12), new() { Offset = 0, IsVerified = false } }, // 2027 April
            { (1449, 10), new() { Offset = -1, IsVerified = false } },// 2028 February
            { (1449, 12), new() { Offset = -1, IsVerified = false } },// 2028 April
            { (1450, 10), new() { Offset = -1, IsVerified = false } },// 2029 January
            { (1450, 12), new() { Offset = -1, IsVerified = false } },// 2029 March
            { (1451, 10), new() { Offset = -1, IsVerified = false } },// 2030 January
            { (1451, 12), new() { Offset = -1, IsVerified = false } },// 2030 March
            { (1452, 10), new() { Offset = 1, IsVerified = false } }, // 2030 December
        };

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

                var month = 10; //Shawwal
                var items = new List<HolidaySpecification>();

                for (var hijriYear = startHijriYear; hijriYear <= startHijriYear + 2; hijriYear++)
                {
                    var tentativeInfo = "";
                    this._hijriCalendar.HijriAdjustment = 0;
                    if (_hijriAdjustments.TryGetValue((hijriYear, month), out var hirjiAdjustmentInfo))
                    {
                        this._hijriCalendar.HijriAdjustment = hirjiAdjustmentInfo.Offset;
                        if (!hirjiAdjustmentInfo.IsVerified)
                        {
                            tentativeInfo = " (Tentative Date)";
                        }
                    }
                    else
                    {
                        continue;
                    }

                    var eidalFitrFirstDayDate = this._hijriCalendar.ToDateTime(hijriYear, month, 1, 0, 0, 0, 0);
                    var eidalFitrSecondDayDate = this._hijriCalendar.ToDateTime(hijriYear, month, 2, 0, 0, 0, 0);
                    var eidalFitrThirdDayDate = this._hijriCalendar.ToDateTime(hijriYear, month, 3, 0, 0, 0, 0);

                    if (eidalFitrFirstDayDate.Year == year)
                    {
                        items.Add(new HolidaySpecification
                        {
                            Id = $"EIDALFITR-{hijriYear}-01",
                            Date = eidalFitrFirstDayDate,
                            EnglishName = $"Eid al-Fitr First Day{tentativeInfo}",
                            LocalName = $"Ramazan Bayramı 1. Gün{tentativeInfo}",
                            HolidayTypes = HolidayTypes.Public,
                        });
                    }

                    if (eidalFitrSecondDayDate.Year == year)
                    {
                        items.Add(new HolidaySpecification
                        {
                            Id = $"EIDALFITR-{hijriYear}-02",
                            Date = eidalFitrSecondDayDate,
                            EnglishName = $"Eid al-Fitr Second Day{tentativeInfo}",
                            LocalName = $"Ramazan Bayramı 2. Gün{tentativeInfo}",
                            HolidayTypes = HolidayTypes.Public,
                        });
                    }

                    if (eidalFitrThirdDayDate.Year == year)
                    {
                        items.Add(new HolidaySpecification
                        {
                            Id = $"EIDALFITR-{hijriYear}-03",
                            Date = eidalFitrThirdDayDate,
                            EnglishName = $"Eid al-Fitr Third Day{tentativeInfo}",
                            LocalName = $"Ramazan Bayramı 3. Gün{tentativeInfo}",
                            HolidayTypes = HolidayTypes.Public,
                        });
                    }
                }

                return [.. items];
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

                var month = 12; //Dhu al-Hijjah
                var items = new List<HolidaySpecification>();

                for (var hijriYear = startHijriYear; hijriYear <= startHijriYear + 2; hijriYear++)
                {
                    var tentativeInfo = "";
                    this._hijriCalendar.HijriAdjustment = 0;
                    if (_hijriAdjustments.TryGetValue((hijriYear, month), out var hirjiAdjustmentInfo))
                    {
                        this._hijriCalendar.HijriAdjustment = hirjiAdjustmentInfo.Offset;
                        if (!hirjiAdjustmentInfo.IsVerified)
                        {
                            tentativeInfo = " (Tentative Date)";
                        }
                    }
                    else
                    {
                        continue;
                    }

                    var eidalAdhaFirstDayDate = this._hijriCalendar.ToDateTime(hijriYear, month, 10, 0, 0, 0, 0);
                    var eidalAdhaSecondDayDate = this._hijriCalendar.ToDateTime(hijriYear, month, 11, 0, 0, 0, 0);
                    var eidalAdhaThirdDayDate = this._hijriCalendar.ToDateTime(hijriYear, month, 12, 0, 0, 0, 0);
                    var eidalAdhaFourthDayDate = this._hijriCalendar.ToDateTime(hijriYear, month, 13, 0, 0, 0, 0);

                    if (eidalAdhaFirstDayDate.Year == year)
                    {
                        items.Add(new HolidaySpecification
                        {
                            Id = $"EIDALADHA-{hijriYear}-01",
                            Date = eidalAdhaFirstDayDate,
                            EnglishName = $"Eid al-Adha First Day{tentativeInfo}",
                            LocalName = $"Kurban Bayramı 1. Gün{tentativeInfo}",
                            HolidayTypes = HolidayTypes.Public,
                        });
                    }

                    if (eidalAdhaSecondDayDate.Year == year)
                    {
                        items.Add(new HolidaySpecification
                        {
                            Id = $"EIDALADHA-{hijriYear}-02",
                            Date = eidalAdhaSecondDayDate,
                            EnglishName = $"Eid al-Adha Second Day{tentativeInfo}",
                            LocalName = $"Kurban Bayramı 2. Gün{tentativeInfo}",
                            HolidayTypes = HolidayTypes.Public,
                        });
                    }

                    if (eidalAdhaThirdDayDate.Year == year)
                    {
                        items.Add(new HolidaySpecification
                        {
                            Id = $"EIDALADHA-{hijriYear}-03",
                            Date = eidalAdhaThirdDayDate,
                            EnglishName = $"Eid al-Adha Third Day{tentativeInfo}",
                            LocalName = $"Kurban Bayramı 3. Gün{tentativeInfo}",
                            HolidayTypes = HolidayTypes.Public,
                        });
                    }

                    if (eidalAdhaFourthDayDate.Year == year)
                    {
                        items.Add(new HolidaySpecification
                        {
                            Id = $"EIDALADHA-{hijriYear}-04",
                            Date = eidalAdhaFourthDayDate,
                            EnglishName = $"Eid al-Adha Fourth Day{tentativeInfo}",
                            LocalName = $"Kurban Bayramı 4. Gün{tentativeInfo}",
                            HolidayTypes = HolidayTypes.Public
                        });
                    }
                }

                return [.. items];
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
