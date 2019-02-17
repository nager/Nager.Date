Thank you for using the Nager.Date package (https://github.com/tinohager/Nager.Date)
----------------------------------------------------------------
Please support this project with the award of a Github Star (★)


Code examples:
----------------------------------------------------------------

//Get all publicHolidays of a given year and country
var publicHolidays = DateSystem.GetPublicHoliday(2018, "DE");
foreach (var publicHoliday in publicHolidays)
{
	//publicHoliday...
}

//Get all publicHolidays for a date range
var startDate = new DateTime(2016, 5, 1);
var endDate = new DateTime(2019, 5, 31);
var publicHolidays = DateSystem.GetPublicHoliday(startDate, endDate, CountryCode.DE);
foreach (var publicHoliday in publicHolidays)
{
	//publicHoliday...
}