Thank you for using the Nager.Date package (https://github.com/tinohager/Nager.Date)
----------------------------------------------------------------
Please support this project with the award of a GitHub Star (★)


Examples:
----------------------------------------------------------------

//Get all publicHolidays of a given year and country
var publicHolidays = DateSystem.GetPublicHoliday(2018, "DE");
foreach (var publicHoliday in publicHolidays)
{
    //publicHoliday...
    //publicHoliday.Date -> The date
    //publicHoliday.LocalName -> The local name
    //publicHoliday.Name -> The english name
    //publicHoliday.Fixed -> Is this public holiday every year on the same date
    //publicHoliday.Global -> Is this public holiday in every county (federal state)
    //publicHoliday.Counties -> Is the public holiday only valid for a special county ISO-3166-2 - Federal states
    //publicHoliday.Type -> Public, Bank, School, Authorities, Optional, Observance
}

//Get all publicHolidays for a date range
var startDate = new DateTime(2016, 5, 1);
var endDate = new DateTime(2019, 5, 31);
var publicHolidays = DateSystem.GetPublicHoliday(startDate, endDate, CountryCode.DE);
foreach (var publicHoliday in publicHolidays)
{
    //publicHoliday...
    //publicHoliday.Date -> The date
    //publicHoliday.LocalName -> The local name
    //publicHoliday.Name -> The english name
    //publicHoliday.Fixed -> Is this public holiday every year on the same date
    //publicHoliday.Global -> Is this public holiday in every county (federal state)
    //publicHoliday.Counties -> Is the public holiday only valid for a special county ISO-3166-2 - Federal states
    //publicHoliday.Type -> Public, Bank, School, Authorities, Optional, Observance
}