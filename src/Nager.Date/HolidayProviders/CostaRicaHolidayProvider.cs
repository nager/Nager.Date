using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Costa Rica HolidayProvider
    /// </summary>
    internal sealed class CostaRicaHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// CostaRica HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public CostaRicaHolidayProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.CR;

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Año Nuevo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 2),
                    EnglishName = "Feast of Our Lady of the Angels",
                    LocalName = "Fiesta de Nuestra Señora de los Ángeles",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Navidad",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.MaundyThursday("Jueves Santo", year),
                this._catholicProvider.GoodFriday("Viernes Santo", year)
            };

            holidaySpecifications.AddIfNotNull(this.GetJuanSantamariaDay(year));
            holidaySpecifications.AddIfNotNull(this.GetLabourDay(year));
            holidaySpecifications.AddIfNotNull(this.GetAnnexationDay(year));
            holidaySpecifications.AddIfNotNull(this.GetMothersDay(year));
            holidaySpecifications.AddIfNotNull(this.GetIndenpendenceDay(year));

            if (year >= 2020)
            {
                holidaySpecifications.AddIfNotNull(this.GetArmyAbolitionDay(year));
            }
            else
            {
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 12),
                    EnglishName = "Cultures Day",
                    LocalName = "Día de las Culturas",
                    HolidayTypes = HolidayTypes.Public
                });
            }

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode));
            //items.Add(this._catholicProvider.MaundyThursday("Jueves Santo", year, countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Viernes Santo", year, countryCode));
            //items.Add(new Holiday(year, 8, 2, "Fiesta de Nuestra Señora de los Ángeles", "Feast of Our Lady of the Angels", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Navidad", "Christmas Day", countryCode));
            //items.Add(this.GetJuanSantamariaDay(year, countryCode));
            //items.Add(this.GetLabourDay(year, countryCode));
            //items.Add(this.GetAnnexationDay(year, countryCode));            
            //items.Add(this.GetMothersDay(year, countryCode));
            //items.Add(this.GetIndenpendenceDay(year, countryCode));            

            //Law 9803
            //if (year >= 2020)
            //{
            //    items.Add(this.GetArmyAbolitionDay(year, countryCode));
            //}
            //else
            //{
            //    items.Add(new Holiday(year, 10, 12, "Día de las Culturas", "Cultures Day", countryCode));
            //}

            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Costa_Rica",
            };
        }

        private HolidaySpecification GetJuanSantamariaDay(int year)
        {
            ObservedRuleSet observedRuleSet = null;
            if (year == 2020 || year == 2021 || year == 2022)
            {
                observedRuleSet = this.Law9875RuleSet();
            }

            return new HolidaySpecification
            {
                Date = new DateTime(year, 4, 11),
                EnglishName = "Juan Santamaría Day",
                LocalName = "Día de Juan Santamaría",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };

            //return new Holiday(juanSantamariaDay, "Día de Juan Santamaría", "Juan Santamaría Day", countryCode);
        }

        private HolidaySpecification GetLabourDay(int year)
        {
            ObservedRuleSet observedRuleSet = null;
            if (year == 2020 || year == 2021 || year == 2022)
            {
                observedRuleSet = this.Law9875RuleSet();
            }

            return new HolidaySpecification
            {
                Date = new DateTime(year, 5, 1),
                EnglishName = "Labour Day",
                LocalName = "Día Internacional del Trabajo",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };

            //return new Holiday(labourDay, "Día Internacional del Trabajo", "Labour Day", countryCode);
        }

        private HolidaySpecification GetAnnexationDay(int year)
        {
            ObservedRuleSet observedRuleSet = null;
            if (year == 2020 || year == 2021 || year == 2022)
            {
                observedRuleSet = this.Law9875RuleSet();
            }

            return new HolidaySpecification
            {
                Date = new DateTime(year, 7, 25),
                EnglishName = "Annexation of the Party of Nicoya to Costa Rica",
                LocalName = "Anexión del Partido de Nicoya a Costa Rica",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };

            //return new Holiday(annexationDay, "Anexión del Partido de Nicoya a Costa Rica", "Annexation of the Party of Nicoya to Costa Rica", countryCode);
        }

        private HolidaySpecification GetMothersDay(int year)
        {
            ObservedRuleSet observedRuleSet = null;
            if (year == 2020 || year == 2021 || year == 2022)
            {
                observedRuleSet = this.Law9875RuleSet();
            }

            return new HolidaySpecification
            {
                Date = new DateTime(year, 8, 15),
                EnglishName = "Mother's Day",
                LocalName = "Día de la Madre",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };

            //return new Holiday(mothersDay, "Día de la Madre", "Mother's Day", countryCode);
        }

        private HolidaySpecification GetIndenpendenceDay(int year)
        {
            ObservedRuleSet observedRuleSet = null;
            if (year == 2020 || year == 2021 || year == 2022)
            {
                observedRuleSet = this.Law9875RuleSet();
            }

            return new HolidaySpecification
            {
                Date = new DateTime(year, 9, 15),
                EnglishName = "Independence Day",
                LocalName = "Día de la Independencia",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };

            //return new Holiday(indenpendenceDay, "Día de la Independencia", "Independence Day", countryCode);
        }

        private HolidaySpecification GetArmyAbolitionDay(int year)
        {
            ObservedRuleSet observedRuleSet = null;
            if (year == 2020 || year == 2021 || year == 2022)
            {
                observedRuleSet = this.Law9875RuleSet();
            }

            return new HolidaySpecification
            {
                Date = new DateTime(year, 12, 1),
                EnglishName = "Army Abolition Day",
                LocalName = "Día de la Abolición del Ejército",
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet
            };

            //return new Holiday(armyAbolitionDay, "Día de la Abolición del Ejército", "Army Abolition Day", countryCode);
        }

        private ObservedRuleSet Law9875RuleSet()
        {
            return new ObservedRuleSet
            {
                Tuesday = date => date.AddDays(-1),
                Wednesday = date => date.AddDays(-2),
                Thursday = date => date.AddDays(4),
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1)
            };


            //date = date.Shift(saturday: saturday => saturday.AddDays(2), sunday: sunday => sunday.AddDays(1));
            //date = date.ShiftWeekdays(
            //    tuesday: tuesday => tuesday.AddDays(-1),
            //    wednesday: wednesday => wednesday.AddDays(-2),
            //    thursday: thursday => thursday.AddDays(4)
            //    );
            //return date;
        }
    }
}
