using Nager.Date;

HolidaySystem.LicenseKey = "02207B22437265617465644174223A22323032342D30332D30375430303A30303A30302B30313A3030222C22497373756564546F223A224769744875622053706F6E736F72222C2256616C6964556E74696C223A22323132342D30322D31325430303A30303A30302B30313A3030227D45E4C77D87F3C02349AD88822D8455DF1A684B1F7892B7FE130E2AFC0B6E131850E9961C8D931F56BD825E17871DC6AE1EB8B76160F151A6A59CB4FB7C0A557B";

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
Console.WriteLine("Date            Observed                          English Name                       Local Name   Type");

var publicHolidays = HolidaySystem.GetHolidays(year, countryCode);
foreach (var publicHoliday in publicHolidays)
{
    var counties = publicHoliday.SubdivisionCodes != null ? string.Join(',', publicHoliday.SubdivisionCodes) : "";
    Console.WriteLine($"{publicHoliday.Date:ddd}{"",1}{publicHoliday.Date:d}{"",3}{publicHoliday.ObservedDate:ddd}{"",1}{publicHoliday.ObservedDate:d}{"",3}{publicHoliday.EnglishName,30}{"",3}{publicHoliday.LocalName,30}{"",3}{publicHoliday.HolidayTypes}{"",3}{counties}");
}
