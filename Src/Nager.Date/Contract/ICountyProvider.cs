using System.Collections.Generic;

namespace Nager.Date.Contract
{
    public interface ICountyProvider
    {
        IDictionary<string, string> GetCounties();
    }
}
