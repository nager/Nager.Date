using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// NoHolidaysProvider
    /// </summary>
    internal class NoHolidaysProvider : IPublicHolidayProvider
    {
        private static readonly Lazy<IPublicHolidayProvider> _instance =
            new Lazy<IPublicHolidayProvider>(() => new NoHolidaysProvider());

        /// <summary>
        /// Gets the singleton instance of <see cref="NoHolidaysProvider"/>.
        /// </summary>
        public static IPublicHolidayProvider Instance
        {
            get { return _instance.Value; }
        }

        private NoHolidaysProvider() { }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            return Enumerable.Empty<PublicHoliday>();
        }

        /// <summary>
        /// Get the Holiday Sources
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetSources()
        {
            return Enumerable.Empty<string>();
        }
    }
}
