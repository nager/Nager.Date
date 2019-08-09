using System;

namespace Nager.Date.Contract
{
    /// <summary>
    /// Catholic
    /// </summary>
    public interface ICatholicProvider
    {
        DateTime EasterSunday(int year);
        DateTime AdventSunday(int year);
    }
}
