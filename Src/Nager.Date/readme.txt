Thanks for using the Nager.Date package (https://github.com/tinohager/Nager.Date)
----------------------------------------------------------------
Please star (★) this project on github!


Example code:
----------------------------------------------------------------

//Get all publicHolidays of a country and year
var publicHolidays = DateSystem.GetPublicHoliday("DE", 2018);
foreach (var publicHoliday in publicHolidays)
{
	//publicHoliday...
}

//Get all publicHolidays for a date range
var startDate = new DateTime(2016, 5, 1);
var endDate = new DateTime(2019, 5, 31);
var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.DE, startDate, endDate);
foreach (var publicHoliday in publicHolidays)
{
	//publicHoliday...
}