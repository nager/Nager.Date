using Nager.Date.Helpers;
using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Papua New Guinea HolidayProvider
    /// </summary>
    internal sealed class PapuaNewGuineaHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Papua New Guinea HolidayProvider
        /// </summary>
        /// <param name="catholicProvider">CatholicProvider</param>
        public PapuaNewGuineaHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.PG)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            // Public Holidays Act 1953, s. 1(2): Sunday -> next Monday
            // (not for Independence Day and Christmas Day)
            var sundayToMondayRuleSet = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(1),
            };

            // Public Holidays Act 1953, s. 1(3): Christmas Day on Sunday -> following Tuesday
            // (Monday is already Boxing Day)
            var christmasRuleSet = new ObservedRuleSet
            {
                Sunday = date => date.AddDays(2),
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
                    ObservedRuleSet = sundayToMondayRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALREMEMBRANCEDAY-01",
                    Date = new DateTime(year, 7, 23),
                    EnglishName = "National Remembrance Day",
                    LocalName = "National Remembrance Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayToMondayRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALREPENTANCEDAY-01",
                    Date = new DateTime(year, 8, 26),
                    EnglishName = "National Day of Repentance",
                    LocalName = "National Day of Repentance",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "INDEPENDENCEDAY-01",
                    Date = new DateTime(year, 9, 16),
                    EnglishName = "Independence Day",
                    LocalName = "Independence Day",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "CHRISTMASDAY-01",
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Christmas Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = christmasRuleSet,
                },
                new HolidaySpecification
                {
                    Id = "BOXINGDAY-01",
                    Date = new DateTime(year, 12, 26),
                    EnglishName = "Boxing Day",
                    LocalName = "Boxing Day",
                    HolidayTypes = HolidayTypes.Public,
                    ObservedRuleSet = sundayToMondayRuleSet,
                },
                this._catholicProvider.GoodFriday("Good Friday", year),
                this._catholicProvider.EasterSaturday("Easter Saturday", year),
                this._catholicProvider.EasterSunday("Easter Sunday", year),
                this._catholicProvider.EasterMonday("Easter Monday", year),
                this.GetMonarchBirthday(year, sundayToMondayRuleSet),
            };

            if (year == 2022)
            {
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "NATIONALREMEMBRANCEDAYSOMARE-01",
                    Date = new DateTime(2022, 2, 26),
                    EnglishName = "National Remembrance Day for Grand Chief Sir Michael Somare",
                    LocalName = "National Remembrance Day for Grand Chief Sir Michael Somare",
                    HolidayTypes = HolidayTypes.Public,
                });
            }

            return holidaySpecifications;
        }

        private HolidaySpecification GetMonarchBirthday(int year, ObservedRuleSet observedRuleSet)
        {
            var name = year >= 2023 ? "King's Birthday" : "Queen's Birthday";
            var date = year >= 2023
                ? new DateTime(year, 6, 17)
                : DateHelper.FindDay(year, Month.June, DayOfWeek.Monday, Occurrence.Second);

            return new HolidaySpecification
            {
                Id = "MONARCHBIRTHDAY-01",
                Date = date,
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
                "https://www.ipa.gov.pg/public/Holidays.aspx",
                "https://en.wikipedia.org/wiki/Public_holidays_in_Papua_New_Guinea",
                "https://web.archive.org/web/20250406104407/http://www.paclii.org/pg/legis/consol_act/pha1953163.pdf",
                "https://web.archive.org/web/20230530042019/https://publicholidays.asia/wp-content/uploads/2022/01/PNG_PublicHolidays_2022.pdf",
                "https://web.archive.org/web/20240625200332/https://publicholidays.asia/wp-content/uploads/2020/12/PNG_PublicHolidays_2021.pdf",
            ];
        }
    }
}
