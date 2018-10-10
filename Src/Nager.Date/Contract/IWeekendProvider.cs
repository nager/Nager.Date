using System;

namespace Nager.Date.Contract
{
    public interface IWeekendProvider
    {
        bool IsWeekend(DateTime date);
    }
}
