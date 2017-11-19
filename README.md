[![GitHub Release](https://img.shields.io/github/release/tinohager/nager.date.svg?style=flat-square)](https://github.com/tinohager/nager.date/releases)

# Nager.Date

Nager.Date is a Date/Calendar Framework for .NET

- [x] Public holiday calculation for every year, based on easter sunday, country and county support.
Supports more than 60 countries if your country is not supported, fork me, implement it and send me the pull request.
- [x] Age calculation

### Demo Website
http://publicholiday.azurewebsites.net

### nuget
The package is available on [nuget](https://www.nuget.org/packages/Nager.Date)
```
PM> install-package Nager.Date
```

### Donation possibilities
If this project help you reduce time to develop, you can give me a beer :beer:
- [![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.me/nagerat/25)
- BTC: 3PjuVRcAaKPv9yLLmrVUY9mqGngPDm3nPc (Bitcoin)

### Exampels

#### Get all publicHolidays of a country and year
```cs
var publicHolidays = DateSystem.GetPublicHoliday("DE", 2017);
foreach (var publicHoliday in publicHolidays)
{
	//publicHoliday...
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

#### Check if a date a public holiday
```cs
var date = new DateTime(2017, 1, 1);
if (DateSystem.IsPublicHoliday(date, CountryCode.DE))
{
	Console.WriteLine("Is public holiday");
}
```

#### Calculate age
```cs
var date = new DateTime(1900, 1, 1);
var age = DateSystem.GetAge(date);
```

### Country Support
#### Europe
- [x] Andorra
- [ ] Åland
- [x] Austria
- [x] Belarus
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
- [x] Iceland
- [x] Ireland
- [x] Isle of Man
- [x] Italy
- [x] Jersey
- [x] Latvia
- [x] Liechtenstein
- [x] Lithuania
- [x] Luxembourg
- [x] Malta
- [x] Monaco
- [x] Netherlands
- [x] Norway
- [x] Poland
- [x] Portugal
- [x] Romania
- [x] Russia
- [x] Slovakia
- [x] Slovenia
- [x] Spain
- [x] Sweden
- [x] Switzerland
- [x] Turkey (without muslim based holidays)
- [ ] Ukraine
- [x] United Kingdom

#### Asia
- [ ] China
- [ ] Kazakhstan
- [ ] Mongolia
- [x] Russia
- [x] Turkey (without muslim based holidays)

#### North America
- [x] Bahamas
- [x] Canada
- [x] Costa Rica
- [x] Cuba
- [x] Dominican Republic
- [x] Guatemala
- [x] Haiti
- [x] Jamaica
- [ ] Mexico
- [x] Panama
- [x] Puerto Rico
- [x] United States

#### South America
- [x] Argentina
- [x] Bolivia
- [x] Brazil
- [x] Chile
- [x] Colombia
- [x] Ecuador
- [x] Guyana
- [x] Honduras
- [x] Paraguay
- [x] Peru
- [ ] Suriname
- [x] Uruguay
- [x] Venezuela

#### Atlantic
- [x] Greenland

#### Africa
- [x] Botswana
- [x] Madagascar
- [x] Namibia
- [x] South Africa

#### Australia & Pacific
- [x] Australia
- [x] New Zealand

### Alternative projects

| Language  | Project |
| ------------- | ------------- |
| PHP | [yasumi](https://github.com/azuyalabs/yasumi) |
| JavaScript | [date-holidays](https://github.com/commenthol/date-holidays) |
| Java | [jollyday](https://github.com/svendiedrichsen/jollyday) |
| .NET | [Holiday](https://github.com/martinjw/Holiday) |
