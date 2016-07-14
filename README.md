Nager.Date
==========

Public holiday calculation for every year.
Supported countries AT, BE, CH, DE, ES, FR, IT, LI, NL

#####Demo Website
http://publicholiday.azurewebsites.net

#####nuget
install-package Nager.Date

#####Example
```cs
//Get all publicHolidays of a country and year
var publicHolidays = DateSystem.GetPublicHoliday("DE", 2016);
//Check if a date a public holiday
if (DateSystem.IsPublicHoliday(date, "DE"))
{
}
```