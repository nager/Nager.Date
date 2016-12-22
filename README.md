Nager.Date
==========

Public holiday calculation for every year.
Supported countries AT, BE, CH, DE, ES, FR, IT, LI, NL

#####Demo Website
http://publicholiday.azurewebsites.net

#####nuget
The package is available on nuget
https://www.nuget.org/packages/Nager.Date
```
install-package Nager.Date
```

#####Example
```cs
//Get all publicHolidays of a country and year
var publicHolidays = DateSystem.GetPublicHoliday("DE", 2017);
//Check if a date a public holiday
if (DateSystem.IsPublicHoliday(date, "DE"))
{
}
```
