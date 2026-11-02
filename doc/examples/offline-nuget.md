# Offline Examples (NuGet package Nager.Date)

The [Nager.Date](https://www.nuget.org/packages/Nager.Date) NuGet package calculates the holidays locally, without a dependency on the REST API.
A license key is required. As a [sponsor of nager](https://github.com/sponsors/nager), you get a license key.

Supported target frameworks: .NET Framework 4.8.1, .NET Standard 2.0, .NET 8 and .NET 10

```bash
dotnet add package Nager.Date
```

## Set the license key

The license key must be set once before the first call.

```cs
using Nager.Date;
using Nager.Date.Models;

HolidaySystem.LicenseKey = "TheLicenseKey";
```

## Check the license

```cs
using Nager.Date.License;

var licenseInfo = LicenseHelper.CheckLicenseKey("TheLicenseKey");
if (licenseInfo is null)
{
    // license key invalid
    return;
}

if (licenseInfo.ValidUntil < DateTime.Today)
{
    // license key expired
    return;
}
```

## Get all holidays of a country and year

```cs
var holidays = HolidaySystem.GetHolidays(2026, CountryCode.DE);
foreach (var holiday in holidays)
{
    Console.WriteLine($"{holiday.Date:yyyy-MM-dd} {holiday.EnglishName}");

    // holiday.Date             -> The official date of the holiday
    // holiday.ObservedDate     -> The date on which the holiday is observed (e.g. moved from a weekend)
    // holiday.LocalName        -> The local name
    // holiday.EnglishName      -> The english name
    // holiday.NationalHoliday  -> true if the holiday applies to the entire country
    // holiday.SubdivisionCodes -> ISO 3166-2 codes of the subdivisions where the holiday applies
    // holiday.HolidayTypes     -> Flags: Public, Bank, School, Authorities, Optional, Observance
}
```

The country code can also be passed as a string, e.g. `HolidaySystem.GetHolidays(2026, "DE")`.

## Get all holidays for a date range

```cs
var startDate = new DateTime(2026, 1, 1);
var endDate = new DateTime(2027, 6, 30);

var holidays = HolidaySystem.GetHolidays(startDate, endDate, CountryCode.DE);
foreach (var holiday in holidays)
{
    Console.WriteLine($"{holiday.Date:yyyy-MM-dd} {holiday.EnglishName}");
}
```

## Filter by holiday type

`HolidayTypes` is a flags enum, a holiday can have several types.

```cs
var bankHolidays = HolidaySystem.GetHolidays(2026, CountryCode.DK)
    .Where(holiday => holiday.HolidayTypes.HasFlag(HolidayTypes.Bank));
```

## Check if a date is a public holiday

```cs
var date = new DateTime(2026, 1, 1);
if (HolidaySystem.IsPublicHoliday(date, CountryCode.DE))
{
    Console.WriteLine("Is a public holiday");
}
```

For a subdivision (ISO 3166-2):

```cs
var date = new DateTime(2026, 1, 6);
if (HolidaySystem.IsPublicHoliday(date, CountryCode.DE, "DE-BY"))
{
    Console.WriteLine("Is a public holiday in Bavaria");
}
```

## Check if a date is a holiday of a specific type

```cs
var date = new DateTime(2026, 12, 24);
if (HolidaySystem.IsHoliday(date, CountryCode.DK, HolidayTypes.Optional, out var holidays))
{
    Console.WriteLine(holidays[0].EnglishName);
}
```

## Check if a date falls on a weekend

The weekend days depend on the country.

```cs
var date = new DateTime(2026, 1, 3);
if (WeekendSystem.IsWeekend(date, CountryCode.DE))
{
    Console.WriteLine("The date is on a weekend");
}
```
