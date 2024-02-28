using System.Collections.Generic;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// SubdivisionCodesProvider Interface
    /// </summary>
    public interface ISubdivisionCodesProvider
    {
        /// <summary>
        /// Get SubdivisionCodes
        /// </summary>
        /// <returns>Subdivision codes</returns>
        IDictionary<string, string> GetSubdivisionCodes();
    }
}
