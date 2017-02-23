#Nager.Date

Public holiday calculation for every year, based on easter sunday, country and county support.
If your country is not supported, fork me, implement it and send me the pull request.

###Demo Website
http://publicholiday.azurewebsites.net

###nuget
The package is available on [nuget](https://www.nuget.org/packages/Nager.Date)
```
PM> install-package Nager.Date
```

###Exampels

####Get all publicHolidays of a country and year
```cs
var publicHolidays = DateSystem.GetPublicHoliday("DE", 2017);
foreach (var publicHoliday in publicHolidays)
{
	//publicHoliday...
}
```

####Get all publicHolidays for a date range
```cs
var startDate = new DateTime(2016, 5, 1);
var endDate = new DateTime(2018, 5, 31);
var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.DE, startDate, endDate);
foreach (var publicHoliday in publicHolidays)
{
	//publicHoliday...
}
```

####Check if a date a public holiday
```cs
var date = new DateTime(2017, 1, 1);
if (DateSystem.IsPublicHoliday(date, "DE"))
{
	Console.WriteLine("Is public holiday");
}
```

###Country Support
####Europe
- [x] Austria
- [x] Belgium
- [x] Bulgaria
- [x] Croatia
- [x] Cyprus
- [x] Czech Republic
- [x] Denmark
- [x] Estonia
- [x] Finland
- [x] France
- [x] Germany
- [x] Greece
- [x] Hungary
- [x] Ireland
- [x] Italy
- [x] Latvia
- [x] Liechtenstein
- [x] Lithuania
- [x] Luxembourg
- [x] Malta
- [x] Netherlands
- [x] Norway
- [x] Poland
- [x] Portugal
- [x] Romania
- [x] Slovakia
- [x] Slovenia
- [x] Spain
- [x] Sweden
- [x] Switzerland
- [x] United Kingdom

####North America
- [x] Canada
- [x] United States