using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Kenya HolidayProvider
    /// </summary>
    internal sealed class KenyaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Kenya HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public KenyaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.KE)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var easterSunday = this._catholicProvider.EasterSunday(year);

            /*
             * When public holiday falls on a Sunday
             * Where, in any year, a day in Part I of the Schedule falls on a Sunday, then the first succeeding day, not
             * being a public holiday, shall be a public holiday and the first-mentioned day shall cease to be a public
             * holiday.
            */

            var observedRuleSet1 = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(1)
            };

            var observedRuleSet2 = new ObservedRuleSet
            {
                Monday = date => date.AddDays(1)
            };

            //IGNORE
            // - Eid al-Fitr and Eid al-Adha -> https://github.com/nager/Nager.date?tab=readme-ov-file#limitation-regarding-islamic-holidays

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Id = "MADARAKADAY-01",
                    Date = new DateTime(year, 6, 1),
                    EnglishName = "Madaraka Day",
                    LocalName = "Madaraka Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Id = "JAMHURIDAY-01",
                    Date = new DateTime(year, 12, 12),
                    EnglishName = "Jamhuri Day",
                    LocalName = "Jamhuri Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Id = "BOXINGDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Boxing Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet2
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year)
            };

            holidaySpecifications.AddIfNotNull(this.HudumaDay(year));
            holidaySpecifications.AddIfNotNull(this.UtamaduniDay(year));
            holidaySpecifications.AddIfNotNull(this.MazingiraDay(year, observedRuleSet1));
            holidaySpecifications.AddIfNotNull(this.MashujaaDay(year, observedRuleSet1));

            return holidaySpecifications;
        }

        private HolidaySpecification? MashujaaDay(
            int year,
            ObservedRuleSet observedRuleSet)
        {
            if (year >= 2010)
            {
                return new HolidaySpecification
                {
                    Id = "MASHUJAADAY-01",
                    Date = new DateTime(year, 10, 20),
                    EnglishName = "Mashujaa Day",
                    LocalName = "Mashujaa Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                };
            }

            return null;
        }

        private HolidaySpecification? MazingiraDay(
            int year,
            ObservedRuleSet observedRuleSet)
        {
            if (year >= 2023)
            {
                return new HolidaySpecification
                {
                    Id = "MAZINGIRADAY-01",
                    Date = new DateTime(year, 10, 10),
                    EnglishName = "Mazingira Day",
                    LocalName = "Mazingira Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                };
            }

            return null;
        }

        private HolidaySpecification? UtamaduniDay(int year)
        {
            if (year >= 2020 && year < 2023)
            {
                return new HolidaySpecification
                {
                    Id = "UTAMADUNIDAY-01",
                    Date = new DateTime(year, 10, 10),
                    EnglishName = "Utamaduni Day",
                    LocalName = "Utamaduni Day",
                    HolidayTypes = HolidayTypes.Public
                };
            }

            return null;
        }

        private HolidaySpecification? HudumaDay(int year)
        {
            if (year >= 2010 && year < 2020)
            {
                return new HolidaySpecification
                {
                    Id = "HUDUMADAY-01",
                    Date = new DateTime(year, 10, 10),
                    EnglishName = "Huduma Day",
                    LocalName = "Huduma Day",
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
                "https://en.wikipedia.org/wiki/Public_holidays_in_Kenya",
                "https://new.kenyalaw.org/akn/ke/act/1912/21/eng@2024-04-26"
            ];
        }
    }
}
