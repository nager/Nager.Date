using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Angola HolidayProvider
    /// </summary>
    internal sealed class AngolaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Angola HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public AngolaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.AO)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Dia de Ano Novo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "LIBERATIONDAY-01",
                    Date = new DateTime(year, 2, 4),
                    EnglishName = "Liberation Day",
                    LocalName = "Dia da Libertação",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CARNIVAL-01",
                    Date = easterSunday.AddDays(-48),
                    EnglishName = "Carnival",
                    LocalName = "Carnaval",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "INTERNATIONALWOMENSDAY-01",
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "Dia Internacional da Mulher",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "LIBERATIONDAYSOUTHERNAFRICA-01",
                    Date = new DateTime(year, 3, 23),
                    EnglishName = "Day of the Liberation of Southern Africa",
                    LocalName = "Dia da Libertação da África Austral",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "PEACEDAY-01",
                    Date = new DateTime(year, 4, 4),
                    EnglishName = "Peace Day",
                    LocalName = "Dia da Paz",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Dia do Trabalhador",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "NATIONALHEROESDAY-01",
                    Date = new DateTime(year, 9, 17),
                    EnglishName = "National Heroes' Day",
                    LocalName = "Dia do Fundador da Nação e do Herói Nacional",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "ALLSOULSDAY-01",
                    Date = new DateTime(year, 11, 2),
                    EnglishName = "All Souls' Day",
                    LocalName = "Dia de Finados",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 11, 11),
                    EnglishName = "Independence Day",
                    LocalName = "Dia da Independência",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Dia de Natal",
                    HolidayTypes = HolidayTypes.Public
                },

                this._catholicProvider.GoodFriday("Sexta Feira Santa", year),
            };

            return this.Ponte(holidaySpecifications);

            //return holidaySpecifications;
        }


        private IEnumerable<HolidaySpecification> Ponte(IEnumerable<HolidaySpecification> holidaySpecifications)
        {
            foreach (var holidaySpecification in holidaySpecifications)
            {
                if (holidaySpecification.Date.DayOfWeek == DayOfWeek.Tuesday)
                {
                    yield return new HolidaySpecification
                    {
                        Id = $"PONTE-{holidaySpecification.Id}",
                        Date = holidaySpecification.Date.AddDays(-1),
                        EnglishName = $"{holidaySpecification.EnglishName} (Ponte)",
                        LocalName = $"{holidaySpecification.LocalName} (Ponte)",
                        HolidayTypes = HolidayTypes.Public
                    };
                }
                else if (holidaySpecification.Date.DayOfWeek == DayOfWeek.Thursday)
                {
                    yield return new HolidaySpecification
                    {
                        Id = $"PONTE-{holidaySpecification.Id}",
                        Date = holidaySpecification.Date.AddDays(1),
                        EnglishName = $"{holidaySpecification.EnglishName} (Ponte)",
                        LocalName = $"{holidaySpecification.LocalName} (Ponte)",
                        HolidayTypes = HolidayTypes.Public
                    };
                }

                yield return holidaySpecification;
            }
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Angola"
            ];
        }
    }
}
