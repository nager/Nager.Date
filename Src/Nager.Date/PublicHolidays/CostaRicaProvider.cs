using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Costa Rica
    /// </summary>
    public class CostaRicaProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// CostaRicaProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public CostaRicaProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.CR;

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Año Nuevo", "New Year's Day", countryCode));
            items.Add(this._catholicProvider.MaundyThursday("Jueves Santo", year, countryCode));
            items.Add(this._catholicProvider.GoodFriday("Viernes Santo", year, countryCode));
            items.Add(new PublicHoliday(year, 8, 2, "Fiesta de Nuestra Señora de los Ángeles", "Feast of Our Lady of the Angels", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Navidad", "Christmas Day", countryCode));
            items.Add(GetJuanSantamariaDay(year, countryCode));
            items.Add(GetLabourDay(year, countryCode));
            items.Add(GetAnnexationDay(year, countryCode));            
            items.Add(GetMothersDay(year, countryCode));
            items.Add(GetIndenpendenceDay(year, countryCode));            

            //Law 9803
            if (year >= 2020)
            {
                items.Add(GetArmyAbolitionDay(year, countryCode));
            }
            else
            {
                items.Add(new PublicHoliday(year, 10, 12, "Día de las Culturas", "Cultures Day", countryCode));
            }

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Costa_Rica",
            };
        }

        private PublicHoliday GetJuanSantamariaDay(int year, CountryCode countryCode)
        {
            var juanSantamariaDay = new DateTime(year, 4, 11);
            ApplyLaw9875Shift(ref juanSantamariaDay, exceptionYears: new int[] { 2020, 2021, 2022 });

            return new PublicHoliday(juanSantamariaDay, "Día de Juan Santamaría", "Juan Santamaría Day", countryCode);
        }

        private PublicHoliday GetLabourDay(int year, CountryCode countryCode)
        {
            var labourDay = new DateTime(year, 5, 1);
            ApplyLaw9875Shift(ref labourDay, exceptionYears: new int[] { 2020, 2022, 2023, 2024 });

            return new PublicHoliday(labourDay, "Día Internacional del Trabajo", "Labour Day", countryCode);
        }

        private PublicHoliday GetAnnexationDay(int year, CountryCode countryCode)
        {
            var annexationDay = new DateTime(year, 7, 25);
            ApplyLaw9875Shift(ref annexationDay, exceptionYears: new int[] { 2022 });

            return new PublicHoliday(annexationDay, "Anexión del Partido de Nicoya a Costa Rica", "Annexation of the Party of Nicoya to Costa Rica", countryCode);
        }

        private PublicHoliday GetMothersDay(int year, CountryCode countryCode)
        {
            var mothersDay = new DateTime(year, 8, 15);
            ApplyLaw9875Shift(ref mothersDay, exceptionYears: new int[] { 2021, 2022 });

            return new PublicHoliday(mothersDay, "Día de la Madre", "Mother's Day", countryCode);
        }

        private PublicHoliday GetIndenpendenceDay(int year, CountryCode countryCode)
        {
            var indenpendenceDay = new DateTime(year, 9, 15);
            ApplyLaw9875Shift(ref indenpendenceDay, exceptionYears: new int[] { 2023, 2024 });

            return new PublicHoliday(indenpendenceDay, "Día de la Independencia", "Independence Day", countryCode);
        }

        private PublicHoliday GetArmyAbolitionDay(int year, CountryCode countryCode)
        {
            var armyAbolitionDay = new DateTime(year, 12, 1);
            ApplyLaw9875Shift(ref armyAbolitionDay, exceptionYears: new int[] { 2023, 2024 });

            return new PublicHoliday(armyAbolitionDay, "Día de la Abolición del Ejército", "Army Abolition Day", countryCode);
        }

        private void ApplyLaw9875Shift(ref DateTime date, IEnumerable<int> exceptionYears = default)
        {
            var applicableYears = new int[] { 2020, 2021, 2022, 2023, 2024 };
            if ((exceptionYears == null || !exceptionYears.Contains(date.Year)) && applicableYears.Contains(date.Year))
            {
                date = date.Shift(saturday: saturday => saturday.AddDays(2), sunday: sunday => sunday.AddDays(1));
                date = date.ShiftWeekdays(
                    tuesday: tuesday => tuesday.AddDays(-1),
                    wednesday: wednesday => wednesday.AddDays(-2),
                    thursday: thursday => thursday.AddDays(4)
                    );
            }
        }
    }
}
