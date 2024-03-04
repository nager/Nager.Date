# Nager.Date

Nager.Date is a popular project for querying holidays, we currently support for over 100 countries.

## Country Support
The list of supported countries can be found [here](https://date.nager.at/Country/Coverage)

## Examples

### Get all publicHolidays of a country and year
```cs
var holidays = DateSystem.GetHolidays(2021, "DE");
foreach (var holiday in holidays)
{
    //holiday...
    //holiday.Date -> The date
    //holiday.LocalName -> The local name
    //holiday.EnglishName -> The english name
    //holiday.NationalHoliday -> Is this holiday in every county (federal state)
    //holiday.SubdivisionCodes -> Is the public holiday only valid for a special county ISO-3166-2 - Federal states
    //holiday.HolidayTypes -> Public, Bank, School, Authorities, Optional, Observance
}
```

### Get all holidays for a date range
```cs
var startDate = new DateTime(2016, 5, 1);
var endDate = new DateTime(2021, 5, 31);
var holidays = DateSystem.GetHolidays(startDate, endDate, CountryCode.DE);
foreach (var holiday in holidays)
{
	//holiday...
}
```

### Check if a date is a public holiday
```cs
var date = new DateTime(2021, 1, 1);
if (DateSystem.IsPublicHoliday(date, CountryCode.DE))
{
    Console.WriteLine("Is a public holiday");
}
```

### Checks if the given date falls on a weekend day
```cs
var date = new DateTime(2021, 1, 1);
if (DateSystem.IsWeekend(date, CountryCode.DE))
{
    Console.WriteLine("The date is in the weekend");
}
```