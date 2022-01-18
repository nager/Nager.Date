using System.Collections.Generic;

namespace Nager.Date.Contract
{
    /// <summary>
    /// ICountyProvider
    /// </summary>
    public interface ICountyProvider
    {
        /// <summary>
        /// Get Counties
        /// </summary>
        /// <returns>Set of counties</returns>
        IDictionary<string, string> GetCounties();
    }
}
