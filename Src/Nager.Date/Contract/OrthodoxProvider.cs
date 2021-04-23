using System;
using System.Collections.Concurrent;

namespace Nager.Date.Contract
{

    /// <summary>
    /// Orthodox
    /// </summary>
    public class OrthodoxProvider : IOrthodoxProvider
    {
        private static readonly ConcurrentDictionary<int, DateTime> _cache = new ConcurrentDictionary<int, DateTime>();

        ///<inheritdoc/>
        public DateTime EasterSunday(int year)
        {
            return _cache.GetOrAdd(year, y =>
            {
                var a = y % 19;
                var b = y % 7;
                var c = y % 4;

                var d = (19 * a + 16) % 30;
                var e = (2 * c + 4 * b + 6 * d) % 7;
                var f = (19 * a + 16) % 30;
                var key = f + e + 3;

                var month = (key > 30) ? 5 : 4;
                var day = (key > 30) ? key - 30 : key;

                return new DateTime(y, month, day);
            });
        }
    }
}
