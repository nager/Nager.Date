using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Mozambique HolidayProvider
    /// </summary>
    internal sealed class MozambiqueHolidayProvider : AbstractHolidayProvider, ISubdivisionCodesProvider
    {
        /// <summary>
        /// Mozambique HolidayProvider
        /// </summary>
        public MozambiqueHolidayProvider() : base(CountryCode.MZ)
        {
        }

        /// <inheritdoc/>
        public IDictionary<string, string> GetSubdivisionCodes()
        {
            //List of Provinces https://en.wikipedia.org/wiki/Provinces_of_Mozambique

            return new Dictionary<string, string>
            {
                { "MZ-CD","Cabo Delgado" },
                { "MZ-GZ", "Gaza" },
                { "MZ-IH", "Inhambane" },
                { "MZ-MA", "Manica" },
                { "MZ-MP", "Maputo Cidade" },
                { "MZ-MT", "Maputo" },
                { "MZ-NA", "Nampula" },
                { "MZ-NI", "Niassa" },
                { "MZ-SO", "Sofala" },
                { "MZ-TE", "Tete" },
                { "MZ-ZA", "Zambezia" }
            };
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
                    LocalName = "Dia de Ano Novo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 2, 3),
                    EnglishName = "Heroes's Day",
                    LocalName = "Dia do Heroi Nacional",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 7),
                    EnglishName = "Women's Day",
                    LocalName = "Dia da Mulher",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Worker's Day",
                    LocalName = "Dia do Trabalhador",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 25),
                    EnglishName = "Independence Day",
                    LocalName = "Dia da Independência",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 7),
                    EnglishName = "Victory Day",
                    LocalName = "Dia da Victória",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 25),
                    EnglishName = "Revolution Day",
                    LocalName = "Dia da Revolução",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 4),
                    EnglishName = "Day of Peace and Reconciliation",
                    LocalName = "Dia da Paz e da Reconcialição",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Natal",
                    HolidayTypes = HolidayTypes.Public
                }
            };

            return holidaySpecifications;

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Dia de Ano Novo", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 2, 3, "Dia do Heroi Nacional", "Heroes's Day", countryCode));
            //items.Add(new Holiday(year, 4, 7, "Dia da Mulher", "Women's Day", countryCode));
            //items.Add(new Holiday(year, 5, 1, "Dia do Trabalhador", "worker's Day", countryCode));
            //items.Add(new Holiday(year, 6, 25, "Dia da Independência", "Independence Day", countryCode));
            //items.Add(new Holiday(year, 9, 7, "Dia da Victória", "Victory Day", countryCode));
            //items.Add(new Holiday(year, 9, 25, "Dia da Revolução", "Revolution Day", countryCode));
            //items.Add(new Holiday(year, 10, 4, "Dia da Paz e da Reconcialição", "Day of Peace and Reconciliation", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Natal", "Christmas Day", countryCode));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Mozambique"
            ];
        }
    }
}
