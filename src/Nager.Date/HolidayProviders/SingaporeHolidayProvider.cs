using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Singapore HolidayProvider
    /// </summary>
    internal sealed class SingaporeHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Singapore HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SingaporeHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.SG)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
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
            }

            holidaySpecifications.AddIfNotNull(this.HariRayaPuasa(year));
            holidaySpecifications.AddIfNotNull(this.VesakDay(year));
            holidaySpecifications.AddIfNotNull(this.HariRayaHaji(year));
            holidaySpecifications.AddIfNotNull(this.Deepavali(year));
            holidaySpecifications.AddIfNotNull(this.PollingDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? HariRayaPuasa(int year)
        {
            DateTime? date = null;

            switch (year)
            {
                case 2017:
                    date = new DateTime(year, 6, 25);
                    break;
                case 2018:
                    date = new DateTime(year, 6, 15);
                    break;
                case 2019:
                    date = new DateTime(year, 6, 5);
                    break;
                case 2020:
                    date = new DateTime(year, 5, 24);
                    break;
                case 2021:
                    date = new DateTime(year, 5, 13);
                    break;
                case 2022:
                    date = new DateTime(year, 5, 3);
                    break;
                case 2023:
                    date = new DateTime(year, 4, 22);
                    break;
                case 2024:
                    date = new DateTime(year, 4, 10);
                    break;
                case 2025:
                    date = new DateTime(year, 3, 31);
                    break;
                case 2026:
                    date = new DateTime(year, 3, 20);
                    break;
                case 2027:
                    date = new DateTime(year, 3, 10);
                    break;
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

        private HolidaySpecification? VesakDay(int year)
        {
            DateTime? date = null;

            switch (year)
            {
                case 2017:
                    date = new DateTime(year, 5, 10);
                    break;
                case 2018:
                    date = new DateTime(year, 5, 29);
                    break;
                case 2019:
                    date = new DateTime(year, 5, 19);
                    break;
                case 2020:
                    date = new DateTime(year, 5, 7);
                    break;
                case 2021:
                    date = new DateTime(year, 5, 26);
                    break;
                case 2022:
                    date = new DateTime(year, 5, 15);
                    break;
                case 2023:
                    date = new DateTime(year, 6, 2);
                    break;
                case 2024:
                    date = new DateTime(year, 5, 22);
                    break;
                case 2025:
                    date = new DateTime(year, 5, 12);
                    break;
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

        private HolidaySpecification? HariRayaHaji(int year)
        {
            DateTime? date = null;

            switch (year)
            {
                case 2017:
                    date = new DateTime(year, 9, 1);
                    break;
                case 2018:
                    date = new DateTime(year, 8, 22);
                    break;
                case 2019:
                    date = new DateTime(year, 8, 11);
                    break;
                case 2020:
                    date = new DateTime(year, 7, 31);
                    break;
                case 2021:
                    date = new DateTime(year, 7, 20);
                    break;
                case 2022:
                    date = new DateTime(year, 7, 10);
                    break;
                case 2023:
                    date = new DateTime(year, 6, 29);
                    break;
                case 2024:
                    date = new DateTime(year, 6, 17);
                    break;
                case 2025:
                    date = new DateTime(year, 6, 6);
                    break;
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

        private HolidaySpecification? Deepavali(int year)
        {
            DateTime? date = null;

            switch (year)
            {
                case 2017:
                    date = new DateTime(year, 10, 18);
                    break;
                case 2018:
                    date = new DateTime(year, 11, 6);
                    break;
                case 2019:
                    date = new DateTime(year, 10, 27);
                    break;
                case 2020:
                    date = new DateTime(year, 11, 14);
                    break;
                case 2021:
                    date = new DateTime(year, 11, 4);
                    break;
                case 2022:
                    date = new DateTime(year, 10, 24);
                    break;
                case 2023:
                    date = new DateTime(year, 11, 12);
                    break;
                case 2024:
                    date = new DateTime(year, 10, 31);
                    break;
                case 2025:
                    date = new DateTime(year, 10, 21);
                    break;
                case 2026:
                    date = new DateTime(year, 11, 8);
                    break;
                case 2027:
                    date = new DateTime(year, 10, 29);
                    break;
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

        private HolidaySpecification? PollingDay(int year)
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
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Singapore",
                "https://www.mom.gov.sg/newsroom/press-releases?keywords=holiday",
                "https://www.mom.gov.sg/employment-practices/public-holidays",
            ];
        }
    }
}
