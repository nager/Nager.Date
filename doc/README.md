# Nager.Date

Nager.Date is a popular project to query holidays. We currently support over 100 countries.

## Country Support
The list of supported countries can be found [here](https://date.nager.at/Home/RegionStatistic)

## Examples

### Get all publicHolidays of a country and year
```cs
var publicHolidays = DateSystem.GetPublicHolidays(2021, "DE");
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
```

### Get all publicHolidays for a date range
```cs
var startDate = new DateTime(2016, 5, 1);
var endDate = new DateTime(2021, 5, 31);
var publicHolidays = DateSystem.GetPublicHolidays(startDate, endDate, CountryCode.DE);
foreach (var publicHoliday in publicHolidays)
{
	//publicHoliday...
}
```

### Check if a date is a public holiday
```cs
var date = new DateTime(2021, 1, 1);
if (DateSystem.IsPublicHoliday(date, CountryCode.DE))
{
    Console.WriteLine("Is public holiday");
}
```

### Check if a date is a weekend day
```cs
var date = new DateTime(2021, 1, 1);
if (DateSystem.IsWeekend(date, CountryCode.DE))
{
    Console.WriteLine("Is weekend");
}
```