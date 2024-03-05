using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Paraguay HolidayProvider
    /// </summary>
    internal class ParaguayHolidayProvider : IHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Paraguay HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ParaguayHolidayProvider(
            ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var countryCode = CountryCode.PY;

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
                    Date = new DateTime(year, 3, 1),
                    EnglishName = "Heroes' day",
                    LocalName = "Dia de los héroes",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "Día de los Trabajadores",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 14),
                    EnglishName = "Paraguayan Independence",
                    LocalName = "Independencia",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 5, 15),
                    EnglishName = "Paraguayan Independence",
                    LocalName = "Independencia",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 6, 12),
                    EnglishName = "Chaco Armistice",
                    LocalName = "Dia de la Paz del Chaco",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 8, 15),
                    EnglishName = "Founding of Asunción",
                    LocalName = "Fundación de Asunción",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 9, 29),
                    EnglishName = "Boqueron Battle Victory Day",
                    LocalName = "Victoria de Boquerón",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 8),
                    EnglishName = "Virgin of Caacupe",
                    LocalName = "Virgen de Caacupé",
                    HolidayTypes = HolidayTypes.Public
                },
                new HolidaySpecification
                {
                    Date = new DateTime(year, 12, 25),
                    EnglishName = "Christmas Day",
                    LocalName = "Día de Navidad",
                    HolidayTypes = HolidayTypes.Public
                },
                this._catholicProvider.MaundyThursday("Jueves Santo", year),
                this._catholicProvider.GoodFriday("Viernes Santo", year)
            };

            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, countryCode);
            return holidays.OrderBy(o => o.Date);

            //var items = new List<Holiday>();
            //items.Add(new Holiday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            //items.Add(new Holiday(year, 3, 1, "Dia de los héroes", "Heroes' day", countryCode));
            //items.Add(this._catholicProvider.MaundyThursday("Jueves Santo", year, countryCode));
            //items.Add(this._catholicProvider.GoodFriday("Viernes Santo", year, countryCode));
            //items.Add(new Holiday(year, 5, 1, "Día de los Trabajadores", "Labour Day", countryCode));
            //items.Add(new Holiday(year, 5, 14, "Independencia", "Paraguayan Independence", countryCode));
            //items.Add(new Holiday(year, 5, 15, "Independencia", "Paraguayan Independence", countryCode));
            //items.Add(new Holiday(year, 6, 12, "Dia de la Paz del Chaco", "Chaco Armistice", countryCode));
            //items.Add(new Holiday(year, 8, 15, "Fundación de Asunción", "Founding of Asunción", countryCode));
            //items.Add(new Holiday(year, 9, 29, "Victoria de Boquerón", "Boqueron Battle Victory Day", countryCode));
            //items.Add(new Holiday(year, 12, 8, "Virgen de Caacupé", "Virgin of Caacupe", countryCode));
            //items.Add(new Holiday(year, 12, 25, "Día de Navidad", "Christmas Day", countryCode));
            //return items.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Paraguay"
            };
        }
    }
}
