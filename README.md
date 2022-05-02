![Build status](https://github.com/nager/Nager.Date/actions/workflows/dotnet.yml/badge.svg)

# :calendar: Nager.Date - [Official Website](https://date.nager.at)

Nager.Date is a popular project to query holidays. We currently support over 100 countries.
The project is based on .NET but provides a REST interface to retrieve the data.
There are several ways to use Nager.Date, there is a public api, you can start your own docker container or you can use the nuget package.

## :mega: Announcement

Starting May 1, 2022, the Docker container and the NuGet package will require a License Key provided to the sponsors of this project. The public WebApi will remain freely accessible.

## Country Support

The list of supported countries can be found [here](https://date.nager.at/Country/Coverage).

## How can I use it?

If you are use **.NET** you can install the package via nuget, for all other languages we have a public web api available.
If you have restrictive regulations in your company or you need high availability then you can also use the Docker Container.

### nuget
The package is available via [NuGet](https://www.nuget.org/packages/Nager.Date)
```
PM> install-package Nager.Date
```

### web api
- **public** use the public api [date.nager.at](https://date.nager.at/API)
  - The easiest way to retrieve the holidays
- **self-hosted (docker)** use your own api, the docker container is available on [Docker Hub](https://hub.docker.com/r/nager/nager-date)
  - To run a local instance of the docker image run the following command<br>
  `docker run -p 80:80 nager/nager-date`
    - `-p 80:80` publish the port 80 from the docker to your host.

#### Generate a client for the web api

You can use `swagger-codegen-cli` to create a client for the api

```
docker run --rm -v C:\Temp:/local swaggerapi/swagger-codegen-cli-v3 generate -i https://date.nager.at/swagger/v1.0/swagger.json -l csharp-dotnet2 -o /local/out
```

## Sponsor us
Your sponsorship helps us spend more time working on OpenSource related to Nager.Date, [become a sponsor now](https://github.com/sponsors/nager). 
We started in 2014 and look forward to many more years...

## Examples for .NET (nuget package)

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
