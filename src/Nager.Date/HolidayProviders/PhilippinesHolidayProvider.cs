using Nager.Date.Extensions;
using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Philippines HolidayProvider
    /// </summary>
    internal sealed class PhilippinesHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Philippines HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public PhilippinesHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.PH)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var lastMondayInAugust = DateHelper.FindLastDay(year, Month.August, DayOfWeek.Monday);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Bagong Taon",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "DAYOFVALOR-01",
                    Date = new DateTime(year, 4, 9),
                    EnglishName = "Day of Valor",
                    LocalName = "Araw ng Kagitingan",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "MAUNDYTHURSDAY-01",
                    Date = new DateTime(year, 4, 17),
                    EnglishName = "Maundy Thursday",
                    LocalName = "Huwebes Santo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "LABORDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labor Day",
                    LocalName = "Araw ng Paggawa",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 6, 12),
                    EnglishName = "Independence Day",
                    LocalName = "Araw ng Kalayaan",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "NATIONALHEROESDAY-01",
                    Date = lastMondayInAugust,
                    EnglishName = "National Heroes Day",
                    LocalName = "Araw ng mga Bayani",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "BONIFACIODAY-01",
                    Date = new DateTime(year, 11, 30),
                    EnglishName = "Bonifacio Day",
                    LocalName = "Araw ni Gat Andres Bonifacio",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Araw ng Pasko",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "RIZALDAY-01",
                    Date = new DateTime(year, 12, 30),
                    EnglishName = "Rizal Day",
                    LocalName = "Araw ng Kamatayan ni Dr. Jose Rizal",
                    HolidayTypes = HolidayTypes.Public
                },

                //special non-working holidays
                new HolidaySpecification
                {
                    Id = "NINOYAQUINODAY-01",
                    Date = new DateTime(year, 8, 21),
                    EnglishName = "Ninoy Aquino Day",
                    LocalName = "Araw ng Kamatayan ni Senador Benigno Simeon \"Ninoy\" Aquino Jr.",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "ALLSAINTSDAY-01",
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints' Day",
                    LocalName = "Araw ng mga Santo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "IMMACULATECONCEPTIONMARY-01",
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Feast of the Immaculate Conception of Mary",
                    LocalName = "Kapistahan ng Immaculada Concepcion",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "LASTDAYOFTHEYEAR-01",
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "Last Day of The Year",
                    LocalName = "Huling Araw ng Taon",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CHINESENEWYEAR-01",
                    Date = new DateTime(year, 1, 29),
                    EnglishName = "Chinese New Year",
                    LocalName = "Chinese New Year",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASEVE-01",
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Christmas Eve",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Id = "ALLSAINTSDAYEVE-01",
                    Date = new DateTime(year, 10, 31),
                    EnglishName = "All Saints' Day Eve",
                    LocalName = "All Saints' Day Eve",
                    HolidayTypes = HolidayTypes.Public
                },
                
                this._catholicProvider.GoodFriday("Biyernes Santo", year),
                this._catholicProvider.EasterSaturday("Sabado de Gloria", year),
            };

            holidaySpecifications.AddIfNotNull(this.Ramadhan(year));
            holidaySpecifications.AddIfNotNull(this.Election2025(year));
            holidaySpecifications.AddIfNotNull(this.EidlAdha(year));
            return holidaySpecifications;
        }

        // proclamation no. 839
        private HolidaySpecification? Ramadhan(int year)
        {
            if (year == 2025)
            {
                return new HolidaySpecification
                {
                    Id = "RAMADHAN-01",
                    Date = new DateTime(year, 4, 1),
                    EnglishName = "Feast of Ramadhan",
                    LocalName = "Eid’l Fitr",
                    HolidayTypes = HolidayTypes.Public,
                };
            }

            return null;
        }

        // proclamation no. 878
        private HolidaySpecification? Election2025(int year)
        {
            if (year == 2025)
            {
                return new HolidaySpecification
                {
                    Id = "MIDTERMELECTIONS-01",
                    Date = new DateTime(year, 5, 12),
                    EnglishName = "Midterm Elections",
                    LocalName = "Halalan 2025",
                    HolidayTypes = HolidayTypes.Public,
                };
            }

            return null;
        }

        // proclamation no. 911
        private HolidaySpecification? EidlAdha(int year)
        {
            if (year == 2025)
            {
                return new HolidaySpecification
                {
                    Id = "FEASTOFSACRIFICE-01",
                    Date = new DateTime(year, 6, 6),
                    EnglishName = "Feast of Sacrifice",
                    LocalName = "Eid'l Adha",
                    HolidayTypes = HolidayTypes.Public,
                };
            }

            return null;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                //pursuant to proclamation 727
                "https://www.officialgazette.gov.ph/downloads/2024/10oct/20241030-PROC-727-FRM.pdf",

                //pursuant to proclamation 878
                "https://www.officialgazette.gov.ph/downloads/2025/05may/20250506-PROC-878-FRM.pdf",

                //pursuant to proclamation 911
                "https://www.officialgazette.gov.ph/downloads/2025/05may/20250521-PROC-911-FRM.pdf"
            ];
        }
    }
}
