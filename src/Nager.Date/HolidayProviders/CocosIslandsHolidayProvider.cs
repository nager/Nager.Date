using Nager.Date.Extensions;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Cocos (Keeling) Islands HolidayProvider
    /// </summary>
    internal sealed class CocosIslandsHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Cocos (Keeling) Islands HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public CocosIslandsHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.CC)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var weekendObservedRuleSet = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(1),
            };

            var weekendObservedRuleSet2 = new ObservedRuleSet
            {
                Saturday = date => date.AddDays(2),
                Sunday = date => date.AddDays(2),
                Monday = date => date.AddDays(1),
            };

            var easterMonday = this._catholicProvider.EasterSunday(year).AddDays(1);

            DateTime ShiftIfEasterMonday(DateTime date) => date == easterMonday ? date.AddDays(1) : date;

            var selfDeterminationObservedRuleSet = new ObservedRuleSet
            {
                Saturday = date => ShiftIfEasterMonday(date.AddDays(2)),
                Sunday = date => ShiftIfEasterMonday(date.AddDays(1)),
                Monday = date => ShiftIfEasterMonday(date),
            };

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "New Year's Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "AUSTRALIADAY-01",
                    Date = new DateTime(year, 1, 26),
                    EnglishName = "Australia Day",
                    LocalName = "Australia Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "SELFDETERMINATIONDAY-01",
                    Date = new DateTime(year, 4, 6),
                    EnglishName = "Self Determination Day",
                    LocalName = "Self Determination Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = selfDeterminationObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "ANZACDAY-01",
                    Date = new DateTime(year, 4, 25),
                    EnglishName = "Anzac Day",
                    LocalName = "Anzac Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "STSTEPHENSDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "St. Stephen's Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = weekendObservedRuleSet2,
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year),
            };

            holidaySpecifications.AddIfNotNull(this.MonarchBirthday(year, weekendObservedRuleSet));

            // TODO: Islamic Holidays
            // CalendarType: Lunar
            // DeterminationType: MoonSighting (By the Islamic Council of Cocos Keeling Islands)
            // Astronomical calculation: No (Used only as a guide; official announcement depends on actual sighting)
            //Hari Raya Puasa
            //Hari Raya Haji
            //Islamic New Year
            //Hari Maulaud Nabi

            return holidaySpecifications;
        }

        private HolidaySpecification MonarchBirthday(int year, ObservedRuleSet observedRuleSet)
        {
            var name = "Queen's Birthday";
            if (year >= 2023)
            {
                name = "King's Birthday";
            }

            // Fixed on 6 June, moved to Monday when it falls on a weekend
            var holidayDate = new DateTime(year, 6, 6);

            if (year == 2025)
            {
                // Special case: Hari Raya Haji was observed on Friday, 6 June 2025 (in lieu of Saturday, 7 June 2025),
                // therefore King's Birthday was moved to Monday, 9 June 2025
                // (source: Proclamation No 03/2024, IOT Administrator bulletin A21/2024)
                holidayDate = new DateTime(2025, 6, 9);
            }

            return new HolidaySpecification
            {
                Id = "MONARCHBIRTHDAY-01",
                Date = holidayDate,
                EnglishName = name,
                LocalName = name,
                HolidayTypes = HolidayTypes.Public,
                ObservedRuleSet = observedRuleSet,
            };
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_the_Cocos_(Keeling)_Islands",
                "https://www.infrastructure.gov.au/territories-regions-cities/territories/indian_ocean/iot_bulletins/2020/A041-2020-cki-public-holidays",
                "https://www.infrastructure.gov.au/sites/default/files/documents/a19-2022-community-bulletin-2023-kings-birthday-cocos-keeling-islands.pdf",
                "https://www.infrastructure.gov.au/sites/default/files/documents/a12-2023-2024-public-holidays-cocos-k-islands.pdf",
                "https://www.infrastructure.gov.au/sites/default/files/documents/a21-2024-administrator-community-bulletin-cki-public-holidays-2025.pdf",
                "https://www.infrastructure.gov.au/sites/default/files/documents/community-bulletin-cki-public-holidays-2026.pdf",
                "https://www.infrastructure.gov.au/sites/default/files/documents/2027-public-holidays-cocos-keeling-islands-a15-2026-24-july-2026-pdf.pdf",
            ];
        }
    }
}
