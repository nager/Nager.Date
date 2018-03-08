using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nager.Date.PublicHolidays
{
    public abstract class IslamicBaseProvider : IPublicHolidayProvider
    {
        public abstract IEnumerable<PublicHoliday> Get(int year);

        /// <summary>
        /// Gets the start date of the ramadan for a requested year
        /// https://en.wikipedia.org/wiki/Ramadan
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DateTime StartRamadan(int year)
        {
            var startRamadan = LocalDate.FromDateTime(new DateTime().FirstDayOfTheYear(year)).WithCalendar(CalendarSystem.UmAlQura).With(DateAdjusters.Month(9)).With(DateAdjusters.StartOfMonth);
            var gregrorianDate = startRamadan.WithCalendar(CalendarSystem.Gregorian);

            return gregrorianDate.ToDateTimeUnspecified();
        }

        /// <summary>
        /// Gets the of Ramadan Date for a requested year
        /// https://en.wikipedia.org/wiki/Eid_al-Fitr
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private DateTime EndOfRamadanDate(int year)
        {
            var endRamadan = LocalDate.FromDateTime(new DateTime().FirstDayOfTheYear(year)).WithCalendar(CalendarSystem.UmAlQura).With(DateAdjusters.Month(9)).With(DateAdjusters.EndOfMonth);
            var gregrorianDate = endRamadan.WithCalendar(CalendarSystem.Gregorian);

            return gregrorianDate.ToDateTimeUnspecified();
        }

        /// <summary>
        /// Get the start date of the Sacrifice feast for the requested year
        /// https://en.wikipedia.org/wiki/Eid_al-Adha
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private DateTime StartEidalAdha(int year)
        {
            var EidalAdha = LocalDate.FromDateTime(new DateTime().FirstDayOfTheYear(year), CalendarSystem.UmAlQura).With(DateAdjusters.Month(12)).With(DateAdjusters.DayOfMonth(10));
            var gregrorianEndDate = EidalAdha.WithCalendar(CalendarSystem.Gregorian);

            return gregrorianEndDate.ToDateTimeUnspecified();
        }

        /// <summary>
        /// Get the end date of the Sacrifice feast for the requested year
        /// https://en.wikipedia.org/wiki/Eid_al-Adha
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private DateTime EndEidalAdha(int year)
        {
            var EidalAdha = LocalDate.FromDateTime(new DateTime().FirstDayOfTheYear(year), CalendarSystem.UmAlQura).With(DateAdjusters.Month(12)).With(DateAdjusters.DayOfMonth(12));
            var gregrorianEndDate = EidalAdha.WithCalendar(CalendarSystem.Gregorian);

            return gregrorianEndDate.ToDateTimeUnspecified();
        }
    }
}
