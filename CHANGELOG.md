# Change Log
All notable changes to this project will be documented in this file.
 
The format is based on [Keep a Changelog](http://keepachangelog.com/)
and this project adheres to [Semantic Versioning](http://semver.org/).

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


--------------------------------------------------------


## [Unreleased 1.X.X] - yyyy-mm-dd
 
### Added
### Changed
### Deprecated
### Removed
### Fixed