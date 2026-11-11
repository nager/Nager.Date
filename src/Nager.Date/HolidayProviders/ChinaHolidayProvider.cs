using Nager.Date.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Nager.Date.HolidayProviders
{
    /// <summary>
    /// China HolidayProvider
    /// </summary>
    internal sealed class ChinaHolidayProvider : AbstractHolidayProvider
    {
        private static readonly HttpClient HttpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10),
        };

        private static readonly ConcurrentDictionary<int, Lazy<HolidaySpecification[]>> HolidaySpecificationsByYear = new ConcurrentDictionary<int, Lazy<HolidaySpecification[]>>();

        /// <summary>
        /// China HolidayProvider
        /// </summary>
        public ChinaHolidayProvider() : base(CountryCode.CN)
        {
        }

        /// <inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
            var lazyHolidaySpecifications = HolidaySpecificationsByYear.GetOrAdd(
                year,
                currentYear => new Lazy<HolidaySpecification[]>(() => this.DownloadHolidaySpecifications(currentYear)));

            try
            {
                return lazyHolidaySpecifications.Value;
            }
            catch (Exception)
            {
                // Do not retain failed downloads, so later calls can retry when the source is available again.
                ((ICollection<KeyValuePair<int, Lazy<HolidaySpecification[]>>>)HolidaySpecificationsByYear)
                    .Remove(new KeyValuePair<int, Lazy<HolidaySpecification[]>>(year, lazyHolidaySpecifications));
                return this.GetLocalHolidaySpecifications(year);
            }
        }

        private HolidaySpecification[] DownloadHolidaySpecifications(int year)
        {
            var url = string.Format(CultureInfo.InvariantCulture, "https://raw.githubusercontent.com/NateScarlet/holiday-cn/master/{0}.json", year);
            var json = HttpClient.GetStringAsync(url).GetAwaiter().GetResult();

            ChinaHolidayData? holidayData;
            var serializer = new DataContractJsonSerializer(typeof(ChinaHolidayData));
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                holidayData = serializer.ReadObject(stream) as ChinaHolidayData;
            }

            if (holidayData?.Year != year || holidayData.Days == null || holidayData.Days.Length == 0)
            {
                throw new InvalidDataException("The China holiday data is missing or does not match the requested year.");
            }

            var holidaySpecifications = new List<HolidaySpecification>();
            var idsByHoliday = new Dictionary<string, int>(StringComparer.Ordinal);

            foreach (var day in holidayData.Days)
            {
                if (day == null || string.IsNullOrWhiteSpace(day.Name) || string.IsNullOrWhiteSpace(day.Date) || !day.IsOffDay.HasValue)
                {
                    throw new InvalidDataException("The China holiday data contains an invalid day.");
                }

                if (!DateTime.TryParseExact(day.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date) || date.Year != year)
                {
                    throw new InvalidDataException("The China holiday data contains an invalid date.");
                }

                if (!day.IsOffDay.Value)
                {
                    continue;
                }

                var localName = day.Name.Trim();
                var holidayName = GetHolidayName(localName);
                idsByHoliday.TryGetValue(holidayName.Id, out var holidayIndex);
                holidayIndex++;
                idsByHoliday[holidayName.Id] = holidayIndex;

                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = string.Format(CultureInfo.InvariantCulture, "{0}-{1:D2}", holidayName.Id, holidayIndex),
                    Date = date,
                    EnglishName = holidayName.EnglishName,
                    LocalName = localName,
                    HolidayTypes = HolidayTypes.Public,
                });
            }

            return holidaySpecifications.ToArray();
        }

        private IEnumerable<HolidaySpecification> GetLocalHolidaySpecifications(int year)
        {
            var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01",
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "New Year's Day",
                    LocalName = "元旦",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "LABOURDAY-01",
                    Date = new DateTime(year, 5, 1),
                    EnglishName = "Labour Day",
                    LocalName = "劳动节",
                    HolidayTypes = HolidayTypes.Public,
                },
                new HolidaySpecification
                {
                    Id = "NATIONALDAY-01",
                    Date = new DateTime(year, 10, 1),
                    EnglishName = "National Day",
                    LocalName = "国庆节",
                    HolidayTypes = HolidayTypes.Public,
                },
            };

            var chineseCalendar = new ChineseLunisolarCalendar();
            if (year > chineseCalendar.MinSupportedDateTime.Year && year < chineseCalendar.MaxSupportedDateTime.Year)
            {
                // LunisolarCalendar is valid between 1901 and 2100, inclusive.
                var leapMonth = chineseCalendar.GetLeapMonth(year);
                var springFestival = chineseCalendar.ToDateTime(year, this.MoveMonth(1, leapMonth), 1, 0, 0, 0, 0);
                var dragonBoatFestival = chineseCalendar.ToDateTime(year, this.MoveMonth(5, leapMonth), 5, 0, 0, 0, 0);
                var midAutumnFestival = chineseCalendar.ToDateTime(year, this.MoveMonth(8, leapMonth), 15, 0, 0, 0, 0);

                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "CHINESENEWYEAR-01",
                    Date = springFestival,
                    EnglishName = "Chinese New Year (Spring Festival)",
                    LocalName = "春节",
                    HolidayTypes = HolidayTypes.Public,
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "DRAGONBOATFESTIVAL-01",
                    Date = dragonBoatFestival,
                    EnglishName = "Dragon Boat Festival",
                    LocalName = "端午节",
                    HolidayTypes = HolidayTypes.Public,
                });
                holidaySpecifications.Add(new HolidaySpecification
                {
                    Id = "MIDAUTUMNFESTIVAL-01",
                    Date = midAutumnFestival,
                    EnglishName = "Mid-Autumn Festival",
                    LocalName = "中秋节",
                    HolidayTypes = HolidayTypes.Public,
                });
            }

            return holidaySpecifications;
        }

        private static (string Id, string EnglishName) GetHolidayName(string localName)
        {
            switch (localName)
            {
                case "元旦":
                    return ("NEWYEARSDAY", "New Year's Day");
                case "春节":
                    return ("CHINESENEWYEAR", "Chinese New Year (Spring Festival)");
                case "清明节":
                    return ("QINGMINGFESTIVAL", "Qingming Festival (Tomb-Sweeping Day)");
                case "劳动节":
                    return ("LABOURDAY", "Labour Day");
                case "端午节":
                    return ("DRAGONBOATFESTIVAL", "Dragon Boat Festival");
                case "中秋节":
                    return ("MIDAUTUMNFESTIVAL", "Mid-Autumn Festival");
                case "国庆节":
                    return ("NATIONALDAY", "National Day");
                default:
                    return ("CHINAHOLIDAY", localName);
            }
        }

        private int MoveMonth(int month, int leapMonth)
        {
            if (leapMonth == 0)
            {
                return month;
            }

            if (leapMonth < month)
            {
                return ++month;
            }

            return month;
        }

        /// <inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://github.com/NateScarlet/holiday-cn",
                "https://en.wikipedia.org/wiki/Public_holidays_in_China",
            ];
        }

        [DataContract]
        private sealed class ChinaHolidayData
        {
            [DataMember(Name = "year")]
            public int Year { get; set; }

            [DataMember(Name = "days")]
            public ChinaHolidayDay[]? Days { get; set; }
        }

        [DataContract]
        private sealed class ChinaHolidayDay
        {
            [DataMember(Name = "name")]
            public string? Name { get; set; }

            [DataMember(Name = "date")]
            public string? Date { get; set; }

            [DataMember(Name = "isOffDay")]
            public bool? IsOffDay { get; set; }
        }
    }
}
