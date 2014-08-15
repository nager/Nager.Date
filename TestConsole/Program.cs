using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var publicHolidays = Nager.Date.DateSystem.GetPublicHoliday("CH", 2015);

            var isTodayPublicHoliday = Nager.Date.DateSystem.IsPublicHoliday(DateTime.Now, "AT");

            foreach (var publicHoliday in publicHolidays)
            {
                Console.WriteLine("{0:dd.MM.yyyy} {1}", publicHoliday.Date, publicHoliday.Name);
            }
            Console.ReadLine();
        }
    }
}
