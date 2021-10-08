using Nager.Date.Extensions;
using System;
using System.Diagnostics;

namespace Nager.Date.TestConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Test3();

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
            var publicHolidays = DateSystem.GetPublicHolidays(2017, CountryCode.CH);
            foreach (var publicHoliday in publicHolidays)
            {
                Console.WriteLine("{0:dd.MM.yyyy} {1} {2}", publicHoliday.Date, publicHoliday.LocalName, publicHoliday.Global);
            }
        }

		private static void Test3()
		{
			//performance test
			var sw = Stopwatch.StartNew();
			for (var i = 0; i < 10000; i++)
			{
				var x = DateSystem.IsPublicHoliday(new DateTime(2017, 07, 04), CountryCode.JP);
			}
			sw.Stop();
			Console.WriteLine("Elapsed time: " + sw.ElapsedMilliseconds + "ms");
		}
	}
}
