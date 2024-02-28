using Nager.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// NoHolidaysProvider
    /// </summary>
    public class NoHolidaysProvider : IHolidayProvider
    {
        private static readonly Lazy<IHolidayProvider> _instance =
            new Lazy<IHolidayProvider>(() => new NoHolidaysProvider());

        /// <summary>
        /// Gets the singleton instance of <see cref="NoHolidaysProvider"/>.
        /// </summary>
        public static IHolidayProvider Instance
        {
            get { return _instance.Value; }
        }

        private NoHolidaysProvider() { }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> GetHolidays(int year)
        {
            return Enumerable.Empty<PublicHoliday>();
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return Enumerable.Empty<string>();
        }
    }
}
