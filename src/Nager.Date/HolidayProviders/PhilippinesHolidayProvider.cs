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
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 9),
                    EnglishName = "Day of Valor",
                    LocalName = "Araw ng Kagitingan",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 17),
                    EnglishName = "Maundy Thursday",
                    LocalName = "Huwebes Santo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labor Day",
                    LocalName = "Araw ng Paggawa",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 12),
                    EnglishName = "Independence Day",
                    LocalName = "Araw ng Kalayaan",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = lastMondayInAugust,
                    EnglishName = "National Heroes Day",
                    LocalName = "Araw ng mga Bayani",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 30),
                    EnglishName = "Bonifacio Day",
                    LocalName = "Araw ni Gat Andres Bonifacio",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Araw ng Pasko",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 30),
                    EnglishName = "Rizal Day",
                    LocalName = "Araw ng Kamatayan ni Dr. Jose Rizal",
                    HolidayTypes = HolidayTypes.Public
                },

                //special non-working holidays
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 21),
                    EnglishName = "Ninoy Aquino Day",
                    LocalName = "Araw ng Kamatayan ni Senador Benigno Simeon \"Ninoy\" Aquino Jr.",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 1),
                    EnglishName = "All Saints' Day",
                    LocalName = "Araw ng mga Santo",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Feast of the Immaculate Conception of Mary",
                    LocalName = "Kapistahan ng Immaculada Concepcion",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 31),
                    EnglishName = "Last Day of The Year",
                    LocalName = "Huling Araw ng Taon",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 29),
                    EnglishName = "Chinese New Year",
                    LocalName = "Chinese New Year",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Christmas Eve",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 31),
                    EnglishName = "All Saints' Day Eve",
                    LocalName = "All Saints' Day Eve",
                    HolidayTypes = HolidayTypes.Public
                },
                
                this._catholicProvider.GoodFriday("Biyernes Santo", year),
                this._catholicProvider.EasterSaturday("Sabado de Gloria", year),
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                //pursuant to proclamation 727
                "https://www.officialgazette.gov.ph/downloads/2024/10oct/20241030-PROC-727-FRM.pdf"
            ];
        }
    }
}
