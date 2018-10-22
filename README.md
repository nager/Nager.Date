[![GitHub Release](https://img.shields.io/github/release/tinohager/nager.date.svg?style=flat-square)](https://github.com/tinohager/nager.date/releases)

# Nager.Date

Nager.Date is a Date/Calendar Framework for .NET
- Public holiday calculation for every year, based on easter sunday, country and county support.
Supports 88 countries.
- Weekend information (supports 120 countries)
- Age calculation

If your country is not supported, fork me, implement it and send me the pull request.

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

#### Check if a date is a public holiday
```cs
var date = new DateTime(2017, 1, 1);
if (DateSystem.IsPublicHoliday(date, CountryCode.DE))
{
	Console.WriteLine("Is public holiday");
}
```

#### Check if a date is a weekend day
```cs
var date = new DateTime(2017, 1, 1);
if (DateSystem.IsWeekend(date, CountryCode.DE))
{
	Console.WriteLine("Is weekend");
}
```

#### Calculate age
```cs
var date = new DateTime(1900, 1, 1);
var age = DateSystem.GetAge(date);
```

### [Country Support](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2#Officially_assigned_code_elements)

Here is a list of all supported countries.
If a country is not supported, it will be considered having no public holidays and using the universal weekend (saturday-sunday).

#### Europe
---
| Country | Code | Holidays (43/52) | Weekends (32/52)|
| --- | :---: | :---: | :---: |
| Åland Islands | AX | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Albania | AL | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Andorra | AD | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Austria | AT | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Belarus | BY | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Belgium | BE | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Bosnia and Herzegovina | BA | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Bulgaria | BG | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Croatia | HR | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Cyprus | CY | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Czech Republic | CZ | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Denmark | DK | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Estonia | EE | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Faroe Islands | FO | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Finland | FI | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| France | FR | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Germany | DE | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Gibraltar | GI | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Greece | GR | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Guernsey | GG | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Hungary | HU | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Iceland | IS | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Ireland | IE | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Isle of Man | IM | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Italy | IT | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Jersey | JE | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Latvia | LV | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Liechtenstein | LI | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Lithuania | LT | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Luxembourg | LU | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Macedonia (the former Yugoslav Republic of) | MK | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Malta | MT | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Moldova (Republic of) | MD | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Monaco | MC | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Montenegro | ME | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Netherlands | NL | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Norway | NO | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Poland | PL | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Portugal | PT | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Romania | RO | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Russian Federation | RU | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| San Marino | SM | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Serbia | RS | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Slovakia | SK | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Slovenia | SI | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Spain | ES | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Svalbard and Jan Mayen | SJ | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Sweden | SE | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Switzerland | CH | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Ukraine | UA | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| United Kingdom of Great Britain and Northern Ireland | GB | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Vatican City Holy See | VA | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |

#### Asia
---
| Country | Code | Holidays (2/53) | Weekends (38/53)|
| --- | :---: | :---: | :---: |
| Afghanistan | AF | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Armenia | AM | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Azerbaijan | AZ | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Bahrain | BH | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Bangladesh | BD | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Bhutan | BT | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| British Indian Ocean Territory | IO | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Brunei Darussalam | BN | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Cambodia | KH | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| China (without Qingming (Tomb-Sweeping Day)) | CN | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Christmas Island | CX | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Cocos (Keeling) Islands | CC | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| East Timor | TL | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Georgia | GE | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Hong Kong | HK | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| India | IN | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Indonesia | ID | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Iran (Islamic Republic of) | IR | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Iraq | IQ | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Israel | IL | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Japan | JP | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Jordan | JO | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Kazakhstan | KZ | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Kuwait | KW | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Kyrgyzstan | KG | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Laos | LA | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Lebanon | LB | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Macao | MO | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Malaysia | MY | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Maldives | MV | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Mongolia | MN | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Myanmar | MM | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Nepal | NP | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| North Korea | KP | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Oman | OM | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Pakistan | PK | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Palestine, State of | PS | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Philippines | PH | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Qatar | QA | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Saudi Arabia | SA | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Singapore | SG | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| South Korea | KR | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Sri Lanka | LK | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Syrian Arab Republic | SY | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Taiwan, Province of China[a] | TW | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Tajikistan | TJ | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Thailand | TH | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Turkey (without muslim based holidays) | TR | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Turkmenistan | TM | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| United Arab Emirates | AE | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Uzbekistan | UZ | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Viet Nam | VN | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Yemen | YE | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |

#### North America
---
| Country | Code | Holidays (4/6) | Weekends (3/6)|
| --- | :---: | :---: | :---: |
| Bermuda | BM | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Canada | CA | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Dominican Republic | DO | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Greenland | GL | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Saint Pierre and Miquelon | PM | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| United States of America | US | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |

#### Central America and the Antilles (15/22)
---
| Country | Code | Holidays (15/32) | Weekends (2/15)|
| --- | :---: | :---: | :---: |
| Anguilla | AI | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Antigua and Barbuda | AG | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Bahamas | BS | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Barbados | BB | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Belize | BZ | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Bonaire, Sint Eustatius and Saba | BQ | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Cayman Islands | KY | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Costa Rica | CR | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Cuba | CU | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Dominica | DM | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| El Salvador | SV | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Grenada | GD | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Guadeloupe | GP | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Guatemala | GT | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Haiti | HT | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Honduras | HN | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Jamaica | JM | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Martinique | MQ | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Mexico | MX | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Montserrat | MS | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Nicaragua | NI | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Panama | PA | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Puerto Rico | PR | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Saint Barthélemy | BL | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Saint Kitts and Nevis | KN | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Saint Lucia | LC | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Saint Martin (French part) | MF | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Saint Vincent and the Grenadines | VC | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Sint Maarten (Dutch part) | SX | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Turks and Caicos Islands | TC | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Virgin Islands (British) | VG | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Virgin Islands (U.S.) | VI | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |

#### South America (13/14)
---
| Country | Code | Holidays (12/17) | Weekends (6/17)|
| --- | :---: | :---: | :---: |
| Argentina | AR | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Aruba | AW | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Bolivia (Plurinational State of) | BO | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Brazil | BR | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Chile | CL | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Colombia | CO | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Curaçao | CW | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Ecuador | EC | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Falkland Islands (Malvinas) | FK | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| French Guiana | GF | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Guyana (without muslim based holidays and hindu based holidays) | GY | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Paraguay | PY | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Peru | PE | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Suriname | SR | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Trinidad and Tobago | TT | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Uruguay | UY | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Venezuela (Bolivarian Republic of) | VE | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |

#### Africa
---
| Country | Code | Holidays (9/58) | Weekends (36/58)|
| --- | :---: | :---: | :---: |
| Algeria | DZ | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Angola | AO | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Benin | BJ | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Botswana | BW | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Burkina Faso | BF | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Burundi | BI | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Cabo Verde | CV | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Cameroon | CM | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Central African Republic | CF | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Chad | TD | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Comoros | KM | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Congo | CG | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Congo (Democratic Republic of the) | CD | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Côte d'Ivoire | CI | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Djibouti | DJ | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Egypt | EG | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Equatorial Guinea | GQ | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Eritrea | ER | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Ethiopia | ET | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Gabon | GA | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Gambia | GM | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Ghana | GH | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Guinea | GN | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Guinea-Bissau | GW | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Kenya | KE | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Lesotho | LS | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Liberia | LR | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Libya | LY | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Madagascar | MG | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Malawi | MW | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Mali | ML | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Mauritania | MR | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Mauritius | MU | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Mayotte | YT | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Morocco | MA | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Mozambique | MZ | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Namibia | NA | <ul><li>[x] </li></ul> | <ul><li>[ ] </li></ul> |
| Niger | NE | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Nigeria | NG | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Réunion | RE | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Rwanda | RW | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Saint Helena, Ascension and Tristan da Cunha | SH | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Sao Tome and Principe | ST | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Senegal | SN | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Seychelles | SC | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Sierra Leone | SL | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Somalia | SO | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| South Africa | ZA | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| South Sudan | SS | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Sudan | SD | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Swaziland | SZ | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Tanzania, United Republic of | TZ | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Togo | TG | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Tunisia | TN | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Uganda | UG | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Western Sahara | EH | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Zambia | ZM | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |
| Zimbabwe | ZW | <ul><li>[ ] </li></ul> | <ul><li>[x] </li></ul> |

#### Australia & Pacific
---
| Country | Code | Holidays (2/26) | Weekends (2/2)|
| --- | :---: | :---: | :---: |
| American Samoa | AS | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Australia | AU | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Cook Islands | CK | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Fiji | FJ | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| French Polynesia | PF | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Guam | GU | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Kiribati | KI | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Marshall Islands | MH | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Micronesia (Federated States of) | FM | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Nauru | NR | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| New Caledonia | NC | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| New Zealand | NZ | <ul><li>[x] </li></ul> | <ul><li>[x] </li></ul> |
| Niue | NU | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Norfolk Island | NF | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Northern Mariana Islands | MP | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Palau | PW | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Papua New Guinea | PG | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Pitcairn | PN | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Samoa | WS | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Solomon Islands | SB | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Tokelau | TK | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Tonga | TO | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Tuvalu | TV | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| United States Minor Outlying Islands | UM | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Vanuatu | VU | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Wallis and Futuna | WF | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |

#### Antarctica
---
| Country | Code | Holidays (0/5) | Weekends (0/5)|
| --- | :---: | :---: | :---: |
| Antarctica | AQ | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Bouvet Island | BV | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| French Southern Territories | TF | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| Heard Island and McDonald Islands | HM | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |
| South Georgia and the South Sandwich Islands | GS | <ul><li>[ ] </li></ul> | <ul><li>[ ] </li></ul> |


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
