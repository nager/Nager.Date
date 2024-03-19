using Nager.Date.Models;
using System;
using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// NoHolidays HolidayProvider
    /// </summary>
    internal sealed class NoHolidaysHolidayProvider : IHolidayProvider
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
            return [];
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return [];
        }
    }
}
