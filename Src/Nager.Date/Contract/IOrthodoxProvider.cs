using System;

namespace Nager.Date.Contract
{
    public interface IOrthodoxProvider
    {
        DateTime EasterSunday(int year);
    }
}
