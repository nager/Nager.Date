# Nager.Date

Nager.Date is a popular project for querying holidays, we currently support for over 100 countries.

## Country Support
The list of supported countries can be found [here](https://date.nager.at/Country/Coverage)

## Examples

### Set License Key
```cs
HolidaySystem.LicenseKey = "TheLicenseKey";
```

### Get all holidays of a country and year
```cs
var holidays = HolidaySystem.GetHolidays(2024, "DE");
foreach (var holiday in holidays)
{
    Console.WriteLine($"{holiday.Date:yyyy-MM-dd} - {holiday.EnglishName}");
    //holiday...
    //holiday.Date -> The date
    //holiday.ObservedDate -> The date on which the holiday is observed
    //holiday.LocalName -> The local name
    //holiday.EnglishName -> The english name
    //holiday.NationalHoliday -> Is this holiday in every county (federal state)
    //holiday.SubdivisionCodes -> Is the holiday only valid for a special county ISO-3166-2 - Federal states
    //holiday.HolidayTypes -> Public, Bank, School, Authorities, Optional, Observance
}
```

### Get all holidays for a date range
```cs
var startDate = new DateTime(2016, 5, 1);
var endDate = new DateTime(2024, 5, 31);
var holidays = HolidaySystem.GetHolidays(startDate, endDate, CountryCode.DE);
foreach (var holiday in holidays)
{
	//holiday...
}
```

### Check if a date is a public holiday
```cs
var date = new DateTime(2024, 1, 1);
if (HolidaySystem.IsPublicHoliday(date, CountryCode.DE))
{
    Console.WriteLine("Is a public holiday");
}
```

### Checks if the given date falls on a weekend day
```cs
var date = new DateTime(2024, 1, 1);
if (WeekendSystem.IsWeekend(date, CountryCode.DE))
{
    Console.WriteLine("The date is in the weekend");
}
```