
████████ ██   ██  █████  ███    ██ ██   ██     ██    ██  ██████  ██    ██
   ██    ██   ██ ██   ██ ████   ██ ██  ██       ██  ██  ██    ██ ██    ██
   ██    ███████ ███████ ██ ██  ██ █████         ████   ██    ██ ██    ██
   ██    ██   ██ ██   ██ ██  ██ ██ ██  ██         ██    ██    ██ ██    ██
   ██    ██   ██ ██   ██ ██   ████ ██   ██        ██     ██████   ██████


Thank you for choosing this package.
More information about this project can be found here: https://github.com/nager/Nager.Date


This package requires a license key, which is provided to GitHub sponsors.
https://github.com/sponsors/nager

Alternatively, you can also utilize our Web API to access up-to-date holiday information.
https://date.nager.at/Api



Here are some examples of how to use it:

Set the License Key
══════════════════════════════════════════════════════════════════════════════════════════════════════

    HolidaySystem.LicenseKey = "TheLicenseKey";


Get all holidays of a specific year and country
══════════════════════════════════════════════════════════════════════════════════════════════════════

    var holidays = HolidaySystem.GetHolidays(2024, "DE");
    foreach (var holiday in holidays)
    {
        Console.WriteLine($"{holiday.Date:yyyy-MM-dd} - {holiday.EnglishName}");
        //holiday...
        //holiday.Date -> The date
        //holiday.LocalName -> The local name
        //holiday.EnglishName -> The english name
        //holiday.NationalHoliday -> Is this holiday in every county (federal state)
        //holiday.SubdivisionCodes -> Is the holiday only valid for a special county ISO-3166-2 - Federal states
        //holiday.HolidayTypes -> Public, Bank, School, Authorities, Optional, Observance
    }


Get all holidays for a date range
══════════════════════════════════════════════════════════════════════════════════════════════════════

    var startDate = new DateTime(2016, 5, 1);
    var endDate = new DateTime(2022, 5, 31);
    var holidays = HolidaySystem.GetHolidays(startDate, endDate, CountryCode.DE);
    foreach (var holiday in holidays)
    {
        //holiday...
        //holiday.Date -> The date
        //holiday.LocalName -> The local name
        //holiday.EnglishName -> The english name
        //holiday.NationalHoliday -> Is this holiday in every county (federal state)
        //holiday.SubdivisionCodes -> Is the holiday only valid for a special county ISO-3166-2 - Federal states
        //holiday.HolidayTypes -> Public, Bank, School, Authorities, Optional, Observance
    }
