[![GitHub Release](https://img.shields.io/github/release/tinohager/nager.date.svg?style=flat-square)](https://github.com/tinohager/nager.date/releases) [![Build status](https://ci.appveyor.com/api/projects/status/hbwtadup7wnhnjp6?svg=true)](https://ci.appveyor.com/project/tinohager/nager-date) ![Docker Image CI](https://github.com/nager/Nager.Date/workflows/Docker%20Image%20CI/badge.svg)

# :calendar: Nager.Date - [Official Website](https://date.nager.at)

Nager.Date is a popular project to query holidays. We currently support over 100 countries. The project is based on .NET but provides a REST interface to retrieve the data. There are several ways to use Nager.Date, there is a public api, you can start your own docker container or you can use the nuget package.

Nager.Date is open source software and is completely free for commercial use. If you would like to support the project you can award a GitHub star :star: or send a small donation to me :beers:

## How can I use it?

If you are use .net you can install the package over nuget for all other languages we have a docker image with a web api available.

### nuget
The package is available on [nuget](https://www.nuget.org/packages/Nager.Date)
```
PM> install-package Nager.Date
```

### web api
- **public** use the public api [date.nager.at API](https://date.nager.at/API)
  - If you need more as 50 requests per day please use your own private api (docker).
- **private** use the docker container available on [dockerhub](https://hub.docker.com/r/nagerat/nager-date)
  - `docker run -d -p 80:80 nagerat/nager-date`

## Donation possibilities
If this project help you reduce time to develop, you can give me a beer :beer:
[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.me/nagerat/25)

## Examples for .NET (nuget package)

### Get all publicHolidays of a country and year
```cs
var publicHolidays = DateSystem.GetPublicHoliday(2017, "DE");
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
var endDate = new DateTime(2018, 5, 31);
var publicHolidays = DateSystem.GetPublicHoliday(startDate, endDate, CountryCode.DE);
foreach (var publicHoliday in publicHolidays)
{
	//publicHoliday...
}
```

### Check if a date is a public holiday
```cs
var date = new DateTime(2017, 1, 1);
if (DateSystem.IsPublicHoliday(date, CountryCode.DE))
{
    Console.WriteLine("Is public holiday");
}
```

### Check if a date is a weekend day
```cs
var date = new DateTime(2017, 1, 1);
if (DateSystem.IsWeekend(date, CountryCode.DE))
{
    Console.WriteLine("Is weekend");
}
```

### Calculate age
```cs
var date = new DateTime(1900, 1, 1);
var age = DateSystem.GetAge(date);
```

## Country Support

The list of supported countries can be found on the [wiki](https://github.com/nager/Nager.Date/wiki/Supported-Countries).

## Areas of Application
- telephone systems
- carrier (land transport)
- time recording

## Blog Posts

[Mark Seemann - Simple holidays](http://blog.ploeh.dk/2017/04/24/simple-holidays/)

## Alternative projects

| Language | Project | Supported Countries (January 2019) |
| ------------- | ------------- | ------------- |
| PHP | [yasumi](https://github.com/azuyalabs/yasumi) | 34 |
| JavaScript | [date-holidays](https://github.com/commenthol/date-holidays) | 142 |
| Java | [jollyday](https://github.com/svendiedrichsen/jollyday) | 64 |
| .NET | [Holiday](https://github.com/martinjw/Holiday) | 21 |
| Python | [python-holidays](https://github.com/ryanss/python-holidays) | 34 |
| Python | [workalendar](https://github.com/peopledoc/workalendar) | 59 |
