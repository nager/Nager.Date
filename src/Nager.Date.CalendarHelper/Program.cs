using Nager.Date.Calendars;

//06R04  -> Royal Plowing -> new DateTime(2026, 5, 5),
//06K15S -> Visak Bochea Day

var code = KhmerLunarCalendar.GetKhmerLunarCode(new DateTime(2025, 9, 21));

for (var year = 2000; year < 2050; year++)
{
    var date = KhmerLunarCalendar.FindStartDate(year, 166);
    Console.WriteLine($"{year} => new DateTime({date.Value.Year}, {date.Value.Month}, {date.Value.Day}),");
}
