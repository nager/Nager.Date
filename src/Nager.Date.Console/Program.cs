using Nager.Date;

HolidaySystem.LicenseKey = "02207B22437265617465644174223A22323032342D30332D30365430303A30303A30302B30313A3030222C22497373756564546F223A224769744875622053706F6E736F72222C2256616C6964556E74696C223A22323132342D30322D31315430303A30303A30302B30313A3030227D51A2E1C2D95CF107C08AF4783CDDFCC5D555A5C66BE1D5A370190E42A6370140E6753C515C6830C0B33F2191827AFDBE91DC2F3DF4BAE33462D0436B38FBFBE1";

Console.WriteLine("Nager.Date");

Console.WriteLine($"Please enter the year, and press enter (default:{DateTime.Today.Year})");
var tempYear = Console.ReadLine();
if (!int.TryParse(tempYear, out var year))
{
    year = DateTime.Today.Year;
}

Console.WriteLine("Please enter the country code, and press enter (default:AT)");
var countryCode = Console.ReadLine();
if (string.IsNullOrEmpty(countryCode))
{
    countryCode = "at";
}

Console.WriteLine($"Calculate holidays for {countryCode.ToUpper()} {year}");
Console.WriteLine("--------------------------------------------------------------------------------------------------");
Console.WriteLine("Date         Observed                       English Name                       Local Name   Type");

var publicHolidays = HolidaySystem.GetHolidays(year, countryCode);
foreach (var publicHoliday in publicHolidays)
{
    var counties = publicHoliday.SubdivisionCodes != null ? string.Join(',', publicHoliday.SubdivisionCodes) : "";
    Console.WriteLine($"{publicHoliday.Date:d}{"",3}{publicHoliday.ObservedDate:d}{"",3}{publicHoliday.EnglishName,30}{"",3}{publicHoliday.LocalName,30}{"",3}{publicHoliday.HolidayTypes}{"",3}{counties}");
}
