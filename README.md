Nager.Date
==========

Public holiday calculation for every year, based on easter sunday.

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

#Country Support (17/30)
- [x] Austria
- [x] Belgium
- [x] Bulgaria
- [ ] Croatia
- [ ] Cyprus
- [x] Czech Republic
- [x] Denmark
- [ ] Estonia
- [ ] Finland
- [x] France
- [x] Germany
- [ ] Greece
- [ ] Hungary
- [ ] Ireland
- [x] Italy
- [ ] Latvia
- [x] Liechtenstein
- [ ] Lithuania
- [ ] Luxembourg
- [x] Malta
- [x] Netherlands
- [x] Poland
- [x] Portugal
- [ ] Romania
- [ ] Slovakia
- [ ] Slovenia
- [x] Spain
- [x] Sweden
- [x] Switzerland
- [x] United Kingdom
