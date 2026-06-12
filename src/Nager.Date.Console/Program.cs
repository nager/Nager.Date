using Nager.Date;
using Spectre.Console;

HolidaySystem.LicenseKey = "02207B22437265617465644174223A22323032342D30332D30375430303A30303A30302B30313A3030222C22497373756564546F223A224769744875622053706F6E736F72222C2256616C6964556E74696C223A22323132342D30322D31325430303A30303A30302B30313A3030227D45E4C77D87F3C02349AD88822D8455DF1A684B1F7892B7FE130E2AFC0B6E131850E9961C8D931F56BD825E17871DC6AE1EB8B76160F151A6A59CB4FB7C0A557B";

AnsiConsole.WriteLine("Nager.Date");
AnsiConsole.Write(new Rule { Style = Style.Parse("grey dim") });

var availableYears = new List<string>();

for (var year1 = DateTime.Today.AddYears(5).Year; year1 >= DateTime.Today.AddYears(-16).Year; year1--)
{
    availableYears.Add($"{year1}");
}

var selectedYears = AnsiConsole.Prompt(
    new MultiSelectionPrompt<string>()
        .Title("Please select the [green]years[/] to calculate:")
        .AddChoices(availableYears)
        .Select(DateTime.Today.Year.ToString())
        .Select(DateTime.Today.AddYears(-1).Year.ToString())
        .Select(DateTime.Today.AddYears(1).Year.ToString()));


var countryCode = AnsiConsole.Ask<string>("Please enter the country code (example:AT)");

var years = selectedYears.Select(int.Parse);

foreach (var year in years)
{
    var table = new Table();

    table.Title(new TableTitle($"Calculated holidays for [blue]{countryCode.ToUpper()}[/] [blue]{year}[/]"));

    table.AddColumn("Date");
    table.AddColumn("Observed");
    table.AddColumn("English Name");
    table.AddColumn("Local Name");
    table.AddColumn("Type");
    table.AddColumn("SubdivisionCodes");
    //table.AddColumn("ID");

    var publicHolidays = HolidaySystem.GetHolidays(year, countryCode);
    foreach (var publicHoliday in publicHolidays)
    {
        var subdivisionCodes = publicHoliday.SubdivisionCodes != null ? string.Join(',', publicHoliday.SubdivisionCodes) : "";

        var observedDate = "";
        if (!publicHoliday.Date.Equals(publicHoliday.ObservedDate.Date))
        {
            observedDate = $"{publicHoliday.ObservedDate:ddd} {publicHoliday.ObservedDate:d}";
        }

        table.AddRow(
            $"{publicHoliday.Date:ddd} {publicHoliday.Date:d}",
            $"{observedDate}",
            $"{publicHoliday.EnglishName}",
            $"{publicHoliday.LocalName}",
            $"{publicHoliday.HolidayTypes}",
            $"{subdivisionCodes}"
            //$"{publicHoliday.Id}"
        );
    }

    AnsiConsole.Write(table);
}
