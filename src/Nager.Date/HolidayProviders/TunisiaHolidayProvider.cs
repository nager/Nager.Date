using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Tunisia HolidayProvider
    /// </summary>
    internal sealed class TunisiaHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Tunisia HolidayProvider
        /// </summary>
        public TunisiaHolidayProvider() : base(CountryCode.TN)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            //TODO:Add moon calendar logic

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "رأس السنة الميلادية",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 20),
                    EnglishName = "Independence Day",
                    LocalName = "عيد الاستقلال",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 4, 9),
                    EnglishName = "Martyrs' Day",
                    LocalName = "عيد الشهداء",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "عيد الشغل",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 25),
                    EnglishName = "Republic Day",
                    LocalName = "عيد الجمهورية",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 13),
                    EnglishName = "Women's Day",
                    LocalName = "عيد المرأة",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 15),
                    EnglishName = "Evacuation Day",
                    LocalName = "عيد الجلاء",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 17),
                    EnglishName = "Revolution Day",
                    LocalName = "عيد الثورة",
                    HolidayTypes = HolidayTypes.Public
                }
            };

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Tunisia"
            ];
        }
    }
}
