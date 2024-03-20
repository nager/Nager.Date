using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Bulgaria HolidayProvider
    /// </summary>
    internal sealed class BulgariaHolidayProvider : AbstractHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// Bulgaria HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public BulgariaHolidayProvider(
            IOrthodoxProvider orthodoxProvider) : base(CountryCode.BG)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {

            //var newYearDay = new DateTime(year, 1, 1).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            //var liberationDay = new DateTime(year, 3, 3).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            //var saintGeorgesDay = new DateTime(year, 5, 6).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            //var independenceDay = new DateTime(year, 9, 22).Shift(saturday => saturday.AddDays(2), sunday => sunday.AddDays(1));
            //var christmasEve = new DateTime(year, 12, 24).Shift(saturday => saturday, sunday => sunday.AddDays(3));
            //var christmasDay1 = new DateTime(year, 12, 25).Shift(saturday => saturday, sunday => sunday.AddDays(2));
            //var christmasDay2 = new DateTime(year, 12, 26).Shift(saturday => saturday, sunday => sunday.AddDays(1));

            var observedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1),
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Нова година",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 3),
                    EnglishName = "Liberation Day",
                    LocalName = "Ден на oсвобождението на България от Oсманско робство",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "International Workers' Day",
                    LocalName = "Ден на труда и на международната работническа солидарност",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 6),
                    EnglishName = "Saint George's Day",
                    LocalName = "Гергьовден, ден на храбростта и Българската армия",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 24),
                    EnglishName = "Saints Cyril and Methodius Day",
                    LocalName = "Ден на Българската просвета и култура и на славянската писменост",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 6),
                    EnglishName = "Unification Day",
                    LocalName = "Ден на съединението",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 22),
                    EnglishName = "Independence Day",
                    LocalName = "Ден на независимостта на България",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },

                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Бъдни вечер",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = new ObservedRuleSet
                    {
                        Sunday = date => date.AddDays(3)
                    }
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Рождество Христово",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = new ObservedRuleSet
                    {
                        Sunday = date => date.AddDays(2)
                    }
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Second day of Christmas",
                    LocalName = "Рождество Христово",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = new ObservedRuleSet
                    {
                        Sunday = date => date.AddDays(1)
                    }
                },
                this._orthodoxProvider.GoodFriday("Разпети петък", year),
                this._orthodoxProvider.HolySaturday("Велика събота", year),
                this._orthodoxProvider.EasterSunday("Великден", year),
                this._orthodoxProvider.EasterMonday("Велики понеделник", year)
            };

            return holidaySpecifications;

            //var items = new List<Holiday>();
            //items.Add(new Holiday(newYearDay, "Нова година", "New Year's Day", countryCode, 1967));
            //items.Add(new Holiday(liberationDay, "Ден на oсвобождението на България от Oсманско робство", "Liberation Day", countryCode));
            //items.Add(this._orthodoxProvider.GoodFriday("Разпети петък", year, countryCode));
            //items.Add(this._orthodoxProvider.HolySaturday("Велика събота", year, countryCode));
            //items.Add(this._orthodoxProvider.EasterSunday("Великден", year, countryCode));
            //items.Add(this._orthodoxProvider.EasterMonday("Велики понеделник", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Ден на труда и на международната работническа солидарност", "International Workers' Day", countryCode));
            //items.Add(new Holiday(saintGeorgesDay, "Гергьовден, ден на храбростта и Българската армия", "Saint George's Day", countryCode));
            //items.Add(new Holiday(year, 5, 24, "Ден на Българската просвета и култура и на славянската писменост", "Saints Cyril and Methodius Day", countryCode));
            //items.Add(new Holiday(year, 9, 6, "Ден на съединението", "Unification Day", countryCode));
            //items.Add(new Holiday(independenceDay, "Ден на независимостта на България", "Independence Day", countryCode));
            //items.Add(new Holiday(christmasEve, "Бъдни вечер", "Christmas Eve", countryCode));
            //items.Add(new Holiday(christmasDay1, "Рождество Христово", "Christmas Day", countryCode));
            //items.Add(new Holiday(christmasDay2, "Рождество Христово", "Second day of Christmas", countryCode));

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Bulgaria",
            ];
        }
    }
}
