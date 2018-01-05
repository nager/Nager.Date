using System;
using System.Linq;
using Nager.Date.Extensions;

namespace Nager.Date.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();

            Console.ReadLine();
        }

        private static void Test1()
        {
            var date = DateTime.Today;
            var countryCode = CountryCode.US;

            do
            {
                date = date.AddDays(1);
            } while (DateSystem.IsPublicHoliday(date, countryCode) || date.IsWeekend(countryCode));
        }

        private static void Test2()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.CH, 2017);
            foreach (var publicHoliday in publicHolidays)
            {
                Console.WriteLine("{0:dd.MM.yyyy} {1} {2}", publicHoliday.Date, publicHoliday.LocalName, publicHoliday.Global);
            }
        }
    }
}
