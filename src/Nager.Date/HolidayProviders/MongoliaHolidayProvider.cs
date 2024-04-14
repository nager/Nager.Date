using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Mongolia HolidayProvider
    /// </summary>
    internal sealed class MongoliaHolidayProvider : AbstractHolidayProvider
    {
        /// <summary>
        /// Mongolia HolidayProvider
        /// </summary>
        public MongoliaHolidayProvider() : base(CountryCode.MN)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            //TODO:Add lunar calendar support
            //TODO:Add Mongolian calendar support

            //Add Lunar New Year or Tsagaan Sar (Цагаан сар (Tsagaan sar))
            //Add Genghis Khan's birthday (Чингис хааны төрсөн өдөр (Chingis Khaany törsön ödör))

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Шинэ жил (Shine jil)",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "Олон Улсын Эмэгтэйчүүдийн Баяр",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 1),
                    EnglishName = "Naadam Holiday",
                    LocalName = "Наадам",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 11),
                    EnglishName = "Naadam Holiday",
                    LocalName = "Наадам",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 12),
                    EnglishName = "Naadam Holiday",
                    LocalName = "Наадам",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 13),
                    EnglishName = "Naadam Holiday",
                    LocalName = "Наадам",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 14),
                    EnglishName = "Naadam Holiday",
                    LocalName = "Наадам",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 15),
                    EnglishName = "Naadam Holiday",
                    LocalName = "Наадам",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 11, 26),
                    EnglishName = "Republic Day",
                    LocalName = "Улс тунхагласны өдөр",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 29),
                    EnglishName = "Independence Day",
                    LocalName = "Тусгаар Тогтнолын Өдөр",
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
                "https://en.wikipedia.org/wiki/Public_holidays_in_Mongolia"
            ];
        }
    }
}
