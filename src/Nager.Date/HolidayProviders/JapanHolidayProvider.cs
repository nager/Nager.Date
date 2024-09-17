using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Japan HolidayProvider
    /// </summary>
    internal sealed class JapanHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Japan HolidayProvider
        /// </summary>
        public JapanHolidayProvider() : base(CountryCode.JP)
        { }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var secondMondayInJanuary = DateHelper.FindDay(year, Month.January, DayOfWeek.Monday, Occurrence.Second);
            var thirdMondayInJuly = DateHelper.FindDay(year, Month.July, DayOfWeek.Monday, Occurrence.Third);
            var thirdMondayInSeptember = DateHelper.FindDay(year, Month.September, DayOfWeek.Monday, Occurrence.Third);

            var observedRuleSet = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(1)
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "元日",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = secondMondayInJanuary,
                    EnglishName = "Coming of Age Day",
                    LocalName = "成人の日",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 11),
                    EnglishName = "Foundation Day",
                    LocalName = "建国記念の日",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 29),
                    EnglishName = "Shōwa Day",
                    LocalName = "昭和の日",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 3),
                    EnglishName = "Constitution Memorial Day",
                    LocalName = "憲法記念日",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 4),
                    EnglishName = "Greenery Day",
                    LocalName = "みどりの日",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 5),
                    EnglishName = "Children's Day",
                    LocalName = "こどもの日",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = thirdMondayInJuly,
                    EnglishName = "Marine Day",
                    LocalName = "海の日",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 11),
                    EnglishName = "Mountain Day",
                    LocalName = "山の日",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = thirdMondayInSeptember,
                    EnglishName = "Respect for the Aged Day",
                    LocalName = "敬老の日",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 3),
                    EnglishName = "Culture Day",
                    LocalName = "文化の日",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 23),
                    EnglishName = "Labour Thanksgiving Day",
                    LocalName = "勤労感謝の日",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                }
            };

            //Will change to the date of the new emperor on the death of the current one
            holidaySpecifications.AddIfNotNull(this.EmperorsBirthday(year));
            holidaySpecifications.AddIfNotNull(this.VernalEquinox(year));
            holidaySpecifications.AddIfNotNull(this.AutumnalEquinox(year));
            holidaySpecifications.AddIfNotNull(this.SportsDay(year));

            return holidaySpecifications;
        }

        /// <summary>
        /// Adds the emperor's birthday based on the era/emperor of the current year.
        /// </summary>
        /// <see href="https://en.wikipedia.org/wiki/The_Emperor%27s_Birthday#Emperor_birthday_list" />
        /// <param name="year"></param>
        /// <returns>Emperors Birthday object or null</returns>
        private HolidaySpecification? EmperorsBirthday(int year)
        {
            if (year < 1868)
            {
                return null;
            }

            DateTime result;

            if (year < 1873)
            {
                //TODO: Period 1868 - 1872 based on Lunisolar calendar
                return null;
            }
            else if (year < 1912)
            {
                result = new DateTime(year, 11, 3);
            }
            else if (year < 1913)
            {
                result = new DateTime(year, 8, 31);
            }
            else if (year < 1927)
            {
                result = new DateTime(year, 10, 31);
            }
            else if (year < 1989)
            {
                result = new DateTime(year, 4, 29);
            }
            else if (year < 2019)
            {
                result = new DateTime(year, 12, 23);
            }
            else if (year == 2019)
            {
                return null;
            }
            else
            {
                result = new DateTime(year, 2, 23);
            }

            return new HolidaySpecification
            {
                Date = result,
                EnglishName = "The Emperor's Birthday",
                LocalName = year < 1948 ? "天長節" : "天皇誕生日",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = new ObservedRuleSet
                {
                    Sunday = date => date.AddDays(1)
                }
            };
        }

        private HolidaySpecification? SportsDay(int year)
        {
            if (year <= 1965)
            {
                return null;
            }
            else if (year > 1965 && year < 2000)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 10),
                    EnglishName = "Health and Sports Day",
                    LocalName = "体育の日",
                    HolidayTypes = HolidayTypes.Public
                };
            }
            else if (year >= 2000 && year < 2020)
            {
                var secondMondayInOctober = DateHelper.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.Second);

                return new HolidaySpecification
                {
                    Date = secondMondayInOctober,
                    EnglishName = "Health and Sports Day",
                    LocalName = "体育の日",
                    HolidayTypes = HolidayTypes.Public
                };
            }
            else if (year == 2020)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 07, 24),
                    EnglishName = "Sports Day",
                    LocalName = "スポーツの日",
                    HolidayTypes = HolidayTypes.Public
                };
            }
            else if (year ==  2021)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 07, 23),
                    EnglishName = "Sports Day",
                    LocalName = "スポーツの日",
                    HolidayTypes = HolidayTypes.Public
                };
            }
            else if (year >= 2022)
            {
                var secondMondayInOctober = DateHelper.FindDay(year, Month.October, DayOfWeek.Monday, Occurrence.Second);

                return new HolidaySpecification
                {
                    Date = secondMondayInOctober,
                    EnglishName = "Sports Day",
                    LocalName = "スポーツの日",
                    HolidayTypes = HolidayTypes.Public
                };
            }

            return null;
        }

        private HolidaySpecification? VernalEquinox(int year)
        {
            if (year < 1850 || year > 2151)
            {
                return null;
            }

            var differencePerYear = 0.242194;
            var equinoxDay = 0.0;
            if (year >= 1851 && year <= 1899)
            {
                equinoxDay = Math.Truncate(19.8277 + differencePerYear * (year - 1980) - Math.Truncate((year - 1983) / 4.0));
            }
            else if (year >= 1900 && year <= 1979)
            {
                equinoxDay = Math.Truncate(20.8357 + differencePerYear * (year - 1980) - Math.Truncate((year - 1983) / 4.0));
            }
            else if (year >= 1980 && year <= 2099)
            {
                equinoxDay = Math.Truncate(20.8431 + differencePerYear * (year - 1980) - Math.Truncate((year - 1980) / 4.0));
            }
            else if (year >= 2100 && year <= 2150)
            {
                equinoxDay = Math.Truncate(21.8510 + differencePerYear * (year - 1980) - Math.Truncate((year - 1980) / 4.0));
            }

            return new HolidaySpecification
            {
                Date = new DateTime(year, 3, (int)equinoxDay),
                EnglishName = "Vernal Equinox Day",
                LocalName = "春分の日",
                HolidayTypes = HolidayTypes.Public
            };
        }

        private HolidaySpecification? AutumnalEquinox(int year)
        {
            if (year < 1850 || year > 2151)
            {
                return null;
            }

            var differencePerYear = 0.242194;
            var equinoxDay = 0.0;
            if (year >= 1851 && year <= 1899)
            {
                equinoxDay = Math.Truncate(22.2588 + differencePerYear * (year - 1980) - Math.Truncate((year - 1983) / 4.0));
            }
            else if (year >= 1900 && year <= 1979)
            {
                equinoxDay = Math.Truncate(23.2588 + differencePerYear * (year - 1980) - Math.Truncate((year - 1983) / 4.0));
            }
            else if (year >= 1980 && year <= 2099)
            {
                equinoxDay = Math.Truncate(23.2488 + differencePerYear * (year - 1980) - Math.Truncate((year - 1980) / 4.0));
            }
            else if (year >= 2100 && year <= 2150)
            {
                equinoxDay = Math.Truncate(24.2488 + differencePerYear * (year - 1980) - Math.Truncate((year - 1980) / 4.0));
            }

            return new HolidaySpecification
            {
                Date = new DateTime(year, 9, (int)equinoxDay),
                EnglishName = "Autumnal Equinox Day",
                LocalName = "秋分の日",
                HolidayTypes = HolidayTypes.Public
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Japan",
                "https://en.wikipedia.org/wiki/Golden_Week_(Japan)",
                "https://www.boj.or.jp/en/about/outline/holi.htm/",
                "https://en.wikipedia.org/wiki/The_Emperor%27s_Birthday#Emperor_birthday_list",
                "https://zariganitosh.hatenablog.jp/entry/20140929/japanese_holiday_memo",
                "https://rkapl123.github.io/QLAnnotatedSource/da/db4/japan_8cpp_source.html",
                "http://addinbox.sakura.ne.jp/holiday_logic_English.htm"
            ];
        }
    }
}
