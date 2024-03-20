using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Mongoli HolidayProvider
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

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "Шинэ жил (Shine jil)", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 3, 8, "Олон Улсын Эмэгтэйчүүдийн Баяр", "International Women's Day", countryCode));
            //items.Add(new Holiday(year, 6, 1, "Наадам", "Naadam Holiday", countryCode));
            //items.Add(new Holiday(year, 7, 11, "Наадам", "Naadam Holiday", countryCode));
            //items.Add(new Holiday(year, 7, 12, "Наадам", "Naadam Holiday", countryCode));
            //items.Add(new Holiday(year, 7, 13, "Наадам", "Naadam Holiday", countryCode));
            //items.Add(new Holiday(year, 7, 14, "Наадам", "Naadam Holiday", countryCode));
            //items.Add(new Holiday(year, 7, 15, "Наадам", "Naadam Holiday", countryCode));
            //items.Add(new Holiday(year, 11, 26, "Улс тунхагласны өдөр", "Republic Day", countryCode));
            //items.Add(new Holiday(year, 12, 29, "Тусгаар Тогтнолын Өдөр ", "Independence Day", countryCode));
            //return items.OrderBy(o => o.Date);
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
