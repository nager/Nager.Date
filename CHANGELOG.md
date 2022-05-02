# Change Log
All notable changes to this project will be documented in this file.
 
The format is based on [Keep a Changelog](http://keepachangelog.com/)
and this project adheres to [Semantic Versioning](http://semver.org/).

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