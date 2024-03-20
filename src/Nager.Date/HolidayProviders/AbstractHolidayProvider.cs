using Nager.Date.Models;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// Abstract HolidayProvider
    /// </summary>
    internal abstract class AbstractHolidayProvider : IHolidayProvider
    {
       private readonly CountryCode _countryCode ;

        /// <summary>
        /// Abstract HolidayProvider
        /// </summary>
        /// <param name="countryCode"></param>
        protected AbstractHolidayProvider(CountryCode countryCode)
        {
            this._countryCode = countryCode;
        }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            var holidaySpecifications = this.GetHolidaySpecifications(year);
            var holidays = HolidaySpecificationProcessor.Process(holidaySpecifications, this._countryCode);
            return holidays.OrderBy(o => o.Date);
        }

        /// <inheritdoc/>
        public abstract IEnumerable<string> GetSources();

        /// <summary>
        /// Get Holiday specifications for a given year
        /// </summary>
        /// <param name="year"></param>
        protected abstract IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year);
    }
}
