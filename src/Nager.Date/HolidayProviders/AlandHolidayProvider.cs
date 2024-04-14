using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Åland HolidayProvider
    /// </summary>
    internal sealed class AlandHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Aland HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public AlandHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.AX)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var thirdFridayInJune = DateHelper.FindDay(year, Month.June, DayOfWeek.Friday, Occurrence.Third);
            var thirdSaturdayInJune = DateHelper.FindDay(year, Month.June, DayOfWeek.Saturday, Occurrence.Third);
            var firstSaturdayInNovember = DateHelper.FindDay(year, Month.November, DayOfWeek.Saturday, Occurrence.First);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Nyårsdagen",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 6),
                    EnglishName = "Epiphany",
                    LocalName = "Trettondagen",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "May Day",
                    LocalName = "Första maj",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 9),
                    EnglishName = "Autonomy Day",
                    LocalName = "Självstyrelsedagen",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = thirdFridayInJune,
                    EnglishName = "Midsummer Evey",
                    LocalName = "Midsommarafton",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = thirdSaturdayInJune,
                    EnglishName = "Midsummer Day",
                    LocalName = "Midsommardagen",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = firstSaturdayInNovember,
                    EnglishName = "All Saints Day",
                    LocalName = "Alla helgons dag",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 6),
                    EnglishName = "Independence Day",
                    LocalName = "Självständighetsdagen",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 24),
                    EnglishName = "Christmas Eve",
                    LocalName = "Julafton",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Juldagen",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Annandag jul",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.GoodFriday("Långfredag", year),
                this._catholicProvider.EasterSunday("Påskdagen", year),
                this._catholicProvider.EasterMonday("Annandag påsk", year),
                this._catholicProvider.AscensionDay("Kristi himmelsfärdsdagn", year),
                this._catholicProvider.Pentecost("Pingstdagen", year)
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_%C3%85land",
                "https://de.wikipedia.org/wiki/%C3%85land"
            ];
        }
    }
}
