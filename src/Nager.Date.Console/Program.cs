using Nager.Date;

DateSystem.LicenseKey = "Thank you for supporting open source projects";

Console.WriteLine("Nager.Date");

Console.WriteLine("Please enter the year, and press enter");
var tempYear = Console.ReadLine();
if (!int.TryParse(tempYear, out var year))
{
    Console.WriteLine("Cannot parse year");
    return;
}

Console.WriteLine("Please enter the country code, and press enter");
var countryCode = Console.ReadLine();

var publicHolidays = DateSystem.GetPublicHolidays(year, countryCode);
foreach (var publicHoliday in publicHolidays)
{
    var counties = publicHoliday.Counties != null ? string.Join(',', publicHoliday.Counties) : "";
    Console.WriteLine($"{publicHoliday.Date:d} {publicHoliday.Name} ({publicHoliday.LocalName}) {counties}");
}
