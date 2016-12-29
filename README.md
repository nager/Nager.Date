Nager.Date
==========

Public holiday calculation for every year.
Supported countries AT, BE, CH, DE, ES, FR, IT, LI, NL, PT

#####Demo Website
http://publicholiday.azurewebsites.net

#####nuget
The package is available on nuget
https://www.nuget.org/packages/Nager.Date
```
install-package Nager.Date
```

#####Example - Get all publicHolidays of a country and year
```cs
var publicHolidays = DateSystem.GetPublicHoliday("DE", 2017);
foreach (var publicHoliday in publicHolidays)
{
}
```

#####Example - Check if a date a public holiday
```cs
var date = new DateTime(2017, 1, 1);
if (DateSystem.IsPublicHoliday(date, "DE"))
{
	Console.WriteLine("Is public holiday");
}
```
