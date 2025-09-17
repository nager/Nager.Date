using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Democratic Republic of the Congo HolidayProvider
    /// </summary>
    internal sealed class DemocraticRepublicOfCongoHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Democratic Republic of the Congo HolidayProvider
        /// </summary>
        public DemocraticRepublicOfCongoHolidayProvider() : base(CountryCode.CD)
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
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "MARTYRSDAY-01",
                    Date = new DateTime(year, 1, 4),
                    EnglishName = "Martyrs Day",
                    LocalName = "Martyrs Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LAURENTDESIREKABILAASSASSINATION-01",
                    Date = new DateTime(year, 1, 16),
                    EnglishName = "Laurent-Désiré Kabila Assassination",
                    LocalName = "Laurent-Désiré Kabila Assassination",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "PATRICELUMUMBAASSASSINATION-01",
                    Date = new DateTime(year, 1, 17),
                    EnglishName = "Patrice Lumumba Assassination",
                    LocalName = "Patrice Lumumba Assassination",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "KIMBANGUSDAY-01",
                    Date = new DateTime(year, 4, 6),
                    EnglishName = "Kimbangu's Day",
                    LocalName = "Kimbangu's Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Labour Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LIBERATIONDAY-01",
                    Date = new DateTime(year, 5, 17),
                    EnglishName = "Liberation Day",
                    LocalName = "Liberation Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 6, 30),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "PARENTSDAY-01",
                    Date = new DateTime(year, 8, 1),
                    EnglishName = "Parents' Day",
                    LocalName = "Parents' Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CONGOLESEGENOCIDEDAY-01",
                    Date = new DateTime(year, 8, 2),
                    EnglishName = "Congolese Genocide Day",
                    LocalName = "Congolese Genocide Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                }
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Democratic_Republic_of_the_Congo",
                "https://www.officeholidays.com/countries/dr-congo"
            ];
        }
    }
}
