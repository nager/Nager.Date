using Nager.Date.Models;
using Nager.Date.ReligiousProviders;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Paraguay HolidayProvider
    /// </summary>
    internal sealed class ParaguayHolidayProvider : AbstractHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// Paraguay HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public ParaguayHolidayProvider(
            ICatholicProvider catholicProvider) : base(CountryCode.PY)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
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

            return holidaySpecifications;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://en.wikipedia.org/wiki/Public_holidays_in_Paraguay"
            ];
        }
    }
}
