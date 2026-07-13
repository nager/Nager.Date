using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// São Tomé and Príncipe HolidayProvider
    /// </summary>
    internal sealed class SaoTomeAndPrincipeHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// São Tomé and Príncipe HolidayProvider
        /// </summary>
        public SaoTomeAndPrincipeHolidayProvider() : base(CountryCode.ST)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Ano Novo",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "MARTYRSDAY-01",
                    Date = new DateTime(year, 2, 3),
                    EnglishName = "Martyrs' Day",
                    LocalName = "Dia dos Mártires",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Dia do trabalhador",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 7, 12),
                    EnglishName = "Independence Day",
                    LocalName = "Dia da Independência",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "ARMEDFORCESDAY-01",
                    Date = new DateTime(year, 9, 6),
                    EnglishName = "Armed Forces Day",
                    LocalName = "Dia das Forças Armadas",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "AGRICULTURALREFORMDAY-01",
                    Date = new DateTime(year, 9, 30),
                    EnglishName = "Agricultural Reform Day",
                    LocalName = "Dia da Reforma Agrária",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "SAOTOMEDAY-01",
                    Date = new DateTime(year, 12, 21),
                    EnglishName = "São Tomé Day",
                    LocalName = "Dia de São Tomé",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Natal",
                    HolidayTypes = HolidayTypes.Public,
                },
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_S%C3%A3o_Tom%C3%A9_and_Pr%C3%ADncipe",
            ];
        }
    }
}
