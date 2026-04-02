using Nager.Date.Extensions;
using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Bangladesh HolidayProvider
    /// </summary>
    internal sealed class BangladeshHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Bangladesh HolidayProvider
        /// </summary>
        public BangladeshHolidayProvider() : base(CountryCode.BD)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "MOTHERLANGUAGEDAY-01",
                    Date = new DateTime(year, 2, 21),
                    EnglishName = "International Mother Language Day",
                    LocalName = "শহিদ দিবস ও আন্তর্জাতিক মাতৃভাষা দিবস",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 3, 26),
                    EnglishName = "Independence and National Day",
                    LocalName = "স্বাধীনতা ও জাতীয় দিবস",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "BENGALINEWYEAR-01",
                    Date = new DateTime(year, 4, 14),
                    EnglishName = "Bengali New Year",
                    LocalName = "নববর্ষ",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "মে দিবস",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "VICTORYDAY-01",
                    Date = new DateTime(year, 12, 16),
                    EnglishName = "Victory Day",
                    LocalName = "বিজয় দিবস",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "বড়দিন",
                    HolidayTypes = HolidayTypes.Public
                }
            };

            holidaySpecifications.AddIfNotNull(this.JulyMassUprisingDay(year));

            // Lunar/religious holidays (Eid-ul-Fitr, Eid-ul-Adha, Buddha Purnima, Janmashtami,
            // Durga Puja, Miladunnabi, etc.) depend on moon sighting and are NOT fixed.
            // TODO: Add when Nager.Date supports Hijri/Bengali calendar calculations
            // (see IndonesiaHolidayProvider and EgyptHolidayProvider for the pattern).

            return holidaySpecifications;
        }

        private HolidaySpecification? JulyMassUprisingDay(int year)
        {
            if (year >= 2025)
            {
                return new HolidaySpecification
                {
                    Id = "JULYMASSUPRISINGDAY-01",
                    Date = new DateTime(year, 8, 5),
                    EnglishName = "July Mass Uprising Day",
                    LocalName = "জুলাই গণঅভ্যুত্থান দিবস",
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
                "https://mopa.gov.bd/ (Official Government Gazette dated 09 November 2025, Ref: 05.00.0000.000.175.08.0008.25-17)",
                "https://objectstorage.ap-dcc-gazipur-1.oraclecloud15.com/n/axvjbnqprylg/b/V2Ministry/o/office-mopa/2024/12/209c6283d9234a0fa8f1f30b90068b57.pdf",
                "https://en.wikipedia.org/wiki/Public_holidays_in_Bangladesh"
            ];
        }
    }
}
