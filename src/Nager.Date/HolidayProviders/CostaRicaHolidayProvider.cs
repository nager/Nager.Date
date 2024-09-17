using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Costa Rica HolidayProvider
    /// </summary>
    internal sealed class CostaRicaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// CostaRica HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public CostaRicaHolidayProvider(ICatholicProvider catholicProvider) : base(CountryCode.CR)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
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

            return holidaySpecifications;
        }

        private HolidaySpecification GetJuanSantamariaDay(int year)
        {
            ObservedRuleSet? observedRuleSet = null;
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
        }

        private HolidaySpecification GetLabourDay(int year)
        {
            ObservedRuleSet? observedRuleSet = null;
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
        }

        private HolidaySpecification GetAnnexationDay(int year)
        {
            ObservedRuleSet? observedRuleSet = null;
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
        }

        private HolidaySpecification GetMothersDay(int year)
        {
            ObservedRuleSet? observedRuleSet = null;
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
        }

        private HolidaySpecification GetIndenpendenceDay(int year)
        {
            ObservedRuleSet? observedRuleSet = null;
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
        }

        private HolidaySpecification GetArmyAbolitionDay(int year)
        {
            ObservedRuleSet? observedRuleSet = null;
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
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Costa_Rica",
            ];
        }
    }
}
