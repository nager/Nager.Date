[![GitHub Release](https://img.shields.io/github/release/tinohager/nager.date.svg?style=flat-square)](https://github.com/tinohager/nager.date/releases)

# Nager.Date

Nager.Date is a Date/Calendar Framework for .NET
- Public holiday calculation for every year, based on easter sunday, country and county support.
Supports over 90 countries.
- Weekend information (supports 120 countries)
- Age calculation

If your country is not supported, fork me, implement it and send me the pull request.

### Website / API
https://date.nager.at

### nuget
The package is available on [nuget](https://www.nuget.org/packages/Nager.Date)
```
PM> install-package Nager.Date
```

### Donation possibilities
If this project help you reduce time to develop, you can give me a beer :beer:
[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.me/nagerat/25)

### Examples

#### Get all publicHolidays of a country and year
```cs
var publicHolidays = DateSystem.GetPublicHoliday("DE", 2017);
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

#### Get all publicHolidays for a date range
```cs
var startDate = new DateTime(2016, 5, 1);
var endDate = new DateTime(2018, 5, 31);
var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.DE, startDate, endDate);
foreach (var publicHoliday in publicHolidays)
{
	//publicHoliday...
}
```

#### Check if a date is a public holiday
```cs
var date = new DateTime(2017, 1, 1);
if (DateSystem.IsPublicHoliday(date, CountryCode.DE))
{
	Console.WriteLine("Is public holiday");
}
```

#### Check if a date is a weekend day
```cs
var date = new DateTime(2017, 1, 1);
if (DateSystem.IsWeekend(date, CountryCode.DE))
{
	Console.WriteLine("Is weekend");
}
```

#### Calculate age
```cs
var date = new DateTime(1900, 1, 1);
var age = DateSystem.GetAge(date);
```

### Country Support

The list of supported countries can be found on the [wiki](https://github.com/tinohager/Nager.Date/wiki/Supported-Countries).

### Areas of Application
- telephone systems
- carrier (land transport)
- time recording

### Blog Posts

[Mark Seemann - Simple holidays](http://blog.ploeh.dk/2017/04/24/simple-holidays/)

### Alternative projects

| Language | Project | Supported Countries (January 2019) |
| ------------- | ------------- | ------------- |
| PHP | [yasumi](https://github.com/azuyalabs/yasumi) | 34 |
| JavaScript | [date-holidays](https://github.com/commenthol/date-holidays) | 142 |
| Java | [jollyday](https://github.com/svendiedrichsen/jollyday) | 64 |
| .NET | [Holiday](https://github.com/martinjw/Holiday) | 21 |
| Python | [python-holidays](https://github.com/ryanss/python-holidays) | 34 |
| Python | [workalendar](https://github.com/peopledoc/workalendar) | 59 |
