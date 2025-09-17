using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Slovenia HolidayProvider
    /// </summary>
    internal sealed class SloveniaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Slovenia HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public SloveniaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.SI)
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
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "novo leto",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-02",
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "New Year's Day",
                    LocalName = "novo leto",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "PRESERENDAY-01",
                    Date = new DateTime(year, 2, 8),
                    EnglishName = "Prešeren Day",
                    LocalName = "Prešernov dan",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "DAYOFUPRISINGAGAINSTOCCUPATION-01",
                    Date = new DateTime(year, 4, 27),
                    EnglishName = "Day of Uprising Against Occupation",
                    LocalName = "dan upora proti okupatorju",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "praznik dela",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-02",
                    Date = new DateTime(year, 5, 2),
                    EnglishName = "Labour Day",
                    LocalName = "praznik dela",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "PRIMOZTRUBARDAY-01",
                    Date = new DateTime(year, 5, 2),
                    EnglishName = "Primož Trubar Day",
                    LocalName = "dan Primoža Trubarja",
                    HolidayTypes = HolidayTypes.Observance
                },
                new HolidaySpecification
                {
                    Id = "STATEHOODDAY-01",
                    Date = new DateTime(year, 6, 25),
                    EnglishName = "Statehood Day",
                    LocalName = "dan državnosti",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "ASSUMPTIONDAY-01",
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Assumption Day",
                    LocalName = "Marijino vnebovzetje",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "UNIFICATIONOFSLOVENES-01",
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Unification of Prekmurje Slovenes with the Mother Nation",
                    LocalName = "združitev prekmurskih Slovencev z matičnim narodom",
                    HolidayTypes = HolidayTypes.Observance
                },
                new HolidaySpecification
                {
                    Id = "INTEGRATIONOFPRIMORSKA-01",
                    Date = new DateTime(year, 9, 15),
                    EnglishName = "Integration of Primorska into the Homeland",
                    LocalName = "priključitev Primorske k matični domovini",
                    HolidayTypes = HolidayTypes.Observance
                },
                new HolidaySpecification
                {
                    Id = "SLOVENIANSPORTSDAY-01",
                    Date = new DateTime(year, 9, 23),
                    EnglishName = "Slovenian Sports Day",
                    LocalName = "dan slovenskega športa",
                    HolidayTypes = HolidayTypes.Observance
                },
                new HolidaySpecification
                {
                    Id = "REFORMATIONDAY-01",
                    Date = new DateTime(year, 10, 31),
                    EnglishName = "Reformation Day",
                    LocalName = "dan reformacije",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "DAYOFTHEDEAD-01",
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "Day of the Dead",
                    LocalName = "dan spomina na mrtve",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "RUDOLFMAISTERDAY-01",
                    Date = new DateTime(year, 11, 23),
                    EnglishName = "Rudolf Maister Day",
                    LocalName = "dan Rudolfa Maistra",
                    HolidayTypes = HolidayTypes.Observance
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "božič",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEANDUNITYDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Independence and Unity Day",
                    LocalName = "dan samostojnosti in enotnosti",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.EasterSunday("velikonočna nedelja in ponedeljek", year),
                this._catholicProvider.EasterMonday("velikonočna nedelja in ponedeljek", year),
                this._catholicProvider.Pentecost("binkoštna nedelja", year) //Whit Sunday
            };

            holidaySpecifications.AddIfNotNull(this.SolidarityDay(year));
            holidaySpecifications.AddIfNotNull(this.SovereigntyDay(year));

            return holidaySpecifications;
        }

        private HolidaySpecification? SolidarityDay(int year)
        {
            if (year == 2023)
            {
                return new HolidaySpecification
                {
                    Id = "SOLIDARITYDAY-01",
                    Date = new DateTime(year, 8, 14),
                    EnglishName = "Solidarity Day",
                    LocalName = "dan solidarnosti",
                    HolidayTypes = HolidayTypes.Public
                };
            }

            return null;
        }

        private HolidaySpecification? SovereigntyDay(int year)
        {
            if (year >= 2015)
            {
                return new HolidaySpecification
                {
                    Id = "SOVEREIGNTYDAY-01",
                    Date = new DateTime(year, 8, 14),
                    EnglishName = "Sovereignty Day",
                    LocalName = "dan suverenosti",
                    HolidayTypes = HolidayTypes.Observance
                };
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://www.gov.si/en/topics/national-holidays/",
                "https://en.wikipedia.org/wiki/Public_holidays_in_Slovenia",
                "https://www.gov.si/en/topics/national-holidays/",
                "https://www.gov.si/teme/drzavni-prazniki-in-dela-prosti-dnevi/"
            ];
        }
    }
}
