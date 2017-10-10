using System;

namespace Nager.Date.Model
{
    [Flags]
    public enum PublicHolidayType : int
    {
        Public = 1, //public holiday
        Bank = 2, //bank holiday, banks and offices are closed
        School = 4, //school holiday, schools are closed
        Authorities = 8, //authorities are closed
        Optional = 16, //majority of people take a day off
        Observance = 32, //optional festivity, no paid day off
    }
}
