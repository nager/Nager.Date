# Change Log
All notable changes to this project will be documented in this file.
 
The format is based on [Keep a Changelog](http://keepachangelog.com/)
and this project adheres to [Semantic Versioning](http://semver.org/).

## [Unreleased 1.X.X] - yyyy-mm-dd
 
### Added
### Changed
### Deprecated
### Removed
### Fixed


## [1.31.0] - 2022-01-02
 
### Changed
- Change Access Modifier of NoHolidaysProvider to check the country is supported

## [1.30.0] - 2021-09-30
 
### Added
- Add Bosnia and Herzegovina
- Add Singapore
### Fixed
- Fix Netherlands - Holiday Type of Good Friday
- Fix Chile - Set Battle of Arica only valid in CL-AP
- Fix Switzerland - Federal Day of Thanksgiving

## [1.29.2] - 2021-06-21
 
### Added
- Add Whit Monday to Cyprus
- Add Juneteenth to UnitedStates
### Fixed
- Fix Netherlands - Local translation Good Friday

## [1.29.1] - 2021-06-16
 
### Added
- Add GoodFriday to UnitedStates
### Changed
- WebApi Swagger OperationId
### Fixed
- Fix Costa Rica, Law 9803
- Fix German, EasterSunday

## [1.29.0] - 2021-05-18
 
### Added
- Add Nigeria
### Changed
- Straighten method names GetPublicHoliday to GetPublicHolidays
- Move religious holidays in the Catholic or Orthodox provider
### Fixed
- Fix Canada, FamilyDay for New-Brunswick
- Fix Vatican City, Wrong char in Anniversary of the election of Pope Francis
- Fix DateSystem.IsPublicHoliday(DateTime date, CountryCode countryCode)
- Fix Japan, Emperors Birthday
- Fix LongWeekend calculation (only PublicHolidayType Public)
- Fix Bahamas, Lack of rules for the shifting of holidays

## [1.28.2] - 2021-03-08
 
### Added
- Add Montenegro
### Fixed
- Fix Canada Victoria day

## [1.28.1] - 2021-02-17
 
### Added
- Add CHANGELOG file
- Add Region Statistic
- Add Papua New Guinea
- Add Guernsey
- Add Gibraltar
- Add Montserrat
### Changed
- Docker Image location
### Fixed
- Fix Åland, Midsummer Day and All Saints Day
- Fix Canada, FamilyDay
- Fix Docker Container crash
- Fix Australia, Add Weekend shift

## [1.28.0] - 2021-01-20

### Added

- Add South Korea

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
- Ireland add Good Friday

### Fixed

- Croatia - Fix Remembrance Day and National Day
- Spain - Fix Maundy Thursday

## [1.26.4] - 2020-10-22

### Added

- Publish nuget symbols

## [1.26.3] - 2020-08-26

### Fixed

- Fix Croatia Public Holiday

## [1.26.2] - 2020-07-01

### Fixed

- Fix United Kingdom Christmas Day and Boxing Day

## [1.26.1] - 2020-06-16

### Changed

- Simplify IsPublicHoliday

### Fixed

- Fix Lithuania

## [1.26.0] - 2020-05-29

### Added

- Bulgaria add Good Friday
- Ireland add Good Friday

### Fixed

- Fixes for Switzerland
- Fix Australia add Reconciliation Day
