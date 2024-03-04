using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Singapore HolidayProvider
    /// </summary>
    internal class SingaporeHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Singapore HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SingaporeHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.SG;

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
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 9),
                    EnglishName = "National Day",
                    LocalName = "National Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                this._catholicProvider.GoodFriday("Good Friday", year)
            };

            var chineseCalendar = new ChineseLunisolarCalendar();
            if (year > chineseCalendar.MinSupportedDateTime.Year && year < chineseCalendar.MaxSupportedDateTime.Year)
            {
                var chineseNewYear = chineseCalendar.ToDateTime(year, 1, 1, 0, 0, 0, 0);

                holidaySpecifications.AddIfNotNull(new HolidaySpecification
                {
                    Date = chineseNewYear,
                    EnglishName = "Chinese New Year",
                    LocalName = "Chinese New Year",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                });

                holidaySpecifications.AddIfNotNull(new HolidaySpecification
                {
                    Date = chineseNewYear.AddDays(1),
                    EnglishName = "Chinese New Year",
                    LocalName = "Chinese New Year",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                });

                //items.Add(new Holiday(chineseNewYear, "Chinese New Year", "Chinese New Year", countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1)));
                //items.Add(new Holiday(chineseNewYear.AddDays(1), "Chinese New Year", "Chinese New Year", countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1)));
            }

            holidaySpecifications.AddIfNotNull(this.HariRayaPuasa(year));
            holidaySpecifications.AddIfNotNull(this.VesakDay(year));
            holidaySpecifications.AddIfNotNull(this.HariRayaHaji(year));
            holidaySpecifications.AddIfNotNull(this.Deepavali(year));
            holidaySpecifications.AddIfNotNull(this.PollingDay(year));

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "New Year’s Day", "New Year’s Day", countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1)));
            //items.Add(new Holiday(year, 5, 1, "Labour Day", "Labour Day", countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1)));
            //items.Add(new Holiday(year, 8, 9, "National Day", "National Day", countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1)));
            //items.Add(new Holiday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1)));
            //items.Add(this._catholicProvider.GoodFriday("Good Friday", year, countryCode));

            //var chineseCalendar = new ChineseLunisolarCalendar();
            //if (year > chineseCalendar.MinSupportedDateTime.Year && year < chineseCalendar.MaxSupportedDateTime.Year)
            //{
            //    var chineseNewYear = chineseCalendar.ToDateTime(year, 1, 1, 0, 0, 0, 0);
            //    items.Add(new Holiday(chineseNewYear, "Chinese New Year", "Chinese New Year", countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1)));
            //    items.Add(new Holiday(chineseNewYear.AddDays(1), "Chinese New Year", "Chinese New Year", countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1)));
            //}

            //items.AddIfNotNull(this.HariRayaPuasa(year, countryCode));
            //items.AddIfNotNull(this.VesakDay(year, countryCode));
            //items.AddIfNotNull(this.HariRayaHaji(year, countryCode));
            //items.AddIfNotNull(this.Deepavali(year, countryCode));
            //items.AddIfNotNull(this.PollingDay(year, countryCode));

            //return items.OrderBy(o => o.Date);
        }

        private HolidaySpecification HariRayaPuasa(int year)
        {
            DateTime? date = null;

            switch (year)
            {
                case 2017:
                    date = new DateTime(year, 6, 25);
                    break;
                    //return new Holiday(year, 6, 25, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2018:
                    date = new DateTime(year, 6, 15);
                    break;
                    //return new Holiday(year, 6, 15, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2019:
                    date = new DateTime(year, 6, 5);
                    break;
                    //return new Holiday(year, 6, 5, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2020:
                    date = new DateTime(year, 5, 24);
                    break;
                    //return new Holiday(year, 5, 24, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2021:
                    date = new DateTime(year, 5, 13);
                    break;
                    //return new Holiday(year, 5, 13, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2022:
                    date = new DateTime(year, 5, 3);
                    break;
                    //return new Holiday(year, 5, 3, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2023:
                    date = new DateTime(year, 4, 22);
                    break;
                    //return new Holiday(year, 4, 22, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2024:
                    date = new DateTime(year, 4, 10);
                    break;
                    //return new Holiday(year, 4, 10, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2025:
                    date = new DateTime(year, 3, 31);
                    break;
                    //return new Holiday(year, 3, 31, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2026:
                    date = new DateTime(year, 3, 20);
                    break;
                    //return new Holiday(year, 3, 20, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2027:
                    date = new DateTime(year, 3, 10);
                    break;
                    //return new Holiday(year, 3, 10, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                default:
                    break;
            }

            if (date.HasValue)
            {
                var observedRuleSet = new ObservedRuleSet
                {
                    Sunday = date => date.AddDays(1)
                };

                var name = "Hari Raya Puasa";
                return new HolidaySpecification
                {
                    Date = date.Value,
                    EnglishName = name,
                    LocalName = name,
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                };
            }

            return null;
        }

        private HolidaySpecification VesakDay(int year)
        {
            DateTime? date = null;

            switch (year)
            {
                case 2017:
                    date = new DateTime(year, 5, 10);
                    break;
                    //return new Holiday(year, 5, 10, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2018:
                    date = new DateTime(year, 5, 29);
                    break;
                    //return new Holiday(year, 5, 29, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2019:
                    date = new DateTime(year, 5, 19);
                    break;
                    //return new Holiday(year, 5, 19, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2020:
                    date = new DateTime(year, 5, 7);
                    break;
                    //return new Holiday(year, 5, 7, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2021:
                    date = new DateTime(year, 5, 26);
                    break;
                    //return new Holiday(year, 5, 26, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2022:
                    date = new DateTime(year, 5, 15);
                    break;
                    //return new Holiday(year, 5, 15, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2023:
                    date = new DateTime(year, 6, 2);
                    break;
                    //return new Holiday(year, 6, 2, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2024:
                    date = new DateTime(year, 5, 22);
                    break;
                    //return new Holiday(year, 5, 22, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2025:
                    date = new DateTime(year, 5, 12);
                    break;
                    //return new Holiday(year, 5, 12, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                default:
                    break;
            }

            if (date.HasValue)
            {
                var observedRuleSet = new ObservedRuleSet
                {
                    Sunday = date => date.AddDays(1)
                };

                var name = "Vesak Day";
                return new HolidaySpecification
                {
                    Date = date.Value,
                    EnglishName = name,
                    LocalName = name,
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                };
            }

            return null;
        }

        private HolidaySpecification HariRayaHaji(int year)
        {
            DateTime? date = null;

            switch (year)
            {
                case 2017:
                    date = new DateTime(year, 9, 1);
                    break;
                    //return new Holiday(year, 9, 1, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2018:
                    date = new DateTime(year, 8, 22);
                    break;
                    //return new Holiday(year, 8, 22, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2019:
                    date = new DateTime(year, 8, 11);
                    break;
                    //return new Holiday(year, 8, 11, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2020:
                    date = new DateTime(year, 7, 31);
                    break;
                    //return new Holiday(year, 7, 31, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2021:
                    date = new DateTime(year, 7, 20);
                    break;
                    //return new Holiday(year, 7, 20, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2022:
                    date = new DateTime(year, 7, 10);
                    break;
                    //return new Holiday(year, 7, 10, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2023:
                    date = new DateTime(year, 6, 29);
                    break;
                    //return new Holiday(year, 6, 29, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2024:
                    date = new DateTime(year, 6, 17);
                    break;
                    //return new Holiday(year, 6, 17, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2025:
                    date = new DateTime(year, 6, 6);
                    break;
                    //return new Holiday(year, 6, 6, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                default:
                    break;
            }

            if (date.HasValue)
            {
                var observedRuleSet = new ObservedRuleSet
                {
                    Sunday = date => date.AddDays(1)
                };

                var name = "Hari Raya Haji";
                return new HolidaySpecification
                {
                    Date = date.Value,
                    EnglishName = name,
                    LocalName = name,
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                };
            }

            return null;
        }

        private HolidaySpecification Deepavali(int year)
        {
            DateTime? date = null;

            switch (year)
            {
                case 2017:
                    date = new DateTime(year, 10, 18);
                    break;
                    //return new Holiday(year, 10, 18, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2018:
                    date = new DateTime(year, 11, 6);
                    break;
                    //return new Holiday(year, 11, 6, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2019:
                    date = new DateTime(year, 10, 27);
                    break;
                    //return new Holiday(year, 10, 27, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2020:
                    date = new DateTime(year, 11, 14);
                    break;
                    //return new Holiday(year, 11, 14, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2021:
                    date = new DateTime(year, 11, 4);
                    break;
                    //return new Holiday(year, 11, 4, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2022:
                    date = new DateTime(year, 10, 24);
                    break;
                    //return new Holiday(year, 10, 24, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2023:
                    date = new DateTime(year, 11, 12);
                    break;
                    //return new Holiday(year, 11, 12, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2024:
                    date = new DateTime(year, 10, 31);
                    break;
                    //return new Holiday(year, 10, 31, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2025:
                    date = new DateTime(year, 10, 21);
                    break;
                    //return new Holiday(year, 10, 21, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2026:
                    date = new DateTime(year, 11, 8);
                    break;
                    //return new Holiday(year, 11, 8, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                case 2027:
                    date = new DateTime(year, 10, 29);
                    break;
                    //return new Holiday(year, 10, 29, name, name, countryCode).Shift(saturday => saturday, sunday => sunday.AddDays(1));
                default:
                    break;
            }

            if (date.HasValue)
            {
                var observedRuleSet = new ObservedRuleSet
                {
                    Sunday = date => date.AddDays(1)
                };

                var name = "Deepavali";
                return new HolidaySpecification
                {
                    Date = date.Value,
                    EnglishName = name,
                    LocalName = name,
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                };
            }

            return null;
        }

        private HolidaySpecification PollingDay(int year)
        {
            if (year == 2023)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 1),
                    EnglishName = "Polling Day",
                    LocalName = "Polling Day",
                    HolidayTypes = HolidayTypes.Public
                };

                //return new Holiday(year, 9, 1, "Polling Day", "Polling Day", countryCode);
            }

            return null;
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Singapore",
                "https://www.mom.gov.sg/newsroom/press-releases?keywords=holiday",
                "https://www.mom.gov.sg/employment-practices/public-holidays",
            };
        }
    }
}
