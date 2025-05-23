using Nager.Date.Extensions;
using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Egypt HolidayProvider
    /// </summary>
    internal sealed class EgyptHolidayProvider() : AbstractHolidayProvider(CountryCode.EG)
    {
        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            //TODO: Add Islamic calender logic
            //Sham El Nessim (Spring Festival)
            //Islamic New Year
            //Birthday of the Prophet Muhammad (Sunni)
            //Eid al-Fitr
            //Eid al-Adha

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "Christmas",
                    LocalName = "عيد الميلاد المجيد",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 25),
                    EnglishName = "Revolution Day 2011 National Police Day",
                    LocalName = "عيد الثورة 25 يناير",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "عيد العمال",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 23),
                    EnglishName = "Revolution Day",
                    LocalName = "عيد ثورة 23 يوليو",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 6),
                    EnglishName = "Armed Forces Day",
                    LocalName = "عيد القوات المسلحة",
                    HolidayTypes = HolidayTypes.Public
                }
            };

            holidaySpecifications.AddIfNotNull(this.SinaiLiberationDay(year));
            holidaySpecifications.AddIfNotNull(this.June30Revolution(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? June30Revolution(int year)
        {
            var localName = "ثورة 30 يونيو";
            var englishName = "June 30 Revolution";

            if (year >= 2015 && year <= 2017)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 30),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public
                };
            }
            else if (year == 2018)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 1),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public
                };
            }
            else if (year >= 2019 && year <= 2020)
            {
                return new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 30),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public
                };
            }
            else if (year >= 2021)
            {
                var observedRuleSet = new ObservedRuleSet
                {
                    Monday = date => date.AddDays(3),
                    Tuesday = date => date.AddDays(2),
                    Wednesday = date => date.AddDays(1),
                    Friday = date => date.AddDays(2),
                };

                return new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 30),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                };
            }

            return null;
        }

        private HolidaySpecification SinaiLiberationDay(int year)
        {
            var localName = "عيد تحرير سيناء";
            var englishName = "Sinai Liberation Day";

            if (year == 2025)
            {
                var observedRuleSet = new ObservedRuleSet
                {
                    Friday = date => date.AddDays(-1),
                };

                return new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 25),
                    EnglishName = englishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                };
            }

            return new HolidaySpecification
            {
                Date = new DateTime(year, 4, 25),
                EnglishName = englishName,
                LocalName = localName,
                HolidayTypes = HolidayTypes.Public
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Egypt",
                "https://www.sis.gov.eg/Story/207089/Egypt-sets-April-21%2C-April-24%2C-May-1-as-public-holidays?lang=en-us",
                "https://www.sis.gov.eg/Story/207089/Egypt-sets-April-21%2C-April-24%2C-May-1-as-public-holidays?lang=en-us&utm_source=chatgpt.com"
            ];
        }
    }
}
