using System;

namespace Nager.Date.Contract
{
    /// <summary>
    /// Orthodox
    /// </summary>
    public interface IOrthodoxProvider
    {
        DateTime EasterSunday(int year);
    }
}
