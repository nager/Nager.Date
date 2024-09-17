using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Mexico HolidayProvider
    /// </summary>
    internal sealed class MexicoHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Mexico HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public MexicoHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.MX)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            //Only Statutory holidays

            var firstMondayOfFebruary = DateHelper.FindDay(year, Month.February, DayOfWeek.Monday, Occurrence.First);
            var thirdMondayOfMarch = DateHelper.FindDay(year, Month.March, DayOfWeek.Monday, Occurrence.Third);
            var thirdMondayOfNovember = DateHelper.FindDay(year, Month.November, DayOfWeek.Monday, Occurrence.Third);

            var observedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(-1),
                Sunday = date => date.AddDays(1)
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Año Nuevo",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = firstMondayOfFebruary,
                    EnglishName = "Constitution Day",
                    LocalName = "Día de la Constitución",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = thirdMondayOfMarch,
                    EnglishName = "Benito Juárez's birthday",
                    LocalName = "Natalicio de Benito Juárez",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labor Day",
                    LocalName = "Día del Trabajo",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = observedRuleSet
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 16),
                    EnglishName = "Independence Day",
                    LocalName = "Día de la Independencia",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = thirdMondayOfNovember,
                    EnglishName = "Revolution Day",
                    LocalName = "Día de la Revolución",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Navidad",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.MaundyThursday("Jueves Santo", year).SetHolidayTypes(HolidayTypes.Authorities | HolidayTypes.Bank | HolidayTypes.School),
                this._catholicProvider.GoodFriday("Viernes Santo", year).SetHolidayTypes(HolidayTypes.Authorities | HolidayTypes.Bank | HolidayTypes.School)
            };

            holidaySpecifications.AddIfNotNull(this.InaugurationDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? InaugurationDay(int year)
        {
            // The president in Mexico is usually elected every 6 years
            // A reform was introduced in 2014 that changes the date from 2024

            switch (year)
            {
                case 1934:
                case 1940:
                case 1946:
                case 1952:
                case 1958:
                case 1964:
                case 1970:
                case 1976:
                case 1982:
                case 1988:
                case 1994:
                case 2000:
                case 2006:
                case 2012:
                case 2018:
                    return new HolidaySpecification
                    {
                        Date = new DateTime(year, 12, 1),
                        EnglishName = "Inauguration Day",
                        LocalName = "Transmisión del Poder Ejecutivo Federal",
                        HolidayTypes = HolidayTypes.Public
                    };
                case 2024:
                case 2030:
                case 2036:
                case 2042:
                case 2048:
                case 2054:
                case 2060:
                case 2066:
                case 2072:
                case 2078:
                    return new HolidaySpecification
                    {
                        Date = new DateTime(year, 10, 1),
                        EnglishName = "Inauguration Day",
                        LocalName = "Transmisión del Poder Ejecutivo Federal",
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
                "https://en.wikipedia.org/wiki/Public_holidays_in_Mexico"
            ];
        }
    }
}
