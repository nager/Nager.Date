using Nager.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// NoHolidays HolidayProvider
    /// </summary>
    public class NoHolidaysHolidayProvider : IHolidayProvider
    {
        private static readonly Lazy<IHolidayProvider> _instance =
            new Lazy<IHolidayProvider>(() => new NoHolidaysHolidayProvider());

        /// <summary>
        /// Gets the singleton instance of <see cref="NoHolidaysHolidayProvider"/>.
        /// </summary>
        public static IHolidayProvider Instance
        {
            get { return _instance.Value; }
        }

        private NoHolidaysHolidayProvider() { }

        /// <inheritdoc/>
        public IEnumerable<Holiday> GetHolidays(int year)
        {
            return Enumerable.Empty<Holiday>();
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return Enumerable.Empty<string>();
        }
    }
}
