# Nager.Date

Nager.Date is a comprehensive .NET library for querying public and federal holidays, supporting over 110 countries worldwide.
It provides native and English translations and supports country subdivisions (federal states) according to ISO 3166-2 standards.

## Supported Countries
You can see the full list of supported countries [here](https://date.nager.at/Country/Coverage)

## Features
- Query public, federal, bank, school, and optional holidays (availability may vary by country).
- Support for country subdivisions (federal states, provinces).
- Native and English translations for holiday names.
- Retrieve holidays by year or date range.
- Check if a specific date is a public holiday.
- Weekend detection for any country.

## Getting Started

### Set License Key
```cs
HolidaySystem.LicenseKey = "TheLicenseKey";
```

### Check License
```cs
var licenseKey = "TheLicenseKey";
var licenseInfo = Nager.Date.Helpers.LicenseHelper.CheckLicenseKey(licenseKey);
if (licenseInfo is null)
{
    //license key invalid
    return;
}

if (licenseInfo.ValidUntil < DateTime.Today)
{
    //license key expired
    return;
}
```

### Get Holidays for a Year
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

### Get Holidays for a Date Range
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
    Console.WriteLine("This date is a public holiday.");
}
```

### Check if a Date is on a Weekend
```cs
var date = new DateTime(2024, 1, 1);
if (WeekendSystem.IsWeekend(date, CountryCode.DE))
{
    Console.WriteLine("The date falls on a weekend.");
}
```