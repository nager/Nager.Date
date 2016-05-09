using System;

namespace Nager.Date.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var publicHolidays = DateSystem.GetPublicHoliday("CH", 2017);
            foreach (var publicHoliday in publicHolidays)
            {
                Console.WriteLine("{0:dd.MM.yyyy} {1} {2}", publicHoliday.Date, publicHoliday.LocalName, publicHoliday.Global);
            }

            Console.ReadLine();
        }
    }
}
