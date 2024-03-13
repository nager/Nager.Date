# Change Log
All notable changes to this project will be documented in this file.
 
The format is based on [Keep a Changelog](http://keepachangelog.com/)
and this project adheres to [Semantic Versioning](http://semver.org/).

## :loudspeaker: From version 2 - you will find the change log here
https://github.com/nager/Nager.Date/releases


## [2.0.0-alpha] - 2024-03-05

### Added
- Add a second date for holiday observed
### Changed
- Move Day finding logic to DateHelper
- Change project structure
### Removed
- Remove bridge day logic part

## [1.48.0] - 2024-02-12

### Added
- Add .NET 8 Support
### Removed
- Japan - Remove obsolete code
- Åland - Remove some wrong holidays
### Fixed
- Mexico - Fix Inauguration Day 2024
- Singapore - Fix Deepavali Day

## [1.47.1] - 2023-12-13

### Fixed
- Singapore - Fix Chinese New Year sunday shift
- Canada - Fix British Columbia Day

## [1.47.0] - 2023-11-21

### Added
- South Africa - Add Springboks Victory 2023

### Fixed
- Australia - Fix missing Melbourne Cup

## [1.46.0] - 2023-10-10

### Fixed
- Japan - Fix Health and Sports Day
- Australia - Fix King's Birthday Queensland
- Australia - Fix New Year's Day weekend shift
- Serbia - Fix Weekendshift non-religious holidays

## [1.45.0] - 2023-08-27

### Added
- Singapore - Add Polling Day
- Slovenia - Solidarity day

### Fixed
- Chile - Fix National Day of Indigenous Peoples 

## [1.44.0] - 2023-08-22

### Fixed
- Colombia - Fix Battle of Boyacá translation
- Zimbabwe - Fix Defence Forces Day

### Removed
- Colombia - Carnival

## [1.43.0] - 2023-06-26

### Added
- Belgium - Add Bank holidays

### Fixed
- Netherlands - Fix Whit Monday translation
- Germany - Fix World Childrens Day show before 2019
- New Zealand - Fix Kings Birthday

## [1.42.0] - 2023-04-24

### Fixed
- Liechtenstein - Fix Ascension Day, fix missing Pentecost, fix Bank Holidays

## [1.41.0] - 2023-04-18

### Fixed
- Belarus - Fix missing second new year day
- Bulgaria - Fix weekend shift logic
- Australia - Fix Monarch birthday name
- Australia - Fix EasterSunday missing AU-WA


## [1.40.0] - 2023-03-04

### Added
- Romania - Epiphany and Saint John the Baptist
### Fixed
- Greece - Fix Pentecost
- Australia - Fix Christmas and Boxing Day Weekend Shift
- Germany - Fix International Womens Day
- Denmark - Fix General Prayer Day 2024
- Brazil - Fix Carnival


## [1.39.0] - 2023-02-11

### Added
- United States - Add counties
### Removed
- United States - Remove wrong Inauguration Day
### Fixed
- Colombia - Fix missing Monday shift
- Spain - Fix holidays for 2023 changes
- South Africa - Fix missing holiday shift

## [1.38.0] - 2023-01-11

### Added
- Isle of Man - Add Missing Royal Holidays
- Canada - Add Saskatchewan Day
- Ireland - Add Saint Brigid's Day
### Fixed
- Chile - Fix National Plebiscite
- Australia - Fix incorrect counties
- Bosnia And Herzegovina - Fix incorrect counties
- Canada - Fix St. Stephen's Day naming
- Turkey - Check Hijri year is supported

## [1.37.0] - 2022-11-09

### Added
- Singapore - Add Hari Raya Puasa, Vesak Day, Hari Raya Haji, Deepavali
- United Kingdom - Add Coronation Bank Holiday
- Turkey - Add Eid al-Adha, add Eid al-Fitr
### Changed
- France - Holidays revised, county information revised
### Fixed
- Singapore - Fix missing sunday shift

## [1.36.4] - 2022-10-04

### Fixed
- DateSystem - NoHolidaysProvider Access Modifier public

## [1.36.3] - 2022-09-30

### Changed
- Chile - Apply changes from Wikipedia
- DateSystem - Change holiday provider access level
- DateSystem - Rename get method in providers

## [1.36.2] - 2022-09-19

### Added
- Albania - Add catholic easter
- Andorra - Add missing holidays
### Changed
- Albania - Optimized Weekend Shift

## [1.36.1] - 2022-09-13

### Added
- Canada - Add State Funeral of Queen Elizabeth II
- New Zealand - Add Queen Elizabeth II Memorial Day
- Australia - Add National Day of Mourning for Queen Elizabeth II

## [1.36.0] - 2022-09-11

### Added
- Spain - Add Santiago Apóstol
- Spain - Add Lunes de Pascua Granada
- United Kingdom - Queen Elizabeth II’s State Funeral
### Changed
- Unit tests - Optimize
- San Marino - Optimize St. Stephen's Day
- Spain - Updated regions, removed provinces
- Spain - Change Christmas Day counties for 2022
### Fixed
- DateSystem - Fix bug FindDayBetween 
- Spain - Fix San Jose Day

## [1.35.0] - 2022-06-01

### Added
- New Zealand - Add Matariki
### Fixed
- Spain - Fix Labour Day and Day of Madrid 
- Sweden - Fix Ascension Day
- Faroe Islands - Fix General Prayer Day

## [1.34.1] - 2022-05-02

### Fixed
- Fix readme.txt

## [1.34.0] - 2022-05-02

### Added
- Add LicenseKey for NuGet Package and Docker Container
- Greenland - Add local Translations
### Removed
- Remove obsolete methods in DateSystem.cs
### Fixed
- Fix summary in DateSystem.cs
- Brazil - Fix holiday names

## [1.33.1] - 2022-03-16

### Changed
- Switch to .NET 6
### Fixed
- Fixing missing changes from Japan Pull Request

## [1.33.0] - 2022-03-16

### Added
- Bulgaria - Add Holy Saturday
### Fixed
- Bulgaria - Fix spelling issues
- Japan - Fix AutumnalEquinox and VernalEquinox
- Isle of Man - Fix Bank Holidays

## [1.32.0] - 2022-01-21

### Changed
- New Zealand - Optimize
- Finland - Optimize translation
- Optimize return description
- Docker no longer requires enviorment variables for swagger mode
### Removed
- Docker Remove Ip Rate Limiting
- Docker Remove CORS configuration
### Fixed
- United States - Fix spelling issue

## [1.31.0] - 2022-01-02

### Changed
- Change Access Modifier of NoHolidaysProvider to check the country is supported

## [1.30.0] - 2021-09-30

### Added
- Bosnia and Herzegovina
- Singapore
### Fixed
- Netherlands - Fix Holiday Type of Good Friday
- Chile - Fix Battle of Arica only valid in CL-AP
- Switzerland -Fix Federal Day of Thanksgiving

## [1.29.2] - 2021-06-21

### Added
- Cyprus - Add Whit Monday
- UnitedStates - Add Juneteenth
### Fixed
- Netherlands - Fix Local translation Good Friday

## [1.29.1] - 2021-06-16

### Added
- UnitedStates - Add GoodFriday
### Changed
- WebApi Swagger OperationId
### Fixed
- Costa Rica - Fix Law 9803

## [1.29.0] - 2021-05-18

### Added
- Nigeria
### Changed
- Straighten method names GetPublicHoliday to GetPublicHolidays
- Move religious holidays in the Catholic or Orthodox provider
### Fixed
- Canada - Fix FamilyDay for New-Brunswick
- Vatican City - Fix wrong char in Anniversary of the election of Pope Francis
- Japan - Fix Emperors Birthday
- Bahamas - Fix lack of rules for the shifting of holidays
- Fix LongWeekend calculation (only PublicHolidayType Public)
- Fix DateSystem.IsPublicHoliday(DateTime date, CountryCode countryCode)

## [1.28.2] - 2021-03-08

### Added
- Montenegro
### Fixed
- Canada - Fix Victoria day

## [1.28.1] - 2021-02-17

### Added
- Add CHANGELOG file
- Add Region Statistic
- Papua New Guinea
- Guernsey
- Gibraltar
- Montserrat
### Changed
- Docker Image location
### Fixed
- Åland - Fix Midsummer Day and All Saints Day
- Canada - Fix FamilyDay
- Australia - Fix Weekend shift
- Fix Docker Container crash

## [1.28.0] - 2021-01-20

### Added
- South Korea

## [1.27.1] - 2021-01-20

### Added
- Add .net 5 target

## [1.27.0] - 2021-01-13

### Changed
- Performance improvements
- Simplified usage of FindDay

### Fixed
- Croatia - Fix Remembrance Day and National Day
- Spain - Fix Maundy Thursday

## [1.26.7] - 2020-12-18

### Fixed
- Spain - Fix boe.es

## [1.26.5] - 2020-11-20

### Added
- United Kingdom - Add Queen’s Platinum Jubilee
- Ireland - Add Good Friday

### Fixed
- Croatia - Fix Remembrance Day and National Day
- Spain - Fix Maundy Thursday

## [1.26.4] - 2020-10-22

### Added
- Publish nuget symbols

## [1.26.3] - 2020-08-26

### Fixed
- Croatia - Fix Public Holiday

## [1.26.2] - 2020-07-01

### Fixed
- United Kingdom - Fix Christmas Day and Boxing Day

## [1.26.1] - 2020-06-16

### Changed
- Simplify IsPublicHoliday

### Fixed
- Lithuania - Small fix

## [1.26.0] - 2020-05-29

### Added
- Bulgaria - Add Good Friday
- Ireland - Add Good Friday

### Fixed
- Switzerland - Some fixes
- Australia - Fix Reconciliation Day

## [1.25.0] - 2019-06-10

### Fixed
- Added UK May Bank Holiday Change VE Day 2020

## [1.23.0] - 2019-01-05

### Added
- Mongolia
- Vietnam
- Indonesia
### Fixed
- Some small fixes, cleanup code

## [1.22.0] - 2018-09-08

### Added
- Lesotho
### Removed
- Powershell install script
### Fixed
- United Kingdom - Fix St Andrews Day for Scotland

## [1.21.0] - 2018-08-15

### Added
- Moldova
- Tunisia
- Egypt
- Serbia
- Vatican City
- San Marino
- Barbados
- Grenada
- Ukraine
- Faroe Islands
- Svalbard
- Jan Mayen

## [1.20.0] - 2018-08-01

### Added
- Morocco
- Gabon
- Macedonia

## [1.19.0] - 2018-01-22

### Added
- Nicaragua
- Mexico
- Belize

## [1.18.0] - 2017-11-27

### Added
- Åland

## [1.17.0] - 2017-11-26

### Added
- Chile
- Haiti
- Guyana
- Suriname
- China
### Fixed
- Germany - Optimize Provider

## [1.16.0] - 2017-11-05

### Added
- Dominican Republic
- Jamaica
- Ecuador
- Cuba

## [1.15.0] - 2017-10-09

### Added
- Colombia
- Andorra
- Monaco
- Jersey
- Isle of Man

## [1.14.0] - 2017-10-04

### Added
- Costa Rica
- Puerto Rico

## [1.13.0] - 2017-09-30

### Added
- Venezuela
### Changed
- Change to .netstandard 2.0

## [1.12.0] - 2017-09-17

### Added
- Panama
### Changed
- Change to .netstandard 2.0

## [1.11.0] - 2017-09-11

### Added
- Argentina
### Changed
- Change to .netstandard 2.0

## [1.10.0] - 2017-08-28

### Added
- Uruguay
### Changed
- Change to .netstandard 2.0
### Fixed
- Somes fixes

## [1.9.0] - 2017-05-18

### Added
- Bahamas
### Fixed
- Somes fixes

## [1.8.0] - 2017-05-18

### Added
- Australia
- Guatemala
### Fixed
- Somes fixes

## [1.7.0] - 2017-05-04

### Added
- Add .net standard and .net 4.5 target

## [1.6.0] - 2017-03-26

### Added
- Botswana
- Namibia
- Iceland
- Paraguay
- Honduras

## [1.5.1] - 2017-03-19

### Added
- Bolivia

## [1.4.1] - 2017-03-12

### Added
- Madagascar
- South Africa
- New Zealand
- Brazil
- Peru
### Fixed
- Some bugfixes

## [1.2.0] - 2017-02-28

### Added
- Belarus
- Greenland
- Russia

## [1.1.0] - 2017-02-25

### Added
- Add Worldmap
### Fixed
- United Kingdom - Fix CountryCode

--------------------------------------------------------


## [Unreleased 1.X.X] - yyyy-mm-dd

### Added
### Changed
### Deprecated
### Removed
### Fixed
