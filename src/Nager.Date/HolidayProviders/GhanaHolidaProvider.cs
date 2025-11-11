using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using Nager.Date.Helpers;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Ghana HolidayProvider
    /// </summary>
    internal sealed class GhanaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Ghana HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public GhanaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.GH)
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
                    Id = "CONSTITUTIONDAY-01",
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "Constitution Day",
                    LocalName = "Constitution Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 3, 6),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Id = "MAYDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "May Day",
                    LocalName = "May Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Id = "REPUBLICDAY-01",
                    Date = new DateTime(year, 7, 1),
                    EnglishName = "Republic Day",
                    LocalName = "Republic Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet1
                },
                new HolidaySpecification
                {
                    Id = "FOUNDERSDAY-01",
                    Date = new DateTime(year, 9, 21),
                    EnglishName = "Founders Day",
                    LocalName = "Founders Day",
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
            
            holidaySpecifications.Add(this.FarmersDay(year, observedRuleSet1));

            return holidaySpecifications;
        }

        private HolidaySpecification FarmersDay(int year, ObservedRuleSet observedRuleSet)
        {
            var farmersDay = DateHelper.FindDay(year, Month.December, 1, DayOfWeek.Friday);

                return new HolidaySpecification
                {
                    Id = "FARMERSDAY-01",
                    Date = farmersDay,
                    EnglishName = "Farmers' Day",
                    LocalName = "Farmers' Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Ghana",
            ];
        }
    }
}
