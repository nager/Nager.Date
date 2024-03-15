using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Kazakhstan HolidayProvider
    /// </summary>
    internal sealed class KazakhstanHolidayProvider : IHolidayProvider
    {
        private readonly IOrthodoxProvider _orthodoxProvider;

        /// <summary>
        /// Kazakhstan HolidayProvider
        /// </summary>
        /// <param name="orthodoxProvider"></param>
        public KazakhstanHolidayProvider(
            IOrthodoxProvider orthodoxProvider)
        {
            this._orthodoxProvider = orthodoxProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.KZ;

            //TODO: Last day of Hajj -> Islamic calendar

            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "Жаңа жыл",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 1, 2),
                    EnglishName = "New Year's Day",
                    LocalName = "Жаңа жыл",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 8),
                    EnglishName = "International Women's Day",
                    LocalName = "Халықаралық әйелдер күні",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 21),
                    EnglishName = "Nauryz Meyramy",
                    LocalName = "Наурыз мейрамы",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 22),
                    EnglishName = "Nauryz Meyramy",
                    LocalName = "Наурыз мейрамы",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 3, 23),
                    EnglishName = "Nauryz Meyramy",
                    LocalName = "Наурыз мейрамы",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Kazakhstan People's Unity Day",
                    LocalName = "Қазақстан халқының",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 7),
                    EnglishName = "Defender of the Fatherland Day",
                    LocalName = "Отан Қорғаушы күні",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 9),
                    EnglishName = "Great Patriotic War Against Fascism Victory Day",
                    LocalName = "Жеңіс күні",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 7, 6),
                    EnglishName = "Capital City Day",
                    LocalName = "Астана күні",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 30),
                    EnglishName = "Constitution Day",
                    LocalName = "Конституция күні",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 10, 25),
                    EnglishName = "Republic Day",
                    LocalName = "Республика күні",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 16),
                    EnglishName = "Independence Day",
                    LocalName = "Тәуелсіздік күні",
                    HolidayTypes = HolidayTypes.Public
                }
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Kazakhstan"
            };
        }
    }
}
