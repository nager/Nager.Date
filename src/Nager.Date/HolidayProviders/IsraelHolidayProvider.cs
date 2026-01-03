using Nager.Date.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Israel HolidayProvider
    /// </summary>
    internal sealed class IsraelHolidayProvider : AbstractHolidayProvider
    {
        private readonly HebrewCalendar _hebrewCalendar = new HebrewCalendar();

        /// <summary>
        /// Israel HolidayProvider
        /// </summary>
        public IsraelHolidayProvider() : base(CountryCode.IL)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>();

            // Fixed Gregorian calendar holidays
            holidaySpecifications.Add(new HolidaySpecification
            {
                Id = "NEWYEARSDAY-01",
                Date = new DateTime(year, 1, 1),
                EnglishName = "New Year's Day",
                LocalName = "ראש השנה האזרחית",
                HolidayTypes = HolidayTypes.Observance
            });

            // Hebrew calendar-based holidays
            // The Hebrew calendar year that contains most of the Gregorian year
            // For holidays in the first half of the Hebrew year (Tishrei-Adar), use the Hebrew year that starts in the previous Gregorian year
            // For holidays in the second half (Nisan-Elul), use the Hebrew year that starts in the current Gregorian year

            var hebrewYear = _hebrewCalendar.GetYear(new DateTime(year, 1, 1));

            // Purim (14 Adar, or 14 Adar II in leap years) - typically Feb/Mar
            var purimDate = this.GetPurimDate(hebrewYear);
            if (purimDate.Year == year)
            {
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "PURIM-01",
                    Date = purimDate,
                    EnglishName = "Purim",
                    LocalName = "פורים",
                    HolidayTypes = HolidayTypes.Public | HolidayTypes.Bank | HolidayTypes.School
                });
            }

            // Passover / Pesach (15-21 Nisan) - typically Mar/Apr
            var passoverStart = this.GetHebrewHolidayDate(hebrewYear, 7, 15); // Nisan is month 7 in .NET HebrewCalendar
            if (passoverStart.Year == year)
            {
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "PASSOVER-01",
                    Date = passoverStart,
                    EnglishName = "Passover (First day)",
                    LocalName = "פסח",
                    HolidayTypes = HolidayTypes.Public
                });

                var passoverEnd = passoverStart.AddDays(6);
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "PASSOVER-02",
                    Date = passoverEnd,
                    EnglishName = "Passover (Seventh day)",
                    LocalName = "שביעי של פסח",
                    HolidayTypes = HolidayTypes.Public
                });

                // Passover Eve (half day)
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "PASSOVEREVE-01",
                    Date = passoverStart.AddDays(-1),
                    EnglishName = "Passover Eve",
                    LocalName = "ערב פסח",
                    HolidayTypes = HolidayTypes.Bank | HolidayTypes.Optional
                });

                // Chol HaMoed Pesach (intermediate days) - 16-20 Nisan
                for (int i = 1; i <= 5; i++)
                {
                    holidaySpecifications.Add(new HolidaySpecification
                    {
                        Id = $"CHOLHAMOEDPESACH-0{i}",
                        Date = passoverStart.AddDays(i),
                        EnglishName = $"Chol HaMoed Pesach (Day {i})",
                        LocalName = "חול המועד פסח",
                        HolidayTypes = HolidayTypes.Optional | HolidayTypes.School
                    });
                }
            }

            // Holocaust Remembrance Day (27 Nisan) - typically Apr/May
            var holocaustDay = this.GetHebrewHolidayDate(hebrewYear, 7, 27);
            if (holocaustDay.Year == year)
            {
                // If it falls on Friday, moved to Thursday. If on Sunday, moved to Monday.
                holocaustDay = this.AdjustForShabbat(holocaustDay);

                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "HOLOCAUSTREMEMBRANCEDAY-01",
                    Date = holocaustDay,
                    EnglishName = "Holocaust Remembrance Day",
                    LocalName = "יום השואה",
                    HolidayTypes = HolidayTypes.Observance
                });
            }

            // Memorial Day (4 Iyar) - typically Apr/May
            var memorialDay = this.GetHebrewHolidayDate(hebrewYear, 8, 4); // Iyar is month 8
            if (memorialDay.Year == year)
            {
                // Adjusted if falls on Thursday-Saturday (pushed to Wednesday) or Sunday (pushed to Monday)
                memorialDay = this.AdjustMemorialDay(memorialDay);

                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "MEMORIALDAY-01",
                    Date = memorialDay,
                    EnglishName = "Memorial Day",
                    LocalName = "יום הזיכרון",
                    HolidayTypes = HolidayTypes.Observance
                });
            }

            // Independence Day (5 Iyar) - typically Apr/May (day after Memorial Day)
            var independenceDay = this.GetHebrewHolidayDate(hebrewYear, 8, 5);
            if (independenceDay.Year == year)
            {
                // Same adjustment logic as Memorial Day (follows Memorial Day)
                independenceDay = this.AdjustIndependenceDay(independenceDay);

                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = independenceDay,
                    EnglishName = "Independence Day",
                    LocalName = "יום העצמאות",
                    HolidayTypes = HolidayTypes.Public
                });

                // Independence Day Eve
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAYEVE-01",
                    Date = independenceDay.AddDays(-1),
                    EnglishName = "Independence Day Eve",
                    LocalName = "ערב יום העצמאות",
                    HolidayTypes = HolidayTypes.Bank | HolidayTypes.Optional
                });
            }

            // Jerusalem Day (28 Iyar) - typically May/Jun
            var jerusalemDay = this.GetHebrewHolidayDate(hebrewYear, 8, 28);
            if (jerusalemDay.Year == year)
            {
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "JERUSALEMDAY-01",
                    Date = jerusalemDay,
                    EnglishName = "Jerusalem Day",
                    LocalName = "יום ירושלים",
                    HolidayTypes = HolidayTypes.Observance | HolidayTypes.School
                });
            }

            // Shavuot (6 Sivan) - typically May/Jun
            var shavuot = this.GetHebrewHolidayDate(hebrewYear, 9, 6); // Sivan is month 9
            if (shavuot.Year == year)
            {
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "SHAVUOT-01",
                    Date = shavuot,
                    EnglishName = "Shavuot",
                    LocalName = "שבועות",
                    HolidayTypes = HolidayTypes.Public
                });

                // Shavuot Eve (half day)
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "SHAVUOTEVE-01",
                    Date = shavuot.AddDays(-1),
                    EnglishName = "Shavuot Eve",
                    LocalName = "ערב שבועות",
                    HolidayTypes = HolidayTypes.Bank | HolidayTypes.Optional
                });
            }

            // For holidays in the fall (Tishrei), we need the next Hebrew year
            var nextHebrewYear = hebrewYear + 1;

            // Rosh Hashanah (1-2 Tishrei) - typically Sep/Oct
            var roshHashanah1 = this.GetHebrewHolidayDate(nextHebrewYear, 1, 1); // Tishrei is month 1
            if (roshHashanah1.Year == year)
            {
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "ROSHHASHANAH-01",
                    Date = roshHashanah1,
                    EnglishName = "Rosh Hashanah (Jewish New Year)",
                    LocalName = "ראש השנה",
                    HolidayTypes = HolidayTypes.Public
                });

                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "ROSHHASHANAH-02",
                    Date = roshHashanah1.AddDays(1),
                    EnglishName = "Rosh Hashanah (Second day)",
                    LocalName = "ראש השנה יום ב׳",
                    HolidayTypes = HolidayTypes.Public
                });

                // Rosh Hashanah Eve (half day)
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "ROSHHASHANAHEVE-01",
                    Date = roshHashanah1.AddDays(-1),
                    EnglishName = "Rosh Hashanah Eve",
                    LocalName = "ערב ראש השנה",
                    HolidayTypes = HolidayTypes.Bank | HolidayTypes.Optional
                });
            }

            // Yom Kippur (10 Tishrei) - typically Sep/Oct
            var yomKippur = this.GetHebrewHolidayDate(nextHebrewYear, 1, 10);
            if (yomKippur.Year == year)
            {
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "YOMKIPPUR-01",
                    Date = yomKippur,
                    EnglishName = "Yom Kippur (Day of Atonement)",
                    LocalName = "יום כיפור",
                    HolidayTypes = HolidayTypes.Public
                });

                // Yom Kippur Eve (half day)
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "YOMKIPPUREVE-01",
                    Date = yomKippur.AddDays(-1),
                    EnglishName = "Yom Kippur Eve",
                    LocalName = "ערב יום כיפור",
                    HolidayTypes = HolidayTypes.Bank | HolidayTypes.Optional
                });
            }

            // Sukkot (15-21 Tishrei) - typically Sep/Oct
            var sukkotStart = this.GetHebrewHolidayDate(nextHebrewYear, 1, 15);
            if (sukkotStart.Year == year)
            {
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "SUKKOT-01",
                    Date = sukkotStart,
                    EnglishName = "Sukkot (First day)",
                    LocalName = "סוכות",
                    HolidayTypes = HolidayTypes.Public
                });

                // Sukkot Eve (half day)
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "SUKKOTEVE-01",
                    Date = sukkotStart.AddDays(-1),
                    EnglishName = "Sukkot Eve",
                    LocalName = "ערב סוכות",
                    HolidayTypes = HolidayTypes.Bank | HolidayTypes.Optional
                });

                // Chol HaMoed Sukkot (intermediate days) - 16-20 Tishrei
                for (int i = 1; i <= 5; i++)
                {
                    holidaySpecifications.Add(new HolidaySpecification
                    {
                        Id = $"CHOLHAMOEDSUKKOT-0{i}",
                        Date = sukkotStart.AddDays(i),
                        EnglishName = $"Chol HaMoed Sukkot (Day {i})",
                        LocalName = "חול המועד סוכות",
                        HolidayTypes = HolidayTypes.Optional | HolidayTypes.School
                    });
                }

                // Hoshana Rabbah (21 Tishrei)
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "HOSHANARABBAH-01",
                    Date = sukkotStart.AddDays(6),
                    EnglishName = "Hoshana Rabbah",
                    LocalName = "הושענא רבה",
                    HolidayTypes = HolidayTypes.Bank | HolidayTypes.Optional
                });
            }

            // Shemini Atzeret / Simchat Torah (22 Tishrei) - In Israel these are combined
            var sheminiAtzeret = this.GetHebrewHolidayDate(nextHebrewYear, 1, 22);
            if (sheminiAtzeret.Year == year)
            {
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "SHEMINIATZERET-01",
                    Date = sheminiAtzeret,
                    EnglishName = "Shemini Atzeret / Simchat Torah",
                    LocalName = "שמיני עצרת / שמחת תורה",
                    HolidayTypes = HolidayTypes.Public
                });
            }

            // Hanukkah (25 Kislev - 2/3 Tevet) - typically Nov/Dec
            var hanukkahStart = this.GetHebrewHolidayDate(nextHebrewYear, 3, 25); // Kislev is month 3
            if (hanukkahStart.Year == year || hanukkahStart.AddDays(7).Year == year)
            {
                for (int i = 0; i < 8; i++)
                {
                    var hanukkahDay = hanukkahStart.AddDays(i);
                    if (hanukkahDay.Year == year)
                    {
                        holidaySpecifications.Add(new HolidaySpecification
                        {
                            Id = $"HANUKKAH-0{i + 1}",
                            Date = hanukkahDay,
                            EnglishName = $"Hanukkah (Day {i + 1})",
                            LocalName = "חנוכה",
                            HolidayTypes = HolidayTypes.Optional | HolidayTypes.School
                        });
                    }
                }
            }

            return holidaySpecifications;
        }

        /// <summary>
        /// Get the Gregorian date for a Hebrew calendar date
        /// </summary>
        private DateTime GetHebrewHolidayDate(int hebrewYear, int hebrewMonth, int hebrewDay)
        {
            return _hebrewCalendar.ToDateTime(hebrewYear, hebrewMonth, hebrewDay, 0, 0, 0, 0);
        }

        /// <summary>
        /// Get Purim date, accounting for leap years (Adar II)
        /// </summary>
        private DateTime GetPurimDate(int hebrewYear)
        {
            // In a leap year, Purim is in Adar II (month 7), otherwise in Adar (month 6)
            var isLeapYear = _hebrewCalendar.IsLeapYear(hebrewYear);
            var purimMonth = isLeapYear ? 7 : 6; // Adar II in leap year, Adar otherwise
            return _hebrewCalendar.ToDateTime(hebrewYear, purimMonth, 14, 0, 0, 0, 0);
        }

        /// <summary>
        /// Adjust Holocaust Remembrance Day to avoid Shabbat
        /// </summary>
        private DateTime AdjustForShabbat(DateTime date)
        {
            // If Friday, move to Thursday
            if (date.DayOfWeek == DayOfWeek.Friday)
            {
                return date.AddDays(-1);
            }
            // If Sunday, move to Monday
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                return date.AddDays(1);
            }
            return date;
        }

        /// <summary>
        /// Adjust Memorial Day according to Israeli law
        /// </summary>
        private DateTime AdjustMemorialDay(DateTime date)
        {
            // If Thursday, Friday, or Saturday - move to Wednesday
            // If Sunday - move to Monday
            return date.DayOfWeek switch
            {
                DayOfWeek.Thursday => date.AddDays(-1),
                DayOfWeek.Friday => date.AddDays(-2),
                DayOfWeek.Saturday => date.AddDays(-3),
                DayOfWeek.Sunday => date.AddDays(1),
                _ => date
            };
        }

        /// <summary>
        /// Adjust Independence Day according to Israeli law (follows Memorial Day)
        /// </summary>
        private DateTime AdjustIndependenceDay(DateTime date)
        {
            // If Friday or Saturday - move to Thursday (day after adjusted Memorial Day)
            // If Monday - move to Tuesday
            return date.DayOfWeek switch
            {
                DayOfWeek.Friday => date.AddDays(-1),
                DayOfWeek.Saturday => date.AddDays(-2),
                DayOfWeek.Monday => date.AddDays(1),
                _ => date
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Israel",
                "https://www.gov.il/en/departments/general/holidays-and-memorial-days"
            ];
        }
    }
}
