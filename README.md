[![GitHub Release](https://img.shields.io/github/release/tinohager/nager.date.svg?style=flat-square)](https://github.com/tinohager/nager.date/releases)

# Nager.Date

Nager.Date is a Date/Calendar Framework for .NET
- Public holiday calculation for every year, based on easter sunday, country and county support.
Supports more than 70 countries if your country is not supported, fork me, implement it and send me the pull request.
- Age calculation

### Website / API
https://date.nager.at

### nuget
The package is available on [nuget](https://www.nuget.org/packages/Nager.Date)
```
PM> install-package Nager.Date
```

### Donation possibilities
If this project help you reduce time to develop, you can give me a beer :beer:
[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.me/nagerat/25)

### Examples

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

### [Country Support](https://simple.wikipedia.org/wiki/List_of_countries_by_continents)
#### Europe (40/49)
---
- [ ] Albania
- [x] Åland
- [x] Andorra
- [x] Austria
- [x] Belarus
- [x] Belgium
- [ ] Bosnia and Herzegovina
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
- [ ] Kosovo
- [x] Jersey
- [x] Latvia
- [x] Liechtenstein
- [x] Lithuania
- [x] Luxembourg
- [x] Macedonia
- [x] Malta
- [x] Moldova
- [x] Monaco
- [ ] Montenegro
- [x] Netherlands
- [x] Norway
- [x] Poland
- [x] Portugal
- [x] Romania
- [x] Russia
- [ ] San Marino
- [ ] Serbia
- [x] Slovakia
- [x] Slovenia
- [x] Spain
- [x] Sweden
- [x] Switzerland
- [ ] Ukraine
- [x] United Kingdom
- [ ] Vatican City

#### Asia (3/50)
---
- [ ] Armenia
- [x] China (without Qingming (Tomb-Sweeping Day))
- [ ] Georgia
- [ ] Kazakhstan
- [ ] Mongolia
- [x] Russia
- [x] Turkey (without muslim based holidays)

#### North America (4/4)
---
- [x] Canada
- [x] Greenland
- [x] Mexico
- [x] United States

#### Central America and the Antilles (13/22)
---
- [x] Bahamas
- [ ] Barbados
- [x] Belize
- [x] Costa Rica
- [x] Cuba
- [ ] Curacao
- [ ] Dominica
- [x] Dominican Republic
- [x] El Salvador
- [ ] Grenada
- [x] Guatemala
- [x] Haiti
- [x] Honduras
- [x] Jamaica
- [x] Nicaragua
- [x] Panama
- [x] Puerto Rico
- [ ] Saint Kitts and Nevis
- [ ] Saint Lucia
- [ ] Saint Vincent and the Grenadines
- [ ] Trinidad and Tobago
- [ ] Turks and Caicos

#### South America (13/14)
---
- [x] Argentina
- [x] Bolivia
- [x] Brazil
- [x] Chile
- [x] Colombia
- [x] Ecuador
- [ ] French Guiana
- [x] Guyana (without muslim based holidays and hindu based holidays)
- [x] Paraguay
- [x] Peru
- [x] Suriname
- [x] Uruguay
- [x] Venezuela

#### Africa (7/58)
---
- [ ] Algeria
- [ ] Angola
- [ ] Benin
- [x] Botswana
- [ ] Burkina Faso
- [ ] Burundi
- [ ] Cameroon
- [ ] Cape Verde
- [ ] Chad
- [ ] Central African Republic
- [ ] Comoros
- [ ] Republic of the Congo
- [ ] Democratic Republic of the Congo
- [ ] Côte d'Ivoire
- [ ] Djibouti
- [x] Egypt
- [ ] Equatorial Guinea
- [ ] Eritrea
- [ ] Ethiopia
- [x] Gabon
- [ ] The Gambia
- [ ] Ghana
- [ ] Guinea
- [ ] Guinea-Bissau
- [ ] Kenya
- [ ] Lesotho
- [ ] Liberia
- [ ] Libya
- [x] Madagascar
- [ ] Malawi
- [ ] Mali
- [ ] Mauritania
- [ ] Mauritius
- [x] Morocco
- [x] Mozambique
- [x] Namibia
- [ ] Niger
- [ ] Nigeria
- [ ] Rwanda
- [ ] São Tomé and Príncipe
- [ ] Senegal
- [ ] Seychelles
- [ ] Sierra Leone
- [ ] Somalia
- [x] South Africa
- [ ] South Sudan
- [ ] Sudan
- [ ] Swaziland
- [ ] Tanzania
- [ ] Togo
- [x] Tunisia
- [ ] Uganda
- [ ] Western Sahara
- [ ] Zambia
- [ ] Zimbabwe

#### Australia & Pacific
---
- [x] Australia
- [x] New Zealand

### Areas of Application
- telephone systems
- carrier (land transport)
- time recording

### Blog Posts

[Mark Seemann - Simple holidays](http://blog.ploeh.dk/2017/04/24/simple-holidays/)

### Alternative projects

| Language | Project | Supported Countries (November 2017) |
| ------------- | ------------- | ------------- |
| PHP | [yasumi](https://github.com/azuyalabs/yasumi) | 29 |
| JavaScript | [date-holidays](https://github.com/commenthol/date-holidays) | 130 |
| Java | [jollyday](https://github.com/svendiedrichsen/jollyday) | 64 |
| .NET | [Holiday](https://github.com/martinjw/Holiday) | 21 |
| Phyton | [python-holidays](https://github.com/ryanss/python-holidays) | 20 |
| Phyton | [workalendar](https://github.com/peopledoc/workalendar) | 53 |

