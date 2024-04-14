using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Belarus HolidayProvider
    /// </summary>
    internal sealed class BelarusHolidayProvider : AbstractHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// Belarus HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public BelarusHolidayProvider(
            IOrthodoxProvider orthodoxProvider) : base(CountryCode.BY)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var easterSunday = this._orthodoxProvider.EasterSunday(year);

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Новы год",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "New Year's Day",
                    LocalName = "Новы год",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 7),
                    EnglishName = "Orthodox Christmas Day",
                    LocalName = "Каляды праваслаўныя",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "Мiжнародны жаночы дзень",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Дзень працы",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 9),
                    EnglishName = "Victory Day",
                    LocalName = "Дзень Перамогi",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 3),
                    EnglishName = "Independence Day",
                    LocalName = "Дзень Незалежнасцi",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 7),
                    EnglishName = "October Revolution Day",
                    LocalName = "Дзень Кастрычніцкай рэвалюцыі",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Catholic Christmas Day",
                    LocalName = "Каляды каталiцкiя",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Date = easterSunday.AddDays(9),
                    EnglishName = "Commemoration Day",
                    LocalName = "Радунiца",
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
                "https://en.wikipedia.org/wiki/Public_holidays_in_Belarus"
            ];
        }
    }
}
