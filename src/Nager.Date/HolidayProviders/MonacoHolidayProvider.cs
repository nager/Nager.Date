using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Monaco HolidayProvider
    /// </summary>
    internal class MonacoHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Monaco HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public MonacoHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.MC;

            //var newYearsDay = new DateTime(year, 1, 1).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            //var allSaintsDay = new DateTime(year, 11, 1).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            //var nationalDay = new DateTime(year, 11, 19).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            //var christmasDay = new DateTime(year, 12, 25).Shift(saturday => saturday, sunday => sunday.AddDays(1));

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
                    LocalName = "Le jour de l’An",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 27),
                    EnglishName = "Saint Devota's Day",
                    LocalName = "La Sainte Dévote",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "May Day",
                    LocalName = "Le 1er mai",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "L'Assomption de Marie",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints Day",
                    LocalName = "La Toussaint",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 19),
                    EnglishName = "National Day",
                    LocalName = "La Fête du Prince",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "The Immaculate Conception",
                    LocalName = "L’Immaculée Conception",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "​Christmas Day",
                    LocalName = "Noël​",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                this._catholicProvider.EasterMonday("Easter Monday", year),
                this._catholicProvider.AscensionDay("L’Ascension", year),
                this._catholicProvider.WhitMonday("Le lundi de Pentecôte", year),
                this._catholicProvider.CorpusChristi("La Fête Dieu", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(newYearsDay, "Le jour de l’An", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 1, 27, "La Sainte Dévote", "Saint Devota's Day", countryCode));
            //items.Add(this._catholicProvider.EasterMonday("Easter Monday", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Le 1er mai", "May Day", countryCode));
            //items.Add(this._catholicProvider.AscensionDay("L’Ascension", year, countryCode));
            //items.Add(this._catholicProvider.WhitMonday("Le lundi de Pentecôte", year, countryCode));
            //items.Add(this._catholicProvider.CorpusChristi("La Fête Dieu", year, countryCode));
            //items.Add(new Holiday(year, 8, 15, "L'Assomption de Marie", "Assumption Day", countryCode));
            //items.Add(new Holiday(allSaintsDay, "La Toussaint", "All Saints Day", countryCode));
            //items.Add(new Holiday(nationalDay, "La Fête du Prince", "National Day", countryCode));
            //items.Add(new Holiday(year, 12, 8, "L’Immaculée Conception", "The Immaculate Conception", countryCode));
            //items.Add(new Holiday(christmasDay, "Noël​", "​Christmas Day", countryCode));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Monaco"
            };
        }
    }
}
